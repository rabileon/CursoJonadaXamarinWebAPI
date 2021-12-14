using CursoJonadaXamarinWebAPI.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CursoJonadaXamarinWebAPI.Routes
{
    public static class AuthenticationRoutes
    {
        private const string apiEndPoint = "api/authentication";

        internal static void AddRoutes(IEndpointRouteBuilder routeBuilder)
        {
            routeBuilder.MapPost($"{apiEndPoint}/users", [Authorize("IsAdmin")] async (UserManager<ApplicationUser> userManager, UserDTO userDTO) =>
             {
                 ApplicationUser applicationUser = new()
                 {
                     Address = userDTO.Address,
                     Email = userDTO.Email,
                     UserName = userDTO.UserName
                 };

                 var result = await userManager.CreateAsync(applicationUser, userDTO.Password);

                 if (result.Succeeded)
                 {
                     var claim = new Claim("IsAdmin", "true");
                     await userManager.AddClaimAsync(applicationUser, claim);
                     return Results.Ok();
                 }
                 else
                 {
                     return Results.BadRequest(result.Errors);
                 }
             });

            routeBuilder.MapPost($"{apiEndPoint}/login", async (IConfiguration configuration, UserManager<ApplicationUser> userManager, LoginDTO loginDTO) =>
            {
                var applicationUser = await ValidateCredentials(loginDTO);

                if (applicationUser is not null)
                {
                    var jwt = await GenerateJWT(configuration, userManager, applicationUser);
                    return Results.Ok(jwt);
                }

                return Results.BadRequest("Usuario o contraseña incorrecta");

                async Task<string> GenerateJWT(IConfiguration configuration, UserManager<ApplicationUser> userManager, ApplicationUser applicationUser)
                {
                    var claims = await userManager.GetClaimsAsync(applicationUser);

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Issuer = configuration["Issuer"],
                        Audience = configuration["Issuer"],
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Key"])), SecurityAlgorithms.HmacSha256Signature),
                        Expires = DateTime.UtcNow.AddDays(15),
                        Subject = new ClaimsIdentity(claims),
                    };

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    return tokenHandler.WriteToken(token);
                }

                async Task<ApplicationUser> ValidateCredentials(LoginDTO loginDTO)
                {
                    var applicationUser = await userManager.FindByNameAsync(loginDTO.UserName);

                    if (applicationUser is not null)
                    {
                        var result = userManager.PasswordHasher.VerifyHashedPassword
                        (applicationUser, applicationUser.PasswordHash, loginDTO.Password);

                        return result == PasswordVerificationResult.Success ? applicationUser : null!;


                    }

                    return null!;
                }
            });
        }
    }
}