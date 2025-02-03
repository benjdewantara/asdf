var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

var app = builder.Build();

// app.UseHttpsRedirection();
app.MapGet("/", () => "Hello World! monkey");
app.MapControllers();
app.Run();
