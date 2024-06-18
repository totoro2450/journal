using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Journal.Database.Base;

namespace Journal.Database.Entities.Security
{
    [ExcludeFromCodeCoverage]
    [Table("UserRole", Schema = "Security")]
    [Index(nameof(Guid), IsUnique = true)]
    public class SecurityUserRole: EntityBase
    {
        [ForeignKey("Users")] 
        public int UserId { get; set; }

        [ForeignKey("Roles")] 
        public int RoleId { get; set; }

        public User User { get; set; }

        public SecurityRole Role { get; set; }
    }
}
