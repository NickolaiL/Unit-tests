using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.Tests
{
    [TestFixture]
    class BookingHelperOverlappingBookingsExistTests
    {
        private Mock<IBookingRepository> _bookingRepository;
        private Booking _existingBooking;
        [SetUp]
        public void SetUp()
        {
            _existingBooking = new Booking
            {
                Id = 2,
                ArrivalDate = SetArrivalDate(2020, 1, 11),
                DepartureDate = SetDepartureDate(2020, 1, 15),
                Reference = "s"
            };
            _bookingRepository = new Mock<IBookingRepository>();
            _bookingRepository.Setup(br => br.GetActiveBookings(It.IsAny<int>())).Returns(new List<Booking>
            {
                _existingBooking
            }.AsQueryable());
        }
        [Test]
        public void BookingStartsAndFinishesBeforeAnExistingBooking_ReturnEmptyString()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking 
            { 
                Id = 1, 
                Status = "Active", 
                ArrivalDate = Before(_existingBooking.ArrivalDate, days: 2), 
                DepartureDate = Before(_existingBooking.ArrivalDate),
            }, _bookingRepository.Object);
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void BookingStartsBeforeAndFinishesInTheMiddleOfAnExistingBooking_ReturnExistingBookingReference()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                Status = "Active",
                ArrivalDate = Before(_existingBooking.ArrivalDate, days: 2),
                DepartureDate = After(_existingBooking.ArrivalDate),
            }, _bookingRepository.Object);
            Assert.That(result, Is.EqualTo(_existingBooking.Reference));
        }

        [Test]
        public void BookingStartsBeforeAndFinishesAfterAnExistingBooking_ReturnExistingBookingReference()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                Status = "Active",
                ArrivalDate = Before(_existingBooking.ArrivalDate, days: 2),
                DepartureDate = After(_existingBooking.DepartureDate),
            }, _bookingRepository.Object);
            Assert.That(result, Is.EqualTo(_existingBooking.Reference));
        }

        [Test]
        public void BookingStartsAndFinishesInTheMiddleOfAnExistingBooking_ReturnExistingBookingReference()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                Status = "Active",
                ArrivalDate = After(_existingBooking.ArrivalDate, days: 2),
                DepartureDate = Before(_existingBooking.DepartureDate),
            }, _bookingRepository.Object);
            Assert.That(result, Is.EqualTo(_existingBooking.Reference));
        }

        [Test]
        public void BookingStartsInTheMiddleOfAndFinishesAfterAnExistingBooking_ReturnExistingBookingReference()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                Status = "Active",
                ArrivalDate = After(_existingBooking.ArrivalDate, days: 2),
                DepartureDate = After(_existingBooking.DepartureDate),
            }, _bookingRepository.Object);
            Assert.That(result, Is.EqualTo(_existingBooking.Reference));
        }

        [Test]
        public void BookingStartsAndFinishesAfterAnExistingBooking_ReturnEmptyString()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                Status = "Active",
                ArrivalDate = After(_existingBooking.DepartureDate, days: 2),
                DepartureDate = After(_existingBooking.DepartureDate, days: 4),
            }, _bookingRepository.Object);
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void BookingIsOverlappingButCanceled_ReturnEmptyString()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                Status = "Cancelled",
                ArrivalDate = Before(_existingBooking.DepartureDate, days: 2),
                DepartureDate = After(_existingBooking.DepartureDate, days: 4),
            }, _bookingRepository.Object);
            Assert.That(result, Is.Empty);
        }
        private DateTime Before (DateTime dateTime, int days = 1)
        {
            return dateTime.AddDays(-days);
        }

        private DateTime After(DateTime dateTime, int days = 1)
        {
            return dateTime.AddDays(days);
        }
        private DateTime SetArrivalDate (int year, int month, int date)
        {
            return new DateTime(year, month, date, 14, 0, 0);
        }
        private DateTime SetDepartureDate(int year, int month, int date)
        {
            return new DateTime(year, month, date, 10, 0, 0);
        }
    }
}
