﻿namespace SBC.Services.Data.User
{
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Web.ViewModels.User;

    public interface IUsersService
    {
        Task<Result> Register(RegisterServiceModel model);

        Task<Result> Login(LoginServiceModel model, string secret);

        Task<bool> NoTrackUserExistsByEmail(string email);
    }
}