namespace SBC.Services.Identity.Contracts
{
    using SBC.Data.Models;

    public interface IIdentityService
    {
        string GenerateJwt(ApplicationUser user, string secret);
    }
}
