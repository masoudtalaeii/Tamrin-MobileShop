using BLL;
using DAL;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DB>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProjContext")));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ISilderService, SilderService>();
builder.Services.AddScoped<IProductGroupService,ProductGroupService>();
builder.Services.AddScoped<IArticleGroupService, ArticleGroupService>();
builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<IAboutsService, AboutsService>();
builder.Services.AddScoped<ISocialNetworkService, SocialNetworkService>();
builder.Services.AddScoped<IProducService, ProducService>();
builder.Services.AddScoped<IProductGalleryService, ProductGalleryService>();
builder.Services.AddScoped<IProductCommentService, ProductCommentService>();
builder.Services.AddScoped<IProductFeatureService, ProductFeatureService>();
builder.Services.AddScoped<IProductSpecificationService, ProductSpecificationService>();
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<IRulesService, RulesService>();


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{
    options.LoginPath = "/Login";
    options.LogoutPath = "/Logout";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(8600);
});
builder.Services.AddSession(Options =>
{
    Options.IdleTimeout = TimeSpan.FromMinutes(30);
    Options.Cookie.HttpOnly = true;
    Options.Cookie.IsEssential = true;
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS  is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
