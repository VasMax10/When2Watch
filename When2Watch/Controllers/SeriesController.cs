using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using When2Watch.BLL.DTO;
using When2Watch.BLL.Interfaces;

namespace When2Watch.Controllers
{
    [Authorize]
    public class SeriesController : Controller
    {
        private readonly ISeriesService _seriesService;
        
        public SeriesController(ISeriesService seriesService)
        {
            _seriesService = seriesService;
        }

        // GET: SeriesController
        public async Task<IActionResult> Index()
        {
            var result = _seriesService.GetAllAsync();
            return View(await result);
        }

        public async Task<IActionResult> Search(string keyword)
        {
            if ((keyword == "") || (keyword == null))
            {
                return RedirectToAction(nameof(Index));
            }
            var result = _seriesService.FindSeriesAsync(keyword);
            ViewBag.keyword = keyword;
            return View(await result);
        }

        // GET: SeriesController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();
            var result = _seriesService.GetSeriesAsync((int)id);
            return View(await result);
        }

        // GET: SeriesController/Create
        public async Task<IActionResult> Create([Bind("Id,Title,Description,TmdbId,RatingIMDb,PosterPath")] SeriesDTO series)
        {
            await _seriesService.ImportSeriesAsync(series);
            return RedirectToAction("Index", "Series");
        }

        // POST: SeriesController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public Task<IActionResult> Create([Bind("Id,Title,Description,TmdbId,RatingImdb,PosterPath")] SeriesDTO series)
        //{
          //  throw new NotImplementedException();
            //var series = _seriesService.GetAllAsync();
            
            //return View(await result);

        //}

        // GET: SeriesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SeriesController/Edit/5
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

        // GET: SeriesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SeriesController/Delete/5
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
