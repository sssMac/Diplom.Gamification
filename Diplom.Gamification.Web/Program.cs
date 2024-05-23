using Diplom.Gamification.Application;
using Diplom.Gamification.Persistence;
using Diplom.Gamification.Infrastructure;
using Diplom.Gamification.Web.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationLayer();
builder.Services.AddPersistenceLayer(builder.Configuration);
builder.Services.AddInfrastructureLayer();

builder.Services.AddControllersWithViews();

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.MigrateDatabase();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Education}/{action=Index}");

app.UseStatusCodePagesWithRedirects("/Education");

app.Run();
