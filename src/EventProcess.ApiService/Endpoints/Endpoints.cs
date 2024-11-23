
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;



public static class Endpoints
{
    private static readonly OpenApiSecurityScheme securityScheme = new()
    {
        Type = SecuritySchemeType.Http,
        Name = JwtBearerDefaults.AuthenticationScheme,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Reference = new()
        {
            Type = ReferenceType.SecurityScheme,
            Id = JwtBearerDefaults.AuthenticationScheme
        }
    };

    public static void MapEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("")
            .WithOpenApi();

        endpoints.MapPostEndpoints();
       
    }

   

    private static void MapPostEndpoints(this IEndpointRouteBuilder app)
    {
        var endpoints = app.MapGroup("/posts")
            .WithTags("Posts");

        // endpoints.MapPublicGroup()
        //     .MapEndpoint<GetPosts>()
        //     .MapEndpoint<GetPostById>()
        //     .MapEndpoint<GetPostComments>();

        // endpoints.MapAuthorizedGroup()
        //     .MapEndpoint<CreatePost>()
        //     .MapEndpoint<UpdatePost>()
        //     .MapEndpoint<DeletePost>()
        //     .MapEndpoint<LikePost>()
        //     .MapEndpoint<UnlikePost>();
    }

    private static RouteGroupBuilder MapPublicGroup(this IEndpointRouteBuilder app, string? prefix = null)
    {
        return app.MapGroup(prefix ?? string.Empty)
            .AllowAnonymous();
    }

    private static RouteGroupBuilder MapAuthorizedGroup(this IEndpointRouteBuilder app, string? prefix = null)
    {
        return app.MapGroup(prefix ?? string.Empty)
            .RequireAuthorization()
            .WithOpenApi(x => new(x)
            {
                Security = [new() { [securityScheme] = [] }],
            });
    }

    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app) where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }
}