using Proxies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Contracts;
using System.Data;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        //inserted
        // Configure the message box to be displayed
        string messageBoxText = "Do you want to delete the product?";
        string caption = "Word Processor";
        MessageBoxButton buttonYN = MessageBoxButton.YesNo;
        MessageBoxButton Okbtn = MessageBoxButton.OK;
        //button.IComponentConnector IComponentConnectorYesNO = new IComponentConnector;
        MessageBoxImage icon = MessageBoxImage.Warning;
        string Alert = "woops something when worng try again";
        ProductData selcetion = null;

        //inserted close
        
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TabControl_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
              
            if (selcetion !=null)
            {
               
                txtUDescription.Text = selcetion.productDescription;
                txtUName.Text = selcetion.productName;
                txtUPrice.Text = selcetion.price.ToString();
                txtUQuntity.Text = selcetion.quantity.ToString();
                txtUSupplier.Text = selcetion.supplierID.ToString();
                myTabControl.SelectedItem = editProductTab;
            }

        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            myTabControl.SelectedItem = productMenuTab;

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            myTabControl.SelectedItem = createProductTab;

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            myTabControl.SelectedItem = searchProductTab;

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            myTabControl.SelectedItem = productMenuTab;

        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            myTabControl.SelectedItem = productMenuTab;

        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            myTabControl.SelectedItem = mainMenuTab;

        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(messageBoxText, caption, button, icon);
            if (selcetion !=null)
            {
                ProductClient proxy = new ProductClient();
                ProductData data = selcetion;
                data.viasble = false;
                proxy.setVisibleTofalse(data);
            }
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            myTabControl.SelectedItem = searchProductTab;
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            if(selcetion != null)
            {
                try 
                {
                    ProductClient proxy = new ProductClient();
                    ProductData data = new ProductData();
                    data.price = double.Parse(txtUPrice.Text);
                    data.productID = selcetion.productID;
                    data.productDescription = txtUDescription.Text;
                    data.productName = txtUName.Text;
                    data.quantity = int.Parse(txtUQuntity.Text);
                    data.quantity = int.Parse(txtUSupplier.Text);
                    // take taxt from txtUboxes and save them a productdata send it tho updateProduct close proxy
                    


                    proxy.updateProduct(data);
                    selcetion = null;
                } 
                catch (System.ServiceModel.FaultException)
                {
                    MessageBox.Show(Alert, "Alert",Okbtn, icon);

                    //ProductClient proxy = new ProductClient();
                    //ProductData data = new ProductData();
                    //data.price = double.Parse(txtUPrice.Text);
                    //data.productID = selcetion.productID;
                    //data.productDescription = txtUDescription.Text;
                    //data.productName = txtUName.Text;
                    //data.quantity = int.Parse(txtUQuntity.Text);
                    //data.quantity = int.Parse(txtUSupplier.Text);
                    //take taxt from txtUboxes and save them a productdata send it tho updateProduct close proxy




                    //proxy.updateProduct(data);
                    //selcetion = null;
                } 
              
            }
            
            myTabControl.SelectedItem = searchProductTab;

        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            if (txtPrice !=null && txtName !=null && txtLocation !=null && txtQuantity !=null && txtSupplier !=null && txtDescription !=null)
            {
               
                //do somehitng
                ProductClient proxy = new ProductClient();

                ProductData data = new ProductData();
                data.productName = txtName.Text;
                data.price = double.Parse(txtPrice.Text);
                data.quantity = int.Parse(txtQuantity.Text);
                data.supplierID = int.Parse(txtSupplier.Text);
                data.productDescription = txtDescription.Text;
                data.productID = 0;


                proxy.Insertproduct(data); 
            }
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            myTabControl.SelectedItem = productMenuTab;
        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            myTabControl.SelectedItem = invetoryListTab;
        }

        private void Button_Click_14(object sender, RoutedEventArgs e)
        {
            myTabControl.SelectedItem = productMenuTab;
        }

        private void searchProductTab_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            

        }

        private void LBproductName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void myTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(myTabControl.SelectedItem == editProductTab && dataProducts.SelectedItem !=null)
            {
                
                    var row = (ProductData)dataProducts.SelectedItem;
                    txtDescription.Text = row.productName;
                
            }

            if(myTabControl.SelectedItem == searchProductTab)
            {
                ProductClient proxy = new ProductClient();
               dataProducts.ItemsSource= proxy.GetProducts();
                
                    
                    proxy.Close();
                }
            }

        private void dataProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var row = (ProductData)dataProducts.SelectedItem;
            if (row != null)
            {
                selcetion = row;
            }
        }

        private void setVisible_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(messageBoxText, caption, button, icon);
            if (selcetion != null)
            {
                ProductClient proxy = new ProductClient();
                ProductData data = selcetion;
                data.viasble = false;
                proxy.setVisibleTofalse(data);
            }
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            ProductClient proxy = new ProductClient();
            dataProducts.ItemsSource = proxy.GetlikeProdctNames(txtSearch.Text);
        }
    }
    
}
