using System;
using System.Collections.Generic;

namespace YouTubeAbstraction
{
    // Video class
    public class Video
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }  // seconds
        public int Likes { get; private set; }
        public int Dislikes { get; private set; }

        public void Play() => Console.WriteLine($"Playing: {Title}");
        public void Pause() => Console.WriteLine($"Paused: {Title}");
        public void Like() => Likes++;
        public void Dislike() => Dislikes++;
    }

    // User class
    public class User
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public List<User> Subscriptions { get; set; } = new List<User>();
        public List<Playlist> Playlists { get; set; } = new List<Playlist>();

        public void Subscribe(User channel)
        {
            Subscriptions.Add(channel);
            Console.WriteLine($"{Username} subscribed to {channel.Username}");
        }

        public void CreatePlaylist(string name)
        {
            Playlists.Add(new Playlist { Name = name });
            Console.WriteLine($"{Username} created a playlist called {name}");
        }
    }

    // Playlist class
    public class Playlist
    {
        public string Name { get; set; }
        public List<Video> Videos { get; set; } = new List<Video>();

        public void AddVideo(Video video)
        {
            Videos.Add(video);
            Console.WriteLine($"{video.Title} added to playlist {Name}");
        }

        public void RemoveVideo(Video video)
        {
            Videos.Remove(video);
            Console.WriteLine($"{video.Title} removed from playlist {Name}");
        }

        public void PlayAll()
        {
            Console.WriteLine($"Playing all videos in playlist {Name}:");
            foreach (var video in Videos)
            {
                video.Play();
            }
        }
    }

    // YouTubePlatform class
    public class YouTubePlatform
    {
        public List<User> Users { get; set; } = new List<User>();
        public List<Video> Videos { get; set; } = new List<Video>();
        public List<Playlist> Playlists { get; set; } = new List<Playlist>();

        public void UploadVideo(User user, Video video)
        {
            Videos.Add(video);
            Console.WriteLine($"{user.Username} uploaded video: {video.Title}");
        }

        public void SearchVideo(string keyword)
        {
            Console.WriteLine($"Searching for videos with '{keyword}'...");
            foreach (var video in Videos)
            {
                if (video.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Found: {video.Title}");
                }
            }
        }
    }

    // MAIN PROGRAM
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("YouTube Abstraction Program Simulation\n");

            // Create platform
            YouTubePlatform platform = new YouTubePlatform();

            // Create users
            User user1 = new User { Username = "Prince", Email = "prince@email.com" };
            User user2 = new User { Username = "Kafui", Email = "kafui@email.com" };
            platform.Users.Add(user1);
            platform.Users.Add(user2);

            // User1 uploads video
            Video video1 = new Video { Title = "Learn Abstraction", Description = "Learn Abstraction", Duration = 600 };
            platform.UploadVideo(user1, video1);

            // User2 subscribes to User1
            user2.Subscribe(user1);

            // User2 creates a playlist
            user2.CreatePlaylist("Learning Abstraction");
            user2.Playlists[0].AddVideo(video1);

            // Play all videos in playlist
            user2.Playlists[0].PlayAll();

            // Search videos
            platform.SearchVideo("Abstraction");
        }
    }
}
