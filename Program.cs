using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using WebApi.Authorization;
using WebApi.Helpers;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connection));
builder.Services.AddAuthorization();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
{
options.TokenValidationParameters = new TokenValidationParameters
{
// указывает, будет ли валидироваться издатель при валидации токена
ValidateIssuer = false,
// строка, представляющая издателя

// будет ли валидироваться потребитель токена
ValidateAudience = false,
// установка потребителя токена

// будет ли валидироваться время существования
ValidateLifetime = true,
// установка ключа безопасности
IssuerSigningKey = JwtConfigurations.GetSymmetricSecurityKey(),
// валидация ключа безопасности
ValidateIssuerSigningKey = true,

};
});
builder.Services.Configure<IdentityOptions>(options =>
    options.ClaimsIdentity.UserIdClaimType = ClaimTypes.NameIdentifier);
// add services to DI container
{
    var services = builder.Services;
    var env = builder.Environment;


    services.AddDbContext<DataContext>();
    services.AddCors();
    services.AddControllers();
    services.AddSwaggerGen();

    //builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connection));


    // configure automapper with all automapper profiles from this assembly
    services.AddAutoMapper(typeof(Program));
    services.AddMvc();
    // configure strongly typed settings object
    services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

    // configure DI for application services
    services.AddScoped<IJwtUtils, JwtUtils>();
    services.AddScoped<IUserService, UserService>();
    services.AddScoped<IDishService, DishService>();
    services.AddScoped<IBasketService, BasketService>();
    services.AddScoped<IOrderService, OrderService>();


}

var app = builder.Build();

// migrate any database changes on startup (includes initial db creation)
/*using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<DataContext>();    
    dataContext.Database.Migrate();
}*/
using var serviceScope = app.Services.CreateScope();
//var dbContext = serviceScope.ServiceProvider.GetService<DataContext>();
//dbContext?.Database.Migrate();
// configure HTTP request pipeline
{
    // global cors policy
    app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

    // global error handler
    app.UseMiddleware<ErrorHandlerMiddleware>();   

    app.MapControllers();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();