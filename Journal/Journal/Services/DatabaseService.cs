using Journal.Database.Context;
using Journal.DTO;
using Journal.Services.Attributes;
using Journal.Services.Base;

namespace Journal.Services
{
    [Injection(InjectionType.Scoped)]
    public class DatabaseService: JournalServiceBase
    {
        public const int DefaultPageSize = 100;
        public JournalContext DbContext { get; set; }
        public DatabaseService(JournalContext dbContext)
        {
            DbContext = dbContext;
        }

        public int GetApplicationCount()
        {
            return DbContext.Applications.Count();
        }

        public List<UserDto> GetUsers(int pageNo = 0, int pageSize = DefaultPageSize)
        {
            return DbContext.Users
                .Skip(pageNo * pageSize)
                .Take(pageSize)
                .Select(u => new UserDto(u))
                .ToList();
        }
    }
}
