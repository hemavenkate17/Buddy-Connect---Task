using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryTask.Models
{
    public class CustomerReportMonthwise
    {
        public tbl_PurchaseOrder Date { get; set; }
        public tbl_Customer CustomerName { get; set; }
        public tbl_PurchaseOrder Amount { get; set; }

    }
}