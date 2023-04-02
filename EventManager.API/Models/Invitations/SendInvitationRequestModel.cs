namespace EventManager.API.Models.Invitations
{
    public class SendInvitationRequestModel
    {
        public int EventId { get; set; }
        public int SenderId { get; set; }
        public List<int> ReceiverIds { get; set; }
    }
}
