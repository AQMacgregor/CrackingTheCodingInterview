using CrackingTheCodingInterview.Moderate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview
{
    class Program
    {
        static void Main(string[] args)
        {
            var type = typeof(ISolution);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && p != type);
            var testCount = 0;
            var failureCount = 0;
            foreach (var solution in types)
            {
                Console.Write($"Testing {solution.Name}...");
                ISolution sol = Activator.CreateInstance(solution) as ISolution;
                try
                {
                    sol.Test();
                    Console.WriteLine(" Passed");
                    testCount++;
                }
                catch(AssertionException)
                {
                    Console.WriteLine(" Assertion Failure");
                    failureCount++;
                }
                catch(Exception e)
                {
                    Console.WriteLine(" Exception");
                    Console.WriteLine(e);
                    failureCount++;
                }
            }
            Console.WriteLine($"Tests Ran : {testCount}. Tests Failed : {failureCount}");
        }
    }
}
