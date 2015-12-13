using System.Security.Cryptography;

namespace SimpleProblemsApi.Features.EulerProblems.Models
{
    public class ProblemApiResponse
    {
        public ProblemApiResponse(int id, string description, string result, string errorMessage = null)
        {
            Id = id;
            Description = description;
            Result = result;
            ErrorMessage = errorMessage;
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public string Result { get; set; }
        public string ErrorMessage { get; set; }

    }
}