using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace When2Watch.Controllers
{
    [Authorize]
    public class WatchlistsController : Controller
    {
        // GET: WatchlistsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: WatchlistsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WatchlistsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WatchlistsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WatchlistsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WatchlistsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WatchlistsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WatchlistsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
