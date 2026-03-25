var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddMemoryCache();
builder.Services.AddHttpClient<YoutubeService>();
builder.Services.AddControllers();
 

builder.Services.AddCors(options =>
{
    options.AddPolicy("frontend", policy =>
        policy
            .WithOrigins(
                "http://localhost:5174"
            )
            .AllowAnyHeader()
            .AllowAnyMethod()
    );
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors("frontend");
app.UseHttpsRedirection();
app.MapControllers();

app.Run();