using Chirper;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServices();
// Add services to the container.
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

app.MapDefaultEndpoints();
await app.Configure();

app.Run();

