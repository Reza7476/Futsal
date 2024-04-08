using Autofac;
using Futsal.Persistence.EF.Players;
using Futsal.Persistence.EF;
using Futsal.Services.Players;
using Taav.Contarcts.Interfaces;

namespace Futsal.RestApi.Services;

public class AutofacBusinessModule:Module
{

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<EFUnitOfWork>().As<UnitOfWork>();
        builder.RegisterAssemblyTypes(typeof(EFPlayerRepository).Assembly)
        .AssignableTo<Repository>()
        .AsImplementedInterfaces()
        .InstancePerLifetimeScope();
        builder.RegisterAssemblyTypes(typeof(PlayerAppService).Assembly)
        .AssignableTo<Service>()
        .AsImplementedInterfaces()
        .InstancePerLifetimeScope();

        base.Load(builder);
    }
}
