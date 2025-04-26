using MucisCRUD.Service.Service;
using MusicCRUD.DataAccess;
using MusicCRUD.Repository.Services;
using MusicCRUD.Server.Configurations;
using MusicCRUD.Server.Filters;
using MusicCRUD.Server.Middlewares;
using Serilog;

namespace MusicCRUD.Server;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.


        builder.ConfigureSerilog();

        builder.Services.AddControllers(options =>
        {
            options.Filters.Add<GlobalExceptionFilter>();
            options.Filters.AddService<MusicCountHeaderFilter>();
            options.Filters.AddService<UserAgentFilter>();
        });
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();



        builder.ConfigureDatabase();

        builder.Services.AddScoped<IMusicService, MusicService>();
        builder.Services.AddScoped<MusicCountHeaderFilter>();
        builder.Services.AddScoped<UserAgentFilter>();
        builder.Services.AddScoped<LogActionFilter>();



        //builder.Services.AddScoped<IMusicRepository, MusicRepository>();
        //builder.Services.AddSingleton<MainContext>();
        //builder.Services.AddScoped<IMusicRepository, MusicRepositoryFile>();
        builder.Services.AddScoped<IMusicRepository, MusicRepositoryAdoNet>();

        var app = builder.Build();

        //app.UseMiddleware<TestMiddleware>();
        //app.UseMiddleware<ApiKeyMiddleware>(); 
        //app.UseMiddleware<GeoBlockMiddleware>(); 
        //app.UseMiddleware<MaintenanceMiddleware>(); 
        //app.UseMiddleware<NightBlockMiddleware>();
        //app.UseMiddleware<GlobalExceptionMiddleware>(); // should be FIRST in the pipeline
        //app.UseMiddleware<RequestLoggingMiddleware>();  // early in pipeline but after exception handling
        //app.UseMiddleware<RequestDurationMiddleware>();


        //app.Use(async (context, next) =>
        //{
        //    Console.WriteLine("Request received in inline middleware");
        //    await next(); // continue pipeline
        //});



        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
