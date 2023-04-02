namespace EventManager.BLL.Exceptions
{
    public class EventNotFoundException : NotFoundException
    {
        public EventNotFoundException(long id)
            : base($"Event with id {id} not found") { }
    }
}