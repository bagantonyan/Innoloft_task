using EventManager.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace EventManager.DAL.Configurations
{
    public class EventParticipantConfiguration : BaseEntityConfiguration<EventParticipant>
    {
        public override void Configure(EntityTypeBuilder<EventParticipant> builder)
        {
            base.Configure(builder);

            builder.HasKey(ep => new { ep.EventId, ep.UserId });

            builder.HasOne(ep => ep.Event)
                .WithMany(e => e.Participants)
                .HasForeignKey(ep => ep.EventId);

            builder.HasOne(ep => ep.User)
                .WithMany(e => e.Participants)
                .HasForeignKey(ep => ep.UserId);
        }
    }
}