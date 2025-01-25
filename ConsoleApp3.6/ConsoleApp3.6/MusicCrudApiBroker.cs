using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json;

namespace ConsoleApp3._6;

public class MusicCrudApiBroker
{
    private HttpClient _httpClient;
    private string _baseUrl;
    public MusicCrudApiBroker()
    {
        _baseUrl = "http://localhost:5044/api/music";
        _httpClient = new HttpClient();
        //Add();
        GetAll();
        //GetById();
        //Delete();
        //Update();
    }


    public void Update()
    {
        var url = $"{_baseUrl}/updateMusic";
        var music = new Music()
        {
            Id = new Guid("97b02f78-c678-466a-a2f5-2a14fa66ac95"),
            Name = "Esindan chiqar",
            MB = 9,
            AuthorName = "Ummon",
            Description = "azoblash",
            QuentityLikes = 200
        };

        var json = JsonSerializer.Serialize(music);
        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");


        var response = _httpClient.PutAsync(url, content).Result;
        response.EnsureSuccessStatusCode();

        var responseContent = response.Content.ReadAsStringAsync().Result;
        Console.WriteLine(responseContent);
    }

    public void Delete()
    {
        Guid id = new Guid("0c78696f-15f4-4784-8b5f-8f0e03b4f287");

        var url = $"{_baseUrl}/deleteMusic/{id}";

        HttpResponseMessage response = _httpClient.DeleteAsync(url).Result;

        response.EnsureSuccessStatusCode();

        string responseContent = response.Content.ReadAsStringAsync().Result;

        var finish = 0;
    }

    public void GetById()
    {
        Guid id = new Guid("0c78696f-15f4-4784-8b5f-8f0e03b4f287");
        var url = $"{_baseUrl}/getMusicById/{id}";

        HttpResponseMessage response = _httpClient.GetAsync(url).Result;

        response.EnsureSuccessStatusCode();

        string responseContent = response.Content.ReadAsStringAsync().Result;

        JsonSerializerOptions options = new JsonSerializerOptions();
        options.PropertyNameCaseInsensitive = true;

        var music = JsonSerializer.Deserialize<Music>(responseContent, options);

        Console.WriteLine(music);
    }

    public void GetAll()
    {
        var url = $"{_baseUrl}/getAllMusic";

        HttpResponseMessage response = _httpClient.GetAsync(url).Result;
        string responseContent = response.Content.ReadAsStringAsync().Result;
       
        response.EnsureSuccessStatusCode();
        
        if(response.IsSuccessStatusCode == false)
        {
            throw new Exception("response qoniqarli emas");
        }

        JsonSerializerOptions options = new JsonSerializerOptions();
        options.PropertyNameCaseInsensitive = true;
        
         var music = JsonSerializer.Deserialize<Music[]>(responseContent, options);
        
        foreach(var m in music)
        {
            Console.WriteLine(m);
        }
    }

    public void Add()
    {
        var url = $"{_baseUrl}/addMusic";
        var music = new Music()
        {
            Name = "Bandaman",
            MB = 4.8,
            AuthorName = "Sherali Jo'rayev",
            Description = "Yaxshi",
            QuentityLikes = 45
        };

        var json = JsonSerializer.Serialize(music); 
        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");


        var response = _httpClient.PostAsync(url, content).Result;
        response.EnsureSuccessStatusCode();

        var responseContent = response.Content.ReadAsStringAsync().Result;
        Console.WriteLine(responseContent);

    }
}
