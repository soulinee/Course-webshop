using System;
using YoutubeWebApi.contracts;
using YoutubeWebApi.Dtos;

namespace YoutubeWebApi.mapping;

public class CourseMapper
{
    public static List<CourseDto> FromYoutubeSearch(YoutubeSearchResponse data)
{
    return data.Items
        .Select(i => new CourseDto
        {
            Id = i.Id.PlaylistId,
            Title = i.Snippet.Title,
            Description = i.Snippet.Description,
            Thumbnail = i.Snippet.Thumbnails.Medium.Url,
            ItemCount = 0
        })
        .ToList();
}


}
