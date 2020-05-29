using System.Security.Claims;
using Microsoft.Owin;
using DAL.Models;
using BLL.Contracts;

namespace html.Interfaces
{
    public interface IAuthenticationService
    {
        void OwinCookieAuthentication(IOwinContext owinContext, ClaimsIdentity claim);

        ClaimsIdentity ClaimTypesСreation(UserDto userDto);
    }
}
