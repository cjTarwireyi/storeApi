using Microsoft.OpenApi.Models;
using store.DataLayer.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Store API",
        Description = "An ASP.NET Core Web API for an online store",
        TermsOfService = new Uri("https://github.com/cjTarwireyi/storeApi"),
        Contact = new OpenApiContact
        {
            Name = "Contact",
            Url = new Uri("https://github.com/cjTarwireyi/storeApi")
        },
        License = new OpenApiLicense
        {
            Name = "License",
            Url = new Uri("https://github.com/cjTarwireyi/storeApi")
        }
    });
    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
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
