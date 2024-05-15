using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Task.Models;
using Task.Repository.IRepository;

namespace Task.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Container _container;

        public EmployeeRepository(CosmosClient cosmosClient)
        {
            _container = cosmosClient.GetContainer("EmployeeDB", "Employee");
        }

        // Creates an employee
        public async Task<Employee> CreateEmployeeAsync(Employee employee)
        {
            var response = await _container.CreateItemAsync(employee, new PartitionKey(employee.Id));
            return response.Resource;
        }

        // Deletes an employee
        public async Task<bool> DeleteEmployeeAsync(string id)
        {
            await _container.DeleteItemAsync<Employee>(id, new PartitionKey(id));
            return true;
        }

        // Retrieves an employee by ID
        public async Task<Employee> GetEmployeeByIdAsync(string id)
        {
            var query = _container.GetItemLinqQueryable<Employee>()
                .Where(u => u.Id == id)
                .Take(1)
                .ToFeedIterator();

            var response = await query.ReadNextAsync();
            return response.FirstOrDefault();
        }

        // Updates an employee
        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            var response = await _container.ReplaceItemAsync(employee, employee.Id);
            return response.Resource;
        }
    }
}