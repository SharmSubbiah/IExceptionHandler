using IExceptionHandler;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddExceptionHandler<BadExceptionHandler>();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

var app = builder.Build();
app.UseExceptionHandler((_ => { }));

app.MapGet("api/exception", () =>
{
 throw new Exception("Error Occured");
});

app.MapGet("api/badexception", () =>
{
    throw new BadHttpRequestException("Bad Request");
});


app.Run();

