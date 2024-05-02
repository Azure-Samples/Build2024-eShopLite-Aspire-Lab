var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Store>("store");

builder.AddProject<Projects.Products>("products");

builder.Build().Run();
