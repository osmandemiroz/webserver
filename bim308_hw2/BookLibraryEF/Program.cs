using Microsoft.EntityFrameworkCore;
using BookLibraryEF.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register DbContext - use SQLite in Docker (Production), SQL Server locally
var connectionString = builder.Configuration.GetConnectionString("LibraryConnection");

if (builder.Environment.IsProduction())
{
    // Docker/Production: use SQLite (no SQL Server LocalDB on Linux)
    builder.Services.AddDbContext<LibraryContext>(options =>
        options.UseSqlite("Data Source=/app/data/BookLibraryEF.db"));
}
else
{
    // Development: use SQL Server LocalDB
    builder.Services.AddDbContext<LibraryContext>(options =>
        options.UseSqlServer(connectionString));
}

var app = builder.Build();

// Apply migrations and create database if it doesn't exist
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<LibraryContext>();
    if (app.Environment.IsProduction())
    {
        // SQLite: create database and tables from model (no migrations needed)
        dbContext.Database.EnsureCreated();
    }
    else
    {
        // SQL Server: apply migrations
        dbContext.Database.Migrate();
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
