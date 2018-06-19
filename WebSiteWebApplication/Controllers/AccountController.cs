using BookingStoreWebApplication.Models;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace BookingStoreWebApplication.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if(ModelState.IsValid)
            {
                User user = null;
                using (UserContext db = new UserContext())
                {
                    user = db.Users.FirstOrDefault(u => u.Email == model.Login);
                }
                if(user == null)
                {
                    //if repeat password correct
                    if (model.Password == model.RepeatPassword)
                    {
                        //create new user
                        using (UserContext db = new UserContext())
                        {
                            db.Users.Add(new User { Email = model.Login, Password = model.Password });
                            db.SaveChanges();

                            user = db.Users.Where(u => u.Email == model.Login && u.Password == model.Password).FirstOrDefault();
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Password was repeat uncorrectly");
                    }
                    //if user successfully add in db
                    if(user != null)
                    {
                        ModelState.AddModelError("", "User with such login already exists");
                    }
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(model.Login, true);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                //Search user in db
                User user = null;
                using (UserContext db = new UserContext())
                {
                    user = db.Users.FirstOrDefault(u => u.Email == model.Login && u.Password == model.Password);
                }
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Login, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "User with such login and password does not exist");
                }
            }
            return View(model);
        }
    }
}