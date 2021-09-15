using RestCode_WebApplication.Domain.Models;
using RestCode_WebApplication.Domain.Repositories;
using RestCode_WebApplication.Domain.Services;
using RestCode_WebApplication.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        public readonly IUnitOfWork _unitOfWork;

        public AppointmentService(IAppointmentRepository appointmentRepository, IUnitOfWork unitOfWork)
        {
            _appointmentRepository = appointmentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Appointment>> ListAsync()
        {
            return await _appointmentRepository.ListAsync();
        }

        public async Task<AppointmentResponse> GetByIdAsync(int id)
        {
            var existingAppointment = await _appointmentRepository.FindById(id);

            if (existingAppointment == null)
                return new AppointmentResponse("Appointment not found");
            return new AppointmentResponse(existingAppointment);

        }

        public async Task<AppointmentResponse> SaveAsync(Appointment appointment)
        {
            try
            {
                await _appointmentRepository.AddAsync(appointment);
                await _unitOfWork.CompleteAsync();

                return new AppointmentResponse(appointment);
            }
            catch (Exception ex)
            {
                return new AppointmentResponse($"An error ocurred when while saving appointment: {ex.Message}");

            }
        }

        public async Task<AppointmentResponse> UpdateAsync(int id, Appointment appointment)
        {
            var existingAppointment = await _appointmentRepository.FindById(id);
            if (existingAppointment == null)
                return new AppointmentResponse("Appointment not found");

            existingAppointment.CurrentDateTime = appointment.CurrentDateTime;
            existingAppointment.ScheduleDateTime = appointment.ScheduleDateTime;
            existingAppointment.Topic = appointment.Topic;
            existingAppointment.MeetLink = appointment.MeetLink;
            existingAppointment.ConsultantId = appointment.ConsultantId;
            existingAppointment.OwnerId = appointment.OwnerId;
            try
            {
                _appointmentRepository.Update(existingAppointment);
                await _unitOfWork.CompleteAsync();

                return new AppointmentResponse(existingAppointment);
            }
            catch (Exception ex)
            {
                return new AppointmentResponse($"An error ocurred when while saving appointment: {ex.Message}");

            }
        }

        public async Task<AppointmentResponse> DeleteAsync(int id)
        {
            var existingAppointment = await _appointmentRepository.FindById(id);
            if (existingAppointment == null)
                return new AppointmentResponse("Appointment not found");

            try
            {
                _appointmentRepository.Remove(existingAppointment);
                await _unitOfWork.CompleteAsync();

                return new AppointmentResponse(existingAppointment);
            }
            catch (Exception ex)
            {
                return new AppointmentResponse($"An error ocurred when while saving appointment: {ex.Message}");

            }
        }
    }
}
