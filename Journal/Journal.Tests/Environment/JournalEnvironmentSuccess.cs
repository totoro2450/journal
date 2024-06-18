using Journal.Database.Data.Environment;
using Journal.Pages;
using Journal.Registrations;
using Microsoft.Extensions.DependencyInjection;

namespace Journal.Tests.Environment
{
    public class JournalEnvironmentSuccess: EnvironmentSuccess
    {
        public override void AdjustEnvironment(IServiceCollection services)
        {
            base.AdjustEnvironment(services);
            ServiceCollection.AddScoped<IndexModel>();
            ServiceCollection.RegisterJournal();
        }
    }
}
