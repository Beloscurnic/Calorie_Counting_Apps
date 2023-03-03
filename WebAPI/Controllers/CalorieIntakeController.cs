using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiVersion("1")]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class CalorieIntakeController : ControllerBase
    {
        private readonly CalorieTrackerContext _context;

        public CalorieIntakeController(CalorieTrackerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CalorieIntake>>> GetCalorieIntakes()
        {
            return await _context.CalorieIntakes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CalorieIntake>> GetCalorieIntake(int id)
        {
            var calorieIntake = await _context.CalorieIntakes.FindAsync(id);

            if (calorieIntake == null)
            {
                return NotFound();
            }

            return calorieIntake;
        }

        [HttpPost]
        public async Task<ActionResult<CalorieIntake>> PostCalorieIntake(CalorieIntake calorieIntake)
        {
            _context.CalorieIntakes.Add(calorieIntake);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCalorieIntake), new { id = calorieIntake.Id }, calorieIntake);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalorieIntake(int id, CalorieIntake calorieIntake)
        {
            if (id != calorieIntake.Id)
            {
                return BadRequest();
            }

            _context.Entry(calorieIntake).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalorieIntakeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalorieIntake(int id)
        {
            var calorieIntake = await _context.CalorieIntakes.FindAsync(id);
            if (calorieIntake == null)
            {
                return NotFound();
            }

            _context.CalorieIntakes.Remove(calorieIntake);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CalorieIntakeExists(int id)
        {
            return _context.CalorieIntakes.Any(e => e.Id == id);
        }
    }
}
