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
using ToDoAppWindowsClient.Model;
using ToDoAppWindowsClient.ViewModel;

namespace ToDoAppWindowsClient.View
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        SignUpViewModel _viewModel;

        public SignUp(AmazonCognitoIdentityProviderClient client, Creditentials creds)
        {
            InitializeComponent();
            _viewModel = new SignUpViewModel(client, creds);
        }

        public SignUp()
        {
            InitializeComponent();
        }

        private async void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            await _viewModel.SignUp(PasswordTextBox.Password, UserNameTextBox.Text, EmailTextBox.Text);
        }

        private async void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            await _viewModel.Confirm(UserNameTextBox.Text, ConfirmationTextBox.Text);
        }
    }
}
