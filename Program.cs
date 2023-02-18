using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using smart_alert_api.Interfaces;
using smart_alert_api.Models.Database;
using smart_alert_api.Repositories;
using smart_alert_api.Services.Auth;
using smart_alert_api.Services.Events;
using smart_alert_api.Utilities;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("SmartAlertContextConnection") ?? throw new InvalidOperationException("Connection string 'SmartAlertContextConnection' not found.");

builder.Services.AddDbContext<SmartAlertContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddIdentity<EntityUser, IdentityRole>(options => {
    options.SignIn.RequireConfirmedAccount = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    })
    .AddDefaultUI()
    .AddEntityFrameworkStores<SmartAlertContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllers();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IEntityUserUtilities, EntityUserUtilities>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IDateUtilities, DateUtilities>();
builder.Services.AddScoped<IGeoLocation, GeoLocation>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
