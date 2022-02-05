using System;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DbDataLibrary.Models.Entities
{
    public partial class Macro : IDomainObject
    {
        public int Id { get; set; }
        public string MacroName { get; set; }
        public string GmasMacroId { get; set; }
        public string GmasMacroWebPage { get; set; }
        public int? MacroDeveloper { get; set; }
        public string BusinessTeam { get; set; }
        public string Description { get; set; }
        public DateTime? AddOn { get; set; }

        public virtual Employee MacroDeveloperNavigation { get; set; }
    }
}