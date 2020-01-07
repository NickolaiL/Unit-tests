using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using TestNinja.Mocking;
using NUnit.Framework;

namespace TestNinja.Tests
{
    [TestFixture]
    class EmployeeControllerTests
    {
        private Mock<IEmployeeStorage> _employeeStorage;
        private EmployeeController _employeeController;

        [SetUp]
        public void SetUp()
        {
            _employeeStorage = new Mock<IEmployeeStorage>();
            _employeeController = new EmployeeController(_employeeStorage.Object);
        }
        [Test]
        public void DeleteEmployee_WhenCalled_DeleteTheEmployeeFromDB()
        {
            _employeeController.DeleteEmployee(1);
            _employeeStorage.Verify(es => es.DeleteEmployee(1));
        }
        [Test]
        public void DeleteEmployee_WhenCalled_ReturnsRedirectResultObject()
        {
            var redirectResult = _employeeController.DeleteEmployee(1);
            Assert.AreEqual(redirectResult.GetType(), typeof(RedirectResult));
        }
    }
}
