using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using When2Watch.BLL.Interfaces;

namespace When2Watch.Controllers
{
    public class SeasonsController : Controller
    {
        private readonly ISeasonService _seasonService;

        public SeasonsController(ISeasonService seasonService)
        {
            _seasonService = seasonService;
        }

        // GET: SeasonsController
        public async Task<IActionResult> Index(int? seriesId, string seriesName)
        {
            if (seriesId == null)
                return NotFound();
            var result = await _seasonService.GetSeasonsBySeriesId((int)seriesId);
            ViewBag.SeriesName = seriesName;
            return View(result);
        }

        // GET: SeasonsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SeasonsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SeasonsController/Create
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

        // GET: SeasonsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SeasonsController/Edit/5
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

        // GET: SeasonsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SeasonsController/Delete/5
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
