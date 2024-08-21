var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseStaticFiles();

app.MapGet("/hello1", () => "Hello World!");

app.Use(async (context, next) =>
{
    if (context.Request.Path == "/hello")
    {
        await context.Response.WriteAsync("Hello\n");
    }
    await next();
});

app.Use(async (context, next) =>
{
    if (context.Request.Path == "/end")
    {
        await context.Response.WriteAsync("This is Ending\n");
        
    }
    else
    {
        await next(); 
    }
});


app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Hello2\n");
    await next();
});


app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Hello3\n");
    await next();
});

app.Run(async (context) =>
{
    await context.Response.WriteAsync("Hello1\n");
});

app.Run(async (context) =>
{
    await context.Response.WriteAsync("This will never run.\n");
});

app.Run();








