using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Task.Models;
using Task.Repository.IRepository;

namespace Task.Repository
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly Container _container;

        public AnswerRepository(CosmosClient cosmosClient)
        {
            _container = cosmosClient.GetContainer("EmployeeDB", "Answer");
        }

        // Get an answer
        public async Task<Answer> GetAnswerById(string id)
        {
            var query = _container.GetItemLinqQueryable<Answer>()
                .Where(u => u.Id == id)
                .Take(1)
                .ToFeedIterator();

            var response = await query.ReadNextAsync();
            return response.FirstOrDefault();
        }

        // Get an answer by Employee
        public async Task<IEnumerable<Answer>> GetAnswersByEmployeeId(string id)
        {
            var query = _container.GetItemLinqQueryable<Answer>()
                .Where(a => a.EmployeeId == id)
                .ToFeedIterator();

            var response = await query.ReadNextAsync();
            return response;
        }

        // Get an answer by Question
        public async Task<IEnumerable<Answer>> GetAnswersByQuestionId(string id)
        {
            var query = _container.GetItemLinqQueryable<Answer>()
                .Where(a => a.QuestionId == id)
                .ToFeedIterator();

            var response = await query.ReadNextAsync();
            return response;
        }

        // Create a answer
        public async Task<Answer> CreateAnswer(Answer answer)
        {
            var response = await _container.CreateItemAsync(answer);
            return response.Resource;
        }

        // Update an answer
        public async Task<Answer> UpdateAnswer(string id, Answer answer)
        {
            var response = await _container.ReplaceItemAsync(answer, answer.Id);
            return response.Resource;
        }
    }
}
