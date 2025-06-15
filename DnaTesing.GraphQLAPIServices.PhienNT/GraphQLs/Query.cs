using DNATesting.Repository.PhienNT;
using DNATesting.Service.PhienNT;
using IServiceProvider = DNATesting.Service.PhienNT.IServiceProvider;

namespace DnaTesing.GraphQLAPIServices.PhienNT.GraphQLs
{
    public class Query
    {
        private readonly DNATesting.Service.PhienNT.IServiceProvider _serviceProvider;

        public Query(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

        public async Task<List<DnaTestsPhienNt>> GetDnaTests()
        {
            try
            {
                var res = await _serviceProvider.DnaTestsPhienNtService.GetAllAsync();
                return res ?? new List<DnaTestsPhienNt>();
            }
            catch (Exception ex)
            {
                return new List<DnaTestsPhienNt>();
                
            }
        }
    }
}
