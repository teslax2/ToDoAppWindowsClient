using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoAppWindowsClient.Model
{
    public class Creditentials
    {
        public string Region { get; set; }
        public string ClientId { get; set; }
        public string UserpoolId { get; set; }
        public string IdentitypoolId { get; set; }
        public string IdentityProvider { get; set; }
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly string filePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ToDoAppWindowsClient\AwsCredits.txt";

        public Creditentials() { }

        public void Write()
        {
            try
            {
                using (StreamWriter file = File.CreateText(filePath))
                {
                    var serializer = new JsonSerializer();
                    serializer.Serialize(file, this);
                }
            }
            catch (Exception ex)
            {
                log.Error("couldnt save creditentials for aws" + Environment.NewLine + ex.Message);
            }
        }

        public Creditentials Read()
        {
            try
            {
                using (StreamReader file = File.OpenText(filePath))
                {
                    var desrializer = new JsonSerializer();
                    var creds = (Creditentials)desrializer.Deserialize(file, typeof(Creditentials));
                    Region = creds.Region;
                    ClientId = creds.ClientId;
                    UserpoolId = creds.UserpoolId;
                    IdentitypoolId = creds.IdentitypoolId;
                    IdentityProvider = creds.IdentityProvider;
                    return creds;
                }
            }
            catch (Exception ex)
            {
                log.Error("couldnt read creditentials for aws" + Environment.NewLine + ex.Message);
                return new Creditentials();
            }
        }

    }
}
