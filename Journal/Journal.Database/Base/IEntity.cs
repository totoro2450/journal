namespace Journal.Database.Base
{
    public interface IEntity
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
    }
}
