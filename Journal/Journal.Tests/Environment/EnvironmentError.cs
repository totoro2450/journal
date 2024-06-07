using Microsoft.Extensions.DependencyInjection;

namespace Journal.Tests.Environment
{
    public class EnvironmentError: EnvironmentBase
    {
        public override void AdjustEnvironment(IServiceCollection services)
        {
            base.AdjustEnvironment(services);
            services.Clear();
        }
    }
}
