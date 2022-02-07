﻿namespace SBC.Services.Data.Infrastructures
{
    using System.Security.Claims;

    public static class ClaimsPrincipalExtensions
    {
        public static string Id(this ClaimsPrincipal user)
               => user.FindFirst(ClaimTypes.NameIdentifier).Value;
    }
}
