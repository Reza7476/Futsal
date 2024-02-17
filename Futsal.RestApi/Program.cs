using Futsal.Persistence.EF;
using Futsal.Persistence.EF.Players;
using Futsal.Persistence.EF.Teams;
using Futsal.Services.Players;
using Futsal.Services.Players.Contracts;
using Futsal.Services.Teams;
using Futsal.Services.Teams.Contracts;
using Taav.Contarcts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<EFDatabaseContext>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<UnitOfWork,EFUnitOfWork>();

builder.Services.AddScoped<TeamRepository, EFTeamRepository>();
builder.Services.AddScoped<TeamServices, TeamAppServices>();

builder.Services.AddScoped<PlayerServices, PlayerAppService>();
builder.Services.AddScoped<PlayerRepository, EFPlayerRepository>();



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
