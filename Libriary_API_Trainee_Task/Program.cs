using Libriary_API.Extensions;
using Libriary_DAL;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

builder.Host.UseSerilog((ctx, lc) => lc.WriteTo.Console()
.WriteTo.File("debug_log.txt"));

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddIdentityDbContext();
services.AddMapper();
services.RegisterBALDependencies();
services.RegisterDALDependencies();
services.ConfigureSwagger();
services.AddControllers();
services.AddAuthentication();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();