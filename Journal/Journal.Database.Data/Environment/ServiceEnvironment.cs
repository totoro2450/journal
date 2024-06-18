using Journal.Database.Context;
using Journal.Database.Data.Environment.Base;
using Microsoft.EntityFrameworkCore;

namespace Journal.Database.Data.Environment
{
    public static class ServiceEnvironment
    {
        public static EnvironmentBase Success { get; set; } = new();
        public static EnvironmentBase Error { get; set; } = new();
        public static JournalContext DatabaseContext { get; set; }

        static ServiceEnvironment()
        {
            DatabaseContext = Success.GetService<JournalContext>();
            OpenDataBase();
        }

        public static void AddTestData()
        {
            Console.WriteLine("Creating Test Data");
            TestData.DiscoverAndRegisterTestPocos();
            TestData.AddTestData();
        }

        public static void AddSeedData()
        {
            Console.WriteLine("Creating Seed Data");
            SeedData.DiscoverAndRegisterSeedData();
            SeedData.AddSeedData();
        }

        public static void RemoveTestData()
        {
            Console.WriteLine("Removing Test Data");
            TestData.RemoveTestData();
        }

        public static void RemoveAllData()
        {
            Console.WriteLine("Removing All Data");
            SeedData.RemoveSeedData();
        }

        private static void OpenDataBase()
        {
            DatabaseContext.Database.OpenConnection();
            DatabaseContext.Database.EnsureCreated();
        }
    }
}
