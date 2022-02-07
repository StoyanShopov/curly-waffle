namespace SBC.Services.Identity.Contracts
{
    public interface IIdentityService
    {
        string GenerateJwt(string secret, string userId, string userName, string role);
    }
}
