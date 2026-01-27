
using CourseGatewayApi.Contracts;
using CourseGatewayApi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace CourseGatewayApi.Controllers
{
    // [Authorize]
    [Route("api/enrollments")]
    [ApiController]

    public class EnrollmentController(IEnrollmentService service) : ControllerBase
    {
        [HttpPost]
        //nog aanpassen
        //  [EnableRateLimiting("quote-creation-limiter")]
        // [Authorize(Policy = "QuoteWritePolicy")] 
        public async Task<IActionResult> Enroll(EnrollmentRequestContract request)
        {
            await service.EnrollAsync(request);
            return Created("", null);
        }
        
        [HttpGet("dashboard/{klantId}")]
        public async Task<IActionResult> GetDashboard(string klantId)
        {
            var result = await service.GetDashboardAsync(klantId);
            return Ok(result);
        }
    }


}
