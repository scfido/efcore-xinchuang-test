namespace Blogs;

public class Post
{
    public int PostId { get; set; }
    public string Title { get; set; } = "untitled";
    public string Content { get; set; } = "";

    public int BlogId { get; set; }
    public Blog Blog { get; set; }
}