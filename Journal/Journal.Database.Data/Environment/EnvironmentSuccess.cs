using Journal.Database.Data.Environment.Base;
using Microsoft.Extensions.DependencyInjection;

namespace Journal.Database.Data.Environment
{
    public class EnvironmentSuccess: EnvironmentBase
    {
        public override void AdjustEnvironment(IServiceCollection services)
        {
            base.AdjustEnvironment(services);
        }
    }
}
