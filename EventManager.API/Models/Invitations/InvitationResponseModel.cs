namespace EventManager.API.Models.Invitations
{
    public class InvitationResponseModel
    {
        public int Id { get; private set; }
        public int SenderId { get; private set; }
        public string SenderName { get; set; }
        public string SenderCompany { get; set; }
        public int ReceiverId { get; private set; }
        public string ReceiverName { get; set; }
        public string ReceiverCompany { get; set; }
        public int EventId { get; private set; }
        public string EventTitle { get; set; }
        public bool Approved { get; private set; }
    }
}