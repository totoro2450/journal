using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Journal.Database.Base;
using Journal.Database.Context;
using Journal.Database.Entities;
using Journal.Tests.Helper;
using Journal.Tests.TestData.Applications;
using Journal.Tests.TestData.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TestData1 = Journal.Tests.TestData.TestData;

namespace Journal.Tests.Environment
{
    public static class TestEnvironment
    {
        public static EnvironmentBase Success { get; set; } = new EnvironmentSuccess();
        public static EnvironmentBase Error { get; set; } = new EnvironmentError();
        public static JournalContext? DataBase { get; set; }

        static TestEnvironment()
        {
            DataBase = Success.GetService<JournalContext>();
            OpenDataBase();
        }

        public static void CreateTestData()
        {
            Console.WriteLine("Creating Test Data");
            TestData1.CreateTestData();
        }

        public static void RemoveTestData()
        {
            Console.WriteLine("Removing Test Data");
            TestData1.RemoveTestData();
        }

        public static void OpenDataBase()
        {
            DataBase.Database.OpenConnection();
            DataBase.Database.EnsureCreated();
        }
    }
}
