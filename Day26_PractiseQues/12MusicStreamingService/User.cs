using System;
using System.Collections.Generic;

namespace MusicStreamingService
{
    public class User
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public List<string> FavoriteGenres { get; set; }
        public List<Playlist> UserPlaylists { get; set; }

        public User()
        {
            FavoriteGenres = new List<string>();
            UserPlaylists = new List<Playlist>();
        }
    }
}
