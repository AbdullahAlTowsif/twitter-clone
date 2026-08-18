using TwitterClone.Domain.Entities;

namespace TwitterClone.Test
{
    public class AbstractionTest
    {
        public void Run()
        {
            // Upcasting: kono ekta child class k tar parent class e assign korar j ability setai upcasting.
            //Notification likeNotification = new LikeNotification(Guid.NewGuid());

            // eta sudu immediate parent class na even grand parent class er moddhe o assign kora jabe.
            //BaseEntity likeNotification = new LikeNotification(Guid.NewGuid());

            var notifications = new List<Notification>()
            {
                new LikeNotification(Guid.NewGuid()),
                new CommentNotification(Guid.NewGuid()),
                new FriendRequestNotification(Guid.NewGuid()),
                new MentionNotification(Guid.NewGuid()),
                new SystemNotification()
            };

            foreach (var notification in notifications)
            {
                Console.WriteLine(notification.GetMessage());
            }

        }
    }
}

/*
 An abstract class can not be told fully abstract because there exists both abstract and non-abstract method.
But fully abstraction exists in interface.
 */