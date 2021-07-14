using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryTask.Models
{
    public class MaximumOrderPrice
    {
        public tbl_PurchaseOrder Month { get; set; }
        public tbl_PurchaseOrder POID { get; set; }
        public tbl_PurchaseOrderDetail Price { get; set; }

    }
}