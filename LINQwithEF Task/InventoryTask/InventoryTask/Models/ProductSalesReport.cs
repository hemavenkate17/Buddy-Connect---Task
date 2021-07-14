using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryTask.Models
{
    public class ProductSalesReport
    {
        public tbl_PurchaseOrder Month{ get; set; }
        public tbl_Product ProductName { get; set; }
        public tbl_PurchaseOrderDetail Qty{ get; set; }

    }
}