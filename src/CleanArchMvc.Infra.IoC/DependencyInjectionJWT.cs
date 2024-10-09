using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CleanArchMvc.Infra.IoC;
public static class DependencyInjectionJWT
{
    public static void AddInfrastructureJWT(this IServiceCollection services, 
        IConfiguration configuration)
    {
        var signingKey = configuration.GetValue<string>("Jwt:SecretKey")!;
        var audience = configuration.GetValue<string>("Jwt:Audience")!;
        var issuer = configuration.GetValue<string>("Jwt:Issuer")!;

        // tipo de autenticação jwt-bearer
        // define modelo do desafio de autenticação
        services.AddAuthentication(config =>
        {
            config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(config => // habilita a autenticação jwt usando desafios definidos, e validar o token
        {
            config.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                // valores validos
                ValidIssuer = issuer,
                ValidAudience = audience,
                ClockSkew = new TimeSpan(0), // não tem tempo de vida a mais do que o definido
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey!))
            };
        });
    }
}
