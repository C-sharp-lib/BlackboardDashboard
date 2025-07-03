using System.Text;
using backend.Areas.Course.Services;
using backend.Areas.Identity.Models;
using backend.Areas.Identity.Services;
using backend.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options => { options.UseSqlServer(connectionString); });


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddIdentityCore<User>(options =>
    {
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequiredLength = 6;
        options.User.RequireUniqueEmail = true;
        options.Password.RequiredUniqueChars = 0;
    })
    .AddRoles<Role>()
    .AddRoleManager<RoleManager<Role>>()
    .AddUserManager<UserManager<User>>()
    .AddSignInManager<SignInManager<User>>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

var jwtSettings = configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]!);

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.MetadataAddress = jwtSettings["MetadataAddress"]!;
        options.RequireHttpsMetadata = true;
        options.SaveToken = true;
        options.Authority = jwtSettings["Authority"];
        options.Audience = jwtSettings["Audience"];

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/Login";
    options.Cookie.Name = "crm_cookie";
    options.Cookie.HttpOnly = true;
    options.LogoutPath = "/Identity/Logout";
    options.SlidingExpiration = true;
    options.AccessDeniedPath = "/Identity/AccessDenied";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    options.Cookie.Expiration = TimeSpan.FromMinutes(30);
    options.Cookie.MaxAge = TimeSpan.FromMinutes(31);
    options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
});
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowCredentials();

        policy.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();

        // (Optional: restrict origins in production)
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();