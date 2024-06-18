namespace Journal.Database.Data.Attributes
{
    public class SeedDataAttribute(DataTypeOrder insertOrder = 0) : Attribute
    {
        public DataTypeOrder InsertOrder { get; set; } = insertOrder;
    }
}
