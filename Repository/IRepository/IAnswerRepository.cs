using Task.Models;

namespace Task.Repository.IRepository
{
    public interface IAnswerRepository
    {
        Task<Answer> GetAnswerById(string id);
        Task<IEnumerable<Answer>> GetAnswersByEmployeeId(string id);
        Task<IEnumerable<Answer>> GetAnswersByQuestionId(string id);
        Task<Answer> CreateAnswer(Answer answer);
        Task<Answer> UpdateAnswer(string id, Answer answer);
    }
}
