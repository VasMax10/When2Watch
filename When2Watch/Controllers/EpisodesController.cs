using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using When2Watch.BLL.Interfaces;

namespace When2Watch.Controllers
{
    [Authorize]
    public class EpisodesController : Controller
    {
        private readonly IEpisodeService _episodeService;
        private readonly IMapper _mapper;

        public EpisodesController(IEpisodeService episodeService, IMapper mapper)
        {
            _episodeService = episodeService;
            _mapper = mapper;
        }

        // GET: EpisodeController
        public async Task<IActionResult> Index(int? seasonId)
        {
            if (seasonId == null)
                return NotFound();
            var result = _episodeService.GetEpisodesBySeasonAsync((int)seasonId);
            return View(await result);
        }

        // GET: EpisodeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EpisodeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EpisodeController/Create
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

        // GET: EpisodeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EpisodeController/Edit/5
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

        // GET: EpisodeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EpisodeController/Delete/5
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
