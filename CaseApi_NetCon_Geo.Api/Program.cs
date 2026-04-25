using CaseApi_NetCon_Geo.Application.Interfaces;
using CaseApi_NetCon_Geo.Application.Services;
using CaseApi_NetCon_Geo.Application.Validators;
using CaseApi_NetCon_Geo.Infrastructure.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<FeasibilityRequestValidator>();

builder.Services.AddScoped<ILocationRepository, InMemoryLocationRepository>();
builder.Services.AddScoped<FeasibilityService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/health", () => Results.Ok("OK"));

app.Run();
