using API.IService;
using API.Service;
using Data.IRepositories;
using Data.Repositories;
using DATA.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<LapDbContext>(c => c.UseOracle(builder.Configuration.GetConnectionString("CS")));
builder.Services.AddScoped(typeof(IAllRepositories<>), typeof(AllRepositories<>));
builder.Services.AddScoped<IPcDetailService, PcDetailService>();
builder.Services.AddScoped<ILapTopDetailService, LapTopDetailService>();
builder.Services.AddScoped<IMonitorDetailService, MonitorDetailService>();
builder.Services.AddScoped<IOrderDetailService, OrderDetailService>();
builder.Services.AddScoped<IOrderDetailLaptopDetailService, OrderDetailLaptopDetailService>();
builder.Services.AddScoped<IOrderMonitorDetail, OrderMonitorDetailService>();
builder.Services.AddScoped<IDashboardService, DashboardService>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
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
