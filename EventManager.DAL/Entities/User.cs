namespace EventManager.DAL.Entities
{
    public class User : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public string UserName { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string CompanyName { get; private set; }
        public ICollection<Event> Events { get; private set; }
        public ICollection<EventParticipant> Participants { get; private set; }

        public static User CreateUser(string name, string userName, string email, string phone, string companyName)
        {
            var user = new User();
            user.Name = name;
            user.UserName = userName;
            user.Email = email;
            user.Phone = phone;
            user.CompanyName = companyName;
            return user;
        }
    }
}