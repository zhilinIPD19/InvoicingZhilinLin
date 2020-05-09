using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfInvoicingZhilin.Service
{
    interface ICustomerService
    {
        List<Customer> GetCustomers();
        void AddCustomer(Customer customer);

        void DeleteCustomerById(int Id);

        void UpdateCustomer(Customer customer);
        List<Invoice> GetInvoicesByCustomer(Customer selectedCustomer);
        void SaveInvoice(Invoice invoice);
    }
}
