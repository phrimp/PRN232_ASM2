using GraphQL.Client.Abstractions;
using GraphQL;
using DnaTesting.BlazorWAS.GraphQLClient.PhienNT.Models;

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

        public async Task<PaginationResult<List<DnaTest>>> GetDnaTestsAsync(int page = 1, int pageSize = 10)
        {
            var query = new GraphQLRequest
            {
                Query = @"
                    query GetDnaTests($page: Int!, $pageSize: Int!) {
                        dnaTests(page: $page, pageSize: $pageSize) {
                            currentPage
                            pageSize
                            totalItems
                            totalPages
                            items {
                                conclusion
                                createdAt
                                isCompleted
                                phienNtid
                                probabilityOfRelationship
                                relationshipIndex
                                testType
                            }
                        }
                    }",
                Variables = new { page, pageSize }
            };

            try
            {
                var response = await _graphQLClient.SendQueryAsync<DnaTestListData>(query);
                return response.Data?.DnaTests ?? new PaginationResult<List<DnaTest>>
                {
                    Items = new List<DnaTest>(),
                    CurrentPage = page,
                    PageSize = pageSize,
                    TotalItems = 0,
                    TotalPages = 0
                };
            }
            catch (Exception ex)
            {
                return new PaginationResult<List<DnaTest>>
                {
                    Items = new List<DnaTest>(),
                    CurrentPage = page,
                    PageSize = pageSize,
                    TotalItems = 0,
                    TotalPages = 0
                };
            }
        }

        public async Task<PaginationResult<List<DnaTest>>> SearchDnaTestsAsync(string testType = null, bool? isCompleted = null, int page = 1, int pageSize = 10)
        {
            var query = new GraphQLRequest
            {
                Query = @"
                    query SearchDnaTests($testType: String, $isCompleted: Boolean, $page: Int!, $pageSize: Int!) {
                        searchDnaTests(testType: $testType, isCompleted: $isCompleted, page: $page, pageSize: $pageSize) {
                            currentPage
                            pageSize
                            totalItems
                            totalPages
                            items {
                                conclusion
                                createdAt
                                isCompleted
                                phienNtid
                                probabilityOfRelationship
                                relationshipIndex
                                testType
                            }
                        }
                    }",
                Variables = new { testType, isCompleted, page, pageSize }
            };

            try
            {
                var response = await _graphQLClient.SendQueryAsync<SearchDnaTestListData>(query);
                return response.Data?.SearchDnaTests ?? new PaginationResult<List<DnaTest>>
                {
                    Items = new List<DnaTest>(),
                    CurrentPage = page,
                    PageSize = pageSize,
                    TotalItems = 0,
                    TotalPages = 0
                };
            }
            catch (Exception ex)
            {
                return new PaginationResult<List<DnaTest>>
                {
                    Items = new List<DnaTest>(),
                    CurrentPage = page,
                    PageSize = pageSize,
                    TotalItems = 0,
                    TotalPages = 0
                };
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