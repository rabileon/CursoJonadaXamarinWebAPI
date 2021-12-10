using CursoJonadaXamarinWebAPI.Authentication;
using CursoJonadaXamarinWebAPI.Routes;
using DTOs.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<CursoJornadaXamarin2021Context>
    (builder.Configuration.GetConnectionString("BooksConnectionString"));
builder.Services.AddDbContext<AuthContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AuthConnectionString")));
//builder.Services.AddSqlServer<AuthContext>
//    (builder.Configuration.GetConnectionString("AuthConnectionString"));
builder.Services.AddScoped<BooksRepository>();
builder.Services.AddValidators();

builder.Services.AddIdentityCore<ApplicationUser>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireUppercase = true;
}).AddEntityFrameworkStores<AuthContext>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Key"])),
            ValidateLifetime = true,
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Issuer"]
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseHttpsRedirection();

AuthenticationRoutes.AddRoutes(app);
BooksRoutes.AddBooksRoutes(app);

app.Run();

