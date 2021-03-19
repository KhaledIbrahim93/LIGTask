using LIGWebApp.AuthFilters;
using ProductManagment.BAL.DTO;
using ProductManagment.BAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LIGWebApp.Controllers
{
    [GlobalAuthrization]
    public class ProductController : Controller
    {
        readonly IProductRepository _repo;
        public ProductController(IProductRepository repo)
        {
            _repo = repo;
        }
        // GET: Product
        public ActionResult Index()
        {
            var entity = _repo.GetAll();
            return View(entity);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            var entity = _repo.GetById(id);
            return View(entity);
        }

        // GET: Product/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(ProductVM product)
        {
            try
            {
                // TODO: Add insert logic here
                _repo.Insert(product);
                _repo.Save();
				return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var entity = _repo.GetById(id);
            return View(entity);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(ProductVM product)
        {
            try
            {
                _repo.Update(product);
                _repo.Save();
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            var entity = _repo.GetById(id);
            return View(entity);
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(ProductVM product)
        {
            try
            {
                // TODO: Add delete logic here
                _repo.Delete(product);
                _repo.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult ArchiveProduct(List<int> ids)
        {
            try
            {
                // TODO: Add delete logic here
                _repo.ArchiveProduct(ids);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult SearchProductWithDate(DateTime date)
		{
         var entity=  _repo.SearchWithDate(date);
            return View("Index", entity);
        } 
    }
}
