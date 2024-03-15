using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace CodeCampRestora.Identity;

public class TokenBuilder
{
    private string _issuer = default!;
    private string _audience = default!;
    private DateTime _expiry = default!;
    private DateTime _notBefore = default!;
    private IEnumerable<Claim> _claims = new List<Claim>();
    private SigningCredentials _signingCredentials = default!;

    public TokenBuilder AddIssuer(string issuer)
    {
        _issuer = issuer;
        return this;
    }

    public TokenBuilder AddAudience(string audience)
    {
        _audience = audience;
        return this;
    }

    public TokenBuilder AddExpiry(DateTime expiry)
    {
        _expiry = expiry;
        return this;
    }

    public TokenBuilder AddNotBefore(DateTime notBefore)
    {
        _notBefore = notBefore;
        return this;
    }

    public TokenBuilder AddClaims(IEnumerable<Claim> claims)
    {
        _claims = claims;
        return this;
    }

    public TokenBuilder AddKey(string key)
    {
        _signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)), SecurityAlgorithms.HmacSha256);
        return this;
    }

    public JwtSecurityToken Build()
    {
        var token = new JwtSecurityToken(
            issuer: _issuer,
            audience: _audience,
            expires: _expiry,
            notBefore: _notBefore,
            claims: _claims,
            signingCredentials: _signingCredentials
        );

        return token;
    }
}