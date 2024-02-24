using System.Collections.Generic;
using Labolatorium_3_App.Models;

namespace Labolatorium_3_App.Models
{
    public class PostsListViewModel
    {
        public PageInfo PageInfo { get; set; }
        public List<Post> Posts { get; set; }
    }

    public class PageInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages => (int)System.Math.Ceiling((decimal)TotalItems / ItemsPerPage);
    }
}
