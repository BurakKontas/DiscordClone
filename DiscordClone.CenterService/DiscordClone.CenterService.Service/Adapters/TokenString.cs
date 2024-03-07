using DiscordClone.CenterService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DiscordClone.CenterService.Service.Adapters
{
    public static class TokenString
    {
        public static string ToTokenString(this ExtractTokenResponse? response)
        {
            return JsonSerializer.Serialize(response);
        }
    }
}
