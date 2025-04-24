using Microsoft.AspNetCore.Mvc.Filters;
using MucisCRUD.Service.Service;

namespace MusicCRUD.Server.Filters;

public class MusicCountHeaderFilter : IResultFilter
{
    private readonly IMusicService _musicService;

    public MusicCountHeaderFilter(IMusicService musicService)
    {
        _musicService = musicService;
    }

    public void OnResultExecuted(ResultExecutedContext context)
    {
      
    }

    public void OnResultExecuting(ResultExecutingContext context)
    {
        var count = _musicService.GetAllMusicAsync().Result.Count();
        context.HttpContext.Response.Headers.Add("X-Music-Count", count.ToString());
    }
}

