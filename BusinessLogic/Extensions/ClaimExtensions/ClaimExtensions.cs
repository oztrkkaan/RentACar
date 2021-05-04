using BusinessLogic.Constants;
using System.Security.Claims;
using System.Security.Principal;

namespace BusinessLogic.Extensions.ClaimExtensions
{
    public static class ClaimExtensions
    {
        public static int UserId(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst(CustomClaimTypes.UserId);
            return int.Parse(claim.Value);
        }

        public static string UserFullName(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst(CustomClaimTypes.UserFullName);
            return claim?.Value ?? string.Empty;
        }

        public static string UserEmail(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst(CustomClaimTypes.UserEmail);
            return claim?.Value ?? string.Empty;
        }
    }
}
