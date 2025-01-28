namespace _3._6dars;

public class Music
{
    //[JsonPropertyName("id")]
    public Guid? Id { get; set; }

    //[JsonPropertyName("name")]
    public string Name { get; set; }

    //[JsonPropertyName("mb")]
    public double MB { get; set; }

    //[JsonPropertyName("authorName")]
    public string AuthorName { get; set; }

    //[JsonPropertyName("description")]
    public string Description { get; set; }

    //[JsonPropertyName("quentityLikes")]
    public int QuentityLikes { get; set; }
}
