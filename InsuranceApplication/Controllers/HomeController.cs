using InsuranceApplication.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace InsuranceApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Customer customers)
        {
            if(ModelState.IsValid)
            {
                CustomerDBEntities db = new CustomerDBEntities();
                if(customers.Password==customers.ConfirmPassword)
                {
                    db.Customers.Add(customers);
                    db.SaveChanges();
                    ViewBag.RegistrationSuccessful = "Registration Successfull";
                }
                 else
                {
                    ViewBag.RegistrationSuccessful = "Both passwords are not same. Registration UnSuccessfull";
                }
            }
           
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Customer customers)
        {
           
                CustomerDBEntities db = new CustomerDBEntities();
                var isValidUser = IsValidUser(customers);

                if (isValidUser != null)
                {               
      
                    return RedirectToAction("Index");
                }

            
            return View();
        }


        public Customer IsValidUser(Customer model)
        {
            using (var dataContext = new CustomerDBEntities())
            {
              
                Customer user = dataContext.Customers.Where(query => query.Email.Equals(model.Email) && query.Password.Equals(model.Password)).FirstOrDefault();
             
                if (user == null)
                    return null;
                
                else
                    return user;
            }


            }

    }
}