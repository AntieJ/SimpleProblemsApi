using System;

namespace SimpleProblemsApi.Features.EulerProblems.Services
{
    public interface IProblemFactory
    {
        IProblemService CreateProblemService(Type serviceType);
    }
}