using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Requests.Queries;
using Application.Requests.Commands;

namespace WebAPI.Controllers
{
    [ApiVersion("1")]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class CalorieIntakeController : BaseController
    {
        private readonly Apps_DbContext _context;
        private readonly IMediator _mediator;

        public CalorieIntakeController(Apps_DbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        [HttpGet("Values")]
        public async Task<ActionResult<IEnumerable<CalorieIntake>>> GetValuesAsync()
        {
            var query = new GetValuesQuery();
            var calorieIntakes = await _mediator.Send(query);
            return calorieIntakes.ToList();
        }

        [HttpGet("ValuesByProduct")]
        public async Task<ActionResult<CalorieIntake>> GetValuesForProductAsync(FoodProduct product)
        {
            var query = new GetValuesForProductQuery(product);
            var calorieIntake = await _mediator.Send(query);
            return calorieIntake;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CalorieIntake>>> GetCalorieIntakes()
        {
            var result = await _context.CalorieIntakes.ToListAsync();
            return Ok(result);
            /*
            var query = new GetCalorieIntakesQuery();
            var calorieIntakes = await _mediator.Send(query);
            return Ok(calorieIntakes);
            */
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CalorieIntake>> GetCalorieIntake(Guid id)
        {
            var calorieIntake = await _context.CalorieIntakes.FindAsync(id);

            if (calorieIntake == null)
            {
                return NotFound();
            }

            return calorieIntake;
            /*
             var query = new GetCalorieIntakeQuery(id);
            var calorieIntake = await _mediator.Send(query);
            return calorieIntake;
             */
        }

        [HttpGet("byDate")]
        public async Task<ActionResult<IEnumerable<CalorieIntake>>> GetCalorieIntakes(DateTime start, DateTime stop)
        {
            //var calorieIntake = await _context.CalorieIntakes.FindAsync(id);
            var calorieIntakes = await _context.CalorieIntakes
                .Where(x => x.Date >= start && x.Date <= stop)
                .ToListAsync();

            if (calorieIntakes.Count == 0)
            {
                return NotFound();
            }

            return calorieIntakes;

            /*
            var query = new GetCalorieIntakesQuery(start, stop);
            var calorieIntakes = await _mediator.Send(query);
            return calorieIntakes;
             */
        }

        [HttpPost]
        public async Task<ActionResult<CalorieIntake>> PostCalorieIntake([FromForm] string foodProduct, [FromForm] int weight)
        {
            if (!Enum.TryParse(foodProduct, out FoodProduct selectedProduct))
            {
                return BadRequest("Invalid food product.");
            }

            var calorieIntake = new CalorieIntake(selectedProduct, weight);
            await _context.CalorieIntakes.AddAsync(calorieIntake);
            await _context.SaveChangesAsync(CancellationToken.None);

            return CreatedAtAction(nameof(GetCalorieIntakes), new { id = calorieIntake.Id }, calorieIntake);

            /*
             var command = new CreateCalorieIntakeCommand(foodProduct, weight);
            var calorieIntake = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetCalorieIntakes), new { id = calorieIntake.Id }, calorieIntake);
             */
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalorieIntake([FromForm] Guid id, [FromForm] string foodProduct, [FromForm] int weight)
        {
            if (!CalorieIntakeExists(id))
            {
                return NotFound();
            }

            var calorieIntake = await _context.CalorieIntakes.FindAsync(id);
            
            if (calorieIntake is null)
            {
                return BadRequest();
            }

            if (!Enum.TryParse(foodProduct, out FoodProduct selectedProduct))
            {
                return BadRequest("Invalid food product.");
            }

            calorieIntake.Product = selectedProduct;
            calorieIntake.Weight = weight;

            _context.Entry(calorieIntake).State = EntityState.Modified;

                await _context.SaveChangesAsync();

            return NoContent();
            /*
            var command = new UpdateCalorieIntakeCommand(id, foodProduct, weight);
            await _mediator.Send(command);
            return NoContent();
            */
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalorieIntake(Guid id)
        {
            var calorieIntake = await _context.CalorieIntakes.FindAsync(id);
            if (calorieIntake == null)
            {
                return NotFound();
            }

            _context.CalorieIntakes.Remove(calorieIntake);
            await _context.SaveChangesAsync();

            return NoContent();
            /*
             var command = new DeleteCalorieIntakeCommand(id);
            await _mediator.Send(command);
            return NoContent();
             */
        }

        private bool CalorieIntakeExists(Guid id)
        {
            return _context.CalorieIntakes.Any(e => e.Id == id);
        }
    }
}
