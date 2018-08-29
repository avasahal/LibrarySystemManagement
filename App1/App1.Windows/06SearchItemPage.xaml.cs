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
    public sealed partial class SearchItem : Page
    {
        Logics logicsData;
        public SearchItem()
        {
            logicsData = Logics.Instance;
            this.InitializeComponent();
            categoryCmb.ItemsSource = Enum.GetValues(typeof(LibraryCategory));
            if (logicsData.IsAdmin()) searchListView.ItemTemplate = adminData;
            else searchListView.ItemTemplate = visitorData;

        }

        public void InvokeItemDetails()
        {
            string itemName = itemNameTxt.Text;
            string authorName = authorNameTxt.Text;
            DateTime datePrint;
            DateTime.TryParse(datePrintTxt.Text, out datePrint);
            searchListView.ItemsSource = logicsData.SelectItem((LibraryCategory)categoryCmb.SelectedValue, itemName, authorName, datePrint);
        }

        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            InvokeItemDetails();
        }
       
        private AbstractItem GetItemFromSender(object sender)
        {
            return (AbstractItem)((Button)sender).DataContext;
        }

        private async void btnRemoveItem_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog msg = new MessageDialog("Do you want to delete this item?");
            msg.Commands.Add(new UICommand("Yes"));
            msg.Commands.Add(new UICommand("No"));

            IUICommand selectedCommand = await msg.ShowAsync();
            if (selectedCommand.Label == "Yes")
            {
                logicsData.removeItem(GetItemFromSender(sender));
                InvokeItemDetails();
            }
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MenuAdmin));
        }

        private void btnEditItem_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = GetItemFromSender(sender);
            logicsData.SelectedItem = selectedItem;

            this.Frame.Navigate(typeof(EditItemPage), selectedItem);
        }

        private void btnBorrowItem_Click(object sender, RoutedEventArgs e)
        {
            AbstractItem currentItem = GetItemFromSender(sender);
            if (currentItem.IsBorrowed) logicsData.ReturnItem(currentItem);
            else logicsData.BorrowItem(currentItem);
            InvokeItemDetails();
        }

        
    }
}
