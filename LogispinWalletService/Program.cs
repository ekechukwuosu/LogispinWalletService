using AutoMapper;
using Hangfire;
using LogispinWalletService.BL;
using LogispinWalletService.BL.Mappings;
using LogispinWalletService.DAL.Repository.Implementation;
using LogispinWalletService.DAL.Repository.Interfaces;
using LogispinWalletService.Data.DB;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var appDBconnectionString = builder.Configuration.GetConnectionString("AppDB");
var hangfireDBconnectionString = builder.Configuration.GetConnectionString("HangfireDB");
builder.Services.AddDbContext<AppDBContext>(x => x.UseSqlServer(appDBconnectionString));
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(ProjectRegistry).Assembly));
builder.Services.AddHangfire(x => x.UseSqlServerStorage(hangfireDBconnectionString));
builder.Services.AddHangfireServer();

builder.Services.AddSingleton(provider => new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new GetWalletTransactionsProfile());
}).CreateMapper());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHangfireDashboard();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
