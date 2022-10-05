namespace Lithium.Identity.Services;

public class ProfileService : IProfileService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public ProfileService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    async public Task GetProfileDataAsync(ProfileDataRequestContext context)
    {
        var subject = context.Subject ?? throw new ArgumentNullException(nameof(context.Subject));
        var subjectId = subject.Claims.Where(x => x.Type == "sub").FirstOrDefault().Value;
        var user = await _userManager.FindByIdAsync(subjectId);
        if (user == null)
            throw new ArgumentException("Invalid subject identifier");

        var claims = GetClaimsFromUser(user);
        context.IssuedClaims = claims.ToList();
    }

    public IEnumerable<Claim> GetClaimsFromUser(ApplicationUser user)
    {
        var claims = new List<Claim>
    {
        new Claim(JwtClaimTypes.Subject, user.Id),
        new Claim(JwtClaimTypes.PreferredUserName, user.UserName),
        new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
    };

        if (!string.IsNullOrWhiteSpace(user.FullName))
            claims.Add(new Claim("name", user.FullName));

        if (!string.IsNullOrWhiteSpace(user.FirstName))
            claims.Add(new Claim("given_name", user.FirstName));

        if (!string.IsNullOrWhiteSpace(user.LastName))
            claims.Add(new Claim("family_name", user.LastName));

        if (user.DateOfBirth != DateTime.MinValue)
            claims.Add(new Claim("birthdate", user.DateOfBirth.ToString()));

        claims.Add(new Claim("created_at", user.CreatedDate.ToString()));

        // Check if user supprts email
        if (_userManager.SupportsUserEmail)
        {
            claims.AddRange(new[]
            {
            new Claim(JwtClaimTypes.Email, user.Email),
            new Claim(JwtClaimTypes.EmailVerified, user.EmailConfirmed ? "true" : "false", ClaimValueTypes.Boolean)
        });
        }

        // Check if user supports phone number
        if (_userManager.SupportsUserPhoneNumber && !string.IsNullOrWhiteSpace(user.PhoneNumber))
        {
            claims.AddRange(new[]
            {
            new Claim(JwtClaimTypes.PhoneNumber, user.PhoneNumber),
            new Claim(JwtClaimTypes.PhoneNumberVerified, user.PhoneNumberConfirmed ? "true" : "false", ClaimValueTypes.Boolean)
        });
        }


        return claims;
    }

    public async Task IsActiveAsync(IsActiveContext context)
    {
        var subject = context.Subject ?? throw new ArgumentNullException(nameof(context.Subject));

        var subjectId = subject.Claims.Where(x => x.Type == "sub").FirstOrDefault().Value;
        var user = await _userManager.FindByIdAsync(subjectId);

        context.IsActive = false;

        if (user != null)
        {
            if (_userManager.SupportsUserSecurityStamp)
            {
                var security_stamp = subject.Claims.Where(c => c.Type == "security_stamp").Select(c => c.Value).SingleOrDefault();
                if (security_stamp != null)
                {
                    var db_security_stamp = await _userManager.GetSecurityStampAsync(user);
                    if (db_security_stamp != security_stamp)
                        return;
                }
            }

            context.IsActive =
                !user.LockoutEnabled ||
                !user.LockoutEnd.HasValue ||
                user.LockoutEnd <= DateTime.Now;
        }
    }
}

