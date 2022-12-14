using IdentityServer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityServer()
       .AddInMemoryApiResources(IdentityConfiguration.ApiResources)
       .AddInMemoryIdentityResources(IdentityConfiguration.IdentityResources)
       .AddInMemoryApiScopes(IdentityConfiguration.ApiScopes)
       .AddInMemoryClients(IdentityConfiguration.Clients)
       .AddDeveloperSigningCredential();

var app = builder.Build();

app.UseIdentityServer();

app.Run();
