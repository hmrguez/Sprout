using System.Runtime.CompilerServices;
using Contracts.Authentication;

namespace Api;

public static class JsonSerializerBuilder
{
    public static void AddJsonSerializers(this WebApplicationBuilder builder)
    {
        builder.Services.ConfigureHttpJsonOptions(options =>
        {
            options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
            options.SerializerOptions.TypeInfoResolverChain.Insert(0, RegisterRequestSerializerContext.Default);
            options.SerializerOptions.TypeInfoResolverChain.Insert(0, LoginRequestSerializerContext.Default);
            options.SerializerOptions.TypeInfoResolverChain.Insert(0, AuthenticationResponseSerializerContext.Default);
        });
    }
}