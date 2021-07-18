using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee.Model;
using Microsoft.AspNetCore.Mvc;

namespace Employee
{
    public class HomeController : Controller
    {
       public IActionResult Index()
        {
            return View();
        }

        public JsonResult SaveEmpInfo(EmployeeModel employee)
        {
            List<string> Email = new List<string>();
            Email.Add("hema17@gmail.com");
            Email.Add("vino02@gmail.com");
            Email.Add("deep18@gmail.com");
            Email.Add("jaya27@gmail.com");
            Email.Add("kanaga12@gmail.com");
            Email.Add("venkate24@gmail.com");
            Email.Add("relwan08@gmail.com");
            Email.Add("aishu01@gmail.com");
            Email.Add("vidya29@gmail.com");

            var IsExists = Email.Contains(employee.Email);
            if(IsExists)
            {
                //Db call for saving the data
                return Json(new { msg = "success", data = employee });
            }
           
                return Json(new { msg = "InvalidEmail" });

            
        }
           
    }
}
