using Journal.Database.Data.Attributes;
using Journal.Database.Entities.Security;

namespace Journal.Database.Data.Seed.Security
{
    [SeedData(DataTypeOrder.SecurityRole)]
    public class SecurityRoles_Admin: SecurityRole
    {
        public SecurityRoles_Admin()
        {
            Name = "Admin";
            Rank = 1;
            Guid = Guid.NewGuid();
        }
    }

    [SeedData(DataTypeOrder.SecurityRole)]
    public class SecurityRoles_User : SecurityRole
    {
        public SecurityRoles_User()
        {
            Name = "User";
            Rank = 2;
            Guid = Guid.NewGuid();
        }
    }

    [SeedData(DataTypeOrder.SecurityRole)]
    public class SecurityRoles_Guest : SecurityRole
    {
        public SecurityRoles_Guest()
        {
            Name = "Guest";
            Rank = 3;
            Guid = Guid.NewGuid();
        }
    }
}
