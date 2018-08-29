using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Windows;
using Windows.UI.Popups;
using BookLib;
using UserLogics;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Login : Page
    {
        Logics logicsData;
        public Login()
        {
            logicsData = Logics.Instance;
            this.InitializeComponent();
        }

        private async void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            
            logicsData.LoginUser(usernameBox.Text,passwordBox.Password);
            if (logicsData.IsLoggedIn())
            {
                
                this.Frame.Navigate(typeof(MenuAdmin));
            }
            else
            {
                await new MessageDialog("This user does not exist").ShowAsync();
            }
          
        }
        
       

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void SignUpBTN_Click(object sender, RoutedEventArgs e)
        { 
            //if(UsersCollection.UsersList.Any(u => (u.Username == usernameBox.Text && u.Password==passwordBox.Password)))
            //{
            //    await new MessageDialog("User Already Exists").ShowAsync();
            //}
            //else if ((passwordBox != null)&&(usernameBox != null))
            //{
            //    //UsersCollection.UsersList.Add(new User(usernameBox.Text, passwordBox.Password));
            //    //new MessageDialog("User Added");

            //}
            //else
            //  new MessageDialog("Please Enter an username and a password!", "Attention!");

            this.Frame.Navigate(typeof(SignUpPage));
        }

        private void seeLibBtn_Click(object sender, RoutedEventArgs e)
        {
            logicsData.LoginUser(usernameBox.Text, passwordBox.Password);
            if (logicsData.IsGuest())
            {
                this.Frame.Navigate(typeof(ListofItems));
            }
        }
    }
}

