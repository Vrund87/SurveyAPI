using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SurveyAPI.Models;
using SurveyAPI.Services;
using System.Security.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<SurveyDBSettings>(
    builder.Configuration.GetSection(nameof(SurveyDBSettings)));

builder.Services.AddSingleton<ISurveyDBSettings>(sp =>
    sp.GetRequiredService<IOptions<SurveyDBSettings>>().Value);

//builder.Services.AddSingleton<IMongoClient>(s =>
//    new MongoClient(builder.Configuration.GetValue<string>("SurveyDBSettings:ConnectionString")));

builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var connectionString = builder.Configuration.GetValue<string>("SurveyDBSettings:ConnectionString");
    var settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
    settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
    return new MongoClient(settings);
});

builder.Services.AddScoped<ISurveyService, SurveyService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
