using Journal.Database.Base;
using Journal.Database.Data.Attributes;
using Journal.Database.Data.Environment;
using Journal.Database.Interfaces;
using Journal.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using System;
using System.Reflection;
using Journal.Database.Context;

namespace Journal.Database.Data
{
    public static class SeedData
    {
        private static readonly IServiceCollection SeedDataCollection = new ServiceCollection();
        private static ServiceProvider? SeedDataProvider;
        private static List<ReflectionHelper.ClassWithAttribute<SeedDataAttribute>> SeedPocos = new();

        public static void DiscoverAndRegisterSeedData()
        {
            SeedPocos = ReflectionHelper.GetClassesWithAttribute<SeedDataAttribute>(typeof(EntityBase))
                .OrderBy(poco => poco.Attribute.InsertOrder)
                .ToList();
            SeedPocos.ForEach(seed => SeedDataCollection.AddSingleton(seed.ClassType));
            SeedDataProvider = SeedDataCollection.BuildServiceProvider();
        }

        public static void AddSeedData()
        {
            var seedData = ReflectionHelper.GetClassesWithAttribute<SeedDataAttribute>(typeof(EntityBase))
                .OrderBy(poco => poco.Attribute.InsertOrder)
                .ToList();

            foreach (var seed in seedData)
            {
                SeedDataCollection.AddSingleton(seed.ClassType);
            }
            SeedDataProvider = SeedDataCollection.BuildServiceProvider();
            using var transaction = ServiceEnvironment.DatabaseContext.Database.BeginTransaction();
            try
            {
                foreach (var poco in seedData)
                {
                    var instance = SeedDataProvider.GetRequiredService(poco.ClassType);
                    ServiceEnvironment.DatabaseContext.Add(instance);
                    ServiceEnvironment.DatabaseContext.SaveChanges();
                }
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }

        public static void RemoveSeedData()
        {
            var dataTypes = Enum.GetValues(typeof(DataTypeOrder))
                .Cast<DataTypeOrder>()
                .OrderByDescending(d=>d)
                .ToList();
            var databaseName = ServiceEnvironment.DatabaseContext.Database.GetDbConnection().Database;
            foreach (var dataType in dataTypes)
            {
                var tableName = Enum.GetName(typeof(DataTypeOrder), dataType);
                var table = ServiceEnvironment.DatabaseContext.Model
                    .GetEntityTypes()
                    .First(t => t.Name.EndsWith(tableName!));
                var sql = $"DELETE FROM [{databaseName}].[{table.GetSchema()}].[{table.GetTableName()}]";
                var rowsAffected = ServiceEnvironment.DatabaseContext.Database.ExecuteSqlRaw(sql);
                Console.WriteLine($"From {tableName} removed {rowsAffected} rows");
            }
        }

        public static T GetSeed<T>() where T : IEntity
        {
            return SeedDataProvider!.GetRequiredService<T>();
        }
    }
}
