namespace Journal.Tests.TestData.Attributes
{
    public enum TestLifeTime
    {
        EntireRun,
        SingleTest
    }

    public class TestPocoAttribute(TestLifeTime lifeTime, TestDataTypeOrder insertOrder = 0) : Attribute
    {
        public TestLifeTime LifeTime { get; set; } = lifeTime;
        public TestDataTypeOrder InsertOrder { get; set; } = insertOrder;
    }
}
