using System;

namespace MusicStreamingService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Music Streaming Service");
            var musicManager = new MusicManager();

            // Add songs
            musicManager.AddSong("Bohemian Rhapsody", "Queen", "Rock", "A Night at the Opera", new TimeSpan(0, 5, 55));
            musicManager.AddSong("Imagine", "John Lennon", "Pop", "Imagine", new TimeSpan(0, 3, 3));
            musicManager.AddSong("Stairway to Heaven", "Led Zeppelin", "Rock", "Led Zeppelin IV", new TimeSpan(0, 8, 2));
            musicManager.AddSong("Blinding Lights", "The Weeknd", "Pop", "After Hours", new TimeSpan(0, 3, 20));
            musicManager.AddSong("Hotel California", "Eagles", "Rock", "Hotel California", new TimeSpan(0, 6, 30));
            musicManager.AddSong("Shape of You", "Ed Sheeran", "Pop", "Divide", new TimeSpan(0, 3, 53));
            musicManager.AddSong("Master of Puppets", "Metallica", "Metal", "Master of Puppets", new TimeSpan(0, 8, 35));
            musicManager.AddSong("Enter Sandman", "Metallica", "Metal", "Black Album", new TimeSpan(0, 5, 32));

            // Create playlists
            musicManager.CreatePlaylist("USER001", "My Favorite Rock");
            musicManager.CreatePlaylist("USER002", "Pop Hits");
            musicManager.CreatePlaylist("USER001", "Metal Classics");

            // Add songs to playlists
            musicManager.AddSongToPlaylist("PL1", "SONG1");
            musicManager.AddSongToPlaylist("PL1", "SONG3");
            musicManager.AddSongToPlaylist("PL1", "SONG5");
            musicManager.AddSongToPlaylist("PL2", "SONG2");
            musicManager.AddSongToPlaylist("PL2", "SONG4");
            musicManager.AddSongToPlaylist("PL2", "SONG6");
            musicManager.AddSongToPlaylist("PL3", "SONG7");
            musicManager.AddSongToPlaylist("PL3", "SONG8");

            // Display songs by genre
            Console.WriteLine("Songs by Genre:");
            var grouped = musicManager.GroupSongsByGenre();
            foreach (var genre in grouped)
            {
                Console.WriteLine($"\n{genre.Key}:");
                foreach (var song in genre.Value)
                {
                    Console.WriteLine($"  - {song.Title} by {song.Artist} ({song.Album}) - {song.Duration:mm\\:ss}");
                }
            }

            // Display top played songs
            Console.WriteLine("\nTop Played Songs:");
            var topSongs = musicManager.GetTopPlayedSongs(5);
            int rank = 1;
            foreach (var song in topSongs)
            {
                Console.WriteLine($"{rank}. {song.Title} by {song.Artist} - Plays: {song.PlayCount}");
                rank++;
            }
        }
    }
}
