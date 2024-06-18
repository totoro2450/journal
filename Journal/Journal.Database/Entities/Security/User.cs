using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Journal.Database.Base;
using Journal.Database.Interfaces;

namespace Journal.Database.Entities.Security
{
    [ExcludeFromCodeCoverage]
    [Table("Users", Schema = "Security")]
    [Index(nameof(Guid), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]
    public class User: EntityBase, INameable
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public bool IsSuperAdmin { get; set; }
        public string Password { get; set; }
        public List<SecurityUserRole> Roles { get; set; } = new();
    }
}
