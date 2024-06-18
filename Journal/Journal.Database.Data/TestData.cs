using Journal.Database.Base;
using Journal.Database.Data.Attributes;
using Journal.Database.Data.Environment;
using Journal.Database.Interfaces;
using Journal.Shared.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace Journal.Database.Data
{
    public static class TestData
    {
        private static readonly IServiceCollection TestDataCollection = new ServiceCollection();
        private static ServiceProvider TestDataProvider;
        private static List<ReflectionHelper.ClassWithAttribute<TestDataAttribute>> TestPocos = new();

        public static void DiscoverAndRegisterTestPocos()
        {
            TestPocos = ReflectionHelper.GetClassesWithAttribute<TestDataAttribute>(typeof(EntityBase))
                .OrderBy(poco => poco.Attribute.InsertOrder)
                .ToList();
            TestPocos.ForEach(poco => TestDataCollection.AddSingleton(poco.ClassType));
            TestDataProvider = TestDataCollection.BuildServiceProvider();
        }

        public static void AddTestData()
        {
            Console.WriteLine("Creating Test Data");
            var testPocos = TestPocos
                .Where(poco => poco.Attribute.LifeTime == PocoLifeTime.EntireRun)
                .ToList();
            
            foreach (var poco in testPocos)
            {
                var instance = TestDataProvider.GetRequiredService(poco.ClassType);
                ServiceEnvironment.DatabaseContext.Add(instance);
                ServiceEnvironment.DatabaseContext.SaveChanges();
            }
        }

        public static void RemoveTestData()
        {
            Console.WriteLine("Removing Test Data");

            var pocos = TestPocos
                .OrderByDescending(poco => poco.Attribute.InsertOrder)
                .ToList();

            foreach (var poco in pocos)
            {
                var instance = TestDataProvider.GetRequiredService(poco.ClassType);
                ServiceEnvironment.DatabaseContext.Remove(instance);
            }
        }

        public static T GetPoco<T>() where T : IEntity
        {
            return TestDataProvider.GetRequiredService<T>();
        }
    }
}
