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
            }

        }
        private void ClearInputs()
        {
            rdBtnBook.IsChecked = false;
            rdBtnJournal.IsChecked = false;
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
    }
}
