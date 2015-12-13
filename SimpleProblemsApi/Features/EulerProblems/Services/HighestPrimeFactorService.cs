using System;

namespace SimpleProblemsApi.Features.EulerProblems.Services
{
    public class HighestPrimeFactorService : IProblemService
    {
        public string GetDescription()
        {
            return
                "The prime factors of 13195 are 5, 7, 13 and 29. What is the largest prime factor of the number 600851475143 ?";
        }

        public long GetSolution(long targetNumber)
        {
            for (long i = 2; i < targetNumber; i++)
            {
                if (targetNumber % i == 0)
                {
                    var factor = targetNumber / i;

                    if (IsPrime(factor))
                    {
                        return factor;
                    }
                }
            }
            return 0;
        }

        private bool IsPrime(long toCheck)
        {
            for (long j = 2; j * j < toCheck; j++)
            {
                if (toCheck % j == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}