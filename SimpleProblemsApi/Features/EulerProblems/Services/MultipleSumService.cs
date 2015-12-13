using System.Linq;

namespace SimpleProblemsApi.Features.EulerProblems.Services
{
    public class MultipleSumService : IProblemService
    {
        public string GetDescription()
        {
            return "If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23. Find the sum of all the multiples of 3 or 5 below 1000.";
        }

        public long GetSolution(long inputValue)
        {
            var upperBound = inputValue;
            var sum = 0;
            for (var i = 0; i < upperBound; i++)
            {
                if (HasFactors(i,3,5))
                {
                    sum += i;
                }
            }
            return sum;
        }

        private bool HasFactors(long valueToCheck, params long[] factors)
        {
            return factors.Any(factor => valueToCheck % factor == 0);
        }
    }
}