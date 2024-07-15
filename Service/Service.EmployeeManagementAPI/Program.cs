using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using Service.EmployeeManagementAPI.Helpers;
using Application.Interface;
using Application.Main;
using Domain.Core;
using Domain.Interface;
using Infrastructure.Data;
using Infrastructure.Interface;
using Infrastructure.Repository;
using Transversal.Common;
using Transversal.Logging;
using Transversal.Mapping;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var appSettings = new AppSettings();
builder.Configuration.GetSection("Configurations").Bind(appSettings);

// Configure services for the application container.

#region Services

// Bind the application settings from the configuration.
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("Configurations"));

// Add support for controllers in the application.
builder.Services.AddControllers();

// Enable API endpoint exploration for better documentation.
builder.Services.AddEndpointsApiExplorer();

// Register a singleton instance of the connection factory for database access.
// This improves performance by reusing the same instance across the application.
builder.Services.AddSingleton<IConnectionFactory, ConnectionFactory>();

// Register repository layer services for data access.
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Register domain layer services for business logic.
builder.Services.AddScoped<IEmployeeDomain, EmployeeDomain>();
builder.Services.AddScoped<IUserDomain, UserDomain>();

// Register application layer services for handling requests.
builder.Services.AddScoped<IEmployeeApplication, EmployeeApplication>();
builder.Services.AddScoped<IUserApplication, UserApplication>();

// Register the logging service.
builder.Services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

// Configure AutoMapper for mapping between DTOs and entities throughout the application.
builder.Services.AddAutoMapper(x => x.AddProfile(new MappingProfile()));

// Set up Swagger for API documentation.
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Pizzeria POS", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Enter your token here",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            Array.Empty<string>()
        }
    });
});

// Configure JWT authentication for securing API endpoints.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = appSettings.Issuer,
            ValidAudience = appSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(appSettings.Secret ?? string.Empty)
            ),
        };
    });

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Enable Swagger UI in development mode for API testing.
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // Redirect HTTP requests to HTTPS.

app.UseAuthorization(); // Enable authorization middleware.

app.MapControllers(); // Map controller routes to the application.

app.Run(); // Start the application.
