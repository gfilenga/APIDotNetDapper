using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests
{
    [TestClass]
    public class DocumentTests
    {
        private Document validDocument;
        private Document invalidDocument;
        public DocumentTests()
        {
            validDocument = new Document("48006529019");
            invalidDocument = new Document("12345678910");
        }
        [TestMethod]
        public void ShouldReturnNotificationWhenDocumentIsNotValid()
        {
            Assert.AreEqual(false, invalidDocument.IsValid);
            Assert.AreEqual(1, invalidDocument.Notifications.Count);
        }

        [TestMethod]
        public void ShouldNotReturnNotificationWhenDocumentIsValid()
        {
            Assert.AreEqual(true, validDocument.IsValid);
            Assert.AreEqual(0, validDocument.Notifications.Count);
        }
    }
}
