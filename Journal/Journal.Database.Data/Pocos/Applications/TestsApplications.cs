using Journal.Database.Data.Attributes;
using Journal.Database.Entities.Application;

namespace Journal.Database.Data.Pocos.Applications
{
    [TestData(PocoLifeTime.EntireRun, DataTypeOrder.Application)]
    public class TestApplication : Application
    {
        public TestApplication()
        {
            Guid = Guid.NewGuid();
            Description = "Test Application Description";
            IsLive = true;
            Name = "Test Application";
        }
    }

    [TestData(PocoLifeTime.EntireRun, DataTypeOrder.ApplicationVersion)]
    public class TestApplicationVersion : ApplicationVersion
    {
        public TestApplicationVersion()
        {
            Guid = Guid.NewGuid();
            ApplicationId = TestData.GetPoco<TestApplication>().Id;
        }
    }

    [TestData(PocoLifeTime.SingleTest)]
    public class TestApplication2 : Application
    {
        public TestApplication2()
        {
            Guid = Guid.NewGuid();
            Description = "Test Application 2 Description";
            IsLive = true;
            Name = "Test Application 2";
        }
    }
}
