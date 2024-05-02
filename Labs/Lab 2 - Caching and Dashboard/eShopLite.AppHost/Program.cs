var builder = DistributedApplication.CreateBuilder(args);

var products = builder.AddProject<Projects.Store>("products");

builder.AddProject<Projects.Store>("store").WithReference(products);

builder.Build().Run();
