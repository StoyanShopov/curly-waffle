namespace SBC.Services.Identity
{
    public interface IIdentityService
    {
        string GenerateJwt(string secret, string userId, string userName, string role);
    }
}
