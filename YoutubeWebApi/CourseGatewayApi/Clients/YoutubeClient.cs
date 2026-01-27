using System;
using CourseGatewayApi.Contracts;
using CourseGatewayApi.Interfaces;

namespace CourseGatewayApi.Clients;

public class YoutubeClient : IYoutubeClient
{
    private readonly HttpClient _http;

    public YoutubeClient(HttpClient http)
    {
        _http = http;
    }

    public async Task<CourseResponseContract?> GetCourseAsync(string courseId)
    {
        return await _http.GetFromJsonAsync<CourseResponseContract>(
            $"api/courses/{courseId}");
    }

     public async Task<List<CourseResponseContract>> GetCoursesForUserAsync(string klantId)
    {
        var result = await _http.GetFromJsonAsync<List<CourseResponseContract>>(
            $"api/klanten/{klantId}/courses"
        );

        return result ?? new List<CourseResponseContract>();
    }


}
