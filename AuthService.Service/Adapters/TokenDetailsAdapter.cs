﻿using AuthService.Domain;
using AuthService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Service.Adapters
{
    public static class TokenDetailsAdapter
    {
        public static TokenDetails ToTokenDetails(this ExtractTokenResponse response)
        {
            return new TokenDetails
            {
                Email = response.Email,
                Role = response.Role,
                RoleId = response.RoleId,
                Useruuid = Guid.Parse(response.UserUuid),
                Username = response.Username
            };
        }

        public static ExtractTokenResponse ToExtractTokenResponse(this TokenDetails details)
        {
            return new ExtractTokenResponse
            {
                Email = details.Email,
                Role = details.Role,
                RoleId = details.RoleId ?? 0,
                UserUuid = details.Useruuid.ToString(),
                Username = details.Username
            };
        }
    }
}
