using Clean.Api.Extensions;
using Clean.Application.Adapter.Extensions;
using Company.Framework.Api.Extensions;
using Company.Framework.Logging.Extensions;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services
    .AddApiComponents()
    .AddApplicationComponents(configuration)
    .AddBusComponents();

builder.Host.WithSerilog();

var app = builder.Build();
app.UseApi();
app.Run();