using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DbDataLibrary.Models.Entities
{
    public partial class Admin : IDomainObject
    {
        public Admin()
        {
            Employee = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? AddOn { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}