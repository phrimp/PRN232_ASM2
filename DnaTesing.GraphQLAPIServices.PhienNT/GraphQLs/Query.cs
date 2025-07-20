using DNATesting.Repository.PhienNT;
using DNATesting.Repository.PhienNT.ModelExtensions;
using DNATesting.Repository.PhienNT.Models;
using DNATesting.Service.PhienNT;
using IServiceProvider = DNATesting.Service.PhienNT.IServiceProvider;

namespace DnaTesing.GraphQLAPIServices.PhienNT.GraphQLs
{
    public class Query
    {
        private readonly DNATesting.Service.PhienNT.IServiceProvider _serviceProvider;

        public Query(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

        public async Task<PaginationResult<List<DnaTestsPhienNt>>> DnaTests(int page = 1, int pageSize = 10)
        {
            try
            {
                var res = await _serviceProvider.DnaTestsPhienNtService.GetAllWithPagingAsync(page, pageSize);
                return res ?? new PaginationResult<List<DnaTestsPhienNt>>
                {
                    TotalItems = 0,
                    TotalPages = 0,
                    CurrentPage = page,
                    PageSize = pageSize,
                    Items = new List<DnaTestsPhienNt>()
                };
            }
            catch (Exception ex)
            {
                return new PaginationResult<List<DnaTestsPhienNt>>
                {
                    TotalItems = 0,
                    TotalPages = 0,
                    CurrentPage = page,
                    PageSize = pageSize,
                    Items = new List<DnaTestsPhienNt>()
                };
            }
        }

        public async Task<PaginationResult<List<LociPhienNt>>> GetLoci(int page = 1, int pageSize = 10)
        {
            try
            {
                var res = await _serviceProvider.LociPhienNtService.GetAllWithPagingAsync(page, pageSize);
                return res ?? new PaginationResult<List<LociPhienNt>>
                {
                    TotalItems = 0,
                    TotalPages = 0,
                    CurrentPage = page,
                    PageSize = pageSize,
                    Items = new List<LociPhienNt>()
                };
            }
            catch (Exception ex)
            {
                return new PaginationResult<List<LociPhienNt>>
                {
                    TotalItems = 0,
                    TotalPages = 0,
                    CurrentPage = page,
                    PageSize = pageSize,
                    Items = new List<LociPhienNt>()
                };
            }
        }

        public async Task<PaginationResult<List<DnaTestsPhienNt>>> SearchDnaTests(
            string? testType = null,
            bool? isCompleted = null,
            int page = 1,
            int pageSize = 10)
        {
            try
            {
                var res = await _serviceProvider.DnaTestsPhienNtService.SearchWithPagingAsync(
                    testType,
                    isCompleted,
                    page,
                    pageSize);

                return res ?? new PaginationResult<List<DnaTestsPhienNt>>
                {
                    TotalItems = 0,
                    TotalPages = 0,
                    CurrentPage = page,
                    PageSize = pageSize,
                    Items = new List<DnaTestsPhienNt>()
                };
            }
            catch (Exception ex)
            {
                return new PaginationResult<List<DnaTestsPhienNt>>
                {
                    TotalItems = 0,
                    TotalPages = 0,
                    CurrentPage = page,
                    PageSize = pageSize,
                    Items = new List<DnaTestsPhienNt>()
                };
            }
        }

        public async Task<PaginationResult<List<LociPhienNt>>> SearchLoci(
            string? name = null,
            bool? isCodis = null,
            int page = 1,
            int pageSize = 10)
        {
            try
            {
                var res = await _serviceProvider.LociPhienNtService.SearchWithPagingAsync(
                    name,
                    isCodis,
                    page,
                    pageSize);

                return res ?? new PaginationResult<List<LociPhienNt>>
                {
                    TotalItems = 0,
                    TotalPages = 0,
                    CurrentPage = page,
                    PageSize = pageSize,
                    Items = new List<LociPhienNt>()
                };
            }
            catch (Exception ex)
            {
                return new PaginationResult<List<LociPhienNt>>
                {
                    TotalItems = 0,
                    TotalPages = 0,
                    CurrentPage = page,
                    PageSize = pageSize,
                    Items = new List<LociPhienNt>()
                };
            }
        }

        public async Task<LoginResponse> LoginWithDetails(string username, string password)
        {
            try
            {
                var user = await _serviceProvider.UserAccountService.GetUserAccount(username, password);

                if (user != null)
                {
                    user.Password = null;
                    return new LoginResponse
                    {
                        Success = true,
                        Message = "Login successful",
                        User = user
                    };
                }

                return new LoginResponse
                {
                    Success = false,
                    Message = "Invalid username or password",
                    User = null
                };
            }
            catch (Exception ex)
            {
                return new LoginResponse
                {
                    Success = false,
                    Message = "Login failed due to system error",
                    User = null
                };
            }
        }

        public class LoginResponse
        {
            public bool Success { get; set; }
            public string Message { get; set; }
            public SystemUserAccount? User { get; set; }
        }
    }
}