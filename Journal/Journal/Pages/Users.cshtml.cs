using Journal.DTO;
using Journal.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Journal.Pages
{
    public class UsersModel : PageModel
    {
        public List<UserDto> Users = new List<UserDto>();
        private readonly DatabaseService _dbService;

        public UsersModel(DatabaseService dbService)
        {
            _dbService = dbService;
        }

        public void OnGet()
        {
            Users = GetUsers();
        }

        public List<UserDto> GetUsers()
        {
            return _dbService.GetUsers();
        }
    }
}
