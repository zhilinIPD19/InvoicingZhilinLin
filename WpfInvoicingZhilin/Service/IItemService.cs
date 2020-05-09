using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfInvoicingZhilin.Service
{
    interface IItemService
    {
        List<Item> GetItemList();
        void AddItem(Item item);
        Item GetItemById(int id);
        void UpdateItem(Item item);
        IEnumerable GetItemInvoice();
        void DeleteItemById(int v);
  
    }
}
