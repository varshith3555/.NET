namespace _21SocialMediaPostManagement
{
    public class SocialMediaManager
    {
        private List<User> users;
        private List<Post> posts;
        private int userIdCounter;
        private int postIdCounter;

        public SocialMediaManager()
        {
            users = new List<User>();
            posts = new List<Post>();
            userIdCounter = 1;
            postIdCounter = 1;
        }

        public void RegisterUser(string userName, string bio)
        {
            if (users.Any(u => u.UserName == userName))
            {
                Console.WriteLine($"Username '{userName}' already exists!");
                return;
            }

            users.Add(new User
            {
                UserId = $"USR{userIdCounter++}",
                UserName = userName,
                Bio = bio,
                FollowersCount = 0
            });
            Console.WriteLine($"User '{userName}' registered successfully!");
        }

        public void CreatePost(string userId, string content, string type)
        {
            var user = users.FirstOrDefault(u => u.UserId == userId);
            if (user == null)
            {
                Console.WriteLine($"User {userId} not found!");
                return;
            }

            posts.Add(new Post
            {
                PostId = $"POST{postIdCounter++}",
                UserId = userId,
                Content = content,
                PostTime = DateTime.Now,
                PostType = type,
                Likes = 0
            });
            Console.WriteLine($"Post created by {user.UserName}!");
        }

        public void LikePost(string postId, string userId)
        {
            var post = posts.FirstOrDefault(p => p.PostId == postId);
            if (post == null)
            {
                Console.WriteLine($"Post {postId} not found!");
                return;
            }

            post.Likes++;
            Console.WriteLine($"Post {postId} liked! (Total likes: {post.Likes})");
        }

        public void AddComment(string postId, string userId, string comment)
        {
            var post = posts.FirstOrDefault(p => p.PostId == postId);
            if (post == null)
            {
                Console.WriteLine($"Post {postId} not found!");
                return;
            }

            var user = users.FirstOrDefault(u => u.UserId == userId);
            var commentText = user != null ? $"{user.UserName}: {comment}" : $"User{userId}: {comment}";
            post.Comments.Add(commentText);
            Console.WriteLine($"Comment added to {postId}!");
        }

        public Dictionary<string, List<Post>> GroupPostsByUser()
        {
            return posts.GroupBy(p => p.UserId)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        public List<Post> GetTrendingPosts(int minLikes)
        {
            return posts.Where(p => p.Likes >= minLikes)
                .OrderByDescending(p => p.Likes)
                .ToList();
        }
    }
}
