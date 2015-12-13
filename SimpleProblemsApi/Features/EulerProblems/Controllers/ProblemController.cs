using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SimpleProblemsApi.Features.EulerProblems.Models;
using SimpleProblemsApi.Features.EulerProblems.Services;

namespace SimpleProblemsApi.Features.EulerProblems.Controllers
{
    public class ProblemController : ApiController
    {
        private readonly IProblemFactory _problemFactory;

        public ProblemController(IProblemFactory problemFactory)
        {
            _problemFactory = problemFactory;
        }

        [HttpGet]//todo: validation filter, exception handling
        public HttpResponseMessage Get(int id, long inputValue)
        {
            var problemService = CreateProblemService(id);
            var description = problemService.GetDescription();
            var problemResult = problemService.GetSolution(inputValue);

            return Request.CreateResponse(HttpStatusCode.OK,
                new ProblemApiResponse(id, description, problemResult.ToString()));
        }

        private IProblemService CreateProblemService(int id)
        {
            var serviceType = GetServiceType(id);
            return _problemFactory.CreateProblemService(serviceType);
        }

        private Type GetServiceType(int id)
        {
            switch (id)
            {
                case 0:
                    return typeof(MultipleSumService);
                case 1:
                    return typeof(FibonacciSumService);
                case 2:
                    return typeof (HighestPrimeFactorService);
                default:
                    return null; //todo throw
            }
        }
    }
}
