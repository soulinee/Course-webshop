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
            //wie de user is 
            //of uit de sessie halen 
            

            throw new NotImplementedException();
        }
          

    }
}
