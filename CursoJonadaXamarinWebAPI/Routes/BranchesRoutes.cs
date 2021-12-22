using Microsoft.AspNetCore.Authorization;

namespace CursoJonadaXamarinWebAPI.Routes;

public static class BranchesRoutes
{
    public const string apiEndPoint = "api/branches";

    internal static void AddRoutes(IEndpointRouteBuilder routerBuilder)
    {
        routerBuilder.MapGet(apiEndPoint, [Authorize] async (BranchesRepository repository)
            => Results.Ok(
                (await repository.GetAllAsync())
            .Select(b => new BranchDTO(b.BranchId.ToString(), b.Name, b.Location))
            ))
            .WithTags("Getters");
    }
}

