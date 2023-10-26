namespace CurrencyConverter;

public class Startup
{
    public void ConfigureServices(IServiceCollection services) => services
        .AddSingleton<Converter>()
        .AddControllers();

    public void Configure(IApplicationBuilder app, IWebHostEnvironment _) => app
        .UseRouting()
        .UseEndpoints(endpoints => endpoints.MapControllers());
}