using GraphQL.Client.Abstractions;
using GraphQL;

namespace DnaTesting.BlazorWAS.GraphQLClient.PhienNT.GraphQLClient
{
    public class GraphQLConsumer
    {
        private readonly IGraphQLClient _graphQLClient;

        public GraphQLConsumer(IGraphQLClient graphQLClient)
        {
            _graphQLClient = graphQLClient;
        }

        public async Task<LoginResponse> LoginAsync(string username, string password)
        {
            var query = new GraphQLRequest
            {
                Query = @"
                    query LoginWithDetails($username: String!, $password: String!) {
                        loginWithDetails(username: $username, password: $password) {
                            success
                            message
                            user {
                                userAccountId
                                userName
                                fullName
                                email
                                roleId
                                isActive
                            }
                        }
                    }",
                Variables = new { username, password }
            };

            try
            {
                var response = await _graphQLClient.SendQueryAsync<LoginData>(query);

                if (response.Data?.LoginWithDetails != null)
                {
                    return response.Data.LoginWithDetails;
                }

                return new LoginResponse
                {
                    Success = false,
                    Message = "No response from server",
                    User = null
                };
            }
            catch (Exception ex)
            {
                return new LoginResponse
                {
                    Success = false,
                    Message = "Connection error: " + ex.Message,
                    User = null
                };
            }
        }
        public async Task<List<DnaTest>> GetDnaTestsAsync()
        {
            var query = new GraphQLRequest
            {
                Query = @"
                    query {
                        getDnaTests {
                            totalItems
                            totalPages
                            currentPage
                            pageSize
                            items {
                                phienNtid
                                testType
                                conclusion
                                probabilityOfRelationship
                                relationshipIndex
                                isCompleted
                                createdAt
                            }
                        }
                    }"
            };

            try
            {
                var response = await _graphQLClient.SendQueryAsync<DnaTestListData>(query);
                return response.Data?.GetDnaTests?.Items ?? new List<DnaTest>();
            }
            catch (Exception ex)
            {
                return new List<DnaTest>();
            }
        }

        public async Task<int> CreateDnaTestAsync(DnaTestInput input)
        {
            var mutation = new GraphQLRequest
            {
                Query = @"
                    mutation CreateDnaTest($input: DnaTestsPhienNtInput!) {
                        createDnaTestPhienNT(dnaTestsPhienNt: $input)
                    }",
                Variables = new { input }
            };

            try
            {
                var response = await _graphQLClient.SendMutationAsync<CreateDnaTestData>(mutation);
                return response.Data?.CreateDnaTestPhienNT ?? 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<int> UpdateDnaTestAsync(DnaTestInput input)
        {
            var mutation = new GraphQLRequest
            {
                Query = @"
                    mutation UpdateDnaTest($input: DnaTestsPhienNtInput!) {
                        updateDnaTest(dnaTestsPhienNt: $input)
                    }",
                Variables = new { input }
            };

            try
            {
                var response = await _graphQLClient.SendMutationAsync<UpdateDnaTestData>(mutation);
                return response.Data?.UpdateDnaTest ?? 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<bool> DeleteDnaTestAsync(int id)
        {
            var mutation = new GraphQLRequest
            {
                Query = @"
                    mutation DeleteDnaTest($id: Int!) {
                        deleteDnaTest(id: $id)
                    }",
                Variables = new { id }
            };

            try
            {
                var response = await _graphQLClient.SendMutationAsync<DeleteDnaTestData>(mutation);
                return response.Data?.DeleteDnaTest ?? false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

    // Updated data models to match your LoginResponse
    public class LoginData
    {
        public LoginResponse LoginWithDetails { get; set; }
    }

    public class LoginResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public UserAccount User { get; set; }
    }

    public class UserAccount
    {
        public int UserAccountId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public bool IsActive { get; set; }
    }
public class DnaTestListData
{
    public PaginationResult<List<DnaTest>> GetDnaTests { get; set; }
}

public class CreateDnaTestData
{
    public int CreateDnaTestPhienNT { get; set; }
}

public class UpdateDnaTestData
{
    public int UpdateDnaTest { get; set; }
}

public class DeleteDnaTestData
{
    public bool DeleteDnaTest { get; set; }
}

public class PaginationResult<T>
{
    public int TotalItems { get; set; }
    public int TotalPages { get; set; }
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public T Items { get; set; }
}

public class DnaTest
{
    public int PhienNtid { get; set; }
    public string TestType { get; set; }
    public string Conclusion { get; set; }
    public decimal? ProbabilityOfRelationship { get; set; }
    public decimal? RelationshipIndex { get; set; }
    public bool? IsCompleted { get; set; }
    public DateTime? CreatedAt { get; set; }
}

public class DnaTestInput
{
    public int PhienNtid { get; set; }
    public string TestType { get; set; }
    public string Conclusion { get; set; }
    public decimal? ProbabilityOfRelationship { get; set; }
    public decimal? RelationshipIndex { get; set; }
    public bool? IsCompleted { get; set; }
}
