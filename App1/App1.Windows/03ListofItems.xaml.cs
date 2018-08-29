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
    public sealed partial class ListofItems : Page
    {
        Logics logicsData;
        

        public ListofItems()
        {
            logicsData = Logics.Instance;
            this.InitializeComponent();
            allItemsListView.ItemsSource = logicsData.GetAllLibraryItems();
            HideOption();
        
        }
        private void HideOption()
        {
            if (logicsData.IsAdmin())
            {
                addBtnLink.Visibility = Visibility.Visible;
                editBtnLink.Visibility = Visibility.Visible;
                deleteBtn.Visibility = Visibility.Visible;
            }

            else if (logicsData.IsUser())
            {
                addBtnLink.Visibility = Visibility.Visible;
                editBtnLink.Visibility = Visibility.Collapsed;
                deleteBtn.Visibility = Visibility.Collapsed;
            }
            else if (logicsData.IsGuest())
            {
                addBtnLink.Visibility = Visibility.Collapsed;
                editBtnLink.Visibility = Visibility.Collapsed;
                deleteBtn.Visibility = Visibility.Collapsed;
            }
        }


        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MenuAdmin));
        }

        private void addBtnLink_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddItemPage));
        }

        private async void editBtnLink_Click(object sender, RoutedEventArgs e)
        {
            Object selectedItem = allItemsListView.SelectedItem;

            if (selectedItem != null)
            {
                MessageDialog msg = new MessageDialog("Are you sure to edit this item?");
                msg.Commands.Add(new UICommand("Yes"));
                msg.Commands.Add(new UICommand("No"));

                IUICommand selectedCommand = await msg.ShowAsync();
                if (selectedCommand.Label == "Yes")
                {

                    logicsData.SelectedItem = (AbstractItem)selectedItem;

                    this.Frame.Navigate(typeof(EditItemPage), selectedItem);
                    
                }
            }
            else
            {
                await new MessageDialog("Please select an item to edit!", "No item selected").ShowAsync();
            }
        }



        private async void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (allItemsListView.SelectedItem != null)
            {
                MessageDialog msg = new MessageDialog("Are you sure to delete this item?");
                msg.Commands.Add(new UICommand("Yes"));
                msg.Commands.Add(new UICommand("No"));

                IUICommand selectedCommand = await msg.ShowAsync();
                if (selectedCommand.Label == "Yes")
                {
                    logicsData.SelectedItem = (AbstractItem)allItemsListView.SelectedItem;
                    logicsData.removeItem((AbstractItem)allItemsListView.SelectedItem);
                    allItemsListView.ItemsSource = logicsData.GetAllLibraryItems();
                }
            }
            else
            {
                await new MessageDialog("Please select an item to delete!", "No item selected").ShowAsync();
            }
        }

        private async void borrowReturnBTN_Click(object sender, RoutedEventArgs e)
        {
            Object selectedItem = allItemsListView.SelectedItem;
            if (selectedItem != null)
            {
                MessageDialog msg = new MessageDialog("Are you sure to borrow or return this item?");
                msg.Commands.Add(new UICommand("Yes"));
                msg.Commands.Add(new UICommand("No"));

                IUICommand selectedCommand = await msg.ShowAsync();
                if (selectedCommand.Label == "Yes")
                {
                    logicsData.SelectedItem = (AbstractItem)allItemsListView.SelectedItem;

                    if ((logicsData.SelectedItem).IsBorrowed == false)
                    {
                        logicsData.BorrowItem((AbstractItem)allItemsListView.SelectedItem);
                    }
                    else
                    {
                        logicsData.ReturnItem((AbstractItem)allItemsListView.SelectedItem);
                    }
                    allItemsListView.ItemsSource = logicsData.GetAllLibraryItems();

                }
            }
            else
            {
                await new MessageDialog("Please select an item to borrow or return!", "No item selected").ShowAsync();
            }
        }

      

        
    }
}
