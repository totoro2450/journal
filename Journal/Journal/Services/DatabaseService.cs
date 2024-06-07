using Journal.Database.Context;
using Journal.Services.Attributes;
using Journal.Services.Base;
using Microsoft.EntityFrameworkCore;

namespace Journal.Services
{
    [Injection(InjectionType.Scoped)]
    public class DatabaseService: JournalServiceBase
    {
        public JournalContext DbContext { get; set; }
        public DatabaseService(JournalContext dbContext)
        {
            DbContext = dbContext;
        }

        public int GetApplicationCount()
        {
            return DbContext.Applications.Count();
        }
    }
}
