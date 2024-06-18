using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Journal.Database.Base;
using Journal.Database.Interfaces;

namespace Journal.Database.Entities.Security
{
    [ExcludeFromCodeCoverage]
    [Table("Roles", Schema = "Security")]
    [Index(nameof(Guid), IsUnique = true)]
    public class SecurityRole: EntityBase, INameable
    {
        public string Name { get; set; }
        public int Rank { get; set; }
        public List<SecurityUserRole> Users { get; set; } = new();
    }
}
