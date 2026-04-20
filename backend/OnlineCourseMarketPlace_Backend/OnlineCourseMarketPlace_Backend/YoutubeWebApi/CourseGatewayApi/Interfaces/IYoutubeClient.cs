using System;
using CourseGatewayApi.Contracts;

namespace CourseGatewayApi.Interfaces;

public interface IYoutubeClient
{
     Task<CourseResponseContract?> GetCourseAsync(string courseId);
    Task<List<CourseResponseContract>> GetCoursesForUserAsync(string klantId);

}
