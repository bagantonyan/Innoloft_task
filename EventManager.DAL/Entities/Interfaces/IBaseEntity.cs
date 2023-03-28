namespace EventManager.DAL.Entities.Interfaces
{
    public interface IBaseEntity
    {
        DateTime CreatedDate { get; set; }
        DateTime ModifiedDate { get; set; }
        DateTime? DeletedDate { get; set; }
    }
}
