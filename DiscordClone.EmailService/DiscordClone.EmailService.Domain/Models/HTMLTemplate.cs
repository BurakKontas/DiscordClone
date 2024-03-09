using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordClone.EmailService.Domain.Models
{
    public class HTMLTemplate
    {
        public string HTML { get; set; }

        public HTMLTemplate(string fileName)
        {
            var filePath = "/app/EmailTemplates/";
            fileName = filePath + fileName + ".html";
            //check if file exists
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException("File not found", fileName);
            }
            HTML = File.ReadAllText(fileName);
        }

        public void ChangeValue(string key, string value)
        {
            HTML = HTML.Replace("{{" + key + "}}", value);
        }
    }

}
