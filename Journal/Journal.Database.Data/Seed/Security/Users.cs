using Journal.Database.Data.Attributes;
using Journal.Database.Entities.Security;

namespace Journal.Database.Data.Seed.Security
{
    [SeedData(DataTypeOrder.User)]
    public class Users_SuperAdmin : User
    {
        public Users_SuperAdmin()
        {
            Guid = Guid.NewGuid();
            Email = "superAdmin@localhost";
            Name = "superAdmin";
            DisplayName = "Super Admin";
            IsSuperAdmin = true;
            Password = "SuperAdmin";
        }
    }

    [SeedData(DataTypeOrder.User)]
    public class Users_Admin : User
    {
        public Users_Admin()
        {
            Guid = Guid.NewGuid();
            Email = "admin@localhost";
            Name = "admin";
            DisplayName = "Admin";
            IsSuperAdmin = true;
            Password = "Admin";
        }
    }

    [SeedData(DataTypeOrder.User)]
    public class User_User : User
    {
        public User_User()
        {
            Guid = Guid.NewGuid();
            Email = "user@localhost";
            Name = "user";
            DisplayName = "User";
            IsSuperAdmin = false;
            Password = "user";
        }
    }

    [SeedData(DataTypeOrder.User)]
    public class User_Guest : User
    {
        public User_Guest()
        {
            Guid = Guid.NewGuid();
            Email = "guest@localhost";
            Name = "guest";
            DisplayName = "Guest";
            IsSuperAdmin = false;
            Password = "guest";
        }
    }
}
