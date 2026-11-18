using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Persistence.Configurations
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(n => n.Id);

            builder.Property(n => n.UserId).IsRequired();
            builder.Property(n => n.Type).IsRequired();
            builder.Property(n => n.IsRead).IsRequired();

            // Message is protected, so EF can't see it by convention: map it through its backing field
            builder.Property<string>("_message")
                   .HasColumnName("Message");

            builder.HasIndex(n => n.UserId);

            builder.HasOne<User>()
                   .WithMany()
                   .HasForeignKey(n => n.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasDiscriminator<string>("NotificationKind")
                   .HasValue<LikeNotification>("Like")
                   .HasValue<CommentNotification>("Comment")
                   .HasValue<FriendRequestNotification>("FriendRequest")
                   .HasValue<MentionNotification>("Mention")
                   .HasValue<SystemNotification>("System");
        }
    }
}
