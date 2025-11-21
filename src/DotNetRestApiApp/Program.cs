using Microsoft.EntityFrameworkCore;
using DotNetRestApiApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Enable CORS (any domain — same as your Spring Boot)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

// Add DB Context (SQLite)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=app.db"));

// Add Controllers
builder.Services.AddControllers();

var app = builder.Build();

// Apply CORS
app.UseCors("AllowAll");

// Auto-create the database + tables (no migrations required)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();    // ✔️ FIX: replaces migration need
}

app.MapControllers();

app.Run();
