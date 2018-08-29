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
    public sealed partial class AddItemPage : Page
    {
        Logics logicsData;
        public AddItemPage()
        {
            logicsData = Logics.Instance;
            this.InitializeComponent();
            AuthorUnreveal();
        }

        private async void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog msg = new MessageDialog("Do you want to add a new item?");
            msg.Commands.Add(new UICommand("Yes"));
            msg.Commands.Add(new UICommand("No"));

            IUICommand selectedCommand = await msg.ShowAsync();
            if(selectedCommand.Label=="Yes")
            {
                DateTime printDate;
                int copyNumber;
                DateTime.TryParse(txtBxItemPressDate.Text, out printDate);
                int.TryParse(txtBxCopyNumber.Text, out copyNumber);

                if(rdBtnBook.IsChecked== true)
                {
                    logicsData.addBookItem(
                        (BookCategory)cmbXSubCategory.SelectedValue,
                        txtBxItemName.Text,
                        txtBxItemBookAuthor.Text,
                        txtBxItemPublisher.Text,
                        printDate,
                        copyNumber);
                }
                else if(rdBtnJournal.IsChecked==true)
                {
                    logicsData.addJournalItem (
                        (JournalCategory)cmbXSubCategory.SelectedValue,
                        txtBxItemName.Text,
                        txtBxItemPublisher.Text,
                        printDate,
                        copyNumber
                        );
                }
                ClearInputs();
                this.Frame.Navigate(typeof(ListofItems));
            }

        }
        private void ClearInputs()
        {
            rdBtnBook.IsChecked = false;
            rdBtnJournal.IsChecked = false;
            cmbXSubCategory.SelectedIndex = -1;
            txtBxItemName.Text = "";
            txtBxItemPressDate.Text = "";
            txtBxCopyNumber.Text = "";
            txtBxItemPublisher.Text = "";
            txtBxItemBookAuthor.Text = "";
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MenuAdmin));
        }

      
        private void rdBtn_Checked(object sender, RoutedEventArgs e)
        {
            if(rdBtnBook.IsChecked==true)
            {
                cmbXSubCategory.ItemsSource = Enum.GetValues(typeof(BookCategory));
                AuthorReveal();
            }
            if(rdBtnJournal.IsChecked==true)
            {
                cmbXSubCategory.ItemsSource = Enum.GetValues(typeof(JournalCategory));
            }
        }

        private void AuthorReveal()
        {
            txtBlAuthor.Visibility = Visibility.Visible;
            txtBxItemBookAuthor.Visibility = Visibility.Visible;
        }

        private void rdBtnBook_Unchecked(object sender, RoutedEventArgs e)
        {
            if(rdBtnBook.IsChecked==false)
            {
                AuthorUnreveal();
            }
        }

        private void AuthorUnreveal()
        {
            txtBlAuthor.Visibility = Visibility.Collapsed;
            txtBxItemBookAuthor.Visibility = Visibility.Collapsed;
        }
    }
}
