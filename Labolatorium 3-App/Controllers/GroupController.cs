using Microsoft.AspNetCore.Mvc;
using Labolatorium_3_App.Models;
using Microsoft.AspNetCore.Authorization;
//... inne usingi

namespace Labolatorium_3_App.Controllers
{
    public class GroupController : Controller
    {
        private readonly IGroupService _groupService;
        private readonly IPostService _bookService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        public IActionResult Index()
        {
            var groups = _groupService.GetAllLibraries();
            return View(groups);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Group group)
        {
            if (ModelState.IsValid)
            {
                _groupService.AddLibrary(group);
                return RedirectToAction(nameof(Index));
            }
            return View(group);
        }

        public IActionResult Edit(int id)
        {
            var group = _groupService.GetLibraryById(id);
            if (group == null)
            {
                return NotFound();
            }
            return View(group);
        }

        [HttpPost]
        public IActionResult Edit(Group group)
        {
            if (ModelState.IsValid)
            {
                _groupService.UpdateLibrary(group);
                return RedirectToAction(nameof(Index));
            }
            return View(group);
        }

        public IActionResult Delete(int id)
        {
            var group = _groupService.GetLibraryById(id);
            if (group == null)
            {
                return NotFound();
            }
            return View(group);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _groupService.DeleteLibrary(id);
            return RedirectToAction(nameof(Index));
        }
        
    }
}
