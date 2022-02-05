using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DbDataLibrary.Models.Entities
{
    public partial class ProjectStatus
    {
        public ProjectStatus()
        {
            Project = new HashSet<Project>();
        }

        public string ProjectStatusName { get; set; }
        public string Description { get; set; }
        public DateTime? AddOn { get; set; }

        public virtual ICollection<Project> Project { get; set; }
    }
}