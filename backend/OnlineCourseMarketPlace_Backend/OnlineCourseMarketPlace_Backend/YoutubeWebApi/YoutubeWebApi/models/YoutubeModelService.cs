public class YoutubePlaylistResponse
{
    public List<PlaylistItem> Items { get; set; }
}

public class PlaylistItem
{
    public string Id { get; set; }
    public Snippet Snippet { get; set; }
    public ContentDetails ContentDetails { get; set; }
}

public class Snippet
{
    public string Title { get; set; }
    public string Description { get; set; }
    public ThumbnailGroup Thumbnails { get; set; }
}

public class ThumbnailGroup
{
    public Thumbnail Medium { get; set; }
}

public class Thumbnail
{
    public string Url { get; set; }
}

public class ContentDetails
{
    public int ItemCount { get; set; }
}
