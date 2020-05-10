using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Interaction logic for AddCustomer.xaml
    /// </summary>
    public partial class AddCustomer : Window
    {
        ICustomerService cs = new CustomerService();
        public AddCustomer()
        {
            InitializeComponent();
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
            AddItem addItem = new AddItem(); //create your new form.
            addItem.Show(); //show the new form.
            this.Close();
        }

        private void InvoiceView_Click(object sender, RoutedEventArgs e)
        {
            ViewInvoice viewInvoice = new ViewInvoice(); //create your new form.
            viewInvoice.Show(); //show the new form.
            this.Close();
        }

        private void CustomerCreate_Click(object sender, RoutedEventArgs e)
        {
            
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
            Customer customer = new Customer()
            {
                Id = Int32.Parse(this.TxtCustomerId.Text),
                Name = this.TxtName.Text,
                Address = this.TxtAddress.Text,
                IsMember = IsMemberCheck.IsChecked.Value           
            };

            cs.AddCustomer(customer);
            MessageBox.Show("Successfully Add customer!");
            ViewCustomer viewCustomer = new ViewCustomer(); //create your new form.
            viewCustomer.Show(); //show the new form.
            this.Close();

        }
    }
}
