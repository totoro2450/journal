using System.ComponentModel.DataAnnotations;
using Journal.Database.Interfaces;

namespace Journal.Database.Base
{
    public class EntityBase : IEntity
    {
        [Key] public int Id { get; set; }
        public Guid Guid { get; set; }
    }
}
