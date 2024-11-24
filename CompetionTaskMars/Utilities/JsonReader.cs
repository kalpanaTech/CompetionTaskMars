using Newtonsoft.Json;
using CompetionTaskMars.Model;
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
        public static List<EducationCredentials> GetCredentialsList(string jsonFilePath)
        {
            var jsonData = File.ReadAllText(jsonFilePath);
            return JsonConvert.DeserializeObject<List<EducationCredentials>>(jsonData);
        }

        public static List<SignInCreadentials> GetSignInCredentialsList(string jsonFilePath)
        {
            var jsonData = File.ReadAllText(jsonFilePath);
            return JsonConvert.DeserializeObject<List<SignInCreadentials>>(jsonData);
        }

        public static List<CertificationCredentials> GetCertificationCredentialsList(string jsonFilePath)
        {
            var jsonData = File.ReadAllText(jsonFilePath);
            return JsonConvert.DeserializeObject<List<CertificationCredentials>>(jsonData);
        }
    }
}
