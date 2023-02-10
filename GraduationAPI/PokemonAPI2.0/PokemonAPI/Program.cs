using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PokemonWEB.Data;
using PokemonAPI;
using PokemonAPI.Middleware;
using PokemonAPI.Hubs;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSignalR();
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("ClientPermission", policy =>
    {
        policy.AllowAnyHeader()
            .AllowAnyMethod()
            .WithOrigins("http://localhost:3000")
            .AllowCredentials();
    });
});
builder.Services.AddTransient<Seed>();
builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
DIExtention.ConfigureServices(builder.Services);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(op =>
{
    op.SwaggerDoc("v1", new OpenApiInfo() {Title = "PokemonAPI", Version = "v1"});
    op.AddSecurityDefinition("bearer",
        new OpenApiSecurityScheme()
        {
            Type = SecuritySchemeType.Http,
            BearerFormat = "jwt",
            Scheme = "bearer"
        });
    op.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme()
            {
                Reference = new OpenApiReference() {Type = ReferenceType.SecurityScheme, Id = "bearer"},
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "jwt"
            },
            new List<string>()
        }
    });
});
builder.Services.AddDbContext<PokemonDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = AuthOptions.ISSUER,
            
            ValidateAudience = true,
            ValidAudience = AuthOptions.AUDIENCE,
            ValidateLifetime = false,
            
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true,
        };
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                var accessToken = context.Request.Query["access_token"];
 
                // если запрос направлен хабу
                var path = context.HttpContext.Request.Path;
                if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/chat"))
                {
                    // получаем токен из строки запроса
                    context.Token = accessToken;
                }
                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admins", policy => policy.RequireClaim("Roles", "Admin", "Moderator"));
    options.AddPolicy("Users", policy => policy.RequireClaim("Roles", "User"));
});

var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata")
{
    SeedData(app);
}


void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<Seed>();
        service.SeedDataContext();
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("ClientPermission");

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapHub<PokemonHub>("/pokemonHub");

Task.Run(() =>
{
    if (app.Configuration.GetValue("InitDatabase", false))
    {
        try
        {
            Console.WriteLine($"Initializing database {app.Configuration.GetConnectionString("DefaultConnection")}");
            using var scope = app.Services.CreateScope();
            using var context = scope.ServiceProvider.GetService<PokemonDbContext>();
            context?.Database.EnsureCreated();
            context?.Database.Migrate();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unable to initialize database {app.Configuration.GetConnectionString("DefaultConnection")}: {ex}");
        }
    }
});

app.Run();