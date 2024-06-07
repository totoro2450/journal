using Microsoft.Extensions.DependencyInjection;

namespace Journal.Tests.Environment
{
    public class EnvironmentSuccess: EnvironmentBase
    {
        public override void AdjustEnvironment(IServiceCollection services)
        {
            base.AdjustEnvironment(services);
        }
    }
}
