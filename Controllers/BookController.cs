using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using BookStore.Models.Repositories;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly iBookStoreRepository<Book> bookRepository;
        private readonly iBookStoreRepository<Auther> autherRepository;
        private readonly IHostingEnvironment hosting;

        public BookController(iBookStoreRepository<Book> bookRepository, 
                              iBookStoreRepository<Auther> autherRepository,
                              IHostingEnvironment hosting)
        {
            this.bookRepository = bookRepository;
            this.autherRepository = autherRepository;
            this.hosting = hosting;
        }
        // GET: Book
        public ActionResult Index()
        {
            var book = bookRepository.List();
            return View(book);
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            var book = bookRepository.Find(id);
            return View(book);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View(GetAllAuthers());
        }

        // POST: Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookAutherViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                try
                {
                    if (model.AutherID == -1)
                    {
                        ViewBag.Message = "Please Select an Auther";
                        return View(GetAllAuthers());
                    }
                    string fileName = null;

                    if (model.File != null)
                    {
                        string uploads = Path.Combine(hosting.WebRootPath, "uploads");
                        fileName = model.File.FileName;
                        string fullPath = Path.Combine(uploads, fileName);
                        string oldFileName = bookRepository.Find(model.BookID).imgURL;
                        string fullOldPath = Path.Combine(uploads, oldFileName);
                        System.IO.File.Delete(fullOldPath);
                        model.File.CopyTo(new FileStream(fullPath, FileMode.Create));
                    }
                    var auther = autherRepository.Find(model.AutherID);
                    // TODO: Add insert logic here
                    Book book = new Book
                    {
                        Title = model.Title,
                        Description = model.Description,
                        _auther = auther,
                        imgURL = fileName
                    };

                    bookRepository.Add(book);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            ModelState.AddModelError("", "You have to fill all the required fields!");
            return View(GetAllAuthers());
           
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            var book = bookRepository.Find(id);
            var viewModel = new BookAutherViewModel
            {
                BookID = book.id,
                Title = book.Title,
                Description = book.Description,
                AutherID = book._auther.id,
                Authers = autherRepository.List().ToList(),
                imgUrl = book.imgURL
            };
            return View(viewModel);
        }

        // POST: Book/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BookAutherViewModel viewModel)
        {
           
            try
            {
                // TODO: Add update logic here
                string fileName = null;

                if (viewModel.File != null)
                {
                    string uploads = Path.Combine(hosting.WebRootPath, "uploads");
                    fileName = viewModel.File.FileName;
                    string fullPath = Path.Combine(uploads, fileName);

                    string oldFileName = bookRepository.Find(viewModel.BookID).imgURL;
                    string fullOldPath = Path.Combine(uploads, oldFileName);

                    //Delete the old File
                    System.IO.File.Delete(fullOldPath);
                    //insert the old file
                    viewModel.File.CopyTo(new FileStream(fullPath, FileMode.Create));
                }
                var auther = autherRepository.Find(viewModel.AutherID);
                Book book = new Book
                {
                    Title = viewModel.Title,
                    Description = viewModel.Description,
                    _auther = auther,
                    imgURL = fileName                    
                };

                bookRepository.Update(id, book);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            var book = bookRepository.Find(id);
            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                bookRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        BookAutherViewModel GetAllAuthers()
        {
            var authers = autherRepository.List().ToList();
            authers.Insert(0, new Auther { id = -1, FullName = "Please Select an Auther" });
            var model = new BookAutherViewModel
            {
                Authers = authers
            };
            return model;
        }
    }
}