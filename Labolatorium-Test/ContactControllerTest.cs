// using Laboratorium3___App.Controllers;
// using Laboratorium3___App.Models;
// using Microsoft.AspNetCore.Mvc;
// using System.Collections.Generic;
// using Xunit;
//
// namespace Laboratorium_Test
// {
//     public class ContactControllerTest
//     {
//         private ContactController _controller;
//         private IContactService _service;
//
//
//         public ContactControllerTest()
//         {
//             // Initialize the service with the YourDateTimeProviderImplementation
//             var dateTimeProvider = new DateTimeProviderImplementation();
//             _service = new MemoryContactService(dateTimeProvider);
//
//             // Add test data
//             _service.Add(new Contact() { Id = 1 });
//             _service.Add(new Contact() { Id = 2 });
//
//             _controller = new ContactController(_service);
//         }
//
//         [Fact]
//         public void Test1()
//         {
//             var result = _controller.Index();
//             Assert.IsType<ViewResult>(result);
//             var view = result as ViewResult;
//             Assert.Equal("Index", view.ViewName);
//             var model = view.Model;
//             Assert.IsType<List<Contact>>(model);
//             var list = model as List<Contact>;
//             Assert.Equal(2, list.Count); // Expecting 2 contacts since you've added 2
//         }
//
//         [Theory]
//         [InlineData(1)]
//         [InlineData(2)]
//         public void DetailsTestForExistingContacts(int id)
//         {
//             var result = _controller.Details(id);
//             Assert.IsType<ViewResult>(result);
//             var view = result as ViewResult;
//             var model = view.Model as Contact;
//             Assert.Equal(id, model.Id);
//         }
//
//         [Fact]
//         public void DetailsTestForNonExistingContacts()
//         {
//             var result = _controller.Details(100);
//             Assert.IsType<NotFoundResult>(result);
//         }
//
//
//         [Fact]
//         public void Add_ValidContact_ReturnsNewContactId()
//         {
//             var contact = new Contact { Id = 3, Name = "John" };
//             int newId = _service.Add(contact);
//
//             Assert.True(newId > 2); 
//         }
//
//
//         [Fact]
//         public void Delete_ExistingContact_RemovesContact()
//         {
//             IContactService contactService = new MemoryContactService(new DateTimeProviderImplementation());
//             var contact = new Contact { Id = 1, Name = "John" };
//             contactService.Add(contact);
//             contactService.Delete(contact.Id);
//
//             Assert.Null(contactService.FindById(contact.Id));
//         }
//
//         [Fact]
//         public void Update_ExistingContact_UpdatesContact()
//         {
//             IContactService contactService = new MemoryContactService(new DateTimeProviderImplementation());
//             var contact = new Contact { Id = 1, Name = "John" };
//             contactService.Add(contact);
//             var updatedContact = new Contact { Id = 1, Name = "Updated John" };
//             contactService.Update(updatedContact);
//
//             var retrievedContact = contactService.FindById(updatedContact.Id);
//             Assert.NotNull(retrievedContact);
//             Assert.Equal(updatedContact.Name, retrievedContact.Name);
//         }
//
//         [Fact]
//         public void FindAll_ReturnsAllContacts()
//         {
//             IContactService contactService = new MemoryContactService(new DateTimeProviderImplementation());
//             var contact1 = new Contact { Id = 1, Name = "John" };
//             var contact2 = new Contact { Id = 2, Name = "Alice" };
//             contactService.Add(contact1);
//             contactService.Add(contact2);
//
//             var contacts = contactService.FindAll();
//
//             Assert.Equal(2, contacts.Count);
//         }
//
//         [Fact]
//         public void FindById_ExistingContact_ReturnsContact()
//         {
//             IContactService contactService = new MemoryContactService(new DateTimeProviderImplementation());
//             var contact = new Contact { Id = 1, Name = "John" };
//             contactService.Add(contact);
//             var retrievedContact = contactService.FindById(contact.Id);
//
//             Assert.NotNull(retrievedContact);
//             Assert.Equal(contact.Id, retrievedContact.Id);
//         }
//
//         [Fact]
//         public void FindById_NonExistingContact_ReturnsNull()
//         {
//             IContactService contactService = new MemoryContactService(new DateTimeProviderImplementation());
//             var retrievedContact = contactService.FindById(100); // Assuming contact with ID 100 doesn't exist
//
//             Assert.Null(retrievedContact);
//         }    
//     }
// }
