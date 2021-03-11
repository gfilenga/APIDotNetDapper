using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests
{
    [TestClass]
    public class CreateCustomerCommandTests
    {
        [TestMethod]
        public void ShouldValidateWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Guilherme";
            command.LastName = "Filenga";
            command.Document = "44169225821";
            command.Email = "gui.filenga@hotmail.com";
            command.Phone = "5511998924722";

            Assert.AreEqual(true, command.Valid());
        }
    }
}
