using System;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DbDataLibrary.Models.Entities
{
    public partial class AppLogs : IDomainObject
    {
        public int Id { get; set; }
        public string LogDesc { get; set; }
        public int? IdUser { get; set; }
        public DateTime? AddOn { get; set; }

        public virtual Employee IdUserNavigation { get; set; }
    }
}