using Microsoft.IdentityModel.Tokens;
using StayIn.DTO.Customer;
using StayIn.Interfaces;
using StayInAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StayIn.Services
{
    public class TokenService : ITokenService
    {

        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;
        public TokenService(IConfiguration config) {
            _config= config;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SigningKey"]));
        }
        public string CreateToken(Customer customer)
        {
            var claims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Email, customer.Email),
                new Claim(JwtRegisteredClaimNames.GivenName, customer.UserName)
            };

            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = credentials,
                Issuer = _config["JWT:Issuer"],
                Audience = _config["JWT:Audience"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
        public string CreateTokenx2(CustomerDto customer, TimeSpan tokenLifetime)
        {
            var claims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Email, customer.Email),
                new Claim(JwtRegisteredClaimNames.GivenName, customer.Username),
                new Claim("CustomerId", customer.CustomerId),
                new Claim("FirstName", customer.FirstName),
                new Claim("LastName", customer.LastName),
                new Claim("Role", customer.Role)
            };

            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.Add(tokenLifetime),
                SigningCredentials = credentials,
                Issuer = _config["JWT:Issuer"],
                Audience = _config["JWT:Audience"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
