
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace WebSystem.Core
{
    public class WebSystemToken
    {
        public static string GenerateSimpleToken(string jwtKey, DateTime expires)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = credentials,
                Expires = expires,
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string GenerateToken(WebSystemObject webSystemObject, string jwtKey, DateTime expires)
        {
            var tokenHandle = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = credentials,
                Subject = GenerateClaims(webSystemObject),
                Expires = expires
            };

            var token = tokenHandle.CreateToken(tokenDescriptor);
            return tokenHandle.WriteToken(token);
        }

        private static ClaimsIdentity GenerateClaims(WebSystemObject webSystemObject)
        {
            var ci = new ClaimsIdentity();

            if (webSystemObject.Id.HasValue)
                ci.AddClaim(new Claim("id", webSystemObject.Id.ToString()!));

            if (!string.IsNullOrEmpty(webSystemObject.Name))
                ci.AddClaim(new Claim(ClaimTypes.Name, webSystemObject.Name));

            if (!string.IsNullOrEmpty(webSystemObject.Email))
                ci.AddClaim(new Claim(ClaimTypes.Name, webSystemObject.Email));

            if (!string.IsNullOrEmpty(webSystemObject.Description))
                ci.AddClaim(new Claim("description", webSystemObject.Description));

            if (webSystemObject.Roles is not null)
                foreach (var role in webSystemObject.Roles)
                    ci.AddClaim(new Claim(ClaimTypes.Role, role));

            return ci;
        }
    }
}