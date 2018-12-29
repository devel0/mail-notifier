using System;
using System.IO;
using static System.Environment;

namespace mail_notifier
{

    public class Config
    {

        public static string Pathfilename
        {
            get
            {
                var dir = Path.Combine(System.Environment.GetFolderPath(SpecialFolder.ApplicationData), "mail-notifier");
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

                return Path.Combine(dir, "config.json");
            }
        }

        public static Config Load()
        {
            if (!File.Exists(Pathfilename))
            {
                throw new Exception($"could't find config file [{Pathfilename}]");
            }
            if (!LinuxHelper.IsFilePermissionSafe(Pathfilename))
            {
                throw new Exception($"file [{Pathfilename}] must 700 mode");
            }
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Config>(File.ReadAllText(Pathfilename));
        }

        public string login { get; set; }
        public string password { get; set; }
        public string smtpserver { get; set; }
        public int smtpport { get; set; }
        public bool sslmode { get; set; }

    }

}