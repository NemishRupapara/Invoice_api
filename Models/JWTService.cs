using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InvoiceAppApi.Models
{
    public class JWTService
    {
        private readonly IConfiguration _configuration;

        public string SecretKey {  get; set; }
        public int TokenDuration {  get; set; }

        public JWTService(IConfiguration configuration)
        {
            _configuration = configuration;
            this.SecretKey = _configuration.GetSection("jwtConfig").GetSection("Key").Value;
            this.TokenDuration=Int32.Parse(_configuration.GetSection("jwtConfig").GetSection("Duration").Value);
        }


        public string GenerateToken(string UserName,UserDetails user)
        {
            var key= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.SecretKey));
            var signature=new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var payload = new[]
            {
                new Claim("UseName",UserName),
                new Claim("UserID",user.UserId.ToString()),
                new Claim("RoleID",user.RoleID.ToString()),
                new Claim("Role",user.Role)
            };

            var jwttoken = new JwtSecurityToken(
                issuer: "localhost",
                audience: "localhost",
                claims: payload,
                expires: DateTime.Now.AddMinutes(TokenDuration),
                signingCredentials: signature
                ) ;


            return new JwtSecurityTokenHandler().WriteToken(jwttoken);
            
        }
    }
}
