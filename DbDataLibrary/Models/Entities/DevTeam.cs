using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DbDataLibrary.Models.Entities
{
    public partial class DevTeam : IDomainObject
    {
        public DevTeam()
        {
            Employee = new HashSet<Employee>();
            Project = new HashSet<Project>();
        }

        public int Id { get; set; }
        public string TeamName { get; set; }
        public string Mail { get; set; }
        public int? Departament { get; set; }
        public string Manager { get; set; }
        public DateTime? AddOn { get; set; }
        public virtual Department DepartamentNavigation { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<Project> Project { get; set; }
    }
}