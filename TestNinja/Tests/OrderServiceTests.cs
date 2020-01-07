using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestNinja.Mocking;
using Moq;

namespace TestNinja.Tests
{
    [TestFixture]
    class OrderServiceTests
    {
        [Test]
        public void PlaceOrder_WhenCalled_StoreTheOrder()
        {
            var storage = new Mock<IStorage>();
            var service = new OrderService(storage.Object);

            var order = new Order();
            var orderId = service.PlaceOrder(order);

            storage.Verify(s => s.Store(order));
        }
    }
}
