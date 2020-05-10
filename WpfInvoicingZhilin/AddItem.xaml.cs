using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfInvoicingZhilin.Service;

namespace WpfInvoicingZhilin
{
    /// <summary>
    /// Interaction logic for AddItem.xaml
    /// </summary>
    public partial class AddItem : Window
    {
        IItemService itemservice = new ItemServise();


        public AddItem()
        {
            InitializeComponent();

        }

        public AddItem(string setValueForTxtId, string setValueForTxtName, string setValueForTxtDescription, string setValueForTxtPrice)
        {
            InitializeComponent();
            
            this.TxtId.Text = setValueForTxtId;
            this.TxtDescription.Text = setValueForTxtDescription;
            this.TxtName.Text = setValueForTxtName;
            this.TxtPrice.Text= setValueForTxtPrice;
        }


        #region MenuClicks
        private void ItemView_Click(object sender, RoutedEventArgs e)
        {
            ViewItem viewItem = new ViewItem(); //create your new form.
            viewItem.Show(); //show the new form.
            this.Close();
        }

        private void ItemCreate_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void InvoiceView_Click(object sender, RoutedEventArgs e)
        {
            ViewInvoice viewInvoice = new ViewInvoice(); //create your new form.
            viewInvoice.Show(); //show the new form.
            this.Close();
        }

        private void CustomerCreate_Click(object sender, RoutedEventArgs e)
        {
            AddCustomer addcus = new AddCustomer(); //create your new form.
            addcus.Show(); //show the new form.
            this.Close();
        }

        private void CustomerView_Click(object sender, RoutedEventArgs e)
        {
            ViewCustomer viewcus = new ViewCustomer(); //create your new form.
            viewcus.Show(); //show the new form.
            this.Close();
        }

        private void InvoiceCreate_Click(object sender, RoutedEventArgs e)
        {
            AddInvoice addInvoice = new AddInvoice(); //create your new form.
            addInvoice.Show(); //show the new form.
            this.Close();
        }

        private void HomePage_Click(object sender, RoutedEventArgs e)
        {
            AddInvoice addInvoice = new AddInvoice(); //create your new form.
            addInvoice.Show(); //show the new form.
            this.Close();
        }
        #endregion


        private void OnSave_Click(object sender, RoutedEventArgs e)
        {
            Item item = new Item()
            {
                Id = Int32.Parse(this.TxtId.Text),
                Name = this.TxtName.Text,
                Description = this.TxtDescription.Text,
                Price = Decimal.Parse(this.TxtPrice.Text)
            };

            itemservice.AddItem(item);
            MessageBox.Show("Successfully Edit Item!");
            ViewItem viewItem = new ViewItem(); //create your new form.
            viewItem.Show(); //show the new form.
            this.Close();
        }
    }
}

