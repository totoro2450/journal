using Journal.Services.Attributes;
using Journal.Services.Base;
using Journal.Shared.Helpers;

namespace Journal.Registrations
{
    public static class Dependencies
    {
        public static void RegisterJournal(this IServiceCollection services)
        {
            DiscoverAndRegisterService(services);
        }

        public static void DiscoverAndRegisterService(IServiceCollection services)
        {
            var serviceTypes = ReflectionHelper.GetClassesWithAttribute<InjectionAttribute>(typeof(JournalServiceBase))
                .ToList();

            foreach (var serviceType in serviceTypes)
            {
                switch (serviceType.Attribute.InjectionType)
                {
                    case InjectionType.Singleton:
                        services.AddSingleton(serviceType.ClassType);
                        break;
                    case InjectionType.Scoped:
                        services.AddScoped(serviceType.ClassType);
                        break;
                    case InjectionType.Transient:
                        services.AddTransient(serviceType.ClassType);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}
