using GrpcService.Services;
using Microsoft.EntityFrameworkCore;
using Model.Data;
using StubContext;
using Tarot2B2Model;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Only for macOs
builder.WebHost.ConfigureKestrel(options =>
{
    // Setup a HTTP/2 endpoint without TLS.
    options.ListenLocalhost(7268, o => o.Protocols =
        Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http2);
});

// Add services to the container.
builder.Services.AddGrpc();

builder.Services.AddDbContext<TarotDbContextStub>();
builder.Services.AddTransient<DbContext, TarotDbContextStub>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IReader, DbReader>();
builder.Services.AddTransient<IWriter, DbWriter>();

var app = builder.Build();

app.MapGrpcService<UserService>();
app.MapGet("/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();