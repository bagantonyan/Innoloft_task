namespace EventManager.BLL.DTOs.Invitations
{
    public class SendInvitationRequestDTO
    {
        public int EventId { get; set; }
        public int SenderId { get; set; }
        public List<int> ReceiverIds { get; set; }
    }
}