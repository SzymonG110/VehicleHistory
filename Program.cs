using Microsoft.EntityFrameworkCore;
using VehicleHistory.Data;
using VehicleHistory.Features.Vehicles;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddAutoMapper(cfg => 
{
    cfg.CreateMap<VehicleDto, Vehicle>();
});

builder.Services.AddDbContext<VehicleHistoryDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DatabaseConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();