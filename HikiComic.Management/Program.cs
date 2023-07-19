using FluentValidation;
using FluentValidation.AspNetCore;
using HikiComic.ApiIntegration.AccountsAPIClient;
using HikiComic.ApiIntegration.ArtistsAPIClient;
using HikiComic.ApiIntegration.AuthAPIClient;
using HikiComic.ApiIntegration.AuthorsAPIClient;
using HikiComic.ApiIntegration.ChapterImageURLsAPIClient;
using HikiComic.ApiIntegration.ChaptersAPIClient;
using HikiComic.ApiIntegration.ComicDetailsAPIClient;
using HikiComic.ApiIntegration.ComicsAPIClient;
using HikiComic.ApiIntegration.CommentsAPIClient;
using HikiComic.ApiIntegration.GendersAPIClient;
using HikiComic.ApiIntegration.GenresAPIClient;
using HikiComic.ApiIntegration.NotificationsAPIClient;
using HikiComic.ApiIntegration.RolesAPIClient;
using HikiComic.ApiIntegration.ServiceConfigsAPIClient;
using HikiComic.ApiIntegration.ServicePriceConfigsAPIClient;
using HikiComic.ApiIntegration.StatisticsAPIClient;
using HikiComic.ApiIntegration.StatisticsReportForAdminsAPIClient;
using HikiComic.ApiIntegration.StatisticsReportForCreatorsAPIClient;
using HikiComic.ApiIntegration.UserCoinDepositHistoriesAPIClient;
using HikiComic.ApiIntegration.UserCoinUsageHistoriesAPIClient;
using HikiComic.ApiIntegration.UserComicPurchasesAPIClient;
using HikiComic.ApiIntegration.UserRoleUpgradeExchangesAPIClient;
using HikiComic.ApiIntegration.UserRoleUpgradeRequestsAPIClient;
using HikiComic.ApiIntegration.UsersAPIClient;
using HikiComic.Management.Middleware;
using HikiComic.Management.Services;
using HikiComic.Utilities.Constants;
using HikiComic.ViewModels.Users.UserRequestValidator;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

builder.Services.AddHttpClient();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login";
        options.AccessDeniedPath = "/error/403/";
    });

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<RegisterRequestValidator>();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(120);
});

//DI
//builder.Services.AddHttpContextAccessor();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddScoped<IPolicyAuthorize, PolicyAuthorize>();

builder.Services.AddScoped<IAuthAPIClient, AuthAPIClient>();

builder.Services.AddScoped<IUserAPIClient, UserAPIClient>();
builder.Services.AddScoped<IAccountAPIClient, AccountAPIClient>();

builder.Services.AddScoped<IGenderAPIClient, GenderAPIClient>();

builder.Services.AddScoped<IComicAPIClient, ComicAPIClient>();
builder.Services.AddScoped<IComicDetailAPIClient, ComicDetailAPIClient>();
builder.Services.AddScoped<IChapterAPIClient, ChapterAPIClient>();
builder.Services.AddScoped<IChapterImageURLAPIClient, ChapterImageURLAPIClient>();
builder.Services.AddScoped<IGenreAPIClient, GenreAPIClient>();
builder.Services.AddScoped<IArtistAPIClient, ArtistAPIClient>();
builder.Services.AddScoped<IAuthorAPIClient, AuthorAPIClient>();
builder.Services.AddScoped<ICommentAPIClient, CommentAPIClient>();

builder.Services.AddScoped<IStatisticsAPIClient, StatisticsAPIClient>();

builder.Services.AddScoped<IUserCoinDepositHistoryAPIClient, UserCoinDepositHistoryAPIClient>();
builder.Services.AddScoped<IUserCoinUsageHistoryAPIClient, UserCoinUsageHistoryAPIClient>();
builder.Services.AddScoped<IUserComicPurchaseAPIClient, UserComicPurchaseAPIClient>();

builder.Services.AddScoped<IServiceConfigAPIClient, ServiceConfigAPIClient>();
builder.Services.AddScoped<IServicePriceConfigAPIClient, ServicePriceConfigAPIClient>();
builder.Services.AddScoped<INotificationAPIClient, NotificationAPIClient>();

builder.Services.AddScoped<IRoleAPIClient, RoleAPIClient>();

builder.Services.AddScoped<IUserRoleUpgradeRequestAPIClient, UserRoleUpgradeRequestAPIClient>();
builder.Services.AddScoped<IUserRoleUpgradeExchangeAPIClient, UserRoleUpgradeExchangeAPIClient>();

builder.Services.AddScoped<IStatisticsReportForCreatorAPIClient, StatisticsReportForCreatorAPIClient>();
builder.Services.AddScoped<IStatisticsReportForAdminAPIClient, StatisticsReportForAdminAPIClient>();

builder.Services.AddRazorPages();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(SystemConstants.AppSettings.AdminPolicy, policy =>
    {
        policy.RequireRole("admin");
    });

    options.AddPolicy(SystemConstants.AppSettings.TeamMembersPolicy, policy =>
    {
        policy.RequireRole("teamMembers");
    });

    options.AddPolicy(SystemConstants.AppSettings.CreatorPolicy, policy =>
    {
        policy.RequireRole("creator");
    });

    options.AddPolicy(SystemConstants.AppSettings.ReaderPolicy, policy =>
    {
        policy.RequireRole("reader");
    });

    options.AddPolicy(SystemConstants.AppSettings.AdminOrTeamMembersPolicy, policy =>
    {
        policy.RequireRole("admin", "teamMembers");
    });

    options.AddPolicy(SystemConstants.AppSettings.CRUDComicChapterPolicy, policy =>
    {
        policy.RequireRole("admin", "teamMembers", "creator");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseMiddleware<SetBearerTokenMiddleware>();


app.UseHttpsRedirection();


app.Use(async (context, next) =>
{
    await next();

    if (context.Response.StatusCode == 404)
    {
        context.Request.Path = "/error/404";
        await next();
    }

    if (context.Response.StatusCode == 403)
    {
        context.Request.Path = "/error/403";
        await next();
    }
});


app.UseStaticFiles();

app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "Uploads")
                ),
    RequestPath = "/ComicThumbnail"
});


app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();