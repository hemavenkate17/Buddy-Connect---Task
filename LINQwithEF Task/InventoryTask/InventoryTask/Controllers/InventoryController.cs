using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryTask.Models;

namespace InventoryTask.Controllers
{
    public class InventoryController : Controller
    {
        // GET: Inventory
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ListOfPurchaseOrderAgainstCustomer()
        {
            InventoryEntities inventoryEntities = new InventoryEntities();
            List<tbl_Product> products = inventoryEntities.tbl_Product.ToList();
            List<tbl_Customer> customers = inventoryEntities.tbl_Customer.ToList();
            List<tbl_PurchaseOrder> purchaseOrders = inventoryEntities.tbl_PurchaseOrder.ToList();
            List<tbl_PurchaseOrderDetail> purchaseOrderDetails = inventoryEntities.tbl_PurchaseOrderDetail.ToList();
            var table1 = from prd in products
                     join POD in purchaseOrderDetails on prd.ProductID equals POD.ProductID
                     join PO in purchaseOrders on POD.POID equals PO.POID
                     join cus in customers on PO.CustomerId equals cus.CustomerID
                     orderby cus.CustomerID
                     select new ListOfPurchase
                     {
                         CustomerName = cus,
                         POID = PO,
                         ProductName = prd,
                         Price = POD
                     };

            return View(table1);
        }

        public ActionResult MonthwiseCustomerReportwithProducts()
        {
            InventoryEntities inventoryEntities = new InventoryEntities();
            List<tbl_Customer> customers = inventoryEntities.tbl_Customer.ToList();
            List<tbl_PurchaseOrder> purchaseOrders = inventoryEntities.tbl_PurchaseOrder.ToList();
            var table2 = from Cus in customers
                         join PO in purchaseOrders on Cus.CustomerID equals PO.CustomerId
                         orderby PO.Date.Value.Month
                         //where PO.Date < Convert.ToDateTime("2020-07-08 00:00:00")
                         //group new {Date =PO.Date} by new { Date = PO.Date.ToString("MMMM")} into g
                          //let cdate = PO.Date.ToString("MMMM")
                          //let tg = new { PO.Date.Value.Month}
                          //group tg by new { PO.Date.Value.Month} into newgrp
                          //orderby tg
                         select new CustomerReportMonthwise
                         {
                             Date= PO,
                             Amount =PO,
                             CustomerName= Cus

                         };

            return View(table2);
        }
        public ActionResult ProductSalesReportMonthwise()
        {
            InventoryEntities inventoryEntities = new InventoryEntities();
            List<tbl_Product> products = inventoryEntities.tbl_Product.ToList();
            List<tbl_PurchaseOrder> purchaseOrders = inventoryEntities.tbl_PurchaseOrder.ToList();
            List<tbl_PurchaseOrderDetail> purchaseOrderDetails = inventoryEntities.tbl_PurchaseOrderDetail.ToList();
            var table3 = from prd in products
                         join POD in purchaseOrderDetails on prd.ProductID equals POD.ProductID
                         join PO in purchaseOrders on POD.POID equals PO.POID
                         orderby PO.Date.Value.Month

                         select new ProductSalesReport
                         {
                             Month = PO,
                             ProductName = prd,
                             Qty = POD
                         };

            return View(table3);
        }
        public ActionResult MaximumOrderPriceOrderandMonthwise()
        {
            InventoryEntities inventoryEntities = new InventoryEntities();
            List<tbl_PurchaseOrder> purchaseOrders = inventoryEntities.tbl_PurchaseOrder.ToList();
            List<tbl_PurchaseOrderDetail> purchaseOrderDetails = inventoryEntities.tbl_PurchaseOrderDetail.ToList();
            // var result = purchaseOrderDetails.OrderByDescending(x => x.Price).FirstOrDefault();
            var table4 = from PO in purchaseOrders
                         join POD in purchaseOrderDetails on PO.POID equals POD.POID
                         group new { PO, POD } by new { PO.Date.Value.Month } into grouped
                         let max = grouped.Max(y => y.POD.Price)
                         orderby max descending
                         let Maxgrp = grouped.FirstOrDefault()
                         let Month = Maxgrp.PO
                         let POID = Maxgrp.PO
                         let Price = Maxgrp.POD

                         select new MaximumOrderPrice
                         {
                             Month = Month,
                             POID = POID,
                             Price = Price
                          };
            return View(table4);
        }

    }
}