using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace YoutubeWebApi.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly YoutubeService _youtube;

    public CourseController(YoutubeService youtube)
    {
        _youtube = youtube;
    }

    // Hardcode your playlists for now
    private readonly List<string> playlistIds = new()
    {
        "PLBCF2DAC6FFB574DE",
        "YOUR_OTHER_PLAYLIST",
        "ANOTHER_PLAYLIST"
    };

    [HttpGet]
    public async Task<IActionResult> GetAllPlaylists()
    {
        var results = new List<object>();

        foreach (var id in playlistIds)
        {
            var playlist = await _youtube.GetPlaylistAsync(id);
            var item = playlist.Items.FirstOrDefault();

            if (item != null)
            {
                results.Add(new
                {
                    id = item.Id,
                    title = item.Snippet.Title,
                    thumbnail = item.Snippet.Thumbnails.Medium.Url,
                    description = item.Snippet.Description,
                    itemCount = item.ContentDetails.ItemCount
                });
            }
        }

        return Ok(results);
    }
    }
}
