using System.Net.Http;
using System.Net.Http.Json;

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
}
