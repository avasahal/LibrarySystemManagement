using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UserLogics;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class MenuAdmin : Page
    {
        Logics logicsData;
        public MenuAdmin()
        {
            logicsData = Logics.Instance;
            this.InitializeComponent();
            ShowOption();
        }

        private void ShowOption()
        {
            if (logicsData.IsAdmin())
            {
                addBtn.Visibility = Visibility.Visible;
                editBtn.Visibility = Visibility.Visible;
                deleteBtn.Visibility = Visibility.Visible;
            }
            else
            {
                addBtn.Visibility = Visibility.Collapsed;
                editBtn.Visibility = Visibility.Collapsed;
                deleteBtn.Visibility = Visibility.Collapsed;
            }
        }
        private void logoutBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Login));
        }

        private void allItemsBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ListofItems));
        }
    }
}
