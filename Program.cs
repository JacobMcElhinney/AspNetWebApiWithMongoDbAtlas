using AspNetWebApiWithMongoDbAtlas.Models;
using AspNetWebApiWithMongoDbAtlas.Services;
using MongoDB.Driver;

// Create application builder (see developer notes at end of file)
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Register configuration instance to bind against section in appsettings.json
builder.Services.Configure<MongoDbOptions>(builder.Configuration.GetSection("MongoDB"));
builder.Services.AddSingleton<MongoDbService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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

/* Developer Notes:
Builder Design Pattern: enables us to use the same construction process to yet create different represenations of complex objects 
(by registering service interfaces and service implementations in our DI container to be resolved using reflection) */