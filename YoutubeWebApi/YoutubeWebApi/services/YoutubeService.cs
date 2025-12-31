using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.Extensions.Caching.Memory;
using YoutubeWebApi.contracts;
using YoutubeWebApi.Dtos;
using YoutubeWebApi.mapping;

public class YoutubeService
{
    private readonly HttpClient _http;
    private readonly IConfiguration _config;
     private readonly IMemoryCache _cache;

    private static readonly string[] CourseTopics =
{
    "react tutorial",
    "react hooks tutorial",
    "react context tutorial",
    "typescript react tutorial",
    "javascript tutorial",
    "asp.net core tutorial",
    "c# tutorial",
    "web development course",
    "AI tutorial",
    "English course",
    "Communication tutorial"
};

    public YoutubeService(HttpClient http,IMemoryCache cache, IConfiguration config)
    {
        _http = http;
        _cache = cache;
        _config = config;
    }

    public List<string> PickRandomCourseTopics(int count = 2)
    {
        return CourseTopics
            .OrderBy(_ => Random.Shared.Next())
            .Take(count)
            .ToList();
    }



    public async Task<YoutubePlaylistResponse> GetPlaylistAsync(string playlistId)
    {
        var key = _config["Youtube:ApiKey"];

        var url = $"https://www.googleapis.com/youtube/v3/playlists" +
                  $"?part=snippet,contentDetails&id={playlistId}&key={key}";

        return await _http.GetFromJsonAsync<YoutubePlaylistResponse>(url);
    }
   public async Task<List<CourseDto>> SearchCoursesAsync(string query)
{
    var cacheKey = $"youtube:search:playlist:{query.Trim().ToLowerInvariant()}";

    if (_cache.TryGetValue(cacheKey, out List<CourseDto>? cached) && cached is not null)
        return cached;

    var apiKey = _config["Youtube:ApiKey"];
    var url =
        $"https://www.googleapis.com/youtube/v3/search" +
        $"?part=snippet&type=playlist&maxResults=5&q={Uri.EscapeDataString(query)}&key={apiKey}";

    // IMPORTANT: don't crash your API blindly
    var res = await _http.GetAsync(url);
    var body = await res.Content.ReadAsStringAsync();

    if (!res.IsSuccessStatusCode)
        throw new Exception($"YouTube failed ({(int)res.StatusCode}): {body}");

    var data = await res.Content.ReadFromJsonAsync<YoutubeSearchResponse>()
               ?? throw new Exception("YouTube returned empty response.");

    var mapped = CourseMapper.FromYoutubeSearch(data!);

    _cache.Set(cacheKey, mapped, TimeSpan.FromMinutes(60)); // ✅ cache longer for search
    return mapped;
}

private async Task<List<CourseDto>> ActuallyCallYoutubeAndBuildCourses(int topicsCount)
{
    var topics = new[]
    {
        "react tutorial",
        "c# web api",
        "asp.net core",
        "javascript tutorial",
        "frontend development",
        "backend development"
    };

    var results = new List<CourseDto>();

    foreach (var topic in topics.Take(topicsCount))
    {
        var courses = await SearchCoursesAsync(topic);
        results.AddRange(courses);
    }

    // optional: remove duplicates by playlist id
    return results
        .GroupBy(c => c.Id)
        .Select(g => g.First())
        .ToList();
}



    public async Task<List<CourseDto>> GetMixedCoursesAsync(int topicsCount = 2)
{
    // ✅ cache key should include parameters that change the result
    var cacheKey = $"courses:mixed:{topicsCount}";

    // 1) Return cached if exists
    if (_cache.TryGetValue(cacheKey, out List<CourseDto>? cached) && cached is not null)
        return cached;

    // 2) Otherwise call YouTube
    var courses = await ActuallyCallYoutubeAndBuildCourses(topicsCount);

    // 3) Store in cache with expiration
    _cache.Set(
        cacheKey,
        courses,
        new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30), // ✅ good default
            SlidingExpiration = TimeSpan.FromMinutes(10)               // optional
        });

    return courses;
}



    


}
