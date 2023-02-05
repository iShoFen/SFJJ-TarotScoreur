using System.Net;
using GrpcService.Services;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.Data;
using StubContext;
using Tarot2B2Model;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();

builder.WebHost.ConfigureKestrel(options =>
{
    if (string.Equals(Environment.GetEnvironmentVariable("MACOS"), "true"))
    {
        // Only for macOs
        // Setup a HTTP/2 endpoint without TLS.
        options.ListenLocalhost(5028, o => o.Protocols =
            HttpProtocols.Http2);
    }
    else if (builder.Environment.IsProduction())
    {
        options.Listen(IPAddress.Any, 80);
    }
});

builder.Services.AddDbContext<TarotDbContextStub>();
builder.Services.AddTransient<DbContext, TarotDbContextStub>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IReader, DbReader>();
builder.Services.AddTransient<IWriter, DbWriter>();
builder.Services.AddTransient<Manager>();

var app = builder.Build();

app.MapGrpcService<UserService>();
app.MapGrpcService<GroupService>();
app.MapGrpcService<GameService>();
app.MapGrpcService<HandService>();

app.MapGet("/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();