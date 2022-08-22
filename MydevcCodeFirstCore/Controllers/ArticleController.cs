using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MydevcCodeFirstCore.Models;
using System.Linq;

namespace MydevcCodeFirstCore.Controllers
{
    public class ArticleController : Controller
    {
        MydevContext context;
        public ArticleController(MydevContext context)
        {
            this.context = context;
        }

        // GET: ArticleController
        public ActionResult Index()
        {
            // var authname = HttpContext.Session.GetString("username");
            var auth = HttpContext.Session.GetInt32("id");
            if (auth == null || auth == 0)
            {
                /*
                ModelState.AddModelError("", "Invalid authntication");
                ViewBag.msg = "Pleaz register or login First";
                return RedirectToAction("Create", "User");
                */
                ViewBag.msg = "Pleaz register or login First";
                return RedirectToAction("Create", "User");
            }
            var articles = context.articles.ToList();
            return View(articles);
        }

        // GET: ArticleController/Details/5
        public ActionResult Details(int id)
        {
            var article = context.articles.Where(i => i.id == id).FirstOrDefault();
            return View(article);
        }

        // GET: ArticleController/Create
        public ActionResult Create()
        {
            var auth = HttpContext.Session.GetInt32("id");
            if (auth == null || auth == 0)
            {
                // ModelState.AddModelError("", "Invalid authntication");
                ViewBag.msg = "Pleaz register or login First";
                return RedirectToAction("Create", "User");
            }
            return View();
        }

        // POST: ArticleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Articles article)
        {
            try
            {
                context.articles.Add(article);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArticleController/Edit/5
        public ActionResult Edit(int id)
        {
            var article = context.articles.Where(i => i.id == id).FirstOrDefault();
            if (article == null)
            {
                return Unauthorized();
            }
            return View(article);
        }

        // POST: ArticleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Articles article)
        {
            try
            {
                var item = context.articles.Where(i => i.id == id).FirstOrDefault();
                item.author = article.author;
                item.body = article.body;
                item.title = article.title;
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArticleController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = context.articles.Where(w => w.id == id).FirstOrDefault();
            return View(model);
        }

        // POST: ArticleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Articles model)
        {
            try
            {
                var model2 = context.articles.Where(w => w.id == model.id).FirstOrDefault();
                context.articles.Remove(model2);
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
