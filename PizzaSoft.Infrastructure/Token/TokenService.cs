using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PizzaSoft.Application.Common.Interfaces.Token;
using PizzaSoft.Domain.Token;

namespace PizzaSoft.Infrastructure.Token
{
    public class TokenService : ITokenService
    {
        public static readonly string ClaimsClientId = "ClientId";
        public static readonly string ClaimsUserName = "UserName";
        //public static readonly string ClaimsCBToken = "CBToken";

        private readonly string TokenKey;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly TokenValidationParameters _tokenValidationParameters;

        public TokenService(IConfiguration configuration, IHttpContextAccessor httpContextAccessor,
            TokenValidationParameters tokenValidationParameters)
        {
            _configuration = configuration;
            this.TokenKey = _configuration.GetValue<string>("Security:TokenSecret");
            _httpContextAccessor = httpContextAccessor;
            _tokenValidationParameters = tokenValidationParameters;
        }
        public async Task<AuthenticationResult> CreateTokenAsync(TokenData tokenData)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var claims = new ClaimsIdentity(new[]
            {
                new Claim(ClaimsClientId, tokenData.UserId.ToString()),
              
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            });

            TimeSpan lifetime = TimeSpan.Parse(_configuration.GetValue<string>("Security:TokenLifetime"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.Add(lifetime),
                SigningCredentials = creds
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthenticationResult
            {
                Token = tokenHandler.WriteToken(token),
            };
        }
        public TokenData GetTokenData()
        {
            var claims = _httpContextAccessor.HttpContext.User.Claims;
            return new TokenData
            {
                UserId = Guid.Parse(claims.Single(c => c.Type == ClaimsClientId).Value),
              
            };
        }

        public TokenData ValidateAndGetTokenData(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                var principal = tokenHandler.ValidateToken(token, _tokenValidationParameters, out var validatedToken);
                if (!IsJwtWithValidSecurityAlgorithm(validatedToken))
                {
                    return null;
                }

                return new TokenData
                {
                    UserId = System.Guid.Parse(principal.Claims.Single(c => c.Type == ClaimsClientId).Value),
                
                    Exp = long.Parse(principal.Claims.Single(c => c.Type == JwtRegisteredClaimNames.Exp).Value),
                    Jti = principal.Claims.Single(c => c.Type == JwtRegisteredClaimNames.Jti).Value
                };
            }
            catch
            {
                return null;
            }
        }

        private bool IsJwtWithValidSecurityAlgorithm(SecurityToken validatedToken)
        {
            return (validatedToken is JwtSecurityToken jwtSecurityToken) &&
                    jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                    StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
