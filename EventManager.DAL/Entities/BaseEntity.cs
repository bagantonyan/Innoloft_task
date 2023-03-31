namespace EventManager.DAL.Entities
{
    public abstract class BaseEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}