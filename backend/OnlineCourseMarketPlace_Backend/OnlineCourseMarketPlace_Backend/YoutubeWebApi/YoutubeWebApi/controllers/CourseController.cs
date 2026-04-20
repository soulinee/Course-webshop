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
       
    public async Task<IActionResult> GetCourses()
    {
        var courses = await _youtube.GetMixedCoursesAsync(5);
        return Ok(courses);
    }

        [HttpGet("{id}")]
    public async Task<IActionResult> GetCourseById(string id)
    {
        var course = await _youtube.GetCourseByIdAsync(id);

        if (course == null)
            return NotFound();

        return Ok(course);
    }

     






    }
}
