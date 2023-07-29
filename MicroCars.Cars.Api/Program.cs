using MicroCars.Cars.Application.Interfaces;
using MicroCars.Cars.Application.Services;
using MicroCars.Cars.Data.Context;
using MicroCars.Cars.Data.Repository;
using MicroCars.Cars.Domain.EventHandlers;
using MicroCars.Cars.Domain.Events;
using MicroCars.Cars.Domain.Interfaces;
using MicroCars.Domain.Core.Bus;
using MicroCars.Infra.Bus;
using MicroCars.Infra.IoC;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CarDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CarDbConnection"));
});
builder.Services.Configure<RabbitMQSettings>(builder.Configuration.GetSection("RabbitMQSettings"));

builder.Services.RegisterServices(builder.Configuration);

builder.Services.AddTransient<ICarService, CarService>();
builder.Services.AddTransient<ICarRepository, CarRepository>();
builder.Services.AddTransient<CarDbContext>();
builder.Services.AddTransient<IEventHandler<RegisterCarCreatedEvent>, CarEventHandler>();
//subscriptions
builder.Services.AddTransient<CarEventHandler>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
var app = builder.Build();
var eventBus = app.Services.GetRequiredService<IEventBus>();
eventBus.Subscribe<RegisterCarCreatedEvent, CarEventHandler>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
