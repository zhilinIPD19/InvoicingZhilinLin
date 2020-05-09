﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
    /// Interaction logic for AddInvoice.xaml
    /// </summary>
    public partial class AddInvoice : Window
    {
        //connect to service
        ICustomerService customerService = new CustomerService();
        IItemService itemService = new ItemServise();
        //add filed
        public Customer selectedCustomer = new Customer();
        public List<Item> itemList = new List<Item>();
        public decimal amount = 0;   
        public AddInvoice()
        {
            InitializeComponent();
            CustomerCombo.ItemsSource = customerService.GetCustomers();
            AddItemListGridView.ItemsSource = itemList;
        }
        private void CustomerCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedCustomer = (Customer)CustomerCombo.SelectedItem;
            string txtCusInfos = "ID:"+ selectedCustomer.Id + "  " + selectedCustomer.Name + " Address: 1578 " + selectedCustomer.Address;
            txtCusInfos += selectedCustomer.IsMember? " Is Member" : " Is Not Member" ; 
            this.txtCusInfo.Text = txtCusInfos;
            this.txtCusInfo.Background = Brushes.Yellow;
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
        {   //many to many relationship insert
            using (InvoicingZLEntities context = new InvoicingZLEntities())
            {
                Invoice invoice = new Invoice()
                {
                    Id = int.Parse(txtInvoice.Text),
                    CustomerId = selectedCustomer.Id,
                    SaleDate = dp.SelectedDate.Value.Date,
                    Amount = amount
                };
                context.Invoices.AddOrUpdate(invoice);
                foreach (Item i in itemList)
                {
                    context.Items.AddOrUpdate(i);
                    context.SaveChanges();
                    context.Invoice_Item.AddOrUpdate(new Invoice_Item
                    {
                        InvoiceId = invoice.Id,
                        ItemId = i.Id
                    });
                    context.SaveChanges();
                }
                System.Windows.MessageBox.Show("Saved!!!");
            }
        }
 

        private void OnAdd_Click(object sender, RoutedEventArgs e)
        {
            int Id = Int32.Parse(this.itemId.Text);
            Item item = itemService.GetItemById(Id);
            Item itemInvoicing = new Item()
            {
                Id = Id,
                Name = item.Name,
                Price = item.Price,
                Description = item.Description,
                Qty = Int32.Parse(this.QtyBox.Text)
            };              
            itemList.Add(itemInvoicing);
            AddItemListGridView.Items.Refresh();           
            amount += (decimal)(itemInvoicing.Price) * (decimal)(itemInvoicing.Qty);           
            this.txtAmount.Text = "Total Amout: " + amount;

        }

        private void OnDelete_Click(object sender, RoutedEventArgs e)
        {
            DialogResult result = System.Windows.Forms.MessageBox.Show("Are you sure delete this item?", "Important Query",
             MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                Item item = (Item)AddItemListGridView.SelectedItem;
                amount -= (decimal)(item.Price) * (decimal)(item.Qty);
                itemList.Remove(item);
                AddItemListGridView.Items.Refresh();
                this.txtAmount.Text = "Total Amout: " + amount;
                System.Windows.MessageBox.Show("Delete item!");
            }
        }
    }
}