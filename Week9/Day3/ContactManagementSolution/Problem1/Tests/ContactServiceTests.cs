using NUnit.Framework;
using ContactManagement.Services;
using ContactManagement.Models;

namespace ContactManagement.Tests
{
    public class ContactServiceTests
    {
        private ContactService _service;

        [SetUp]
        public void Setup()
        {
            _service = new ContactService();
        }

        [Test]
        public void AddContact_ShouldAddSuccessfully()
        {
            // Arrange
            var contact = new Contact { Id = 1, Name = "John", Email = "john@test.com" };

            // Act
            _service.AddContact(contact);

            // Assert
            Assert.AreEqual(1, _service.GetAllContacts().Count);
        }

        [Test]
        public void GetContactById_ShouldReturnCorrectContact()
        {
            var contact = new Contact { Id = 1, Name = "John", Email = "john@test.com" };
            _service.AddContact(contact);

            var result = _service.GetContactById(1);

            Assert.IsNotNull(result);
            Assert.AreEqual("John", result.Name);
        }

        [Test]
        public void DeleteContact_ShouldRemoveSuccessfully()
        {
            var contact = new Contact { Id = 1, Name = "John", Email = "john@test.com" };
            _service.AddContact(contact);

            var result = _service.DeleteContact(1);

            Assert.IsTrue(result);
            Assert.AreEqual(0, _service.GetAllContacts().Count);
        }
    }
}
