namespace SBC.Services.Data.User
{
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using SBC.Data.Common.Repositories;
    using SBC.Data.Models;
    using SBC.Services.Data.User.Contracts;

    public class UserService : IUserService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> applicationUser;

        public UserService(IDeletableEntityRepository<ApplicationUser> applicationUser)
        {
            this.applicationUser = applicationUser;
        }

        public async Task<bool> UserExistsByEmail(string email)
        {
            var user = await this.applicationUser
                .AllAsNoTracking()
                .FirstOrDefaultAsync(u => u.NormalizedEmail == email.ToUpper());

            return user is not null;
        }
    }
}
