using Api;
using Api.Controllers;
using Api.Middleware;
using Application;
using Contracts.Authentication;
using Infrastructure;
using Microsoft.AspNetCore.Identity.Data;

var builder = WebApplication.CreateSlimBuilder(args);
{
    builder.Services.AddControllers();
    // builder.Services.ConfigureHttpJsonOptions(options =>
    // {
    //     options.SerializerOptions.TypeInfoResolverChain.Insert(0, RegisterRequestSerializerContext.Default);
    //     // options.SerializerOptions.TypeInfoResolverChain.Insert(0, LoginRequestSerializerContext.Default);
    //     // options.SerializerOptions.TypeInfoResolverChain.Insert(0, AuthenticationResponseSerializerContext.Default);
    //     // options.SerializerOptions.TypeInfoResolverChain.Insert(0, ErrorResponseSerializerContext.Default);
    //     // options.SerializerOptions.TypeInfoResolverChain.Insert(0, AuthenticationResultSerializerContext.Default);
    // });
    
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
}

var app = builder.Build();
{
    app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
}

app.Run();