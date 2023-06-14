using System;
using Benchmark;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
namespace Benchmar
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<ApiBenchmarks>();
        }
    }
}
