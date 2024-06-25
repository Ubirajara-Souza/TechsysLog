using Bira.App.TechsysLog.Domain.DTOs.Request;

namespace Bira.App.TechsysLog.Domain.DTOs.Response
{
    public class LoginResponse
    {
        public string? AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public UserTokenDto UserToken { get; set; }
    }
}
