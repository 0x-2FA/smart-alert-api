using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using smart_alert_api.Models.Database;
using smart_alert_api.Services.Auth;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("SmartAlertContextConnection") ?? throw new InvalidOperationException("Connection string 'SmartAlertContextConnection' not found.");

builder.Services.AddDbContext<SmartAlertContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddDefaultIdentity<EntityUser>(options => {
    options.SignIn.RequireConfirmedAccount = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 8;
    })
    .AddEntityFrameworkStores<SmartAlertContext>();

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllers();

app.Run();
