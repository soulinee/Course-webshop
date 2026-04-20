using CourseGatewayApi.Interfaces;
using CourseGatewayApi.Options;
using CourseGatewayApi.Repositories;
using CourseGatewayApi.Services;
using CourseGatewayApi.Clients;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Stripe;
var builder = WebApplication.CreateBuilder(args);
 
StripeConfiguration.ApiKey =
    builder.Configuration["Stripe:SecretKey"];

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
 

// voeg Duende.IdentityModel toe 
// Controllers
builder.Services.AddControllers();
 

// 🔐 AUTHENTICATION (HIER)
// builder.Services
//     .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//     .AddJwtBearer(options =>
//     {
//         options.Authority = "https://localhost:5001"; // IdentityServer
//         options.RequireHttpsMetadata = true;

//         options.TokenValidationParameters = new()
//         {
//             ValidateAudience = false
//         };
//     });

// 🔐 AUTHORIZATION
// builder.Services.AddAuthorization();
 


// Options pattern
builder.Services.Configure<EnrollmentRepositoryOptions>(
    builder.Configuration.GetSection(
        nameof(EnrollmentRepositoryOptions))
);
// HTTP clients (DIT HOORT HIER)
builder.Services.AddHttpClient<IKlantenClient, KlantenClient>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5056/");
});

builder.Services.AddHttpClient<IYoutubeClient, YoutubeClient>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5263/");
});

// Dependency Injection
builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
builder.Services.AddScoped<IEnrollmentService, EnrollmentService>();
 

 builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


var app = builder.Build();
 
app.UseCors();

// Configure the HTTP request pipeline.

 // Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}


app.UseHttpsRedirection();
// app.UseAuthentication();
// app.UseAuthorization();

app.MapControllers();
 
 

app.Run();

