using LoginWithSession.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace LoginWithSession.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyDbContext _myDbContext;

        public HomeController(MyDbContext myDbContext)
        {
            this._myDbContext = myDbContext;
        }

        public IActionResult Index()
        {
            var AllDatas = _myDbContext.RegistrationDetails.ToList();
            
            return View(AllDatas);
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(RegistrationDetail userDetails)
        {
           if (ModelState.IsValid)
            {
               _myDbContext.RegistrationDetails.Add(userDetails);
                _myDbContext.SaveChanges();
                TempData["Success"] = "Registration uccessfully";
                return RedirectToAction("Login");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Login(RegistrationDetail user)
        {
            var MyUser = _myDbContext.RegistrationDetails.Where(x => x.Email == user.Email && x.Passwords == user.Passwords).FirstOrDefault();
                if (MyUser != null)
            {
                HttpContext.Session.SetString("UserSession",MyUser.Email) ;
                return RedirectToAction("Dashboard");
            }
            else 
            {
                ViewBag.Message = "Login Failed";
            }
            return View();
        }

        public IActionResult Dashboard()
        {
            if(HttpContext.Session.GetString("UserSession")!=null)
            {
                ViewBag.Mysession = HttpContext.Session.GetString("UserSession");
            }
            else
            {
                return RedirectToAction("Login");
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
