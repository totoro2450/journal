namespace Journal.Database.Interfaces
{
    public interface IEntity
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
    }
}
