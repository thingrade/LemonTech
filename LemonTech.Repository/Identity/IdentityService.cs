using Lemontech.DataLayer.Models;
using LemonTech.Repository.Identity.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LemonTech.Repository.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<IdentityUser> _userManager;
        public IdentityService(
            UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<SignUpResult> SignUp(SignUpOptions model)
        {

            IdentityUser addUserModel = new IdentityUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName
            };

            var addUser = await _userManager.CreateAsync(addUserModel, model.Password);

            if (addUser.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);

                var token = CreateJwtToken(user);

                return new SignUpResult
                {
                    Succeeded = true,
                    Token = new JwtSecurityTokenHandler().WriteToken(token)
                };
            }
            else
            {
                return new SignUpResult
                {
                    Succeeded = false
                };
            }
        }

        public async Task<LoginResponseModel> Login(Credentials model)
        {

            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var token = CreateJwtToken(user);

                return new LoginResponseModel
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo
                };
            }

            return new LoginResponseModel
            {
                LoginSuccess = false,
                Message = "Username or Password is incorrect."
            };

        }

        private JwtSecurityToken CreateJwtToken(IdentityUser user)
        {
            var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("themanwhosoldtheworld"));

            var token = new JwtSecurityToken(
                issuer: "http://localhost:3333/",
                audience: "http://localhost:3333/",
                expires: DateTime.UtcNow.AddDays(1),
                claims: claims,
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
            );

            return token;
        }
    }
}
