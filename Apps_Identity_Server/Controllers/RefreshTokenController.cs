using Apps_Identity_Server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Apps_Identity_Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RefreshTokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> userManager;
        public RefreshTokenController(IConfiguration configuration, UserManager<ApplicationUser> userManager)
        {
            _configuration = configuration;
            this.userManager = userManager;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("refresh")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest model)
        {
            if (ModelState.IsValid)
            {
                // Проверяем валидность Refresh Token
                var isValid = ValidateRefreshToken(model.RefreshToken).Result;
                if (isValid != null)
                {
                    var user = await userManager.FindByNameAsync(isValid);
                    var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                    var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                    var token = new JwtSecurityToken(
                        issuer: _configuration["JWT:ValidIssuer"],
                        audience: _configuration["JWT:ValidAudience"],
                        expires: DateTime.Now.AddHours(24),
                        claims: authClaims,
                        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                    return Ok(new
                    {
                        accessToken = new JwtSecurityTokenHandler().WriteToken(token)
                    });
                }
            }

            return BadRequest("Invalid refresh token");
        }

        private async Task<string> ValidateRefreshToken(string token)
        {
            // 1. Проверьте, является ли переданный токен пустым или null
            if (string.IsNullOrEmpty(token))
            {
                return null;
            }
            try
            {
                // 2. Расшифруйте Refresh Token и получите его содержимое ClaimTypes.Name, user.UserName
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
                var nameUser = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

                var now = DateTime.UtcNow;
                if (jwtToken.ValidTo < now)
                {
                    return null;
                }

                return nameUser;
            }
            catch
            {
                return null;
            }
        }       
    }

    public class RefreshTokenRequest
    {
        public string RefreshToken { get; set; }
    }
}