using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using VehicleHistory.Data;
using VehicleHistory.Features.Auth;
using VehicleHistory.Features.Users;
using VehicleHistory.Features.Vehicles;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)),
    };
});
builder.Services.AddAuthorization();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddAutoMapper(cfg => { cfg.CreateMap<VehicleDto, Vehicle>(); });

builder.Services.AddDbContext<VehicleHistoryDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DatabaseConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();