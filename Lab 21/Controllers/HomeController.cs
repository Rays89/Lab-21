using System.Linq;
using System.Web.Mvc;
using Lab_21.Models;


namespace Lab_21.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();

            ViewBag.Items = ORM.Items.ToList();

            return View();
        }

        public ActionResult About()

        {
            //1. create an ORM object
            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();

            ViewBag.UserList = ORM.Users.ToList();
            

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

        public ActionResult Register(User newuser)
        {
            //1. create the ORM 
            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();

            if (ModelState.IsValid)
            {
                

                //2.Insert new user into the database

                ORM.Users.Add(newuser);
                
                //3.save changes to the DB
                ORM.SaveChanges();

                ViewBag.UserList = ORM.Users.ToList();

                ViewBag.Message = $"Hello, Thank you for registering {newuser.FirstName}";
                return View("result");

            }
            else
            {
                ViewBag.Address = Request.UserHostAddress;
                return View("Error");


            }
        }

        public ActionResult searchByEmail(string Email)
        {
            //1. create the ORM
            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();

            ViewBag.UserList = ORM.Users.Where(c => c.Email.Contains(Email)).ToList();

            return View("About");
        }

        public ActionResult DeleteUser(string Email)
        {
            //1. create ORM
            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();

            //2. Find the user you want to delete
            User Found = ORM.Users.Find(Email);

            //3. Remove the user
            if (Found !=null)
            {
                ORM.Users.Remove(Found);

                //4. save to the DB
                ORM.SaveChanges();

                return RedirectToAction("About");

            }
            else
            {
                ViewBag.Error.Message = "User not found";
                return View("Error");
            }
            
        }

        public ActionResult ShowUserDetails(string Email)
        {
            //1. create ORM
            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();

            //2. find the user
            User Found = ORM.Users.Find(Email);

            //3. send the data to a view
            if (Found !=null)
            {
                return View(Found);
            }
            else
            {
                ViewBag.ErrorMessage = "User not found";
                return View("Error");
            }
        }

        public ActionResult SaveUserUpdates(User updatedUser)
        {
            //1. create the ORM

            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();

            //2. Find the User

            User oldUserRecord = ORM.Users.Find(updatedUser.Email);
            if (oldUserRecord != null && ModelState.IsValid)
            {
                //3. Update the exisiting user

                oldUserRecord.FirstName = updatedUser.FirstName;
                oldUserRecord.LastName = updatedUser.LastName;
                oldUserRecord.Email = updatedUser.Email;
                oldUserRecord.PhoneNumber = updatedUser.PhoneNumber;
                oldUserRecord.Password = updatedUser.Password;

                ORM.Entry(oldUserRecord).State = System.Data.Entity.EntityState.Modified;

                //4. save back to the DB
                ORM.SaveChanges();
                return RedirectToAction("About");

            }
            else
            {
                ViewBag.ErrorMessage = "Hooray! something went wrong!";
                return View("Error");
            }
        }
    }
}