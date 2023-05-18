using Books.Business.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Books.Business
{
    public class TokenService : ITokenService
    {
        public string GenerateJwtToken(Data.Model.ApplicationUser user, IList<string> roles)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("[SECRET USED TO SIGN AND VERIFY JWT TOKENS, IT CAN BE ANY STRING]");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GetClaimsIdentity(user, roles),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

     

        private ClaimsIdentity GetClaimsIdentity(Books.Data.Model.ApplicationUser user, IList<string> roles)
        {
            var claims = new ClaimsIdentity();

            claims.AddClaim(new Claim("id", user.Id.ToString()));
            claims.AddClaim(new Claim(ClaimTypes.Name, user.NormalizedUserName));

            foreach (var item in roles)
            {
                claims.AddClaim(new Claim(ClaimTypes.Role, item));
            }

            return new ClaimsIdentity(claims);
        }
    }
}