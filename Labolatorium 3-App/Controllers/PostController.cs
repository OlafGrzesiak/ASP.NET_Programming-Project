using Microsoft.AspNetCore.Mvc;
using Labolatorium_3_App.Models;
using Microsoft.AspNetCore.Authorization;
using static System.Reflection.Metadata.BlobBuilder;
using System.Security.Claims;

namespace Labolatorium_3_App.Models
{
    [Authorize]
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }
        //static readonly Dictionary<int, Contact> _contacts = new Dictionary<int, Contact> ();
        [AllowAnonymous]
        public IActionResult Index(int page = 1, int pageSize = 10)
        {
            int totalPosts = _postService.CountBooks(); // uzyskaj całkowitą liczbę książek
            List<Post> posts = _postService.FindAll(page, pageSize);

            var viewModel = new PostsListViewModel
            {
                Posts = posts,
                PageInfo = new PageInfo { CurrentPage = page, TotalItems = totalPosts, ItemsPerPage = pageSize }
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Post model = new Post();
            model.Groups = _postService.FindAllOrganizations().Select(eo => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
            {
                Text = eo.Name,
                Value = eo.Id.ToString(),
            }).ToList();
            return View(model);
        }


        [HttpPost]
        public IActionResult Create(Post model)
        {
            if (ModelState.IsValid)
            {
                _postService.Add(model);
                //dodanie modelu do aplikacji (zapamiętać dane)
                return RedirectToAction("Index");

            }
            return View(); // ponowne wyświetlenie formualrza po dodaniu jeśli są błędy
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Post post = _postService.FindById(id);

            if (post == null)
            {
                return NotFound();
            }

            post.Groups = _postService.FindAllOrganizations().Select(eo => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = eo.Name,
                Value = eo.Id.ToString(),
            }).ToList();

            return View(post);
        }


        [HttpPost]
        public IActionResult Update(Post model)
        {
            model.Groups = _postService.FindAllOrganizations().Select(eo => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = eo.Name,
                Value = eo.Id.ToString(),
            }).ToList();
            if (ModelState.IsValid)

            {
                _postService.Update(model); 
                return RedirectToAction("Index");
            }


            return View(model);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            Post post = _postService.FindById(id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        [HttpPost]
        public IActionResult Delete(Post model)
        {
            _postService.Delete(model.id);
            return RedirectToAction("Index");
        }
        
    }
}