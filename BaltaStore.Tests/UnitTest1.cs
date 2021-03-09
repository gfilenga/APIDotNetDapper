using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var name = new Name("Guilherme", "Filenga");
            var document = new Document("44169225821");
            var email = new Email("gui.filenga@hotmail.com");
            var customer = new Customer(name, document, email, "44692828");

            var mouse = new Product("Mouse", "Rato", "img.png", 59.39m, 10);
            var teclado = new Product("teclado", "teclado", "img.png", 159.39m, 10);
            var impressora = new Product("impressora", "impressora", "img.png", 359.39m, 10);
            var cadeira = new Product("cadeira", "cadeira", "img.png", 559.39m, 10);

            var order = new Order(customer);
            order.AddItem(new OrderItem(mouse, 5));
            order.AddItem(new OrderItem(teclado, 5));
            order.AddItem(new OrderItem(impressora, 5));
            order.AddItem(new OrderItem(cadeira, 5));

            order.Place();
            order.Pay();
            order.Ship();
            order.Cancel();
        }
    }
}
