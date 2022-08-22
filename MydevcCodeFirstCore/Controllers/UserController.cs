using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MydevcCodeFirstCore.Models;
using System.Linq;

namespace MydevcCodeFirstCore.Controllers
{
    public class UserController : Controller
    {
        // GET: User

        MydevContext context;
        public UserController(MydevContext context)
        {
            this.context = context;
        }
        public ActionResult Index()
        {
            var user = context.logins.ToList();
            return View(user);
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LogIn user)
        {
            var res = context.logins.Where(w => w.username == user.username && w.email == user.email).Any();
            if (res)
            {
                HttpContext.Session.SetString("username", user.username);
                HttpContext.Session.SetInt32("id", user.id);
                return RedirectToAction("Index", "Article"); // view articles
            }
            ModelState.AddModelError("", "Invalid auth & UserName or password");
            return RedirectToAction("Create");
        }
        // GET: User/Create aKA Register
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LogIn model)
        {
            try
            {
                context.logins.Add(model);
                context.SaveChanges();
                HttpContext.Session.SetString("username", model.username);
                HttpContext.Session.SetInt32("id", model.id);
                return RedirectToAction("Index", "Article"); // view articles
            }
            catch
            {
                return View();
            }
        }

      
        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            var item = context.logins.Where(i => i.id == id).FirstOrDefault();
            return View(item);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var item = context.logins.Where(i => i.id == id).FirstOrDefault();
            return View(item);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LogIn user) 
        {
            // change in content of the model
            try
            {
                var item = context.logins.Where(i => i.id == id).FirstOrDefault();
                item.username = user.username;
                item.password = user.password;
                item.email = user.email;
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            var model = context.logins.Where(w => w.id == id).FirstOrDefault();
            return View(model);
        }

        // POST: User/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(LogIn user)
        {
            try
            {
                var item = context.logins.Where(w => w.id == user.id).FirstOrDefault();
                context.logins.Remove(item);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
