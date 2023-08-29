using Microsoft.OpenApi.Models;
using store.DataLayer.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    //    (c =>
    //{
    //    c.RouteTemplate = "/swagger/{documentName}/swagger.json";
    //});
    app.UseSwaggerUI();
    //    (c =>
    //{
    //    c.SwaggerEndpoint("v1/swagger.json", "Store API"); //originally "./swagger/v1/swagger.json"
    //}); ;
}
app.UseAuthorization();

app.MapControllers();

app.Run();
