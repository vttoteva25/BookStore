using BS.ApplicationServices.Implementations;
using BS.ApplicationServices.Interfaces;
using BS.Data.Contexts;
using BS.Data.Entities;
using BS.WebApiServices.Filters;
using BS.WebApiServices.Helpers;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Reflection;
using System.Text;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/log-.txt",
        rollingInterval: RollingInterval.Day)
    .CreateLogger();

try
{
    Log.Logger.Debug("Application is starting");

    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");
    builder.Services.AddDbContext<BookStoreDbContext>(options => options.UseSqlServer(connectionString));

    builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddScoped<IAuthorService, AuthorService>();
    builder.Services.AddScoped<IBookService, BookService>();
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddScoped<IOrderService, OrderService>();
    builder.Services.AddScoped<IRoleService, RoleService>();
    builder.Services.AddScoped<IBookOrderService, BookOrderService>();
    builder.Services.AddScoped<IUserRoleService, UserRoleService>();
    builder.Services.AddScoped<IJWTAuthenticationsManager, JWTAuthenticationsManager>();

    builder.Services.AddSwaggerGen(option =>
    {
        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        option.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

        option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter a valid token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "Bearer"
        });
        option.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                new string[]{}
            }
        });
    });

    
    builder.Services.AddSerilog();

    builder.Services.AddControllersWithViews(options =>
      options.Filters.Add<ApiExceptionFilterAttribute>())
          .AddFluentValidation(x => x.AutomaticValidationEnabled = false);

    builder.Services.AddAuthorization();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseMiddleware<JwtMiddleware>();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Error(ex, "Unhandled exception");
}
finally
{
    await Log.CloseAndFlushAsync();
}