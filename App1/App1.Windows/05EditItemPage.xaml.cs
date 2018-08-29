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
    public sealed partial class EditItemPage : Page
    {
        Logics logicsData;
        public EditItemPage(Object selectedItem)
        {
            logicsData = Logics.Instance;
            this.InitializeComponent();
            showSelectedItems((AbstractItem)selectedItem);


            
            //add borrow

        }

        public EditItemPage()
        {
            logicsData = Logics.Instance;
            this.InitializeComponent();

            txtBlCategory.Text = logicsData.SelectedItem.Category.ToString();
            if (logicsData.SelectedItem is Book)
            {
                cmbXSubCategory.ItemsSource = Enum.GetValues(typeof(BookCategory));
                cmbXSubCategory.SelectedItem = ((Book)logicsData.SelectedItem).SubCategory;
                txtBxItemBookAuthor.Text = ((Book)logicsData.SelectedItem)._author;
            }
            else if (logicsData.SelectedItem is Journal)
            {
                cmbXSubCategory.ItemsSource = Enum.GetValues(typeof(JournalCategory));
                cmbXSubCategory.SelectedItem = ((Journal)logicsData.SelectedItem).SubCategory;
                HideAuthorData();
            }
            txtBxItemName.Text = logicsData.SelectedItem.itemName;
            txtBxItemPublisher.Text = logicsData.SelectedItem.publisher;
            txtBxItemPrintDate.Text = logicsData.SelectedItem.datePrint.ToString();
            txtBlItemIDValue.Text = logicsData.SelectedItem.isbn.ToString();
            txtBxCopyNumber.Text = logicsData.SelectedItem.copyNumber.ToString();
            cmBxItemBorrowed.Items.Add((true).ToString());
            cmBxItemBorrowed.Items.Add((false).ToString());
            cmBxItemBorrowed.SelectedItem = logicsData.SelectedItem.IsBorrowed.ToString();

        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            showSelectedItems((AbstractItem)e.Parameter);
        }

       

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MenuAdmin));
        }

        private async void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog msgDlg = new MessageDialog("Do you want edit this Item?");
            msgDlg.Commands.Add(new UICommand("Yes"));
            msgDlg.Commands.Add(new UICommand("No"));

            IUICommand selectedCommand = await msgDlg.ShowAsync();
            if (selectedCommand.Label == "Yes")
            {
                DateTime dateprint;
                DateTime.TryParse(txtBxItemPrintDate.Text, out dateprint);
                int copyNumber;
                int.TryParse(txtBxCopyNumber.Text, out copyNumber);
                bool borrowStatus;
                bool.TryParse(cmBxItemBorrowed.SelectedItem.ToString().ToLower(), out borrowStatus);
                logicsData.SelectedItem.Category = logicsData.SelectedItem.Category;
                if (logicsData.SelectedItem is Book)
                {
                    ((Book)logicsData.SelectedItem).SubCategory = (BookCategory)cmbXSubCategory.SelectedItem;
                    ((Book)logicsData.SelectedItem)._author = txtBxItemBookAuthor.Text;
                }
                else if (logicsData.SelectedItem is Journal)
                {
                    ((Journal)logicsData.SelectedItem).SubCategory = (JournalCategory)cmbXSubCategory.SelectedItem;
                }

                logicsData.SelectedItem.itemName = txtBxItemName.Text;
                logicsData.SelectedItem.datePrint = dateprint;
                logicsData.SelectedItem.copyNumber = copyNumber;
                logicsData.SelectedItem.IsBorrowed = borrowStatus;
                logicsData.SelectedItem.publisher = txtBxItemPublisher.Text;
                MessageDialog msgDlgConfirm = new MessageDialog("Item edited successfully !");
                selectedCommand = await msgDlgConfirm.ShowAsync();
            }
            this.Frame.Navigate(typeof(ListofItems));
        }

        public void showSelectedItems(AbstractItem selectedItem)
        {

            //txtBlCategory.Text = selectedItem.category.ToString();
            txtBlCategoryValue.Text = logicsData.SelectedItem.Category.ToString();
            txtBxItemName.Text = selectedItem.itemName.ToString();
            txtBxItemPrintDate.Text = selectedItem.datePrint.ToString();
            txtBxCopyNumber.Text = logicsData.SelectedItem.copyNumber.ToString();
            txtBxItemPublisher.Text = logicsData.SelectedItem.publisher.ToString();
            

        }

        private void HideAuthorData()
        {
            txtBlAuthor.Visibility = Visibility.Collapsed;
            txtBxItemBookAuthor.Visibility = Visibility.Collapsed;
        }
     }
}
