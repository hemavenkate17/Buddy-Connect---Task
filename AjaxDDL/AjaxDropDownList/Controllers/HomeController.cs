using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AjaxDropDownList.Models;

namespace AjaxDropDownList.Controllers
{
    public class HomeController : Controller
    {
        private DropdownAjaxEntities DbEntities= new DropdownAjaxEntities();
        public ActionResult Index()
        {
            ViewBag.countries = DbEntities.tbl_Country.ToList();
            return View();
        }
        public ActionResult GetStates(int countryId)
        {
            return Json(DbEntities.tbl_State.Where(s => s.CId == countryId).Select(
                s => new
                {
                    Id = s.StateID,
                    Name = s.Name

                }).ToList(), JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetDistricts(int StateId)
        {
            return Json(DbEntities.tbl_District.Where(d => d.SId == StateId).Select(
                d => new
                {
                    Id = d.DistricID,
                    Name = d.Name

                }).ToList(), JsonRequestBehavior.AllowGet);

        }
    }
}