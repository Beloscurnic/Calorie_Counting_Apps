using Application.Requests.Queries.GetCalorieIntakesByDate;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benchmark
{
   public class ApiBenchmarks
    {
        private readonly IMediator _mediator;

        public ApiBenchmarks(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Benchmark]
        public async Task<List<CalorieIntake>> BenchmarkGetCalorieIntakes()
        {
            var start = new DateTime(2023, 1, 1);
            var stop = new DateTime(2023, 1, 31);

            var query = new GetCalorieIntakesByDate.Query(start, stop);
            var result = await _mediator.Send(query);

            return result.ToList();
        }      
    }
}
