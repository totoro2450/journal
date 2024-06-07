using System.ComponentModel.DataAnnotations;

namespace Journal.Database.Base
{
    public class EntityBase : IEntity
    {
        [Key] public int Id { get; set; }
        public Guid Guid { get; set; }
    }
}
