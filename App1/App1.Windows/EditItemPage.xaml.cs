using BookLib;
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
    public sealed partial class EditItemPage : Page
    {
        Logics logicsData;
        public EditItemPage(Object selectedItem)
        {
            logicsData = Logics.Instance;
            this.InitializeComponent();
            showSelectedItems((AbstractItem)selectedItem);
            //showSelectedItems();


        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            showSelectedItems((AbstractItem)e.Parameter);
        }

        public EditItemPage()
        {
            logicsData = Logics.Instance;
            this.InitializeComponent();
            //showSelectedItems((AbstractItem)selectedItem);
            //showSelectedItems();


        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MenuAdmin));
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        public void showSelectedItems(AbstractItem selectedItem)
        {

            txtBlCategory.Text = selectedItem.category.ToString();
            //cmbXSubCategory.SelectedValue = 
            txtBxItemName.Text = selectedItem.itemName.ToString();
            txtBxItemPressDate.Text = selectedItem.datePrint.ToString();
            //txtBxCopyNumber.Text = logicsData.SelectedItem.copyNumber.ToString();
            //txtBxItemPublisher.Text = logicsData.SelectedItem.publisher.ToString();
            //txtBxItemBookAuthor.Text=logicsData.SelectedItem.

        }
     }
}
