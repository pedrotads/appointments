using Appointments.Domain;
using Appointments.UnityTests.Repository.Mocks;
using Appointments.UseCases.Appointments;
using Appointments.UseCases.Appointments.Validators;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests.UseCases
{
    [TestFixture]
    public class AppointmentsUseCaseTests
    {
        [SetUp]
        public void Setup()
        {            
        }

        [Test]
        public void IsTheNameFilledIn()
        {
            var nameValidation = new NameIsNullValidation();
            var appointment = new Appointment()
            {
                Name = "Reunião de Validação"
            };

            var errorName = nameValidation.Execute(appointment);
            Assert.IsNull(errorName);
        }

        [Test]
        public void IsTheNameEmptyOrNull()
        {
            var nameValidation = new NameIsNullValidation();
            var appointment = new Appointment()
            {
                Name = string.Empty
            };

            var errorName = nameValidation.Execute(appointment);
            Assert.IsNotNull(errorName);
        }

        [Test]
        public void IsTheStartDateFilled()
        {
            var startDateValidation = new StartDateValidationIsMinValue();
            var appointment = new Appointment()
            {
                Start = System.DateTime.Now,
            };

            var errorStartDate = startDateValidation.Execute(appointment);
            Assert.IsNotNull(errorStartDate);
        }

        [Test]
        public void IsTheStartDateNull()
        {
            var appointment = new Appointment();
            var startDateValidation = new StartDateValidationIsMinValue();
            var errorStartDate = startDateValidation.Execute(appointment);
            Assert.IsNotNull(errorStartDate);
        }

        [Test]
        public void IsStartDateInThePast()
        {
            var startDateIsInThePast = new StartDateIsInThePastValidation();
            var appointment = new Appointment()
            {
                Start = System.DateTime.Now.AddHours(-1)
            };
            var errorStartDate = startDateIsInThePast.Execute(appointment);
            Assert.IsNotNull(errorStartDate);
        }

        [Test]
        public void IsStartDateNotInThePast()
        {
            var startDateIsInThePast = new StartDateIsInThePastValidation();
            var appointment = new Appointment()
            {
                Start = System.DateTime.Now.AddHours(1)
            };
            var errorStartDate = startDateIsInThePast.Execute(appointment);
            Assert.IsNull(errorStartDate);
        }


        [Test]
        public void IsTheStartDateAndNameFilled()
        {
            var nameValidation = new NameIsNullValidation();
            var appointment = new Appointment()
            {
                Start = System.DateTime.MinValue,
                Name = "Reunião de Validação"
            };
            var errorStartDate = nameValidation.Execute(appointment);
            Assert.IsNull(errorStartDate);
        }

        [Test]
        public void IsNewAppointmentValid()
        {
            var appointmentNew = new Appointment()
            {
                Start = System.DateTime.Now.AddHours(1),
                Name = "Papo Teste",
                Place = "Rua das Flores, 15",
                End = new System.TimeSpan(1, 0, 0),
                Details = "Reunião de Testes",
                Guests = new List<Guest>()
                {
                    new Guest()
                    {
                        Name = "Pedro Teste",
                        Status = GuestStatus.Waiting
                    }
                }
            };

            var appointmentRepositoryMock = new AppointmentRepositoryMock();
            var newAppointment = new NewAppointment(appointmentRepositoryMock);
            var appointmentInserted = newAppointment.New(appointmentNew);

            Assert.NotNull(appointmentInserted);
            Assert.NotNull(appointmentInserted.Id);
            Assert.AreEqual(appointmentInserted.Id, 1);
        }
    }
}