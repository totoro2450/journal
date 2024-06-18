using Journal.Database.Entities.Security;

namespace Journal.DTO
{
    public class UserDto
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public bool IsSuperAdmin { get; set; }

        public UserDto()
        {
            
        }

        public UserDto(User user)
        {
            Id = user.Id;
            Guid = user.Guid;
            Name = user.Name;
            DisplayName = user.DisplayName;
            Email = user.Email;
            IsSuperAdmin = user.IsSuperAdmin;
        }
    }
}
