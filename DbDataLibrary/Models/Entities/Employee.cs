using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DbDataLibrary.Models.Entities
{
    public partial class Employee : IDomainObject
    {
        public Employee()
        {
            AppLogs = new HashSet<AppLogs>();
            Macro = new HashSet<Macro>();
            Project = new HashSet<Project>();
        }

        public int Id { get; set; }
        public string IdEmployee { get; set; }
        public string EmpName { get; set; }
        public string EmpSurname { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Position { get; set; }
        public int? Departament { get; set; }
        public int? Team { get; set; }
        public int? IdAdmin { get; set; }
        public DateTime? AddOn { get; set; }

        public virtual Department DepartamentNavigation { get; set; }
        public virtual Admin IdAdminNavigation { get; set; }
        public virtual DevTeam TeamNavigation { get; set; }
        public virtual ICollection<AppLogs> AppLogs { get; set; }
        public virtual ICollection<Macro> Macro { get; set; }
        public virtual ICollection<Project> Project { get; set; }
    }
}