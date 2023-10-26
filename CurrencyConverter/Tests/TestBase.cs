using Microsoft.Extensions.DependencyInjection;

namespace CurrencyConverter.Tests;

public class TestBase : IntegrationTestBase<Program>
{
    protected override IServiceCollection ClientServices(IServiceCollection services) 
        => base.ClientServices(services)
        .AddSingleton<Api>()
        .AddSingleton<Currency>();

    protected Api Api
        => Client<Api>();
}