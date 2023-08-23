using Microsoft.VisualStudio.TestTools.UnitTesting;
using MailingList.Models;
using MailingList.Controllers;
using Microsoft.EntityFrameworkCore;
using MailingList.DataAccess;
using System.Linq;
using Moq;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace MailingList.Tests.ControllerTest
{
    [TestClass]
    public class ContactsControllerTests
    {
        [TestMethod]
        public void Create_ValidModel_AddsContactToDatabase()
        {
            /* need to mock temp data to void null reference */
            var tempDataMock = new Mock<ITempDataDictionary>();
            var options = new DbContextOptionsBuilder<MailingListContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new MailingListContext(options))
            {
                // Arrange
                var controller = new ContactsController(context);
                controller.TempData = tempDataMock.Object;

                var validContact = new Contact
                {
                    FirstName = "Nathaniel",
                    LastName = "Trujillo",
                    Email = "nathaniel.trujillo@gmail.com"
                };

                // Act
                controller.Create(validContact);

                // Assert
                Assert.AreEqual(1, context.Contacts.Count());

                // Retrieve the contact from the database
                var createdContact = context.Contacts.FirstOrDefault();

                // Additional assertions to check contact attributes
                Assert.IsNotNull(createdContact);
                Assert.AreEqual("Nathaniel", createdContact.FirstName);
                Assert.AreEqual("Trujillo", createdContact.LastName);
                Assert.AreEqual("nathaniel.trujillo@gmail.com", createdContact.Email);
            }
        }
    }
}
