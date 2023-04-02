namespace EventManager.BLL.Exceptions
{
    public class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(long id)
            : base($"User with id {id} not found") { }
    }
}