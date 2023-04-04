using Lab4.DAL;
using Lab4.BL;
using Microsoft.EntityFrameworkCore;
using Lab4.MVC;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

#region Services

#region Default
// Add services to the container.
builder.Services.AddControllersWithViews();
#endregion

#region Context
var connectionString = builder.Configuration.GetConnectionString("tickets");

builder.Services.AddDbContext<IssuesContext>(options
    => options.UseSqlServer(connectionString));

builder.Services.AddDbContext<UsersContext>(options
    => options.UseSqlServer(connectionString));

#endregion

#region Identity

builder.Services.AddIdentity<CustomUser, IdentityRole>(options =>
{
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = true;

    options.User.RequireUniqueEmail = true;
})
    .AddEntityFrameworkStores<UsersContext>();

#endregion

#region Repos
builder.Services.AddScoped<ITicketsRepo, TicketsRepo>();
builder.Services.AddScoped<IDevelopersRepo, DevelopersRepo>();
builder.Services.AddScoped<IDepartmentsRepo, DepartmentsRepo>();

#endregion

#region Managers
builder.Services.AddScoped<ITicketsManager, TicketsManager>();
builder.Services.AddScoped<IDepartmentsManager, DepartmentsManager>();
builder.Services.AddScoped<IDevelopersManager, DevelopersManager>();
#endregion


builder.Services.Configure<ImagesOptions>(
    builder.Configuration.GetSection("ImagesOptions"));

#region Authentication

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Users/Login";
    options.Cookie.Name = "AuthCookie";
});
#endregion

#endregion

var app = builder.Build();

#region Middelware
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
#endregion

