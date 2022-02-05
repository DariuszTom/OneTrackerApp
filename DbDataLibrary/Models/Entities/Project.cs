using System;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DbDataLibrary.Models.Entities
{
    public partial class Project : IDomainObject
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string RequestingTeam { get; set; }
        public string ContactPerson { get; set; }
        public string ProjectType { get; set; }
        public string ProjectStatus { get; set; }
        public string Piority { get; set; }
        public string Benefits { get; set; }
        public string Comment { get; set; }
        public string MacroName { get; set; }
        public DateTime? SubmitionTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public float? FteSavings { get; set; }
        public int? Developer { get; set; }
        public string DevComment { get; set; }
        public int? DevTeam { get; set; }
        public DateTime? DueDate { get; set; }

        public virtual DevTeam DevTeamNavigation { get; set; }
        public virtual Employee DeveloperNavigation { get; set; }
        public virtual ProjectPriority PiorityNavigation { get; set; }
        public virtual ProjectStatus ProjectStatusNavigation { get; set; }
        public virtual ProjectType ProjectTypeNavigation { get; set; }
    }
}