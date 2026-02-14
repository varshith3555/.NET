using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicStreamingService
{
    public class MusicManager
    {
        private List<Song> songs = new List<Song>();
        private List<Playlist> playlists = new List<Playlist>();
        private int songIdCounter = 1;
        private int playlistIdCounter = 1;

        public void AddSong(string title, string artist, string genre, string album, TimeSpan duration)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Song title cannot be empty.");

            songs.Add(new Song
            {
                SongId = "SONG" + songIdCounter++,
                Title = title,
                Artist = artist,
                Genre = genre,
                Album = album,
                Duration = duration,
                PlayCount = 0
            });
        }

        public void CreatePlaylist(string userId, string playlistName)
        {
            if (string.IsNullOrWhiteSpace(playlistName))
                throw new ArgumentException("Playlist name cannot be empty.");

            playlists.Add(new Playlist
            {
                PlaylistId = "PL" + playlistIdCounter++,
                Name = playlistName,
                CreatedBy = userId
            });
        }

        public bool AddSongToPlaylist(string playlistId, string songId)
        {
            var playlist = playlists.FirstOrDefault(p => p.PlaylistId == playlistId);
            if (playlist == null)
                throw new Exception("Playlist not found.");

            var song = songs.FirstOrDefault(s => s.SongId == songId);
            if (song == null)
                throw new Exception("Song not found.");

            playlist.Songs.Add(song);
            return true;
        }

        public Dictionary<string, List<Song>> GroupSongsByGenre()
        {
            var grouped = new Dictionary<string, List<Song>>();
            foreach (var song in songs)
            {
                if (!grouped.ContainsKey(song.Genre))
                    grouped[song.Genre] = new List<Song>();
                grouped[song.Genre].Add(song);
            }
            return grouped;
        }

        public List<Song> GetTopPlayedSongs(int count)
        {
            return songs.OrderByDescending(s => s.PlayCount).Take(count).ToList();
        }
    }
}
