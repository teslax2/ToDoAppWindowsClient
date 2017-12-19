using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoAppWindowsClient.Model;

namespace ToDoAppWindowsClient.ViewModel
{
    public class MainViewModel
    {
        public readonly AmazonCognitoIdentityProviderClient client = new AmazonCognitoIdentityProviderClient();
        public readonly Creditentials creds = new Creditentials();
        public bool LoggedIn { get; set; }
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public MainViewModel()
        {
            creds.Read();
        }

        public async Task<bool> CheckPasswordAsync(string userName, string password)
        {
            try
            {
                var authReq = new AdminInitiateAuthRequest()
                {
                    UserPoolId = creds.UserpoolId,
                    ClientId = creds.ClientId,
                    AuthFlow = AuthFlowType.ADMIN_NO_SRP_AUTH
                };
                authReq.AuthParameters.Add("USERNAME", userName);
                authReq.AuthParameters.Add("PASSWORD", password);

                AdminInitiateAuthResponse authResp = await client.AdminInitiateAuthAsync(authReq);

                return true;
            }
            catch (Exception ex)
            {
                log.Error("couldnt log in" + Environment.NewLine + ex.Message);
                return false;
            }
        }
    }
}
