using LibrarySystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Controllers
{
    public class BooksController : Controller
    {
        private readonly Context context;

        public BooksController(Context cont)
        {
            context = cont;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(context.Books);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Book book = context.Books.FirstOrDefault(e => e.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                context.Books.Add(book);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Book book = context.Books.FirstOrDefault(e => e.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(int id, Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                context.Books.Update(book);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            ViewBag.Greeting = "Delete";

            Book book = context.Books.FirstOrDefault(e => e.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = context.Books.FirstOrDefault(e => e.Id == id);

            context.Books.Remove(book);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
