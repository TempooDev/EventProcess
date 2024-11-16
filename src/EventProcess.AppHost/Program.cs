var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.EventProcess_ApiService>("apiservice");

builder.AddProject<Projects.EventProcess_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.Build().Run();
