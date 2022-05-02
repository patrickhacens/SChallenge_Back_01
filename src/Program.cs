using Nudes.Retornator.AspnetCore;
using Microsoft.EntityFrameworkCore;
using SChallenge.Domain;
using MediatR;
using System.Reflection;
using SChallenge.PipelineBehavior;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddRetornator();

builder.Services.AddErrorTranslator(ErrorHttpTranslatorBuilder.Default);

builder.Services.AddDbContext<EventManagerContext>((sp, options) => options.UseSqlServer(sp.GetRequiredService<IConfiguration>().GetConnectionString("Default")));

builder.Services.AddMediatR(Assembly.GetEntryAssembly());

builder.Services.AddHttpContextAccessor();

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

builder.Services.AddValidatorsFromAssembly(Assembly.GetEntryAssembly());





var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
