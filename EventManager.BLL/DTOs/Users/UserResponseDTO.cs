namespace EventManager.BLL.DTOs.Users
{
    public class UserResponseDTO
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string UserName { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string CompanyName { get; private set; }
    }
}