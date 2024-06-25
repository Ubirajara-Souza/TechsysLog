using Bira.App.TechsysLog.Domain.DTOs.Request;
using Bira.App.TechsysLog.Domain.DTOs.Response;
using Microsoft.AspNetCore.Identity;

namespace Bira.App.TechsysLog.Service.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponse> GenerateJwt(string email);
        Task<SignInResult> Login(LoginUserDto loginUser);
        Task<IdentityResult> Register(RegisterUserDto registerUser);
        Task<IdentityResult> AddClaim(AddClaimDto addClaimDto);
    }
}
