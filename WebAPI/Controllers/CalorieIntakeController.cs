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
using Application.Requests.Queries.GetValues;
using Application.Requests.Queries.GetValuesForProduct;
using Application.Requests.Queries.GetCalorieIntakes;
using Application.Requests.Queries.GetCalorieIntake;
using Application.Requests.Queries.GetCalorieIntakesByDate;
using Application.Requests.Commands.CreateCalorieIntake;
using Application.Requests.Commands.UpdateCalorieIntake;
using Application.Requests.Commands.DeleteCalorieIntake;

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
            var query = new GetValues.Query();
            var calorieIntakes = await _mediator.Send(query);
            return calorieIntakes.ToList();
        }

        [HttpGet("ValuesByProduct")]
        public async Task<ActionResult<CalorieIntake>> GetValuesForProductAsync(FoodProduct product)
        {
            var query = new GetValuesForProduct.Query(product);
            var calorieIntake = await _mediator.Send(query);
            return calorieIntake;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CalorieIntake>>> GetCalorieIntakes()
        {
            //var result = await _context.CalorieIntakes.ToListAsync();
            //return Ok(result);
            
            var query = new GetCalorieIntakes.Query();
            var calorieIntakes = await _mediator.Send(query);
            return Ok(calorieIntakes);
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CalorieIntake>> GetCalorieIntake(Guid id)
        {
            //var calorieIntake = await _context.CalorieIntakes.FindAsync(id);

            //if (calorieIntake == null)
            //{
            //    return NotFound();
            //}

            //return calorieIntake;

            var query = new GetCalorieIntake.Query(id);
            var calorieIntake = await _mediator.Send(query);
            return calorieIntake;

        }

        [HttpGet("byDate")]
        public async Task<ActionResult<IEnumerable<CalorieIntake>>> GetCalorieIntakes(DateTime start, DateTime stop)
        {
            //var calorieIntake = await _context.CalorieIntakes.FindAsync(id);
            //var calorieIntakes = await _context.CalorieIntakes
            //    .Where(x => x.Date >= start && x.Date <= stop)
            //    .ToListAsync();

            //if (calorieIntakes.Count == 0)
            //{
            //    return NotFound();
            //}
            //return calorieIntakes;

            var query = new GetCalorieIntakesByDate.Query(start, stop);
            var calorieIntakes = await _mediator.Send(query);
            return calorieIntakes;
        }

        [HttpPost]
        public async Task<ActionResult<CalorieIntake>> PostCalorieIntake([FromForm] string foodProduct, [FromForm] int weight)
        {
            //if (!Enum.TryParse(foodProduct, out FoodProduct selectedProduct))
            //{
            //    return BadRequest("Invalid food product.");
            //}

            //var calorieIntake = new CalorieIntake(selectedProduct, weight);
            //await _context.CalorieIntakes.AddAsync(calorieIntake);
            //await _context.SaveChangesAsync(CancellationToken.None);

            //return CreatedAtAction(nameof(GetCalorieIntakes), new { id = calorieIntake.Id }, calorieIntake);


            var command = new CreateCalorieIntake.Command(foodProduct, weight);
            var calorieIntake = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetCalorieIntakes), new { id = calorieIntake.Id }, calorieIntake);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalorieIntake([FromForm] Guid id, [FromForm] string foodProduct, [FromForm] int weight)
        {
            //if (!CalorieIntakeExists(id))
            //{
            //    return NotFound();
            //}

            //var calorieIntake = await _context.CalorieIntakes.FindAsync(id);

            //if (calorieIntake is null)
            //{
            //    return BadRequest();
            //}

            //if (!Enum.TryParse(foodProduct, out FoodProduct selectedProduct))
            //{
            //    return BadRequest("Invalid food product.");
            //}

            //calorieIntake.Product = selectedProduct;
            //calorieIntake.Weight = weight;

            //_context.Entry(calorieIntake).State = EntityState.Modified;

            //    await _context.SaveChangesAsync();

            //return NoContent();

            var command = new UpdateCalorieIntake.Command(id, foodProduct, weight);
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalorieIntake(Guid id)
        {
            //var calorieIntake = await _context.CalorieIntakes.FindAsync(id);
            //if (calorieIntake == null)
            //{
            //    return NotFound();
            //}

            //_context.CalorieIntakes.Remove(calorieIntake);
            //await _context.SaveChangesAsync();

            //return NoContent();

            var command = new DeleteCalorieIntake.Command(id);
            await _mediator.Send(command);
            return NoContent();

        }

        private bool CalorieIntakeExists(Guid id)
        {
            return _context.CalorieIntakes.Any(e => e.Id == id);
        }
    }
}
