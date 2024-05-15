using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SELP.Core;
using SELP.Core.Features.AuthenticationUser.Commands.Models;
using SELP.Core.Features.AuthenticationUser.Commands.Validators;
using SELP.Core.Middleware;
using SELP.Data.Entities.Identity;
using SELP.Infrastructur;
using SELP.Infrastructur.Abstract;
using SELP.Infrastructur.Data;
using SELP.Infrastructur.DataSeeder;
using SELP.Infrastructur.Repository;
using SELP.Service;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//connection to SQL Server

builder.Services.AddDbContext<ApplicationDBContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

//validators
//builder.Services.AddTransient<IValidator<AddUserCommand>, AddValidator>();

//extention method from repositories
builder.Services.AddInfrastructurDependencies()
    .AddServiceDependencies()
    .AddCoreDependencies()
    .AddServiceRegister(builder.Configuration);

#region Allow CORS
var cors = "_cors";
builder.Services.AddCors(option =>
{
    option.AddPolicy(name: cors,
        policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
       // policy.AllowCredentials(); //get error

    });
});
#endregion

builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
builder.Services.AddTransient<IUrlHelper>(x =>
{
    var actionContext = x.GetRequiredService<IActionContextAccessor>().ActionContext;
    var factory = x.GetRequiredService<IUrlHelperFactory>();
    return factory.GetUrlHelper(actionContext);
});

var app = builder.Build();


using (var scope = app.Services.CreateScope())// to deal with it as scoped not singleton
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    await RoleSeeder.SeedAsync(roleManager);
    await UserSeeder.SeedAsync(userManager);
}




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// use Middleware
app.UseMiddleware<ErrorHandlerMiddleware>();
//

app.UseHttpsRedirection();
app.UseCors(cors);
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
