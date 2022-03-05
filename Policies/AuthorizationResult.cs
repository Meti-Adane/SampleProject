using System.Collections.Generic;
using System.Security.Claims;

namespace sitesampleproject.Policies
{
    /// <summary>
    /// Encapsulates the result of <see cref="IAuthorizationService.AuthorizeAsync(ClaimsPrincipal, object, IEnumerable{IAuthorizationRequirement})"/>.
    /// </summary>
    public class AuthorizationResult
    {
        private AuthorizationResult() { }

        /// <summary>
        /// True if authorization was successful.
        /// </summary>
        public bool Succeeded { get; private set; }

        /// <summary>
        /// Contains information about why authorization failed.
        /// </summary>
        public AuthorizationFailure Failure { get; private set; }

        /// <summary>
        /// Returns a successful result.
        /// </summary>
        /// <returns>A successful result.</returns>
        public static AuthorizationResult Success() => new AuthorizationResult { Succeeded = true };

        public static AuthorizationResult Failed(AuthorizationFailure failure) => new AuthorizationResult { Failure = failure };

        public static AuthorizationResult Failed() => new AuthorizationResult { Failure = AuthorizationFailure.ExplicitFail() };

    }
}