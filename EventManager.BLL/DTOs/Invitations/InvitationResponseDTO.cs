namespace EventManager.BLL.DTOs.Invitations
{
    public class InvitationResponseDTO
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public string SenderName { get; set; }
        public string SenderCompany { get; set; }
        public int ReceiverId { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverCompany { get; set; }
        public int EventId { get; set; }
        public string EventTitle { get; set; }
        public bool Approved { get; set; }
    }
}