using TwitterClone.Domain.Entities;

namespace TwitterClone.Test
{
    public class PolymorphismTest
    {
        public void Run()
        {
            // Compile time polymorphism: At compile time i know which constructor is going to work
            var tweet = new Tweet("This is my first tweet");

            tweet.AddContent("Method1 calling");

            ILikeable likeableTweet = new Tweet("This is another tweet");
            Console.WriteLine(likeableTweet.CanBeLiked());

            var maxTweetLength = Tweet.MaxContentLength;
            Console.WriteLine($"Maximum tweet length: {maxTweetLength}");
        }
    }
}

/*
 Polymorphism two types: Compile-time & Runtime
# Compile time polymorphism
    - always happens in one class/same class.
    - mainly two forms: Method & Constructor overloading.
    - Method Overloading: Same name different parameter e.g. AddContent in Tweet class.
    - Constructor Overloading: Same name different signature e.g. Tweet Constructor.
# Runtime polymorphism
    - takes decision on runtime based on actual object which method will be executed.
    - happens in parent-child class.
    - see the Notification (Upcasting) part.

** Interview Question: Does C# support multiple inheritance? If not, why? How can we achieve multiple inheritance?
# In c# we cannot implement Multiple Inheritance because of Diamond Problem.
    - suppose BaseEntity1 has a method ABC and same method exists in BaseEntity2.
    - Object gets confused which method will be executed. (Diamond Problem).
    - We can achieve this problem through interface.(Solution of Diamond Problem).

#  static members --> can be accessed without creating an instance of the class. (Can be accessed by class).

# Non-static members --> can be accessed only after creating an instance of the class. (Can be accessed by object).
 */
