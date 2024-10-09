using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Security;
public interface IAccessTokenGenerator
{
    string GenerateAccessToken(User user);
}