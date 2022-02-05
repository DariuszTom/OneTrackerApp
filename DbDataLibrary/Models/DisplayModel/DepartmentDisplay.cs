using System.ComponentModel.DataAnnotations;

namespace DbDataLibrary.Models.DisplayModel
{
    public class DepartmentDisplay
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "To long name")]
        [MinLength(3, ErrorMessage = "To short name")]
        public string DepName { get; set; }
    }
}