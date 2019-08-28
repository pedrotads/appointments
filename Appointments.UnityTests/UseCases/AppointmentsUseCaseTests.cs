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
        NameIsNullValidation nameValidation = null;
        StartDateValidationIsMinValue startDateValidation = null;
        [SetUp]
        public void Setup()
        {
            nameValidation = new NameIsNullValidation();
            startDateValidation = new StartDateValidationIsMinValue();
        }

        [Test]
        public void IsTheNameFilledIn()
        {
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
                Start = System.DateTime.Now + new System.TimeSpan(1, 0, 0),
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