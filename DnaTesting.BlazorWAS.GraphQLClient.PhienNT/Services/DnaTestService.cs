using DnaTesting.BlazorWAS.GraphQLClient.PhienNT.GraphQLClient;
using DnaTesting.BlazorWAS.GraphQLClient.PhienNT.Models;

namespace DnaTesting.BlazorWAS.GraphQLClient.PhienNT.Services
{
    public class DnaTestService
    {
        private readonly GraphQLConsumer _graphQLConsumer;

        public DnaTestService(GraphQLConsumer graphQLConsumer)
        {
            _graphQLConsumer = graphQLConsumer;
        }

        public async Task<PaginationResult<List<DnaTest>>> GetDnaTestsAsync(int page = 1, int pageSize = 10)
        {
            return await _graphQLConsumer.GetDnaTestsAsync(page, pageSize);
        }

        public async Task<PaginationResult<List<DnaTest>>> SearchDnaTestsAsync(string testType = null, bool? isCompleted = null, int page = 1, int pageSize = 10)
        {
            return await _graphQLConsumer.SearchDnaTestsAsync(testType, isCompleted, page, pageSize);
        }

        public async Task<List<DnaTest>> GetAllDnaTestsAsync()
        {
            var result = await _graphQLConsumer.GetDnaTestsAsync(1, 1000); // Get a large number for "all"
            return result.Items ?? new List<DnaTest>();
        }

        public async Task<int> CreateDnaTestAsync(DnaTestInput input)
        {
            return await _graphQLConsumer.CreateDnaTestAsync(input);
        }

        public async Task<int> UpdateDnaTestAsync(DnaTestInput input)
        {
            return await _graphQLConsumer.UpdateDnaTestAsync(input);
        }

        public async Task<bool> DeleteDnaTestAsync(int id)
        {
            return await _graphQLConsumer.DeleteDnaTestAsync(id);
        }
    }
}