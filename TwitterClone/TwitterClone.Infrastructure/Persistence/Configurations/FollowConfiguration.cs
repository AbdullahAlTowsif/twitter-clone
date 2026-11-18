using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Persistence.Configurations
{
    public class FollowConfiguration : IEntityTypeConfiguration<Follow>
    {
        public void Configure(EntityTypeBuilder<Follow> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.FollowerId).IsRequired();
            builder.Property(f => f.FollowingId).IsRequired();

            // A user can follow another user only once
            builder.HasIndex(f => new { f.FollowerId, f.FollowingId }).IsUnique();
            builder.HasIndex(f => f.FollowingId);

            // Two FKs to User, so cascade is off on both to avoid multiple cascade paths
            builder.HasOne<User>()
                   .WithMany()
                   .HasForeignKey(f => f.FollowerId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<User>()
                   .WithMany()
                   .HasForeignKey(f => f.FollowingId)
                   .OnDelete(DeleteBehavior.Restrict);

            // A user can't follow themselves
            builder.ToTable(t => t.HasCheckConstraint("CK_Follow_NoSelfFollow", "\"FollowerId\" <> \"FollowingId\""));
        }
    }
}
