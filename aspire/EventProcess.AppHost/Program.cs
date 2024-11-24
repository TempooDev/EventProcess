using Aspire.Azure.Messaging.EventHubs;

var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres")
                        WithPgAdmin();
var postdb = postgres.AddDatabase("postdb");

var apiService = builder.AddProject<Projects.EventProcess_ApiService>("apiservice")
                    .WithReference(postdb);



builder.AddProject<Projects.EventProcess_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);


builder.Build().Run();
