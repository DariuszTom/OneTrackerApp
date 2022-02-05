using DbDataLibrary.Models.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace DbDataLibrary.Models
{
    [Serializable()]
    [DataContract]
    public class DeveloperForView : IDomainObject
    {
        [Key]
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string IdEmployee { get; set; }

        [DataMember]
        public string EmpName { get; set; }

        [DataMember]
        public string EmpSurname { get; set; }

        [DataMember]
        public string Phone { get; set; }

        [DataMember]
        public string Mail { get; set; }

        [DataMember]
        public string Position { get; set; }

        [DataMember]
        public int? Departament { get; set; }

        [DataMember]
        public int? Team { get; set; }

        [DataMember]
        public int? IdAdmin { get; set; }

        [DataMember]
        public virtual DevTeam TeamNavigation { get; set; }
    }
}