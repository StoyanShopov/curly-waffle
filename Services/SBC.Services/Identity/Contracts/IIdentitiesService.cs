namespace SBC.Services.Identity.Contracts
{
    public interface IIdentitiesService
    {
        string GenerateJwt(string secret, string userId, string userName, string role);
    }
}
