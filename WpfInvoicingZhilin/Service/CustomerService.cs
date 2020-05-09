using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace WpfInvoicingZhilin.Service
{
    class CustomerService : ICustomerService
    {
        void ICustomerService.AddCustomer(Customer customer)
        {
            using (InvoicingZLEntities context = new InvoicingZLEntities())
            {
                context.Customers.AddOrUpdate(customer);
                context.SaveChanges();
            }
        }

        void ICustomerService.DeleteCustomerById(int Id)
        {

            using (InvoicingZLEntities context = new InvoicingZLEntities())
            {
                var customers = from c in context.Customers
                                    where (c.Id == Id)
                                    select c;
                Customer customer = customers.FirstOrDefault();
                context.Customers.Remove(customer);
                context.SaveChanges();
            }
        }

        void ICustomerService.UpdateCustomer(Customer customer)
        {
            using (InvoicingZLEntities context = new InvoicingZLEntities())
            {
                context.Customers.AddOrUpdate(customer);
                context.SaveChanges();
            }

        }

        List<Customer> ICustomerService.GetCustomers()
        {
            List<Customer> customerList = new List<Customer>();
            using (InvoicingZLEntities context = new InvoicingZLEntities())
            {
                var cusList = from c in context.Customers
                                   select c;
                customerList = cusList.ToList();
            }
            return customerList;
        }

        List<Invoice> ICustomerService.GetInvoicesByCustomer(Customer selectedCustomer)
        {
            List<Invoice> invoiceList = new List<Invoice>();

            using (InvoicingZLEntities context = new InvoicingZLEntities())
            {
                invoiceList = context.Invoices.Where(i => (selectedCustomer.Id).Equals(i.Customer.Id)).ToList();                             
            }
            return invoiceList;
        }

        void ICustomerService.SaveInvoice(Invoice invoice)
        {
            using (InvoicingZLEntities context = new InvoicingZLEntities())
            {
                context.Invoices.AddOrUpdate(invoice);
                context.SaveChanges();
            }
        }
    }
}
