using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SchoolProject.Data.Helper;
using SchoolProject.Data.Results;
using SELP.Data.Entites.Identity;
using SELP.Data.Entities.Identity;
using SELP.Infrustructure.Abstracts;
using SELP.Service.Abstract;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Service.Implementation
{
    public class AuthenticationService : IAuthenticationService
    {
        #region Fields
        private readonly JwtSettings _jwtSettings;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly UserManager<User> _userManager;
        private readonly ConcurrentDictionary<string, RefreshToken> _UserRefreshToken;
        #endregion
        #region Constructor
        public AuthenticationService(JwtSettings jwtSettings,
              IRefreshTokenRepository refreshTokenRepository,
              UserManager<User> userManager)
        {
          _jwtSettings = jwtSettings;
            _refreshTokenRepository = refreshTokenRepository;
            _userManager = userManager;
            _UserRefreshToken = new ConcurrentDictionary<string, RefreshToken>();
        }


        #endregion
        #region Handle Fun
        public async Task<JwtAuthResult> GetJWTToken(User user)
        {
            var Roles = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>()
            {
                new Claim("Email",user.Email),
                new Claim("PhoneNumber",user.PhoneNumber),
                new Claim("FirstName",user.FirstName),
                new Claim("LastName",user.LastName)
            };
            // adding roles
            foreach (var role in Roles)
                claims.Add(new Claim(ClaimTypes.Role, role.ToString()));
            var userClaims = await _userManager.GetClaimsAsync(user);
            claims.AddRange(userClaims);

            //



            var JwtToken = new JwtSecurityToken(
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                claims,
                expires: DateTime.Now.AddMonths(_jwtSettings.AccessTokenExpireDate),
                signingCredentials:
                new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)),
                SecurityAlgorithms.HmacSha256Signature)
                );
            var AccessToken = new JwtSecurityTokenHandler().WriteToken(JwtToken);

            var refreshtoken = new RefreshToken()
            {
                TokenString = GenerateRefreshToken(),
                UserName = user.UserName,
                ExpireAt = DateTime.Now.AddMonths(_jwtSettings.RefreshTokenExpireDate),
            };
            _UserRefreshToken.AddOrUpdate(refreshtoken.TokenString, refreshtoken, (s, t) => refreshtoken);

            //save in database
            var userRefreshToken = new UserRefreshToken
            {
                AddedTime = DateTime.Now,
                ExpiryDate = DateTime.Now.AddMonths(_jwtSettings.RefreshTokenExpireDate),
                IsUsed = true,
                IsRevoked = false,
                JwtId = JwtToken.Id,
                RefreshToken = refreshtoken.TokenString,
                Token = AccessToken,
                UserId = user.Id
            };
            await _refreshTokenRepository.AddAsync(userRefreshToken);
            //


            var response = new JwtAuthResult();
            response.refreshToken = refreshtoken;
            response.AccessToken = AccessToken;
            return response;
        }
        private string GenerateRefreshToken()
        {
            var RandomNumber = new byte[32];
            var RandomNumberGenerate = RandomNumberGenerator.Create();
            RandomNumberGenerate.GetBytes(RandomNumber);
            return Convert.ToBase64String(RandomNumber);
        }
        #endregion
    }
}
