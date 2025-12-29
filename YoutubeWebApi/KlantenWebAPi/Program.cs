using Microsoft.EntityFrameworkCore;
 
using KlantenWebAPi.context;
using KlantenWebAPi.repos;
using KlantenWebAPi.services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IKlantRepository, KlantRepository>();
builder.Services.AddScoped<IKlantService, KlantService>();

// Services
builder.Services.AddControllers();

builder.Services.AddDbContext<KlantDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sql => sql.EnableRetryOnFailure()
    )
);

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
