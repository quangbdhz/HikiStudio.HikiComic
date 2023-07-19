using CorePush.Apple;
using CorePush.Google;
using FluentValidation;
using FluentValidation.AspNetCore;
using HikiComic.Application.Accounts;
using HikiComic.Application.Artists;
using HikiComic.Application.Auth;
using HikiComic.Application.AuthorInComicDetails;
using HikiComic.Application.Authors;
using HikiComic.Application.CacheCleanup;
using HikiComic.Application.ChapterImageURLs;
using HikiComic.Application.Chapters;
using HikiComic.Application.ComicDetails;
using HikiComic.Application.Comics;
using HikiComic.Application.Comments;
using HikiComic.Application.Common;
using HikiComic.Application.ExchangeRate;
using HikiComic.Application.Firebases;
using HikiComic.Application.Genders;
using HikiComic.Application.GenreInComicDetails;
using HikiComic.Application.Genres;
using HikiComic.Application.Notifications;
using HikiComic.Application.Roles;
using HikiComic.Application.SendMails;
using HikiComic.Application.SendSMSs;
using HikiComic.Application.ServiceConfigs;
using HikiComic.Application.ServicePrices;
using HikiComic.Application.Statistics;
using HikiComic.Application.StatisticsReportForAdmins;
using HikiComic.Application.StatisticsReportForCreators;
using HikiComic.Application.UploadImageCloudinaries;
using HikiComic.Application.UserCoinDepositHistories;
using HikiComic.Application.UserCoinUsageHistories;
using HikiComic.Application.UserComicFollowings;
using HikiComic.Application.UserComicPurchases;
using HikiComic.Application.UserComicRatings;
using HikiComic.Application.UserComicReadingHistories;
using HikiComic.Application.UserContext;
using HikiComic.Application.UserDevices;
using HikiComic.Application.UserRoles;
using HikiComic.Application.UserRoleUpgradeExchanges;
using HikiComic.Application.UserRoleUpgradeRequests;
using HikiComic.Application.Users;
using HikiComic.Data.EF;
using HikiComic.Data.Entities;
using HikiComic.Utilities.Constants;
using HikiComic.Utilities.Settings;
using HikiComic.ViewModels.Notifications.FirebaseCloudMessaging;
using HikiComic.ViewModels.Users.UserRequestValidator;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString(SystemConstants.AppSettings.MainConnectionString);
builder.Services.AddDbContext<HikiComicDbContext>(x => x.UseSqlServer(connectionString ?? ""));

builder.Services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<HikiComicDbContext>()
                .AddDefaultTokenProviders();

builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);


//DI
builder.Services.AddHttpContextAccessor();
builder.Services.AddMemoryCache();
builder.Services.AddHttpClient();

builder.Services.AddSingleton<IHostedService, CacheCleanupService>();

builder.Services.AddScoped<ClaimsPrincipal>(provider => provider.GetService<IHttpContextAccessor>()?.HttpContext?.User!);

builder.Services.AddScoped<UserManager<AppUser>, UserManager<AppUser>>();
builder.Services.AddScoped<SignInManager<AppUser>, SignInManager<AppUser>>();
builder.Services.AddScoped<RoleManager<AppRole>, RoleManager<AppRole>>();

builder.Services.AddScoped<IExchangeRateService, ExchangeRateService>();

builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserDeviceService, UserDeviceService>();

builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IUploadImageCloudinaryService, UploadImageCloudinaryService>();

builder.Services.AddScoped<ISendMailService, SendMailService>();
builder.Services.AddScoped<ISendSMSService, SendSMSService>();

builder.Services.AddScoped<ICommonService, CommonService>();
builder.Services.AddScoped<IUserContextService, UserContextService>();

builder.Services.AddScoped<IGenderService, GenderService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IArtistService, ArtistService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IGenreInComicDetailService, GenreInComicDetailService>();
builder.Services.AddScoped<IAuthorInComicDetailService, AuthorInComicDetailService>();
builder.Services.AddScoped<IComicService, ComicService>();
builder.Services.AddScoped<IComicDetailService, ComicDetailService>();
builder.Services.AddScoped<IChapterService, ChapterService>();
builder.Services.AddScoped<IChapterImageURLService, ChapterImageURLService>();
builder.Services.AddScoped<IUserComicReadingHistoryService, UserComicReadingHistoryService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IStatisticsService, StatisticsService>();

builder.Services.AddScoped<IUserComicFollowingService, UserComicFollowingService>();
builder.Services.AddScoped<IUserComicFollowingService, UserComicFollowingService>();
builder.Services.AddScoped<IUserComicRatingService, UserComicRatingService>();

builder.Services.AddScoped<IUserCoinDepositHistoryService, UserCoinDepositHistoryService>();
builder.Services.AddScoped<IUserCoinUsageHistoryService, UserCoinUsageHistoryService>();
builder.Services.AddScoped<IUserComicPurchaseService, UserComicPurchaseSerivice>();

builder.Services.AddScoped<IServiceConfigService, ServiceConfigService>();
builder.Services.AddScoped<IServicePriceService, ServicePriceService>();

builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IUserRoleService, UserRoleService>();

builder.Services.AddScoped<IUserRoleUpgradeRequestService, UserRoleUpgradeRequestService>();
builder.Services.AddScoped<IUserRoleUpgradeExchangeService, UserRoleUpgradeExchangeService>();

//notifications
builder.Services.AddScoped<INotificationService, NotificationService>();

//set up settings for SMSSend
builder.Services.Configure<SMSSetting>(builder.Configuration.GetSection("SMSSettingTwilio"));

builder.Services.AddScoped<IFirebaseCloudMessagingService, FirebaseCloudMessagingService>();
builder.Services.Configure<FCMNotificationSetting>(builder.Configuration.GetSection("FCMNotification"));
builder.Services.AddHttpClient<FcmSender>();
builder.Services.AddHttpClient<ApnSender>();

//statistics
builder.Services.AddScoped<IStatisticsReportForCreatorService, StatisticsReportForCreatorService>();
builder.Services.AddScoped<IStatisticsReportForAdminService, StatisticsReportForAdminService>();


//IdentityOptions
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
});


//CROS
builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
        builder => builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader()
        );
});

builder.Services.AddControllers();

builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<RegisterRequestValidator>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        { new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer"},
                          Scheme = "oauth2", Name = "Bearer", In = ParameterLocation.Header, }, new List<string>()  }
    });
});

string issuer = builder.Configuration.GetSection("Tokens:Issuer").Value ?? "";
string signingKey = builder.Configuration.GetSection("Tokens:Key").Value ?? "";
byte[] signingKeyBytes = System.Text.Encoding.UTF8.GetBytes(signingKey);

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidIssuer = issuer,
        ValidateAudience = true,
        ValidAudience = issuer,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ClockSkew = System.TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(signingKeyBytes)
    };
})
.AddFacebook(options =>
{
    options.AppId = "YourFacebookAppId";
    options.AppSecret = "YourFacebookAppSecret";
})
.AddGoogle(options =>
{
    options.ClientId = builder.Configuration.GetSection("Authentication:Google:ClientId").Value ?? "";
    options.ClientSecret = builder.Configuration.GetSection("Authentication:Google:ClientSecret").Value ?? "";
});

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
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseRouting();


app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
