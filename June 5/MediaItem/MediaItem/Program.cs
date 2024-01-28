using System;

public class MediaItem
{
    public string Title { get; set; }
    public string Id { get; set; }

    public MediaItem(string title, string id)
    {
        Title = title;
        Id = id;
    }

    public virtual void DisplayDetails()
    {
        Console.WriteLine($"Title: {Title}, Id: {Id}");
    }
}

public class Book : MediaItem
{
    public int NumberOfPages { get; set; }

    public Book(string title, string id, int numberOfPages)
        : base(title, id)
    {
        NumberOfPages = numberOfPages;
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Number of Pages: {NumberOfPages}");
    }
}

public class DVD : MediaItem
{
    public int DurationInMinutes { get; set; }

    public DVD(string title, string id, int durationInMinutes)
        : base(title, id)
    {
        DurationInMinutes = durationInMinutes;
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Duration: {DurationInMinutes} minutes");
    }
}

public class Program
{
    public static void Main()
    {
        var mediaItems = new MediaItem[]
        {
            new Book("The Great Gatsby", "B001", 180),
            new DVD("The Matrix", "D001", 136),
        };

        foreach (var mediaItem in mediaItems)
        {
            mediaItem.DisplayDetails();
        }
    }
}

