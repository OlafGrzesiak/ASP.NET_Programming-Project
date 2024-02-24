

namespace Labolatorium_9
{
    public class ContactControllerTest
    {
        private ContactController _controller;
        private IContactService _service;

        public ContactControllerTest()
        {
            _service = new MemoryContactService();
            _service.Add(new Contact() { Id = 1 });
            _controller = new ContactController(_service);
        }



        [Fact]
        public void Test1()
        {
            var result = _controller.Index();
            Assert.IsType<ViewResult>(result);
            var view = result as ViewResult;
            Assert.Equal("Index", view.ViewName);
            var model = view.Model;
            Assert.IsType<List<Contact>>(model);
            var list = model as List<Contact>;
            Assert.Equal(1, list.Count);
        }
    }
}