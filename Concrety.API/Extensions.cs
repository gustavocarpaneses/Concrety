using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace Concrety.API
{
    public static class Extensions
    {
        /// <summary>
        ///     Return the user id using the UserIdClaimType
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static int GetUserId(this IIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException("identity");
            }
            var ci = identity as ClaimsIdentity;

            if (ci == null)
            {
                throw new ApplicationException("Não foi possível obter o Id do Usuário");
            }

            var firstValue = ci.FindFirstValue(ClaimTypes.NameIdentifier);
            if (firstValue == null)
            {
                throw new ApplicationException("Não foi possível obter o Id do Usuário");
            }
                
            return Convert.ToInt32(firstValue);
        }

        /// <summary>
        ///     Return the user name using the UserNameClaimType
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static string GetUserName(this IIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException("identity");
            }
            var ci = identity as ClaimsIdentity;
            if (ci != null)
            {
                return ci.FindFirstValue(ClaimsIdentity.DefaultNameClaimType);
            }
            return null;
        }

        /// <summary>
        ///     Return the claim value for the first claim with the specified type if it exists, null otherwise
        /// </summary>
        /// <param name="identity"></param>
        /// <param name="claimType"></param>
        /// <returns></returns>
        public static string FindFirstValue(this ClaimsIdentity identity, string claimType)
        {
            if (identity == null)
            {
                throw new ArgumentNullException("identity");
            }
            var claim = identity.FindFirst(claimType);
            return claim != null ? claim.Value : null;
        }

    }
}