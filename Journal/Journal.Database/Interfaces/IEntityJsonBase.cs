namespace Journal.Database.Interfaces
{
    public interface IEntityJsonBase: IEntity
    {
        string Name { get; set; }
        string? Json { get; set; }
        string Type { get; set; }
        bool IsEncrypted { get; set; }
        object? Value { get; set; }
    }
}
