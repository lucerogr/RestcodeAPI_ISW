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
    public class ConsultantService : IConsultantService
    {
        private readonly IConsultantRepository _consultantRepository;
        public readonly IUnitOfWork _unitOfWork;

        public ConsultantService(IConsultantRepository consultantRepository, IUnitOfWork unitOfWork)
        {   
            _consultantRepository = consultantRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Consultant>> ListAsync()
        {
            return await _consultantRepository.ListAsync();
        }

        public async Task<ConsultantResponse> GetByIdAsync(int id)
        {
            var existingConsultant = await _consultantRepository.FindById(id);

            if (existingConsultant == null)
                return new ConsultantResponse("Consultant not found");
            return new ConsultantResponse(existingConsultant);
        }

        public async Task<ConsultantResponse> SaveAsync(Consultant consultant)
        {
            try
            {
                await _consultantRepository.AddAsync(consultant);
                await _unitOfWork.CompleteAsync();

                return new ConsultantResponse(consultant);
            }
            catch (Exception ex)
            {
                return new ConsultantResponse($"An error ocurred while saving consultant: {ex.Message}");
            }
        }

        public async Task<ConsultantResponse> UpdateAsync(int id, Consultant consultant)
        {
            var existingConsultant = await _consultantRepository.FindById(id);
            if (existingConsultant == null)
                return new ConsultantResponse("Consultant not found");

            existingConsultant.UserName = consultant.UserName;
            existingConsultant.Password = consultant.Password;
            existingConsultant.FirstName = consultant.FirstName;
            existingConsultant.LastName = consultant.LastName;
            existingConsultant.Cellphone = consultant.Cellphone;
            existingConsultant.Email = consultant.Email;
            existingConsultant.LinkedinLink = consultant.LinkedinLink;

            try
            {
                _consultantRepository.Update(existingConsultant);
                await _unitOfWork.CompleteAsync();

                return new ConsultantResponse(existingConsultant);
            }
            catch (Exception ex)
            {
                return new ConsultantResponse($"An error ocurred while updating consultant: {ex.Message}");
            }
        }

        public async Task<ConsultantResponse> DeleteAsync(int id)
        {
            var existingConsultant = await _consultantRepository.FindById(id);

            if (existingConsultant == null)
                return new ConsultantResponse("Consultant not found");
            try
            {
                _consultantRepository.Remove(existingConsultant);
                await _unitOfWork.CompleteAsync();

                return new ConsultantResponse(existingConsultant);
            }
            catch (Exception ex)
            {
                return new ConsultantResponse($"An error ocurred while deleting consultant: {ex.Message} ");
            }
        }
    }
}
