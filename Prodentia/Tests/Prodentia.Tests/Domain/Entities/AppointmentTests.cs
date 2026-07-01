using Prodentia.Domain.Entities;
using Prodentia.Domain.Enums;
using Prodentia.Domain.Exceptions;
using Prodentia.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Tests.Domain.Entities
{
    [TestClass]
    public class AppointmentTests
    {
        private Guid _patientId = Guid.NewGuid();
        private Guid _dentistId = Guid.NewGuid();
        private Guid _dentalOfficeId = Guid.NewGuid();
        private TimeInterval _timeInterval = new TimeInterval(DateTime.UtcNow.AddDays(1), DateTime.UtcNow.AddDays(2));


        [TestMethod]
        public void Constructor_Throw_WhenStartTimeInThePast()
        {
            var pastTimeInterval = new TimeInterval(DateTime.UtcNow.AddDays(-1), DateTime.UtcNow);
            Assert.ThrowsExactly<BusinessRuleException>(() => new Appointment(_patientId, _dentistId, _dentalOfficeId, pastTimeInterval));
        }

        [TestMethod]
        public void Cancel_CancelingAppointment_ChangesStatusToCanceled()
        {
            var appointment = new Appointment(_patientId, _dentistId, _dentalOfficeId, _timeInterval);
            appointment.Cancel();
            Assert.AreEqual(AppointmentStatus.Canceled, appointment.Status);
        }

        [TestMethod]
        public void Cancel_CancelingAppointment_ThrowsIfStatusIsNotValid()
        {
            var appointment = new Appointment(_patientId, _dentistId, _dentalOfficeId, _timeInterval);
            appointment.Cancel();
            Assert.ThrowsExactly<BusinessRuleException>(() => appointment.Cancel());
        }

        [TestMethod]
        public void Complate_CompletingAppointment_ChangesStatusToCompleted()
        {
            var appointment = new Appointment(_patientId, _dentistId, _dentalOfficeId, _timeInterval);
            appointment.Complete();
            Assert.AreEqual(AppointmentStatus.Completed, appointment.Status);
        }

        [TestMethod]
        public void Complate_CompletingAppointment_ThrowsIfStatusIsAlreadyCompleted()
        {
            var appointment = new Appointment(_patientId, _dentistId, _dentalOfficeId, _timeInterval);
            appointment.Complete();
            Assert.ThrowsExactly<BusinessRuleException>(() => appointment.Complete());
        }

        [TestMethod]
        public void Complate_CompletingAppointment_ThrowsIfStatusIsCanceled()
        {
            var appointment = new Appointment(_patientId, _dentistId, _dentalOfficeId, _timeInterval);
            appointment.Cancel();
            Assert.ThrowsExactly<BusinessRuleException>(() => appointment.Complete());
        }

        [TestMethod]
        public void Constructor_ValidAppointment_StatusIsScheduled()
        {
            var appointment = new Appointment(_patientId, _dentistId, _dentalOfficeId, _timeInterval);
            Assert.AreEqual(_patientId, appointment.PatientId);
            Assert.AreEqual(_dentistId, appointment.DentistId);
            Assert.AreEqual(_dentalOfficeId, appointment.DentalOfficeId);
            Assert.AreEqual(_timeInterval, appointment.TimeInterval);
            Assert.AreEqual(AppointmentStatus.Scheduled, appointment.Status);
            Assert.AreNotEqual(Guid.Empty, appointment.Id);
        }
    }
}
