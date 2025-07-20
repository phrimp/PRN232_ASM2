using DnaTesting.BlazorWAS.GraphQLClient.PhienNT.GraphQLClient;
using DnaTesting.BlazorWAS.GraphQLClient.PhienNT.Models;

namespace DnaTesting.BlazorWAS.GraphQLClient.PhienNT.Services
{
    public class LociService
    {
        private readonly GraphQLConsumer _graphQLConsumer;

        public LociService(GraphQLConsumer graphQLConsumer)
        {
            _graphQLConsumer = graphQLConsumer;
        }

        public async Task<PaginationResult<List<Locus>>> GetLociAsync(int page = 1, int pageSize = 10)
        {
            return await _graphQLConsumer.GetLociAsync(page, pageSize);
        }

        public async Task<PaginationResult<List<Locus>>> SearchLociAsync(string name = null, bool? isCodis = null, int page = 1, int pageSize = 10)
        {
            return await _graphQLConsumer.SearchLociAsync(name, isCodis, page, pageSize);
        }

        public async Task<List<Locus>> GetAllLociAsync()
        {
            var result = await _graphQLConsumer.GetLociAsync(1, 1000); // Get a large number for "all"
            return result.Items ?? new List<Locus>();
        }

        public async Task<int> CreateLocusAsync(LocusInput input)
        {
            return await _graphQLConsumer.CreateLocusAsync(input);
        }

        public async Task<int> UpdateLocusAsync(LocusInput input)
        {
            return await _graphQLConsumer.UpdateLocusAsync(input);
        }

        public async Task<bool> DeleteLocusAsync(int id)
        {
            return await _graphQLConsumer.DeleteLocusAsync(id);
        }
    }
}