using System.ComponentModel.DataAnnotations;

namespace DbDataLibrary.Models.DisplayModel
{
    public class TeamsDisplay
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "To long name")]
        [MinLength(3, ErrorMessage = "To short name")]
        public string TeamName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Mail { get; set; }

        [Required]
        public int? Departament { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "To long name")]
        [MinLength(3, ErrorMessage = "To short name")]
        public string Manager { get; set; }
    }
}