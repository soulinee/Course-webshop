using System.Net.Http;
using System.Net.Http.Json;
using YoutubeWebApi.contracts;
using YoutubeWebApi.Dtos;

public class YoutubeService
{
    private readonly HttpClient _http;
    private readonly IConfiguration _config;

    public YoutubeService(HttpClient http, IConfiguration config)
    {
        _http = http;
        _config = config;
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
    var key = _config["Youtube:ApiKey"];

    var url =
        "https://www.googleapis.com/youtube/v3/search" +
        "?part=snippet" +
        "&type=playlist" +
        $"&q={Uri.EscapeDataString(query)}" +
        "&maxResults=10" +
        $"&key={key}";

    var response = await _http.GetFromJsonAsync<YoutubeSearchResponse>(url);

    return response!.Items.Select(item => new CourseDto
    {
        Id = item.Id.PlaylistId,
        Title = item.Snippet.Title,
        Thumbnail = item.Snippet.Thumbnails.Medium.Url,
        Description = item.Snippet.Description
    }).ToList();
}


}
