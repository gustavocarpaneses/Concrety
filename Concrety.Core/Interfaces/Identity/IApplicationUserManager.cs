using Concrety.Core.Entities.Enumerators;
using Concrety.Core.Entities.Identity;
using Concrety.Core.Entities.Results;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Concrety.Core.Interfaces.Identity
{
    public interface IApplicationUserManager : IDisposable
    {
        string ApplicationCookie { get; }
        string ExternalBearer { get; }
        string ExternalCookie { get; }
        string TwoFactorCookie { get; }
        string TwoFactorRememberBrowserCookie { get; }
        Task<EntityResultBase> AccessFailedAsync(int userId);
        Task<EntityResultBase> AddClaimAsync(int userId, Claim claim);
        Task<EntityResultBase> AddLoginAsync(int userId, ApplicationUserLoginInfo login);
        Task<EntityResultBase> AddToRoleAsync(int userId, string role);
        EntityResultBase AddToRole(int userId, string role);
        Task<EntityResultBase> AddPasswordAsync(int userId, string password);
        Task<EntityResultBase> AddUserToRolesAsync(int userId, IList<string> roles);
        Task<EntityResultBase> ChangePasswordAsync(int userId, string currentPassword, string newPassword);
        Task<EntityResultBase> ChangePhoneNumberAsync(int userId, string phoneNumber, string token);
        void Challenge(string redirectUri, string xsrfKey, int? userId, params string[] authenticationTypes);
        Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
        Task<EntityResultBase> ConfirmEmailAsync(int userId, string token);
        Task<EntityResultBase> CreateAsync(ApplicationUser user);
        Task<EntityResultBase> CreateAsync(ApplicationUser user, string password);
        ClaimsIdentity CreateIdentity(ApplicationUser user, string authenticationType);
        Task<ClaimsIdentity> CreateIdentityAsync(ApplicationUser user, string authenticationType);
        EntityResultBase Create(ApplicationUser user);
        EntityResultBase Create(ApplicationUser user, string password);
        ClaimsIdentity CreateTwoFactorRememberBrowserIdentity(int userId);
        Task<EntityResultBase> DeleteAsync(int userId);
        Task<SignInStatus> ExternalSignIn(ApplicationExternalLoginInfo loginInfo, bool isPersistent);
        Task<ApplicationUser> FindAsync(ApplicationUserLoginInfo login);
        Task<ApplicationUser> FindAsync(string userName, string password);
        Task<ApplicationUser> FindByEmailAsync(string email);
        ApplicationUser FindById(int userId);
        Task<ApplicationUser> FindByIdAsync(int userId);
        Task<ApplicationUser> FindByNameAsync(string userName);
        ApplicationUser FindByName(string userName);
        Task<string> GenerateChangePhoneNumberTokenAsync(int userId, string phoneNumber);
        Task<string> GenerateEmailConfirmationTokenAsync(int userId);
        Task<string> GeneratePasswordResetTokenAsync(int userId);
        Task<string> GenerateTwoFactorTokenAsync(int userId, string twoFactorProvider);
        Task<string> GenerateUserTokenAsync(string purpose, int userId);
        Task<int> GetAccessFailedCountAsync(int userId);
        Task<IList<Claim>> GetClaimsAsync(int userId);
        Task<string> GetEmailAsync(int userId);
        IEnumerable<ApplicationAuthenticationDescription> GetExternalAuthenticationTypes();
        Task<ClaimsIdentity> GetExternalIdentityAsync(string externalAuthenticationType);
        ApplicationExternalLoginInfo GetExternalLoginInfo();
        ApplicationExternalLoginInfo GetExternalLoginInfo(string xsrfKey, string expectedValue);
        Task<ApplicationExternalLoginInfo> GetExternalLoginInfoAsync();
        Task<ApplicationExternalLoginInfo> GetExternalLoginInfoAsync(string xsrfKey, string expectedValue);
        Task<bool> GetLockoutEnabledAsync(int userId);
        Task<DateTimeOffset> GetLockoutEndDateAsync(int userId);
        IList<ApplicationUserLoginInfo> GetLogins(int userId);
        Task<IList<ApplicationUserLoginInfo>> GetLoginsAsync(int userId);
        Task<string> GetPhoneNumberAsync(int userId);
        Task<IList<string>> GetRolesAsync(int userId);
        IList<string> GetRoles(int userId);
        Task<string> GetSecurityStampAsync(int userId);
        Task<bool> GetTwoFactorEnabledAsync(int userId);
        Task<IList<string>> GetValidTwoFactorProvidersAsync(int userId);
        Task<int?> GetVerifiedUserIdAsync();
        Task<bool> HasBeenVerified();
        Task<bool> HasPasswordAsync(int userId);
        Task<bool> IsEmailConfirmedAsync(int userId);
        Task<bool> IsInRoleAsync(int userId, string role);
        Task<bool> IsLockedOutAsync(int userId);
        Task<bool> IsPhoneNumberConfirmedAsync(int userId);
        Task<EntityResultBase> NotifyTwoFactorTokenAsync(int userId, string twoFactorProvider, string token);
        Task<SignInStatus> PasswordSignIn(string userName, string password, bool isPersistent, bool shouldLockout);
        Task<EntityResultBase> RemoveClaimAsync(int userId, Claim claim);
        Task<EntityResultBase> RemoveFromRoleAsync(int userId, string role);
        Task<EntityResultBase> RemoveLoginAsync(int userId, ApplicationUserLoginInfo login);
        Task<EntityResultBase> RemovePasswordAsync(int userId);
        Task<EntityResultBase> RemoveUserFromRolesAsync(int userId, IList<string> roles);
        Task<EntityResultBase> ResetAccessFailedCountAsync(int userId);
        Task<EntityResultBase> ResetPasswordAsync(int userId, string token, string newPassword);
        Task SendEmailAsync(int userId, string subject, string body);
        Task SendSmsAsync(int userId, string message);
        Task SendSmsAsync(ApplicationMessage message);
        Task<bool> SendTwoFactorCode(string provider);
        Task<EntityResultBase> SetEmailAsync(int userId, string email);
        Task<EntityResultBase> SetLockoutEnabledAsync(int userId, bool enabled);
        EntityResultBase SetLockoutEnabled(int userId, bool enabled);
        Task<EntityResultBase> SetLockoutEndDateAsync(int userId, DateTimeOffset lockoutEnd);
        Task<EntityResultBase> SetPhoneNumberAsync(int userId, string phoneNumber);
        Task<EntityResultBase> SetTwoFactorEnabledAsync(int userId, bool enabled);
        Task<SignInStatus> SignInOrTwoFactor(ApplicationUser user, bool isPersistent);
        void SignIn(params ClaimsIdentity[] identities);
        void SignIn(bool isPersistent, params ClaimsIdentity[] identities);
        void SignIn(ApplicationUser user, bool isPersistent, bool rememberBrowser);
        Task SignInAsync(ApplicationUser user, bool isPersistent, bool rememberBrowser);
        void SignOut(params string[] authenticationTypes);
        Task<bool> TwoFactorBrowserRememberedAsync(int userId);
        Task<SignInStatus> TwoFactorSignIn(string provider, string code, bool isPersistent, bool rememberBrowser);
        Task<EntityResultBase> UpdateAsync(int userId);
        Task<EntityResultBase> UpdateSecurityStampAsync(int userId);
        IEnumerable<ApplicationUser> GetUsers();
        Task<IEnumerable<ApplicationUser>> GetUsersAsync();
        Task<bool> VerifyChangePhoneNumberTokenAsync(int userId, string token, string phoneNumber);
        Task<bool> VerifyTwoFactorTokenAsync(int userId, string twoFactorProvider, string token);
        Task<bool> VerifyUserTokenAsync(int userId, string purpose, string token);
        
    }
}