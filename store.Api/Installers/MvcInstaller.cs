namespace store.Api.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(WebApplicationBuilder builder, IConfiguration configuration)
        {
            builder.Services.AddSwaggerGen();//c =>
                                             //{
                                             //    c.SwaggerDoc("V1", new OpenApiInfo
                                             //    {
                                             //        Title = "Store API",
                                             //        Description = "An ASP.Net Api that enables you to work with retail stoere data",
                                             //        Contact = new OpenApiContact
                                             //        {
                                             //            Name = "Cornelious Tarwireyi",
                                             //            Email = "cornelioustarwireyi@gmail.com",
                                             //        },
                                             //        License = new OpenApiLicense
                                             //        {
                                             //            Name = "MIT License",
                                             //            Url = new Uri("https://opensource.org/license/mit/")
                                             //        },
                                             //        Version = "v1"
                                             //    });

            //    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            //});
        }
    }
}
