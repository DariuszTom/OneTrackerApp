using DbDataLibrary.Models.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace DbDataLibrary.Models
{
    [Serializable()]
    [DataContract]
    public class TeamForViewNew : IDomainObject
    {
        [Key]
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string TeamName { get; set; }

        [DataMember]
        public string Mail { get; set; }

        [DataMember]
        public int? Departament { get; set; }

        [DataMember]
        public string Manager { get; set; }

        [DataMember]
        public DateTime? AddOn { get; set; }

        [DataMember]
        public Department DepartamentNavigation { get; set; }
    }
}