using Microsoft.AspNetCore.Identity;

namespace CursoJonadaXamarinWebAPI.Authentication;

public class ApplicationUser : IdentityUser
{
    public string Address { get; set; } = null!;

}

