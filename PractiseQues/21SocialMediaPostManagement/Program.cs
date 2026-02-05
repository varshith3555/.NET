namespace _21SocialMediaPostManagement
{
    class Program
    {
        static void Main()
        {
            SocialMediaManager manager = new SocialMediaManager();

            // Register users
            manager.RegisterUser("alice_wonder", "Adventurer and photographer");
            manager.RegisterUser("bob_builder", "Construction and DIY enthusiast");
            manager.RegisterUser("carol_coder", "Software developer and tech lover");
            manager.RegisterUser("dave_gamer", "Gaming and streaming enthusiast");

            // Create posts
            manager.CreatePost("USR1", "Just finished an amazing hiking trip!", "Image");
            manager.CreatePost("USR3", "Excited to announce my new C# tutorial series!", "Text");
            manager.CreatePost("USR2", "Successfully completed kitchen renovation", "Video");
            manager.CreatePost("USR4", "Live streaming my new game playthrough tonight!", "Text");
            manager.CreatePost("USR1", "Sunset photography session at the beach", "Image");

            // Like posts
            manager.LikePost("POST1", "USR2");
            manager.LikePost("POST1", "USR3");
            manager.LikePost("POST1", "USR4");
            manager.LikePost("POST2", "USR1");
            manager.LikePost("POST2", "USR4");
            manager.LikePost("POST3", "USR1");

            // Add comments
            manager.AddComment("POST1", "USR2", "Amazing views!");
            manager.AddComment("POST1", "USR3", "Looks incredible!");
            manager.AddComment("POST2", "USR1", "Great tutorial, can't wait!");
            manager.AddComment("POST3", "USR4", "Nice work on the renovation!");
            manager.AddComment("POST5", "USR3", "Stunning composition!");

            // Group posts by user
            var postsByUser = manager.GroupPostsByUser();
            foreach (var group in postsByUser)
            {
                Console.WriteLine($"\nUserId: {group.Key}");
                foreach (var post in group.Value)
                {
                    Console.WriteLine($"  - {post.PostType}: {post.Content}");
                }
            }

            // Get trending posts (at least 2 likes)
            var trendingPosts = manager.GetTrendingPosts(2);
            foreach (var post in trendingPosts)
            {
                Console.WriteLine($"{post.PostId}: {post.Content} ({post.Likes} likes)");
            }
        }
    }
}
