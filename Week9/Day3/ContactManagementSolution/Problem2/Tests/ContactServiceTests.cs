using NUnit.Framework;
using Moq;
using ContactManagement.Interfaces;
using ContactManagement.Services;
using ContactManagement.Models;
using System.Collections.Generic;

namespace ContactManagement.Tests
{
    public class ContactServiceTests
    {
        private Mock<IContactRepository> _mockRepo;
        private ContactService _service;

        [SetUp]
        public void Setup()
        {
            _mockRepo = new Mock<IContactRepository>();
            _service = new ContactService(_mockRepo.Object);
        }

        [Test]
        public void AddContact_ShouldCallRepository()
        {
            var contact = new Contact { Id = 1, Name = "Test", Email = "test@test.com" };

            _service.AddContact(contact);

            _mockRepo.Verify(r => r.Add(contact), Times.Once);
        }

        [Test]
        public void GetContacts_ShouldReturnData()
        {
            _mockRepo.Setup(r => r.GetAll()).Returns(new List<Contact> { new Contact() });

            var result = _service.GetContacts();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }

        [Test]
        public void RemoveContact_ShouldReturnTrue()
        {
            _mockRepo.Setup(r => r.Remove(1)).Returns(True);

            var result = _service.RemoveContact(1);

            Assert.IsTrue(result);
        }

        [Test]
        public void AddContact_ShouldThrowException()
        {
            Assert.Throws<System.Exception>(() => _service.AddContact(null));
        }
    }
}
