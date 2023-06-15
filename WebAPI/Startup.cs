using Application;
using Application.Common.Mapping;
using Application.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting; 
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Persistence;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using WebAPI.Controllers;
using WebAPI.Middleware;
using WebAPI.Services;

namespace WebAPI
{
    public class Startup
    {
        private static List<string> RevokedTokens = new List<string>();
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(RevokedTokens);
           
            services.AddHostedService<TokenRevocationBackgroundService>();

            services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(I_DbContext).Assembly));
            });

            //services.AddDbContext<CalorieTrackerContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            // services.AddMvc();
            //services.AddMediatR(typeof(Startup));
            services.AddApplication();
            services.AddPersistence(Configuration);
            services.AddCors();
            services.AddControllers();
            //    var guestPolicy = new AuthorizationPolicyBuilder()
            //.RequireAuthenticatedUser()
            //.RequireClaim("scope", "Role")
            //.Build();

            // Adding Authentication  
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            // Adding Jwt Bearer  
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["JWT:ValidAudience"],
                    ValidIssuer = Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"])),

                    ValidateLifetime = true,
                    LifetimeValidator = (notBefore, expires, token, parameters) =>
                    {
                        if (RevokedTokens.Contains(token.ToString()))
                        {
                            return false;
                        }
                        return true;
                    }
                };
            });

            services.AddVersionedApiExplorer(options =>
                 options.GroupNameFormat = "'v'VVV");

            services.AddAuthorization(options =>
            {

            });
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>,
                    ConfigureSwaggerOtions>();
            services.AddSwaggerGen();
            services.AddApiVersioning();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
          IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(config =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    config.SwaggerEndpoint(
                        $"/swagger/{description.GroupName}/swagger.json",
                        description.GroupName.ToUpperInvariant());
                    config.RoutePrefix = string.Empty;
                }
            });

            app.UseCustomExceptionHandler();
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseCors(x => x
             .WithOrigins("https://localhost:3000")
             .AllowAnyMethod()
             .AllowAnyHeader()
             .SetIsOriginAllowed(origin => true) // allow any origin
             .AllowCredentials()); // allow credentials

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseApiVersioning();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
