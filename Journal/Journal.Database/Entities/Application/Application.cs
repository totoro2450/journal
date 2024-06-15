using Journal.Database.Base;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Journal.Database.Entities.Application
{
    [ExcludeFromCodeCoverage]
    [Table("Applications", Schema = "Application")]
    [Index(nameof(Guid), IsUnique = true)]
    public class Application : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsLive { get; set; }
        public List<ApplicationVersion> Versions { get; set; } = new();

        //[Required]
        //[MaxLength(50)]
        //public string FirstName { get; set; }
    }
}
