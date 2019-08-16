using Appointments.Domain;
using Appointments.UseCases.Appointments.Validators;
using NUnit.Framework;

namespace Tests.UseCases
{
    [TestFixture]
    public class AppointmentsTestsRules
    {

        NameValidation nameValidation = null;
        StartDateValidation startDateValidation = null;

        [SetUp]
        public void Setup()
        {
            nameValidation = new NameValidation();
            startDateValidation = new StartDateValidation();
        }

        [Test]
        public void IsTheNameFilledIn()
        {
            var appointment = new Appointment()
            {
                Name = "Jose da Silva"
            };

            var errorName = nameValidation.Execute(appointment);
            Assert.IsNull(errorName);
        }

        [Test]
        public void IsTheNameEmptyOrNull()
        {
            var appointment = new Appointment()
            {
                Name = ""
            };

            var errorName = nameValidation.Execute(appointment);
            Assert.IsNotNull(errorName);
        }

        [Test]
        public void IsTheStartDateFilled()
        {
            var appointment = new Appointment()
            {
                Start = new System.DateTime().Date,
            };

            var errorStartDate = startDateValidation.Execute(appointment);
            Assert.IsNotNull(errorStartDate);
        }

        [Test]
        public void IsTheStartDateNull()
        {
            var appointment = new Appointment();

            var errorStartDate = startDateValidation.Execute(appointment);
            Assert.IsNotNull(errorStartDate);
        }

        [Test]
        public void IsTheStartDateAndNameFilled()
        {
            var appointment = new Appointment()
            {
                Start = System.DateTime.MinValue
            };

            var errorStartDate = nameValidation.Execute(appointment);
            Assert.IsNotNull(errorStartDate);
        }





    }
}