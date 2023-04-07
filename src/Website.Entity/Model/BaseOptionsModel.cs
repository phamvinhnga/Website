using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Website.Entity.Model
{
    public class FileUploadSettingOptions
    {
        public static string Position { get { return "Upload"; } }
        public string Folder { get; set; }
        public string Url { get; set; }
    }

    public class DbContextConnectionSettingOptions
    {
        public static string Position { get { return "ConnectionString"; } }
        public string DefaultConnection { get; set; }
        public string Server { get; set; }
        public string UserId { get; set; }
        public string Database { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public string Version { get; set; }
    }
}
