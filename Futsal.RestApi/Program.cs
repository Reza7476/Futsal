using Autofac;
using Autofac.Extensions.DependencyInjection;
using Futsal.Persistence.EF;
using Futsal.Persistence.EF.Players;
using Futsal.Persistence.EF.Teams;
using Futsal.RestApi.Services;
using Futsal.Services.Players;
using Futsal.Services.Players.Contracts;
using Futsal.Services.Teams;
using Futsal.Services.Teams.Contracts;
using Taav.Contarcts.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.AddAutofac();


//builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
//{

//    builder.RegisterType<EFUnitOfWork>().As<UnitOfWork>();
//    builder.RegisterAssemblyTypes(typeof(EFPlayerRepository).Assembly)
//    .AssignableTo<Repository>()
//    .AsImplementedInterfaces()
//    .InstancePerLifetimeScope();
//    builder.RegisterAssemblyTypes(typeof(PlayerAppService).Assembly)
//    .AssignableTo<Service>()
//    .AsImplementedInterfaces()s
//    .InstancePerLifetimeScope();

//});


//builder.Services.AddScoped<UnitOfWork, EFUnitOfWork>();

//builder.Services.AddScoped<TeamRepository, EFTeamRepository>();
//builder.Services.AddScoped<TeamServices, TeamAppServices>();

//builder.Services.AddScoped<PlayerServices, PlayerAppService>();
//builder.Services.AddScoped<PlayerRepository, EFPlayerRepository>();



// Add services to the container.
builder.Services.AddDbContext<EFDatabaseContext>();
builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
