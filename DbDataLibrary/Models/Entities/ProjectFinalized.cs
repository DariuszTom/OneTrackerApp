using System;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DbDataLibrary.Models.Entities
{
    public partial class ProjectFinalized : IDomainObject
    {
        public int? IdProject { get; set; }
        public string ProjectName { get; set; }
        public string ContactPerson { get; set; }
        public string RequestingTeam { get; set; }
        public string ProjectType { get; set; }
        public string ProjectStatus { get; set; }
        public string Piority { get; set; }
        public string Benefits { get; set; }
        public string Comment { get; set; }
        public string MacroName { get; set; }
        public DateTime? DoneTime { get; set; }
        public float? FteSavings { get; set; }
        public int? Developer { get; set; }
        public string DevComment { get; set; }
        public int? DevTeam { get; set; }
        public DateTime? SubmitionTime { get; set; }
        public DateTime? DueDate { get; set; }

        [NotMapped]
        public int Id { get => (int)IdProject; set => IdProject = value; }
    }
}