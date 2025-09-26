using Dating.API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(); // Controllers get registered to dotnet as services
builder.Services.AddCors(); // To allow cross-origin requests (from client to API)

// Register the DbContext as a service with dependency injection
builder.Services.AddDbContext<AppDbContext>( opt => {
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

app.MapControllers();
app.UseCors(x =>
{
    x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200", "https://localhost:4200");
});

app.Run();
