using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Persistence.Configurations
{
    public class BookmarkConfiguration : IEntityTypeConfiguration<Bookmark>
    {
        public void Configure(EntityTypeBuilder<Bookmark> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.UserId).IsRequired();
            builder.Property(b => b.TweetId).IsRequired();

            // A user can bookmark a tweet only once
            builder.HasIndex(b => new { b.UserId, b.TweetId }).IsUnique();
            builder.HasIndex(b => b.TweetId);

            builder.HasOne<User>()
                   .WithMany()
                   .HasForeignKey(b => b.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<Tweet>()
                   .WithMany()
                   .HasForeignKey(b => b.TweetId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
