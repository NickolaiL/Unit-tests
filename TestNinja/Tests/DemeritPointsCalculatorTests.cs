using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.Tests
{
    [TestFixture]
    class DemeritPointsCalculatorTests
    {
        [Test]
        [TestCase(-1)]
        [TestCase(301)]
        public void CalculateDemeritPoints_SpeedIsOutOfRange_ThrowsArgumentOutOfRangeException(int points)
        {
            var demeritPointsCalculator = new DemeritPointsCalculator();
            Assert.That(() => demeritPointsCalculator.CalculateDemeritPoints(points), Throws.Exception.TypeOf<ArgumentOutOfRangeException>()) ;
        }
        [Test]
        [TestCase(0, 0)]
        [TestCase(65, 0)]
        [TestCase(69, 0)]
        [TestCase(70, 1)]
        [TestCase(85, 4)]
        public void CalculateDemeritPoints_WhenCalled_ReturnsDemeritPoints(int speed, int expectedPoints)
        {
            var demeritPointsCalculator = new DemeritPointsCalculator();
            var points = demeritPointsCalculator.CalculateDemeritPoints(speed);
            Assert.That(points == expectedPoints);
        }
    }
}
