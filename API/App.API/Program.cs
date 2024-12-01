using App.API.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.ConfigureServices();

var app = builder.Build();

await app.InitializeDatabaseAsync();

app.ConfigureMiddleware();

app.Run();
