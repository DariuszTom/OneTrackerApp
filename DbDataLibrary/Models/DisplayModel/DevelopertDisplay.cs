using System;
using System.ComponentModel.DataAnnotations;

namespace DbDataLibrary.Models.DisplayModel
{
    public class DevelopertDisplay
    {
        public int Id { get; set; }

        [Required]
        [StringLength(9, ErrorMessage = "To long Employer ID")]
        [MinLength(7, ErrorMessage = "To short  Employer ID")]
        public string IdEmployee { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "To long name")]
        [MinLength(3, ErrorMessage = "To short name")]
        public string EmpName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "To long name")]
        [MinLength(3, ErrorMessage = "To short name")]
        public string EmpSurname { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Mail { get; set; }

        public string Position { get; set; }
        public int? Departament { get; set; }
        public int? Team { get; set; }
        public DateTime? AddOn { get; set; }
    }
}