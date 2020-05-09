using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace WpfInvoicingZhilin.Service
{
    public class ItemServise : IItemService
    {
        void IItemService.AddItem(Item item)
        {
            using (InvoicingZLEntities context = new InvoicingZLEntities())
            {
                context.Items.AddOrUpdate(item);
                context.SaveChanges();            
            }
        }
        void IItemService.UpdateItem(Item item)
        {
            using (InvoicingZLEntities context = new InvoicingZLEntities())
            {
                context.Items.AddOrUpdate(item);
                context.SaveChanges();
            }
        }

        Item IItemService.GetItemById(int id)
        {
            using (InvoicingZLEntities context = new InvoicingZLEntities())
            {
                return context.Items.Where(i => id.Equals(i.Id)).FirstOrDefault();
            }
        }

        List<Item> IItemService.GetItemList()
        {
            List<Item> itemList = new List<Item>();

            using (InvoicingZLEntities context = new InvoicingZLEntities())
            {
                var itList = from c in context.Items
                              select c;
                itemList = itList.ToList();
            }
            return itemList;
        }

        void IItemService.DeleteItemById(int Id)
        {

            using (InvoicingZLEntities context = new InvoicingZLEntities())
            {
                var items = from c in context.Items
                            where (c.Id == Id)
                                select c;
                Item item = items.FirstOrDefault();
                context.Items.Remove(item);
                context.SaveChanges();
            }
        }

        IEnumerable IItemService.GetItemInvoice()
        {
            List<Item> itemList = new List<Item>();

            using (InvoicingZLEntities context = new InvoicingZLEntities())
            {
                var itList = from c in context.Items
                             select c;
                itemList = itList.ToList();
            }
            return itemList;
        }

       
    }
    
}
