using Microsoft.OpenApi.Models;
using store.DataLayer.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("V1", new OpenApiInfo
    {
        Title = "Store API",
        Description = "An ASP.Net Api that enables you to work with retail stoere data",
        Contact = new OpenApiContact
        {
            Name = "Cornelious Tarwireyi",
            Email = "cornelioustarwireyi@gmail.com",
        },
        License = new OpenApiLicense
        {
            Name = "MIT License",
            Url = new Uri("https://opensource.org/license/mit/")
        },
        Version = "v1"
    });
    var xmlFile = $"{Assembly.GetExecutingAssembly().FullName}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
}).AddSwaggerGen();

builder.Services.AddTransient<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthorization();

app.MapControllers();

app.Run();
