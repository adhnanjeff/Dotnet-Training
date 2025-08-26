using Hostel.API.Extensions;
using Hostel.Core.Interfaces;
using Hostel.Application.Services;
using Hostel.Infrastructure.Repositories;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// 🔐 Authentication & JWT
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        var jwtConfig = builder.Configuration.GetSection("Jwt"); // must match appsettings.json
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtConfig["Issuer"],
            ValidAudience = jwtConfig["Audience"],
            IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(
                System.Text.Encoding.UTF8.GetBytes(jwtConfig["Key"]))
        };

        // Debugging JWT issues
        options.Events = new Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                Console.WriteLine("❌ Authentication failed: " + context.Exception.Message);
                return Task.CompletedTask;
            },
            OnTokenValidated = context =>
            {
                Console.WriteLine("✅ Token validated for " + context.Principal.Identity.Name);
                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddAuthorization(   // 🛡️ Authorization with roles Day 24
        options =>
        {
            options.AddPolicy("RequireAdmin", policy => policy.RequireRole("Admin"));
            options.AddPolicy("RequireStaff", policy => policy.RequireRole("Staff"));
        }
    );
// 🔑 Swagger with JWT support
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter your valid token."
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });

    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Hostel.API",
        Version = "v1",
        Description = "HostelManagement with JWT Authentication"
    }); // Day 24
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IStaffRepository, StaffRepository>();
builder.Services.AddSingleton<IStudentRepository, StudentRepository>();
builder.Services.AddSingleton<IRoomRepository, RoomRepository>();

builder.Services.AddScoped<IStaffService, StaffService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IRoomService, RoomService>();


var app = builder.Build();

app.UseGlobalExceptionMiddleware(); // ---------


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication(); // 🔐 Authentication middleware
app.UseAuthorization();

app.MapControllers();

app.Run();
