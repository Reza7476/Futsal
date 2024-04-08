using Autofac;

namespace Futsal.RestApi.Services;


public static class ConfigAutofac
{

    public static ConfigureHostBuilder AddAutofac(this ConfigureHostBuilder builder)
    {
        builder.ConfigureContainer<ContainerBuilder>(builder =>
        {
            builder.RegisterModule(new AutofacBusinessModule());

        });
        return builder;
    }
}