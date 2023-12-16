using Issue_tracker_webapp.Data;
using Issue_tracker_webapp.Permission;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
builder.Services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//SEED DATA
using var scope = app.Services.CreateScope();
var servicesdatacontext = scope.ServiceProvider;
var loggerFactory = servicesdatacontext.GetRequiredService<ILoggerFactory>();
var logger = loggerFactory.CreateLogger("app");
try
{
    var userManager = servicesdatacontext.GetRequiredService<UserManager<IdentityUser>>();
    var roleManager = servicesdatacontext.GetRequiredService<RoleManager<IdentityRole>>();
    await Issue_tracker_webapp.Seeds.DefaultRoles.SeedAsync(userManager, roleManager);
    await Issue_tracker_webapp.Seeds.DefaultUsers.SeedSuperAdminAsync(userManager, roleManager);
    await Issue_tracker_webapp.Seeds.DefaultUsers.SeedBasicUserAsync(userManager, roleManager);
    logger.LogInformation("Finished Seeding Default Data");
    logger.LogInformation("Application Starting");
}
catch (Exception ex)
{
    Console.WriteLine(ex);
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
