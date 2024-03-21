
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using WebSystem.Core.models;

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

        public static string GenerateToken(WsUser wsUser, string jwtKey, DateTime expires)
        {
            var tokenHandle = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = credentials,
                Subject = GenerateClaims(wsUser),
                Expires = expires
            };

            var token = tokenHandle.CreateToken(tokenDescriptor);
            return tokenHandle.WriteToken(token);
        }

        private static ClaimsIdentity GenerateClaims(WsUser WsUser)
        {
            var ci = new ClaimsIdentity();

            if (WsUser.Id.HasValue)
                ci.AddClaim(new Claim("id", WsUser.Id.ToString()!));

            if (!string.IsNullOrEmpty(WsUser.Name))
            {
                ci.AddClaim(new Claim(ClaimTypes.Name, WsUser.Name));
                ci.AddClaim(new Claim(ClaimTypes.GivenName, WsUser.Name));
            }

            if (!string.IsNullOrEmpty(WsUser.Email))
                ci.AddClaim(new Claim(ClaimTypes.Email, WsUser.Email));

            if (!string.IsNullOrEmpty(WsUser.Description))
                ci.AddClaim(new Claim("description", WsUser.Description));

            if (WsUser.Roles is not null)
                foreach (var role in WsUser.Roles)
                    ci.AddClaim(new Claim(ClaimTypes.Role, role));

            return ci;
        }
    }
}