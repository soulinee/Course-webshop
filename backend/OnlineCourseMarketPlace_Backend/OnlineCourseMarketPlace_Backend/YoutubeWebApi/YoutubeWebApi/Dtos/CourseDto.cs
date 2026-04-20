using System;

namespace YoutubeWebApi.Dtos;

public class CourseDto
{
     public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Thumbnail { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int? ItemCount { get; set; }

}
