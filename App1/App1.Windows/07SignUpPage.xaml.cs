using BookLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UserLogics;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SignUpPage : Page
    {
        Logics logicsData;

        public SignUpPage()
        {
            logicsData = Logics.Instance;
            this.InitializeComponent();
            userTypeCmbBx.ItemsSource= Enum.GetValues(typeof(UserType));
        }

        private void returnToLogBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Login));
        }

        private async void addUserBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog msg = new MessageDialog("Do you want to add a new user?");
            msg.Commands.Add(new UICommand("Yes"));
            msg.Commands.Add(new UICommand("No"));

            IUICommand selectedCommand = await msg.ShowAsync();
            if (selectedCommand.Label == "Yes")
            {
                logicsData.addNewUser(
                    firstNameTxtBx.Text, 
                    lastNameTxtBx.Text, 
                    usernameTxtBx.Text, 
                    emailTxtBx.Text,
                    passwordTxtBx.Password, 
                    (UserType)userTypeCmbBx.SelectedValue
                    );
            }
            ClearInputs();
            this.Frame.Navigate(typeof(Login));
        }
        private void ClearInputs()
        {
            firstNameTxtBx.Text = "";
            lastNameTxtBx.Text = "";
            usernameTxtBx.Text = "";
            emailTxtBx.Text = "";
            passwordTxtBx.Password = "";
            userTypeCmbBx.SelectedIndex = -1;
        }
    }
}
