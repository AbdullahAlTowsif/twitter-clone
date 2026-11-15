using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Persistence.Configurations
{
    public class LikeConfiguration : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            builder.HasKey(l => l.Id);

            builder.Property(l => l.UserId).IsRequired();
            builder.Property(l => l.TweetId).IsRequired();

            // A user can like a tweet only once
            builder.HasIndex(l => new { l.UserId, l.TweetId }).IsUnique();
            builder.HasIndex(l => l.TweetId); // fast like counts per tweet

            builder.HasOne<User>()
                   .WithMany()
                   .HasForeignKey(l => l.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<Tweet>()
                   .WithMany()
                   .HasForeignKey(l => l.TweetId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
