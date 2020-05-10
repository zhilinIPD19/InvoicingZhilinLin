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
    /// Interaction logic for ViewItem.xaml
    /// </summary>
    public partial class ViewItem : Window
    {
        IItemService itemService = new ItemServise();
        public ViewItem()
        {
            InitializeComponent();         
            this.dataGridView.ItemsSource = itemService.GetItemInvoice();
        }
        
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            object item = dataGridView.SelectedItem;
            string setValueForTxtId = (dataGridView.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            string setValueForTxtName = (dataGridView.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
            string setValueForTxtDescription = (dataGridView.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
            string setValueForTxtPrice = (dataGridView.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
            AddItem ec = new AddItem(setValueForTxtId, setValueForTxtName, setValueForTxtDescription, setValueForTxtPrice);
            ec.Show();
            this.Close();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            object item = dataGridView.SelectedItem;
            string id = (dataGridView.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            itemService.DeleteItemById(Int32.Parse(id));
            ViewItem viewCViewItem = new ViewItem(); //create your new form.
            viewCViewItem.Show(); //show the new form.
            this.Close();
        }

        #region MenuClicks
        private void ItemView_Click(object sender, RoutedEventArgs e)
        {
           
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
    }
}
