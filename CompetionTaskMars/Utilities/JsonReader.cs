using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CompetionTaskMars.Utilities
{
    public static class JsonReader
    {
        public static Credentials GetCredentials()
        {
            var jsonFilePath = "C:\\repo\\CompetionTaskMars\\CompetionTaskMars\\CompetionTaskMars\\TestData\\testData.json"; 
            var jsonData = File.ReadAllText(jsonFilePath);
            return JsonConvert.DeserializeObject<Credentials>(jsonData);
        }
    }

    public class Credentials
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
