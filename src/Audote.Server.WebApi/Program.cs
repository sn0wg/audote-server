using Audote.Server.Application.Animals.Queries;
using Audote.Server.Application.Extensions;
using Audote.Server.Infrastructure.Extensions;
using Audote.Server.WebApi.Endpoints;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructureConfig(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddStorage();
builder.Services.AddMediator();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

AnimalEndpoints.Map(app);
PictureEndpoints.Map(app);

app.Run();
