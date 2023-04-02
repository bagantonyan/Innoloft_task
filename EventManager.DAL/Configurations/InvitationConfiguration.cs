using EventManager.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManager.DAL.Configurations
{
    public class InvitationConfiguration : BaseEntityConfiguration<Invitation>
    {
        public override void Configure(EntityTypeBuilder<Invitation> builder)
        {
            base.Configure(builder);

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Approved)
                .IsRequired(true);

            builder.HasOne(i => i.Sender)
                .WithMany()
                .HasForeignKey(i => i.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(i => i.Receiver)
                .WithMany()
                .HasForeignKey(i => i.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}