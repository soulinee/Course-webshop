using CourseGatewayApi.Interfaces;
using CourseGatewayApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseGatewayApi.Controllers
{
    [ApiController]
    [Route("api/courses")]
    public class CoursesController : ControllerBase
    {
        

        [HttpGet("my")]
        public async Task<IActionResult> GetMyCourses()
        {
            

            throw new NotImplementedException();
        }
          

    }
}
