using EventManager.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManager.DAL.Configurations
{
    public class UserConfiguration : BaseEntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Name)
                .HasMaxLength(64)
                .IsRequired(true);

            builder.Property(p => p.UserName)
                .HasMaxLength(64)
                .IsRequired(true);

            builder.Property(p => p.Email)
                .HasMaxLength(64)
                .IsRequired(true);

            builder.Property(p => p.Phone)
                .HasMaxLength(64)
                .IsRequired(true);

            builder.Property(p => p.CompanyName)
                .HasMaxLength(64)
                .IsRequired(true);
        }
    }
}