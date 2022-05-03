using Nudes.Retornator.AspnetCore;
using Microsoft.EntityFrameworkCore;
using SChallenge.Domain;
using MediatR;
using System.Reflection;
using SChallenge.PipelineBehavior;
using FluentValidation;
using SChallenge.Services;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Mapster;
using System.Linq.Expressions;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.local.json", true, true);

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "SENAI Backend Challenge 01.01",
        Description = "Esta API foi construida com o objetivo de testar o autor nas suas habilidades de desenvolvimento de software em backend, " +
                    "para possivel aprovação em processo seletivo de contratação.",        
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});


builder.Services.AddControllers().AddRetornator();

builder.Services.AddErrorTranslator(ErrorHttpTranslatorBuilder.Default);

builder.Services.AddDbContext<EventManagerContext>((sp, options) => options.UseSqlServer(sp.GetRequiredService<IConfiguration>().GetConnectionString("Default")));

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddMediatR(Assembly.GetEntryAssembly());

builder.Services.AddHttpContextAccessor();

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

builder.Services.AddValidatorsFromAssembly(Assembly.GetEntryAssembly());

TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());

TypeAdapterConfig.GlobalSettings.Compiler = exp => exp.CompileWithDebugInfo();

builder.Services.AddSingleton<TokenService>();

var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("Authentication").GetValue<string>("JWTKey").ToString());
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
