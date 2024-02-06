using Project_Management_System.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging(); // Add logging services

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddScoped<LogActionFilter>();
builder.Services.AddScoped<CustomHeaderFilter>();

builder.Services.AddMvc(options =>
{
    options.Filters.AddService<LogActionFilter>();
    options.Filters.AddService<CustomHeaderFilter>();
});

var app = builder.Build();

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
    name: "ProjectDetailsRoute",
    pattern: "Projects/ProjectDetails/{id}/{page}",
    defaults: new { controller = "Projects", action = "ProjectDetails" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
