using BookLibraryREST.Repositories;
using BookLibraryREST.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddAuthorization();
builder.Services.AddSingleton<ILibraryRepository, InMemoryLibraryRepository>();
builder.Services.AddScoped<ILibraryService, LibraryService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseAuthorization();

app.MapGet("/", () => Results.Redirect("/api/books"));
app.MapControllers();

app.Run();
