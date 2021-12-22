using CursoJonadaXamarinWebAPI.Authentication;
using CursoJonadaXamarinWebAPI.Routes;
using DTOs.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swagger =>
{
    swagger.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Books API", Version = "v1" });
    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Please write a JWT and write Bearer prefix",
        Name = "Authorization",
        BearerFormat = "Bearer [Your Token]",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey
    });

    swagger.AddSecurityRequirement(
        new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }

                },
                Array.Empty<string>()
            }
        }
    );
});
builder.Services.AddSqlServer<CursoJornadaXamarin2021Context>
    (builder.Configuration.GetConnectionString("BooksConnectionString"));
builder.Services.AddDbContext<AuthContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AuthConnectionString")));
//builder.Services.AddSqlServer<AuthContext>
//    (builder.Configuration.GetConnectionString("AuthConnectionString"));
builder.Services.AddScoped<BooksRepository>();
builder.Services.AddScoped<BranchesRepository>();
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
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Issuer"],
            ValidAudience = builder.Configuration["Issuer"]
        };
    });

builder.Services.AddAuthorization(option => option.AddPolicy("IsAdmin", policyBuilder => policyBuilder.RequireClaim("IsAdmin")));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();


AuthenticationRoutes.AddRoutes(app);
BooksRoutes.AddBooksRoutes(app);
BranchesRoutes.AddRoutes(app);

app.Run();

