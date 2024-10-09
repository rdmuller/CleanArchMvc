using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Security;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CleanArchMvc.Infra.Data.Security;
public class AccessTokenGenerator : IAccessTokenGenerator
{
    //private readonly IConfiguration _configuration;
    private readonly uint _expirationTimeMinutes;
    private readonly string _signingKey;
    private readonly string _audience;
    private readonly string _issuer;

    public AccessTokenGenerator(uint expirationTimeMinutes, 
        string signingKey, 
        string audience,
        string issuer)
    {
        _audience = audience;
        _expirationTimeMinutes = expirationTimeMinutes;
        _signingKey = signingKey;
        _issuer = issuer;
    }

    public string GenerateAccessToken(User user)
    {
        // declarações de usuário
        var claims = new Claim[]
        {
            new Claim("email", user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        // gerar chave privada para assinar o token
        var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_signingKey));

        // gerar a assinatura digital
        var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

        // definir o tempo de expiração
        var expiration = DateTime.UtcNow.AddMinutes(_expirationTimeMinutes);

        // gerar o token
        var token = new JwtSecurityToken(
            issuer: _issuer,
            audience: _audience,
            claims: claims,
            expires: expiration,
            signingCredentials: credentials
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
