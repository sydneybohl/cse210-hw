using System;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("Beginner Python", "Jane Johnson", 1000);
        Video video2 = new Video("How to Start a Fire", "Abby Fields", 300);
        Video video3 = new Video("Guide to Doctor Who", "Jake Stone", 500);

        // Comments for Video One 
        video1.AddComment(new Comment("John", "Helpful video!"));
        video1.AddComment(new Comment("Alice", "I was able to finish my Python homework!"));
        video1.AddComment(new Comment("Spencer", "Still confused.."));

        // Comments for Video Two 
        video2.AddComment(new Comment("Clarke", "Have a camping trip coming up. Ready to test my skills."));
        video2.AddComment(new Comment("Finn", "What if you can't find dry wood?"));
        video2.AddComment(new Comment("Octavia", "Did it under a minute!"));

        // Comments for Video Three 
        video3.AddComment(new Comment("Rose", "Why is it a phone box?"));
        video3.AddComment(new Comment("Allison", "Can't wait to watch the new season!"));
        video3.AddComment(new Comment("Lisa", "That is not a screwdriver."));

        List<Video> videos = new List<Video> { video1, video2, video3 };

        foreach (var video in videos)
        {
            video.DisplayVideo();
        }

    }
}