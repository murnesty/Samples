var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.AspireApp1_ApiService>("apiservice");
var redis = builder.AddRedis("cache");

builder.AddProject<Projects.AspireApp1_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WithReference(redis)
    .WaitFor(apiService);

builder.Build().Run();
