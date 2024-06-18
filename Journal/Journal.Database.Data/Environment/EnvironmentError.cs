using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Journal.Database.Data.Environment.Base;
using Microsoft.Extensions.DependencyInjection;

namespace Journal.Database.Data.Environment
{
    public class EnvironmentError: EnvironmentBase
    {
        public override void AdjustEnvironment(IServiceCollection services)
        {
            services.Clear();
        }
    }
}
