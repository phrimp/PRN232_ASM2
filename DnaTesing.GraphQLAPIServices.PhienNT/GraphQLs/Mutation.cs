using DNATesting.Repository.PhienNT;
using DNATesting.Service.PhienNT;
using IServiceProvider = DNATesting.Service.PhienNT.IServiceProvider;

namespace DnaTesing.GraphQLAPIServices.PhienNT.GraphQLs
{
    public class Mutation
    {
        private readonly DNATesting.Service.PhienNT.IServiceProvider _serviceProvider;  

        public Mutation(IServiceProvider serviceProvider) { _serviceProvider = serviceProvider; }

        public async Task<int> CreateDnaTestPhienNT(DnaTestsPhienNt dnaTestsPhienNt)
        {
            try
            {
                var result = await _serviceProvider.DnaTestsPhienNtService.CreateAsync(dnaTestsPhienNt);
                return result;
            }
            catch (Exception ex)
            {
            }
            return 0;
        }

        public async Task<int> UpdateDnaTest(DnaTestsPhienNt dnaTestsPhienNt)
        {
            try
            {
                var res = await _serviceProvider.DnaTestsPhienNtService.UpdateAsync(dnaTestsPhienNt);
                return res;
            }
            catch (Exception ex)
            {

            }
            return 0;
        }

        public async Task<bool> DeleteDnaTest(int id)
        {
            try
            {
                var res = await _serviceProvider.DnaTestsPhienNtService.DeleteAsync(id);
                return res;
            }
            catch (Exception ex)
            {
            }
            return false;
        }
    }
}
