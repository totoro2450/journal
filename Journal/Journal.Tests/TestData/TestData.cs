using Journal.Tests.TestData.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Journal.Database.Base;
using Journal.Shared.Helpers;
using Journal.Tests.Environment;
using Journal.Database.Interfaces;

namespace Journal.Tests.TestData
{
    public static class TestData
    {
        public static readonly IServiceCollection ServiceCollection = new ServiceCollection();
        public static ServiceProvider? ServiceProvider;
        private static List<Guid> TrackedGuids = new List<Guid>();

        public static void CreateTestData()
        {
            Console.WriteLine("Creating Test Data");
            var testPocos = ReflectionHelper.GetClassesWithAttribute<TestPocoAttribute>(typeof(EntityBase))
                .Where(poco => poco.Attribute.LifeTime == TestLifeTime.EntireRun)
                .OrderBy(poco => poco.Attribute.InsertOrder)
                .ToList();
            
            foreach (var poco in testPocos)
            {
                ServiceCollection.AddSingleton(poco.ClassType);
            }
            ServiceProvider = ServiceCollection.BuildServiceProvider();
            foreach (var poco in testPocos)
            {
                var instance = ServiceProvider.GetRequiredService(poco.ClassType);
                TestEnvironment.DataBase.Add(instance);
                TestEnvironment.DataBase.SaveChanges();
                TrackedGuids.Add(((dynamic)instance).Guid);
            }

            // TestEnvironment.DataBase.SaveChanges();
        }

        public static void RemoveTestData()
        {
            Console.WriteLine("Removing Test Data");
            //var testPocos = ReflectionHelper.GetClassesWithAttribute<TestPocoAttribute>(typeof(EntityBase))
            //    .OrderByDescending(poco => poco.Attribute.InsertOrder)
            //    .ToList();

            //foreach (var poco in testPocos)
            //{
                
            //}
        }

        public static T GetPoco<T>() where T : IEntity
        {
            var poco = ServiceProvider.GetRequiredService<T>();
            if (poco != null)
            {
                if (TrackedGuids.Any(t => t == poco.Guid))
                    return poco;
                TrackedGuids.Add(poco.Guid);
            }
            return poco;
        }
    }

    public enum TestDataTypeOrder
    {
        Application = 0,
        ApplicationVersion = 1,
    }
}
