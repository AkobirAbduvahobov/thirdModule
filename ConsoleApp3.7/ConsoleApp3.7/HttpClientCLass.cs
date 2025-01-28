using System.Text;
using System.Text.Json;

namespace test;

public class HttpClientClass
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public HttpClientClass()
    {
        _httpClient = new HttpClient();
        _baseUrl = "http://localhost:5044/api/music/";
    }

    public async Task<Music[]> GetAll()
    {
        Console.WriteLine("GetAll is started");
        try
        {
            var getUrl = $"{_baseUrl}getAllMusic";

            var response = await _httpClient.GetAsync(getUrl);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var result = JsonSerializer.Deserialize<Music[]>(responseContent, options);
            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return null;
        }
        finally
        {
            Console.WriteLine("GetAll is finished");
        }
    }

    public void Add()
    {
        var url = $"{_baseUrl}addMusic";
        var music = new Music()
        {
            Name = "Qaramasa qaramsin",
            AuthorName = "Shoxruxhon",
            MB = 4.9,
            Description = "Yaxshi",
            QuentityLikes = 15,
        };

        var json = JsonSerializer.Serialize(music);
        var content = new StringContent(json, Encoding.UTF8, mediaType:"application/json");


        var response = _httpClient.PostAsync(url, content).Result;
        response.EnsureSuccessStatusCode();

        var responseContent = response.Content.ReadAsStringAsync().Result;

        var finish = 0;
    }

    

    public void DeleteMusic()
    {
        var id = new Guid("b484779f-1c0a-4141-b76f-dd14aa9ed742");
        var url = $"{_baseUrl}deleteMusic/{id}";
        var response = _httpClient.DeleteAsync(url).Result;
        response.EnsureSuccessStatusCode();
        Console.WriteLine("Music deleted successfully.");
    }

    public void Update()
    {
        var url = $"{_baseUrl}updateMusic";
        
        var music = new Music()
        {
            Id = new Guid("16f4cf4e-edd9-486b-b737-fc18d3a4d2da"),
            Name = "salom",
            AuthorName = "salom",
            Description = "salom"
        };

        var json = JsonSerializer.Serialize(music); 
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = _httpClient.PutAsync(url,content).Result;
        response.EnsureSuccessStatusCode();

        var responseContent = response.Content.ReadAsStringAsync().Result;

        var finish = 0;
    }

    public void GetAllByAuthorName()
    {
        var name = "Eminem";
        var url = $"{_baseUrl}getAllMusicByAuthorName/{name}";
        var response = _httpClient.GetAsync(url).Result;
        response.EnsureSuccessStatusCode();
        var responseContent = response.Content.ReadAsStringAsync().Result;

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var music = JsonSerializer.Deserialize<Music[]>(responseContent, options);

        var finish = 0;
    }



    public void AddMusic()
    {
        var url = $"{_baseUrl}addMusic";
        var music = new Music()
        {
            Name = "Qaramasa qaramsin",
            AuthorName = "Shoxruxhon",
            MB = 4.9,
            Description = "Yaxshi",
            QuentityLikes = 15,

        };

        var json = JsonSerializer.Serialize(music);
        var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

        var response = _httpClient.PostAsync(url,stringContent).Result;
        response.EnsureSuccessStatusCode();

        var res = response.Content.ReadAsStringAsync().Result;
        var finish = 0;

    }



}



