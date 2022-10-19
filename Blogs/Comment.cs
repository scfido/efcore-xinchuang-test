namespace Blogs;

public class Comment
{
    public int Id { get; set; }

    public int PostId { get; set; }

    public string Content { get; set; } = "";

    public bool IsDeleted { get; set; }
}