using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using When2Watch.BLL.DTO;
using When2Watch.BLL.Interfaces;
using When2Watch.Models;

namespace When2Watch.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IUserService _userService;
        private readonly UserManager<IdentityUser> _userManager;

        public CommentsController(ICommentService commentService, IUserService userService, UserManager<IdentityUser> userManager)
        {
            _commentService = commentService;
            _userService = userService;
            _userManager = userManager;
        }


        // GET: CommentController
        public async Task<IActionResult> Index(int? seriesId, string seriesName)
        {
            if (seriesId == null)
                return NotFound();

            var comments = await _commentService.GetCommentsBySeriesAsync((int)seriesId);
            ViewBag.seriesId = seriesId;
            ViewBag.seriesName = seriesName;
            ViewBag.isAdmin = User.IsInRole("admin");
            ViewBag.isBlocked = User.IsInRole("blocked");

            var result = comments
                .Select(c => new CommentViewModel(c, _userService.GetUserAsync(c.ClientId).Result.Name));

            return View(result);
        }

        // GET: CommentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CommentController/Create
        public ActionResult Create(int? seriesId)
        {
            ViewBag.seriesId = seriesId;
            return View();
        }

        // POST: CommentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int seriesId, [Bind("Id,Text,DateTime,ReplyTo")] CommentDTO comment)
        {
            var user = await _userService.FindUsersAsync(User.Identity.Name);
            int clientId = user.FirstOrDefault().Id;
            comment.ClientId = clientId;
            comment.SeriesId = seriesId;
            await _commentService.CreateCommentAsync(comment);
            return RedirectToAction(nameof(Index), new { seriesId = seriesId });
        }

        // GET: CommentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CommentController/Edit/5
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

        // GET: CommentController/Delete/5
        public async Task<IActionResult> Delete(int id, string seriesName)
        {
            var comment = await _commentService.GetCommentByIdAsync(id);
            await _commentService.DeleteCommentAsync(id);
            return RedirectToAction(nameof(Index), new { seriesId = comment.SeriesId , seriesName = seriesName});
        }

        // POST: CommentController/Delete/5
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
