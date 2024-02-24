namespace Labolatorium_9___test
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
        }
    }
}