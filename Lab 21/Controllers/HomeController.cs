using Lab_21.Models;
using System.Web.Mvc;

namespace Lab_21.Controllers
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

        public ActionResult AddUser()
        {
            return View();
        }

        public ActionResult Register(UserInfo newuser)
        {
            //Validation
            
            if (ModelState.IsValid)
            {
                //Insert new user into the database

                ViewBag.Message = $"Hello {newuser.FirstName}";
            return View("result");

    }
    else
    {
    ViewBag.Address = Request.UserHostAddress;
        return View("Error");
        
            
    }
}
}
}