using Journal.Database.Data.Attributes;
using Journal.Database.Entities.Security;

namespace Journal.Database.Data.Seed.Security
{
    [SeedData(DataTypeOrder.SecurityUserRole)]
    public class SecurityUserRoles_UserAdmin_AdminRole: SecurityUserRole
    {
        public SecurityUserRoles_UserAdmin_AdminRole()
        {
            Guid = Guid.NewGuid();
            UserId = SeedData.GetSeed<Users_Admin>().Id;
            RoleId = SeedData.GetSeed<SecurityRoles_Admin>().Id;
        }
    }

    [SeedData(DataTypeOrder.SecurityUserRole)]
    public class SecurityUserRoles_UserUser_UserRole : SecurityUserRole
    {
        public SecurityUserRoles_UserUser_UserRole()
        {
            Guid = Guid.NewGuid();
            UserId = SeedData.GetSeed<User_User>().Id;
            RoleId = SeedData.GetSeed<SecurityRoles_User>().Id;
        }
    }

    [SeedData(DataTypeOrder.SecurityUserRole)]
    public class SecurityUserRoles_UserGuest_UserGuest : SecurityUserRole
    {
        public SecurityUserRoles_UserGuest_UserGuest()
        {
            Guid = Guid.NewGuid();
            UserId = SeedData.GetSeed<User_Guest>().Id;
            RoleId = SeedData.GetSeed<SecurityRoles_Guest>().Id;
        }
    }
}
