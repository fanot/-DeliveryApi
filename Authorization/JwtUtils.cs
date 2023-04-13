namespace WebApi.Authorization;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using WebApi.Entities;
using WebApi.Helpers;

public interface IJwtUtils
{
    public string GenerateToken(Users user);
   // public int? ValidateToken(string token);
}

public class JwtUtils : IJwtUtils
{
    private readonly AppSettings _appSettings;

    public JwtUtils(IOptions<AppSettings> appSettings)
    {
        _appSettings = appSettings.Value;
    }

    public string GenerateToken(Users user)
    {
        var now = DateTime.UtcNow;
        var claims = new List<Claim>
        {
                new Claim(ClaimTypes.NameIdentifier, (user.Id).ToString()),
        };

        //Claims identity и будет являться полезной нагрузкой в JWT токене, которая будет проверяться стандартным атрибутом Authorize
        var claimsIdentity =
            new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        // generate token that is valid for minute
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        var jwt = new JwtSecurityToken(
            issuer: JwtConfigurations.Issuer,
            audience: JwtConfigurations.Audience,
            notBefore: now,
            claims: claimsIdentity.Claims,
            expires: now.AddMinutes(JwtConfigurations.Lifetime),
            signingCredentials: new SigningCredentials(JwtConfigurations.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        //var token = tokenHandler.CreateToken(tokenDescriptor);
        return encodedJwt;
    }
    
}
