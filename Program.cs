var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//ensure that the database is created
builder.Services.AddDbContext<SmartMirrorContext>();
using var scope = builder.Services.BuildServiceProvider().CreateScope();
var context = scope.ServiceProvider.GetRequiredService<SmartMirrorContext>();
context.Database.EnsureCreated();
builder.Services.AddSingleton<ArduinoService>();
builder.Services.AddHostedService<ArduinoService>(provider => provider.GetService<ArduinoService>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


