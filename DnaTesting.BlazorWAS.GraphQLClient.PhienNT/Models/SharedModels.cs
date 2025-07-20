namespace DnaTesting.BlazorWAS.GraphQLClient.PhienNT.Models
{
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

    // Internal GraphQL response models
    public class LoginData
    {
        public LoginResponse LoginWithDetails { get; set; }
    }

    public class DnaTestListData
    {
        public PaginationResult<List<DnaTest>> DnaTests { get; set; }
    }

    public class SearchDnaTestListData
    {
        public PaginationResult<List<DnaTest>> SearchDnaTests { get; set; }
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
}