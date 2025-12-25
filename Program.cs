var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

// Health
app.MapGet("/ping", () =>
{
    app.Logger.LogInformation("pong");
    return Results.Json(new { message = "pong" });
});

// Fibonacci
app.MapGet("/fib", (HttpRequest req) =>
{
    var x = req.Query["n"].ToString();
    if (!int.TryParse(x, out var n) || n < 0 || n > 90)
    {
        app.Logger.LogWarning("{value} is not 0 <= n <= 90", x);
        return Results.BadRequest(new { error = $"{x} is not 0 <= n <= 90" });
    }

    var array = new List<long> { 0L, 1L };
    for (int i = 2; i <= n; i++)
    {
        array.Add(array[i - 1] + array[i - 2]);
    }

    app.Logger.LogInformation($"Fibonacci number {n} is {array[n]}.");
    return Results.Json(new { fibonacci_index = n, fibonacci_number = array[n] });
});

app.Run();
