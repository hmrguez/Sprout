using System.Runtime.CompilerServices;
using Api.Middleware;
using Application.Authentication.Common;
using Contracts.Authentication;

namespace Api;

public static class JsonSerializerBuilder
{
    public static void AddJsonSerializers(this WebApplicationBuilder builder)
    {
        builder.Services.ConfigureHttpJsonOptions(options =>
        {
            options.SerializerOptions.TypeInfoResolverChain.Insert(0, RegisterRequestSerializerContext.Default);
            options.SerializerOptions.TypeInfoResolverChain.Insert(0, LoginRequestSerializerContext.Default);
            options.SerializerOptions.TypeInfoResolverChain.Insert(0, AuthenticationResponseSerializerContext.Default);
            options.SerializerOptions.TypeInfoResolverChain.Insert(0, ErrorResponseSerializerContext.Default);
            options.SerializerOptions.TypeInfoResolverChain.Insert(0, AuthenticationResultSerializerContext.Default);
        });
    }
}