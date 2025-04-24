using Microsoft.AspNetCore.Mvc;
using MucisCRUD.Service.DTOs;
using MucisCRUD.Service.Service;
using MusicCRUD.Server.Filters;

namespace MusicCRUD.Server.Controllers;

[Route("api/music")]
[ServiceFilter(typeof(LogActionFilter))]
[ApiController]
public class MusicController : ControllerBase
{
    private readonly IMusicService _musicService;
    private readonly ILogger<MusicController> _logger;

    public MusicController(IMusicService musicService, ILogger<MusicController> logger)
    {
        _musicService = musicService;
        _logger = logger;
    }

    [HttpPost("addMusic")]
    public async Task<long> PostMusic(MusicDto musicDto)
    {
        var id = await _musicService.AddMusicAsync(musicDto);
        return id;
    }

    [HttpGet("getAllMusic")]
    public async Task<List<MusicDto>> GetAllMusic()
    {
        
        _logger.LogInformation("Hello from MusicController at {Time}", DateTime.UtcNow);
        var music = await _musicService.GetAllMusicAsync();

        //var num = 0;
        //var res = 45 / num;

        return music;
    }

    [HttpDelete("deleteMusic")]
    public async Task DeleteMusic(long id)
    {
        await _musicService.DeleteMusicAsync(id);
    }

    [HttpPut("updateMusic")]
    public async Task PutMusic(MusicDto musicDto)
    {
        await _musicService.UpdateMusicAsync(musicDto);
    }

    [HttpGet("getAllMusicByAuthorName")]
    public async Task<List<MusicDto>> GetAllMusicByAuthorName(string name)
    {
        return await _musicService.GetAllMusicByAuthorNameAsync(name);
    }

    [HttpGet("getMostLikedMusic")]
    public async Task<MusicDto> GetMostLikedMusic()
    {
        return await _musicService.GetMostLikedMusicAsync();
    }

    [HttpGet("getMusicByName")]
    public async Task<MusicDto> GetMusicByName(string name)
    {
        return await _musicService.GetMusicByNameAsync(name);
    }

    [HttpGet("getAllMusicAboveSize")]
    public async Task<List<MusicDto>> GetAllMusicAboveSize(double minSizeMB)
    {
        return await _musicService.GetAllMusicAboveSizeAsync(minSizeMB);
    }

    [HttpGet("getAllMusicBelowSize")]
    public async Task<List<MusicDto>> GetAllMusicBelowSize(double maxSizeMB)
    {
        return await _musicService.GetAllMusicBelowSizeAsync(maxSizeMB);
    }

    [HttpGet("getTopMostLikedMusic")]
    public async Task<List<MusicDto>> GetTopMostLikedMusic(int count)
    {
        return await _musicService.GetTopMostLikedMusicAsync(count);
    }

    [HttpGet("getLowMostLikedMusic")]
    public async Task<List<MusicDto>> GetLowMostLikedMusic(int count)
    {
        return await _musicService.GetLowMostLikedMusicAsync(count);
    }

    [HttpGet("getMusicByDescriptionKeyword")]
    public async Task<List<MusicDto>> GetMusicByDescriptionKeyword(string keyword)
    {
        return await _musicService.GetMusicByDescriptionKeywordAsync(keyword);
    }

    [HttpGet("getMusicWithLikesInRange")]
    public async Task<List<MusicDto>> GetMusicWithLikesInRange(int minLikes, int maxLikes)
    {
        return await _musicService.GetMusicWithLikesInRangeAsync(minLikes, maxLikes);
    }

    [HttpGet("getAllUniqueAuthors")]
    public async Task<List<string>> GetAllUniqueAuthors()
    {
        return await _musicService.GetAllUniqueAuthorsAsync();
    }

    [HttpGet("getTotalMusicSizeByAuthor")]
    public async Task<double> GetTotalMusicSizeByAuthor(string authorName)
    {
        return await _musicService.GetTotalMusicSizeByAuthorAsync(authorName);
    }
}
