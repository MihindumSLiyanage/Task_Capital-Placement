using Task.Models;

namespace Task.Repository.IRepository
{
    public interface IQuestionRepository
    {
        Task<Question> GetQuestionById(string id);
        Task<IEnumerable<Question>> GetQuestionsByEmployeeId(string id);
        Task<Question> CreateQuestion(Question question);
        Task<Question> UpdateQuestion(string id, Question question);
    }
}
