using Labolatorium_3_App.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Labolatorium_Test
{
    public class BookControllerTests
    {
        private readonly BookController _controller;

        public BookControllerTests()
        {
            _controller = new BookController(null);
        }

        [Fact]
        public void Index_ReturnsViewResult()
        {
            var result = _controller.Index();
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Create_Get_ReturnsViewResult()
        {
            var result = _controller.Create();
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Create_Post_RedirectsToIndex()
        {
            var result = _controller.Create(new Post());
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public void Update_Get_ReturnsViewResult()
        {
            var result = _controller.Update(1);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Update_Post_RedirectsToIndex()
        {
            var result = _controller.Update(new Post());
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public void Delete_Get_ReturnsViewResult()
        {
            var result = _controller.Delete(1);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Delete_Post_RedirectsToIndex()
        {
            var result = _controller.Delete(new Post());
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public void Details_ReturnsViewResult()
        {
            var result = _controller.Details(1);
            Assert.IsType<ViewResult>(result);
        }
    }
}
