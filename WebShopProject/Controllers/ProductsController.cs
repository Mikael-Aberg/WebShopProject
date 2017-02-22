using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Web.Mvc;
using WebShopProject.DAL;
using WebShopProject.Models;

namespace WebShopProject.Controllers
{
    public class ProductsController : Controller
    {
        private WebShopContext db = new WebShopContext();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.OrderByDescending(x => x.Id).ToList();
            return View(new ProductIndexViewModel { Products = products, Sort = "" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ProductSearchParamaters OldSearchParams, ProductSearchParamaters SearchParams, string search = "", string submit = "Id", string sort = "")
        {
            if (sort.Equals("Id descending")) sort = "Id";

            var products = db.Products.ToList();

            if (search.Equals("Search")) OldSearchParams = SearchParams;

            products = products.Where(x => !(string.IsNullOrWhiteSpace(OldSearchParams.Title)) ? x.Movie.Title.ToLower().Contains(OldSearchParams.Title.ToLower()) : true)
                               .ToList();

            ModelState.Clear();
            if (sort.Equals(submit)) sort = sort + " descending";
            else if (sort.Contains(submit)) sort = submit;
            else sort = submit;

            products = products.OrderBy(sort).ToList();

            return View(new ProductIndexViewModel { Products = products, Sort = sort, OldSearchParams = OldSearchParams, SearchParams = SearchParams });
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.FormatId = new SelectList(db.Formats, "Id", "FormatName");
            ViewBag.MovieId = new SelectList(db.Movies, "Id", "Title");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MovieId,FormatId,Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FormatId = new SelectList(db.Formats, "Id", "FormatName", product.FormatId);
            ViewBag.MovieId = new SelectList(db.Movies, "Id", "Title", product.MovieId);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.FormatId = new SelectList(db.Formats, "Id", "FormatName", product.FormatId);
            ViewBag.MovieId = new SelectList(db.Movies, "Id", "Title", product.MovieId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MovieId,FormatId,Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FormatId = new SelectList(db.Formats, "Id", "FormatName", product.FormatId);
            ViewBag.MovieId = new SelectList(db.Movies, "Id", "Title", product.MovieId);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}