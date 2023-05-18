using Books.Data.Model;

namespace Books.Business.Interfaces
{
    public interface ITokenService
    {
        string GenerateJwtToken(ApplicationUser user, IList<string> roles);
    }
}