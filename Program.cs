using Microsoft.AspNetCore.Mvc;
using StockBike;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/GetCurrentBikeStock", () =>
{
    var amountBike = new SettingsBike().GetBikesAmmount();
    return new { amountBike };
}).WithName("GetAll")
.WithOpenApi();

app.MapPost("/GetProjectionBikes", ([FromBody] SettingBikeDto model) =>
{
    var amountBike = new SettingsBike().GetBikesProjection(model);
    return new { amountBike };
}).WithName("GetProjectionBikes")
.WithOpenApi();

app.Run();
