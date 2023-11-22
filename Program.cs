using TicketFinder.Extensions;

var builder = WebApplication.CreateBuilder(args);

#region WebApplication Builder

var configuration = builder.Configuration;

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddOBiletHttpClient(configuration);

builder.Services.AddControllersWithViews();

builder.Services.AddHttpContextAccessor();

builder.Services.RegisterApplicationServices();

#endregion

var app = builder.Build();

#region WebApplication

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseSession();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseClientIpMiddleware();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "CustomJourneyRoute",
        pattern: "seferler/{Origin}/{OriginId}/{Destination}/{DestinationId}/{DepartureDate}",
        defaults: new { controller = "Journey", action = "Index" }
    );

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

#endregion

app.Run();
