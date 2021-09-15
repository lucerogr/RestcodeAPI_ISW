using RestCode_WebApplication.Domain.Models;
using RestCode_WebApplication.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Domain.Services
{
    public interface IAppointmentService
    {
        Task<IEnumerable<Appointment>> ListAsync();
        Task<AppointmentResponse> GetByIdAsync(int id);
        Task<AppointmentResponse> SaveAsync(Appointment appointment);
        Task<AppointmentResponse> UpdateAsync(int id, Appointment appointment);
        Task<AppointmentResponse> DeleteAsync(int id);
    }
}
