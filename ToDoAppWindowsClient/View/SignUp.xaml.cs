using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ToDoAppWindowsClient.View
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        private readonly string _clientId = ConfigurationManager.AppSettings["CLIENT_ID"];
        private readonly string _poolId = ConfigurationManager.AppSettings["USERPOOL_ID"];
        private AmazonCognitoIdentityProviderClient _client;

        public SignUp(AmazonCognitoIdentityProviderClient client)
        {
            InitializeComponent();

            _client = client;
        }

        public SignUp()
        {
            InitializeComponent();
        }

        private async void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SignUpRequest signUpRequest = new SignUpRequest()
                {
                    ClientId = _clientId,
                    Password = PasswordTextBox.Password,
                    Username = UserNameTextBox.Text
                };
                AttributeType emailAttribute = new AttributeType()
                {
                    Name = "email",
                    Value = EmailTextBox.Text
                };
                signUpRequest.UserAttributes.Add(emailAttribute);

                var signUpResult = await _client.SignUpAsync(signUpRequest);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                MessageBox.Show(message, "Sign Up Error");
            }
        }

        private async void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Amazon.CognitoIdentityProvider.Model.ConfirmSignUpRequest confirmRequest = new ConfirmSignUpRequest()
                {
                    Username = UserNameTextBox.Text,
                    ClientId = _clientId,
                    ConfirmationCode = ConfirmationTextBox.Text
                };

                var confirmResult = await _client.ConfirmSignUpAsync(confirmRequest);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                MessageBox.Show(message, "Sign Up Error");
            }
        }
    }
}
