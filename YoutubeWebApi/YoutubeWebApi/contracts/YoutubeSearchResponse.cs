using System;

namespace YoutubeWebApi.contracts;

public class YoutubeSearchResponse
{
    public List<SearchItem> Items { get; set; } = new();

}
public class SearchItem
    {
        public SearchId Id { get; set; } = null!;
        public SearchSnippet Snippet { get; set; } = null!;
    }

    public class SearchId
    {
        public string PlaylistId { get; set; } = null!;
    }

    public class SearchSnippet
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public ThumbnailSet Thumbnails { get; set; } = null!;
    }

    public class ThumbnailSet
    {
        public Thumbnail Medium { get; set; } = null!;
    }

    public class Thumbnail
    {
        public string Url { get; set; } = null!;
    }


