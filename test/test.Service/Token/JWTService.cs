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
        public string DecodeToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_JWTToken.SecurityKey);

            TokenValidationParameters validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = _JWTToken.Issuer,

                ValidateAudience = true,
                ValidAudience = _JWTToken.Audience,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),

                ClockSkew = TimeSpan.Zero // No clock skew
            };

            SecurityToken validatedToken;
            ClaimsPrincipal claimsPrincipal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);

            // 获取用户的 ID
            var userIdClaim = claimsPrincipal.FindFirst("id");
            if (userIdClaim != null)
            {
                string userId = userIdClaim.Value;
                return userId;
            }
            else
            {
                return ""; // 用户 ID 未找到
            }
        }
    }
}
