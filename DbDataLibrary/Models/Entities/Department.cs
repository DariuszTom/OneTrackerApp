using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DbDataLibrary.Models.Entities
{
    public partial class Department : IDomainObject
    {
        public Department()
        {
            DevTeam = new HashSet<DevTeam>();
            Employee = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string DepName { get; set; }
        public DateTime? AddOn { get; set; }
        public virtual ICollection<DevTeam> DevTeam { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
    }
}