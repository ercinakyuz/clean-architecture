using Clean.Application.Adapter.Extensions;
using Clean.PingAppliedKafkaConsumer.Extensions;
using Company.Framework.Correlation.Extensions;
using Company.Framework.Logging.Extensions;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
builder.Services
    .AddCorrelation()
    .AddApplicationComponents(configuration)
    .AddBusComponents();

builder.Host.WithSerilog();
var app = builder.Build();
app.Run();
