using API.Data.Repositories;
using API.Data.Interfaces;
using API.Data.Profiles;
using Microsoft.Extensions.Options;


var builder = WebApplication.CreateBuilder(args);

var CorsPolicy = "_corsPolicy";

// Add Service MongoDB
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));
builder.Services.AddSingleton<IMongoDbSettings>(serviceProvider =>
    serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);

// Add Service Repository
builder.Services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MapProfile));


builder.Services.AddCors(options => options.AddPolicy(CorsPolicy, builder => {
    builder.WithOrigins("")
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

// Cors
app.UseCors(CorsPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();
