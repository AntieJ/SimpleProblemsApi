using System;
using Autofac;

namespace SimpleProblemsApi.Features.EulerProblems.Services
{
    public class ProblemFactory : IProblemFactory
    {
        private readonly ILifetimeScope _lifetimeScope;

        public ProblemFactory(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }

        public IProblemService CreateProblemService(Type serviceType)
        {
            var thing = _lifetimeScope.ResolveOptional(serviceType);
            return (IProblemService) thing;
        }
    }
}