using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ConferenceManager
{
    public class TokenGenerator
    {
        public void Generate()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your-very-secure-secret-which-should-be-quite-long"));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: "your-name",
                audience: "your-app-name",
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );
            var tokenHandler = new JwtSecurityTokenHandler();

            // Turn the token object into the token string which is added to the header
            string jwtToken = tokenHandler.WriteToken(token);

            // This prints to the debug output in VS2022
            System.Diagnostics.Debug.WriteLine(jwtToken);
        }
    }
}
