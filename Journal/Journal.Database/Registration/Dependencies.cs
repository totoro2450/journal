using Journal.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Journal.Database.Registration
{
    public static class Dependencies
    {
        public static void RegisterDataBaseDependencies(this IServiceCollection services, ContextRegistrationParams regParams)
        {
            if (regParams.InMemoryServer)
            {
                services.AddDbContext<JournalContext>(options => options
                    .UseSqlite("DataSource=:memory:")
                    .EnableSensitiveDataLogging());
            }
            else
            {
                services.AddDbContext<JournalContext>(options => options
                    .UseSqlServer(regParams.ConnectionString), ServiceLifetime.Scoped);
                //regParams.ConnectionString, assembly => assembly
                //    .MigrationsAssembly(typeof(JournalContext).Assembly.FullName)
                //    .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)
            }
        }

        public class ContextRegistrationParams
        {
            public bool InMemoryServer { get; set; }

            public string ConnectionString { get; set; }
        }
    }
}
