using EventManager.DAL.Entities.Interfaces;

namespace EventManager.DAL.Entities
{
    public abstract class BaseEntity : IBaseEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}