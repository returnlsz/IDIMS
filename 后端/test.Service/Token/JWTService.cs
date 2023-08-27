using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using test.Module.Entities;

namespace test.Service.Token
{
    public class JWTService : IJWTService
    {
        private readonly JWTToken _JWTToken;
        public JWTService(IOptionsMonitor<JWTToken> jwttoken)
        {
            _JWTToken = jwttoken.CurrentValue;
        }
        public string GetToken(Users user)
        {
            var claims = new[]
            {
                new Claim("id",user.id.ToString())
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_JWTToken.SecurityKey));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken
                (
                issuer: _JWTToken.Issuer,
                audience: _JWTToken.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
