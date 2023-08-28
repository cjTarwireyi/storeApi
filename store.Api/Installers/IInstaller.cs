namespace store.Api.Installers
{
    public interface IInstaller
    {
        void InstallServices(WebApplicationBuilder builder, IConfiguration configuration);
    }
}
