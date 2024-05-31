public class Video
{
    private string _title;
    private string _author;
    private int _length;
    private List<Comment> _comments;

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public void DisplayVideo()
    {
        Console.WriteLine($"{_title} by {_author} ({_length} seconds)");
        Console.WriteLine($"Comments ({GetNumberOfComments()})");
        foreach (var comment in _comments)
        {
            Console.Write(" > ");
            comment.DisplayComment();
        }

        Console.WriteLine();
    }

    public int GetNumberOfComments()
    {
        return _comments.Count;
    }
}