using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using System.Collections.Generic;
using Task.Models;
using Task.Repository.IRepository;

namespace Task.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly Container _container;

        public QuestionRepository(CosmosClient cosmosClient)
        {
            _container = cosmosClient.GetContainer("EmployeeDB", "Question");
        }

        public async Task<Question> CreateQuestion(Question question)
        {
            var response = await _container.CreateItemAsync(question);
            return response.Resource;
        }

        public async Task<Question> GetQuestionById(string id)
        {
            var query = _container.GetItemLinqQueryable<Question>()
                .Where(q => q.Id == id)
                .Take(1)
                .ToFeedIterator();

            var response = await query.ReadNextAsync();
            return response.FirstOrDefault();
        }

        public async Task<IEnumerable<Question>> GetQuestionsByEmployeeId(string id)
        {
            var query = _container.GetItemLinqQueryable<Question>()
                .Where(q => q.Id == id)
                .ToFeedIterator();

            var response = await query.ReadNextAsync();
            return response;
        }

        public async Task<Question> UpdateQuestion(string id, Question question)
        {
            var response = await _container.ReplaceItemAsync(question, question.Id);
            return response.Resource;
        }
    }
}
