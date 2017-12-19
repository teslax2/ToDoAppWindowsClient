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
    public class SignUpViewModel
    {
        private readonly AmazonCognitoIdentityProviderClient _client;
        private readonly Creditentials _creds = new Creditentials();
        public bool LoggedIn { get; set; }
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public SignUpViewModel(AmazonCognitoIdentityProviderClient client, Creditentials creds)
        {
            _client = client;
            _creds = creds;
        }

        public async Task SignUp(string password, string username, string email)
        {
            try
            {
                SignUpRequest signUpRequest = new SignUpRequest()
                {
                    ClientId = _creds.ClientId,
                    Password = password,
                    Username = username,
                };
                AttributeType emailAttribute = new AttributeType()
                {
                    Name = "email",
                    Value = email,
                };
                signUpRequest.UserAttributes.Add(emailAttribute);

                var signUpResult = await _client.SignUpAsync(signUpRequest);
            }
            catch (Exception ex)
            {
                log.Error("Couldnt sign up" + Environment.NewLine + ex.Message);
            }
        }

        public async Task Confirm(string userName, string confirmationCode)
        {
            try
            {
                Amazon.CognitoIdentityProvider.Model.ConfirmSignUpRequest confirmRequest = new ConfirmSignUpRequest()
                {
                    Username = userName,
                    ClientId = _creds.ClientId,
                    ConfirmationCode = confirmationCode,
                };

                var confirmResult = await _client.ConfirmSignUpAsync(confirmRequest);
            }
            catch (Exception ex)
            {
                log.Error("Couldnt confirm creditentials" + Environment.NewLine + ex.Message);
            }
        }
    }
}
