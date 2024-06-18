using Journal.Database.Data.Environment;
using Microsoft.Extensions.DependencyInjection;

namespace Journal.Tests.Environment
{
    public class JournalEnvironmentError: EnvironmentError
    {
        public override void AdjustEnvironment(IServiceCollection services)
        {
        }
    }
}
