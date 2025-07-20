using DnaTesting.BlazorWAS.GraphQLClient.PhienNT.GraphQLClient;

namespace DnaTesting.BlazorWAS.GraphQLClient.PhienNT.Services
{
    public class DnaTestService
    {
        private readonly GraphQLConsumer _graphQLConsumer;

        public DnaTestService(GraphQLConsumer graphQLConsumer)
        {
            _graphQLConsumer = graphQLConsumer;
        }

        public async Task<List<DnaTest>> GetAllDnaTestsAsync()
        {
            return await _graphQLConsumer.GetDnaTestsAsync();
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