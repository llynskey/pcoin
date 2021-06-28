using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtAuthService.services
{
    public class TokenBuilder : ITokenBuilder
    {
        //TODO : set secret to change on system time
        public string secret = "ec98e4092525b2da608f304082eaf1cbe873298942da32afea25d7536818887c";
        public string BuildToken(string _id ,string username, string type)
        {
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));


            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, _id),
                new Claim("Username",username),
                new Claim("Type", type)
            };
            var jwt = new JwtSecurityToken(claims: claims, signingCredentials: signingCredentials);
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }


    }
}
