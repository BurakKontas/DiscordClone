using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordClone.MessageService.DataAccess.Helpers
{
    public class CassandraHelpers
    {
        public static string ConvertToCassandraTimestamp(DateTime dateTime)
        {
            // ISO 8601 formatına dönüştür
            string iso8601Format = dateTime.ToString("yyyy-MM-ddTHH:mm:ssZ");
            return iso8601Format;
        }
    }
}
