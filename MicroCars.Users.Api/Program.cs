using MediatR;
using MicroCar.User.Data.Context;
using MicroCar.User.Data.Repository;
using MicroCars.Infra.Bus;
using MicroCars.Infra.IoC;
using MicroCars.User.Application.Interfaces;
using MicroCars.User.Application.Services;
using MicroCars.Users.Domain.CommandHandlers;
using MicroCars.Users.Domain.Commands;
using MicroCars.Users.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RentUsersDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("RentUsersDbConnection"));
});
//DependencyContainer.RegisterServices(builder.Services, builder.Configuration);
builder.Services.Configure<RabbitMQSettings>(builder.Configuration.GetSection("RabbitMQSettings"));
builder.Services.RegisterServices(builder.Configuration);
builder.Services.AddTransient<IUserServices, UserServices>();
builder.Services.AddTransient<IUserRentRepository, UserRentRepository>();
builder.Services.AddTransient<RentUsersDbContext>();
builder.Services.AddTransient<IRequestHandler<CreateRegisterCommand, bool>, RegisterCarCommandHandler>();
//builder.Services.AddHttpClient("CarsForRent", config =>
//{
//    config.BaseAddress = new Uri(builder.Configuration["Services:CarsForRent"]);
//});
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
