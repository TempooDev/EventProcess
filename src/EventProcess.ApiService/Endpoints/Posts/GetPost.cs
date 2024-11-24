
public record Response ={
    int id;
}
public class GetPost : IEndpoint
{

  public static void Map(IEndpointRouteBuilder app) => app
        .MapGet("/", Handle)
        .WithSummary("Gets all posts");


        private static async Task Handle( CancellationToken cancellationToken){
            return  new List<Response>();
        }
    
}