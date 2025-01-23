using ApolloExample.Server;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication()
    .AddJwtBearer(options =>
    {
        options.Authority = "";
        options.RequireHttpsMetadata = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true
        };
    });

builder.Services
    .AddGraphQLServer()
    .AddAuthorization()
    .AddSocketSessionInterceptor<SocketSessionInterceptor>()
    .AddQueryType<Query>()
    .AddSubscriptionType<Subscription>()
    .AddObjectType<Book>();

var app = builder.Build();

app.UseWebSockets();

app.MapGraphQL();

app.Run();
