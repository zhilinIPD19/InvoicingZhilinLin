using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfInvoicingZhilin.Service;

namespace WpfInvoicingZhilin
{
    /// <summary>
    /// Interaction logic for ViewCustomer.xaml
    /// </summary>
    public partial class ViewCustomer : Window
    {
        ICustomerService cs = new CustomerService();
        
        public ViewCustomer()
        {
            InitializeComponent();
            this.dataGridView.ItemsSource = cs.GetCustomers();
        }
       
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            object item = dataGridView.SelectedItem;
          
            string setValueForTxtId = (dataGridView.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            string setValueForTxtName = (dataGridView.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
            string setValueForTxtAddress = (dataGridView.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
            string setValueForTxtIsMemership = (dataGridView.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
            EditCustomer ec = new EditCustomer(setValueForTxtId, setValueForTxtName, setValueForTxtAddress, setValueForTxtIsMemership);
            this.Close();
            ec.Show();
            
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            DialogResult result = System.Windows.Forms.MessageBox.Show("Are you sure delete this customer?", "Important Query",
             MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                object customer = dataGridView.SelectedItem;
                string id = (dataGridView.SelectedCells[0].Column.GetCellContent(customer) as TextBlock).Text;
                cs.DeleteCustomerById(Int32.Parse(id));
                ViewCustomer viewCustomer = new ViewCustomer(); //create your new form.
                viewCustomer.Show(); //show the new form.
                this.Close();
            }
        }

        private void CustomerListDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var grid = sender as System.Windows.Controls.DataGrid;
            var selected = grid.SelectedItems[0];
            
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
            AddCustomer addcus = new AddCustomer(); //create your new form.
            addcus.Show(); //show the new form.
            this.Close();
        }

        private void CustomerView_Click(object sender, RoutedEventArgs e)
        {
         
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
    }
}
