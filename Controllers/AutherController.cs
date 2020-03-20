using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using BookStore.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class AutherController : Controller
    {
        private readonly iBookStoreRepository<Auther> autherReposetory;

        public AutherController(iBookStoreRepository<Auther> autherReposetory)
        {
            this.autherReposetory = autherReposetory;
        }
        
        // GET: Auther
        public ActionResult Index()
        {
            var authers = autherReposetory.List();
            return View(authers);
        }

        // GET: Auther/Details/5
        public ActionResult Details(int id)
        {
            var auther = autherReposetory.Find(id);
            return View(auther);
        }

        // GET: Auther/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Auther/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Auther auther)
        {
            try
            {
                // TODO: Add insert logic here
                autherReposetory.Add(auther);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Auther/Edit/5
        public ActionResult Edit(int id)
        {
            var auther = autherReposetory.Find(id);
            return View(auther);
        }

        // POST: Auther/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Auther auther)
        {
            try
            {
                // TODO: Add update logic here
                autherReposetory.Update(id, auther);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Auther/Delete/5
        public ActionResult Delete(int id)
        {
            var auther = autherReposetory.Find(id);
            return View(auther);
        }

        // POST: Auther/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Auther auther)
        {
            try
            {
                // TODO: Add delete logic here
                autherReposetory.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}