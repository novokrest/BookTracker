using BookTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookTracker.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Book book)
        {
            Book? oldBook = Session["book"] as Book?;

            if (oldBook.HasValue)
            {
                Votes.ChangeVote(oldBook.Value, book);
            }
            else
            {
                Votes.RegisterVote(book);
            }

            ViewBag.SelectedBook = Session["book"] = book;
            return View();
        }
    }
}