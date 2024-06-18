namespace Journal.Database.Data.Attributes
{
    public class TestDataAttribute(PocoLifeTime lifeTime, DataTypeOrder insertOrder = 0) : Attribute
    {
        public PocoLifeTime LifeTime { get; set; } = lifeTime;
        public DataTypeOrder InsertOrder { get; set; } = insertOrder;
    }
}
