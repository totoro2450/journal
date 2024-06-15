using Journal.Database.Context;
using Journal.Database.Entities.Application;
using Journal.Services.Attributes;
using Journal.Services.Base;

namespace Journal.Services
{
    [Injection(InjectionType.Scoped)]
    public class TestDataService: JournalServiceBase
    {
        public JournalContext DbContext { get; set; }

        public TestDataService(JournalContext dbContext)
        {
            DbContext = dbContext;
        }

        public void CreateApplications()
        {
            DbContext.Applications.Add(new Application { Name = "Test Application 1", Guid = Guid.NewGuid(), Description = "" });
            DbContext.Applications.Add(new Application { Name = "Test Application 2", Guid = Guid.NewGuid(), Description = "" });
            DbContext.Applications.Add(new Application { Name = "Test Application 3", Guid = Guid.NewGuid(), Description = "" });
            // DbContext.SaveChanges();
        }
    }
}
