using System.Net;
using System.Runtime.InteropServices;
using GrpcService.Services;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.Data;
using NLog;
using NLog.Web;
using StubContext;
using Tarot2B2Model;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddGrpc();

    builder.Services.AddDbContext<TarotDbContextStub>();
    builder.Services.AddTransient<DbContext, TarotDbContextStub>();
    builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
    builder.Services.AddTransient<IReader, DbReader>();
    builder.Services.AddTransient<IWriter, DbWriter>();
    builder.Services.AddTransient<Manager>();

    // Setup NLog
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    builder.WebHost.ConfigureKestrel(options =>
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            // Setup a HTTP/2 endpoint without TLS.
            options.ListenLocalhost(5028, o => o.Protocols = HttpProtocols.Http2);
        }
        else if (builder.Environment.IsProduction())
        {
            options.Listen(IPAddress.Any, 80);
        }
    });

    var app = builder.Build();

    // Setup Grpc Services
    app.MapGrpcService<UserServiceV1>();
    app.MapGrpcService<GroupServiceV1>();
    app.MapGrpcService<GameServiceV1>();
    app.MapGrpcService<HandServiceV1>();

    app.MapGet("/",
        () =>
            "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

    app.Run();
}
catch (Exception ex)
{
    logger.Error(ex, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    LogManager.Shutdown();
}