
namespace SimpleProblemsApi.Features.EulerProblems.Services
{
    public interface IProblemService
    {
        string GetDescription();
        long GetSolution(long inputValue);
    }
}