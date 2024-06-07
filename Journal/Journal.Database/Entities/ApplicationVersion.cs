using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using Journal.Database.Base;
using Microsoft.EntityFrameworkCore;

namespace Journal.Database.Entities
{
    [ExcludeFromCodeCoverage]
    [Table("ApplicationVersions", Schema = "Application")]
    [Index(nameof(Guid), IsUnique = true)]
    public class ApplicationVersion : EntityBase
    {
        public int ApplicationId { get; set; }
        
        [JsonIgnore]
        public Application Application { get; set; }
    }
}
