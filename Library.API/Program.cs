using Library.API.Extensions;
using Libriary_BAL.Utilities.Exceptions;
using Libriary_DAL;
using Libriary_DAL.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

builder.Host.UseSerilog((ctx, lc) => lc.WriteTo.Console()
.WriteTo.File("debug_log.txt"));

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddIdentityDbContext(builder.Configuration);
services.AddIdentitySupport();
services.AddAuthenticationBearer(builder.Configuration);
services.AddMapper();
services.RegisterBALDependencies();
services.RegisterDALDependencies();
services.ConfigureSwagger();
services.AddAutoValidation();


var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.UseAuthorization();

app.Run();
