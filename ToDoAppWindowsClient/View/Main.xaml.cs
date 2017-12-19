using System;
using System.Collections.Generic;
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
using Amazon;
using Amazon.Runtime;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using System.Configuration;
using ToDoAppWindowsClient.ViewModel;

namespace ToDoAppWindowsClient.View
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        private MainViewModel _viewModel = new MainViewModel();
        public Main()
        {
            InitializeComponent();
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            SignUp signUpDlg = new SignUp(_viewModel.client, _viewModel.creds);
            signUpDlg.ShowDialog();
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.LoggedIn = await _viewModel.CheckPasswordAsync(UserNameTextBox.Text, PasswordTextBox.Password);
        }

    }
}
