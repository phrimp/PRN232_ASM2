using System.ComponentModel.DataAnnotations;

namespace DnaTesting.BlazorWAS.GraphQLClient.PhienNT.Models
{
    public class DnaTestCreateModel
    {
        [Required(ErrorMessage = "Test Type is required")]
        public string TestType { get; set; } = "";

        [StringLength(500, ErrorMessage = "Conclusion cannot exceed 500 characters")]
        public string Conclusion { get; set; } = "";

        [Range(0, 100, ErrorMessage = "Probability must be between 0 and 100")]
        public decimal? ProbabilityOfRelationship { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Relationship Index must be positive")]
        public decimal? RelationshipIndex { get; set; }

        public bool IsCompleted { get; set; } = false;
    }

    public class DnaTestEditModel
    {
        [Required(ErrorMessage = "Test Type is required")]
        public string TestType { get; set; } = "";

        [StringLength(500, ErrorMessage = "Conclusion cannot exceed 500 characters")]
        public string Conclusion { get; set; } = "";

        [Range(0, 100, ErrorMessage = "Probability must be between 0 and 100")]
        public decimal? ProbabilityOfRelationship { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Relationship Index must be positive")]
        public decimal? RelationshipIndex { get; set; }

        public bool IsCompleted { get; set; } = false;
    }

    public class LocusCreateModel
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; } = "";

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string Description { get; set; } = "";

        [Range(0, 1, ErrorMessage = "Mutation Rate must be between 0 and 1")]
        public decimal? MutationRate { get; set; }

        public bool IsCodis { get; set; } = true;
    }

    public class LocusEditModel
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; } = "";

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string Description { get; set; } = "";

        [Range(0, 1, ErrorMessage = "Mutation Rate must be between 0 and 1")]
        public decimal? MutationRate { get; set; }

        public bool IsCodis { get; set; } = true;
    }
}