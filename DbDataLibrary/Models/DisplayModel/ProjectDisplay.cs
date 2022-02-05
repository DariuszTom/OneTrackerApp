using System;
using System.ComponentModel.DataAnnotations;

namespace DbDataLibrary.Models.DisplayModel
{
    public class ProjectDisplay
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "To long name")]
        [MinLength(3, ErrorMessage = "To short name")]
        public string ProjectName { get; set; }

        [Required]
        public string RequestingTeam { get; set; }

        [Required]
        public string ContactPerson { get; set; }

        [Required]
        public string ProjectType { get; set; }

        [Required]
        public string ProjectStatus { get; set; }

        [Required]
        public string Piority { get; set; }

        public string Benefits { get; set; }
        public string Comment { get; set; }
        public string MacroName { get; set; }
        public DateTime? SubmitionTime { get; set; }
        public DateTime? UpdateTime { get; set; }

        [Range(0.00, 100.00, ErrorMessage = "FTE must be between 0.01 and 100.00")]
        public float? FteSavings { get; set; }

        public int? Developer { get; set; }
        public string DevComment { get; set; }
        public int? DevTeam { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? DueDate { get; set; }
    }
}