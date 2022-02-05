using DbDataLibrary.Models.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace DbDataLibrary.Models
{
    [Serializable()]
    [DataContract]
    public class ProjectForView : IDomainObject
    {
        [Key]
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string ProjectName { get; set; }

        [DataMember]
        public string RequestingTeam { get; set; }

        [DataMember]
        public string ContactPerson { get; set; }

        [DataMember]
        public string ProjectType { get; set; }

        [DataMember]
        public string ProjectStatus { get; set; }

        [DataMember]
        public string Piority { get; set; }

        [DataMember]
        public string Benefits { get; set; }

        [DataMember]
        public string Comment { get; set; }

        [DataMember]
        public string MacroName { get; set; }

        [DataMember]
        public DateTime? SubmitionTime { get; set; }

        [DataMember]
        public DateTime? UpdateTime { get; set; }

        [DataMember]
        public float? FteSavings { get; set; }

        [DataMember]
        public int? Developer { get; set; }

        [DataMember]
        public string DevComment { get; set; }

        [DataMember]
        public int? DevTeam { get; set; }

        [DataMember]
        public DateTime? DueDate { get; set; }

        [DataMember]
        public virtual DevTeam DevTeamNavigation { get; set; }

        [DataMember]
        public virtual Employee DeveloperNavigation { get; set; }
    }
}