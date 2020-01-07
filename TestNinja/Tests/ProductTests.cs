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
    class ProductTests
    {
        [Test]
        public void GetPrice_CustomerIsGold_Apply30PercentDiscount()
        {
            var product = new Product { ListPrice = 100 };
            var result = product.GetPrice(new Customer { IsGold = true });
            Assert.That(result == 70);
        }
    }
}
