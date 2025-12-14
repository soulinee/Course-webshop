using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace YoutubeWebApi.controllers
{
    [Route("api/courses")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly YoutubeService _youtube;

    public CourseController(YoutubeService youtube)
    {
        _youtube = youtube;
    }
      [HttpGet]
        public async Task<IActionResult> GetCourses([FromQuery] string topic = "react tutorial")
        {
            var courses = await _youtube.SearchCoursesAsync(topic);
            return Ok(courses);
        }



    }
}
