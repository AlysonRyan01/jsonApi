using jsonDesafio.Handlers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<UserHandler>();
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.Limits.MaxRequestBodySize = 104857600; // 100 MB
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/add-json-file", async (IFormFile file, UserHandler handler) =>
{
    var result = await handler.UsersJsonToClass(file);
    return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
}).DisableAntiforgery();

app.MapGet("/get-all-users", async (UserHandler handler) =>
{
    var result = await handler.GetAllUsers();
    return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
});

app.Run();