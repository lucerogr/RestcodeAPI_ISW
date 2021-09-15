using RestCode_WebApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Domain.Repositories
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> ListAsync();
        Task AddAsync(Appointment appointment);
        Task<Appointment> FindById(int id);
        void Update(Appointment appointment);
        void Remove(Appointment appointment);
    }
}
