//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfInvoicingZhilin
{
    using System;
    using System.Collections.Generic;
    
    public partial class Invoice_Item
    {
        public int InvoiceId { get; set; }
        public int ItemId { get; set; }
        public int Id { get; set; }
    
        public virtual Invoice Invoice { get; set; }
        public virtual Item Item { get; set; }
    }
}