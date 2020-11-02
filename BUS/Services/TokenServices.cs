using BUS.Interface;
using BUS.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace BUS.Services
{
    public class TokenServices : ITokenService
    {
        private IConfiguration _Configuration;
        static string _Token;
        static Dictionary<string, User> _RefreshToken;
        public TokenServices(IConfiguration configuration)
        {
            _Configuration = configuration;
        }
        public AuthToken CreateToken(User user)
        {
            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Configuration["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var claims = new[] {
                    new Claim("Id", user.Id.ToString()),
                    //new Claim("User", user.ToJson()),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
                var token = new JwtSecurityToken(_Configuration["Jwt:Issuer"],
                    _Configuration["Jwt:Issuer"],
                    claims,
                    expires: DateTime.Now.AddMinutes(int.Parse(_Configuration["Jwt:Expire"])),
                    signingCredentials: credentials);
                var bearerToken = new JwtSecurityTokenHandler().WriteToken(token);
                DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Local);
                var exp = start.AddSeconds(int.Parse(token.Claims.FirstOrDefault(c => c.Type == "exp").Value)).AddHours(7);// VN: utc + 7
                var tokenResult = new AuthToken
                {
                    Token = bearerToken,
                    RefreshToken = Guid.NewGuid().ToString(),
                    Exprire = exp
                };
                _RefreshToken.Add(tokenResult.RefreshToken,user);
                _Token = bearerToken;
                //var cacheKey = _CacheService.CreateCacheKey(CacheKeyName.RefreshToken, tokenResult.RefreshToken);
                //_CacheService.Set(cacheKey, user);
                return tokenResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public AuthToken RefreshToken(string RefreshToken)
        {
            try
            {
                if (_RefreshToken.ContainsKey(RefreshToken))
                {
                    return CreateToken(_RefreshToken[RefreshToken]);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
