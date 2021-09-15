using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestCode_WebApplication.Domain.Models;
using RestCode_WebApplication.Domain.Repositories;
using RestCode_WebApplication.Domain.Services;
using RestCode_WebApplication.Domain.Services.Communication;

namespace RestCode_WebApplication.Services
{
    public class ConsultancyService : IConsultancyService
    {
        private readonly IConsultancyRepository _consultancyRepository;
        public readonly IUnitOfWork _unitOfWork;

        public ConsultancyService(IConsultancyRepository consultancyRepository, IUnitOfWork unitOfWork)
        {
            _consultancyRepository = consultancyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ConsultancyResponse> GetByIdAsync(int id)
        {
            var existingConsultancy = await _consultancyRepository.FindById(id);

            if (existingConsultancy == null)
                return new ConsultancyResponse("Consultancy not found");
            return new ConsultancyResponse(existingConsultancy);
        }

        public async Task<IEnumerable<Consultancy>> ListAsync()
        {
            return await _consultancyRepository.ListAsync();
        }

        public async Task<ConsultancyResponse> SaveAsync(Consultancy consultancy)
        {
            try
            {
                await _consultancyRepository.AddAsync(consultancy);
                await _unitOfWork.CompleteAsync();

                return new ConsultancyResponse(consultancy);
            }
            catch (Exception ex)
            {
                return new ConsultancyResponse($"An error ocurred when while saving consultancy: {ex.Message}");

            }
        }

        public async Task<ConsultancyResponse> UpdateAsync(int id, Consultancy consultancy)
        {
            var existingConsultancy = await _consultancyRepository.FindById(id);
            if (existingConsultancy == null)
                return new ConsultancyResponse("Consultancy no found");

            existingConsultancy.Diagnosis= consultancy.Diagnosis;
            existingConsultancy.Recommendation = consultancy.Recommendation;

            try
            {
                _consultancyRepository.Update(existingConsultancy);
                await _unitOfWork.CompleteAsync();

                return new ConsultancyResponse(existingConsultancy);
            }
            catch (Exception ex)
            {
                return new ConsultancyResponse($"An error ocurred when while saving consultancy: {ex.Message}");

            }
        }

        public async Task<ConsultancyResponse> DeleteAsync(int id)
        {
            var existingConsultancy = await _consultancyRepository.FindById(id);
            if (existingConsultancy == null)
                return new ConsultancyResponse("Consultancy no found");

            try
            {
                _consultancyRepository.Remove(existingConsultancy);
                await _unitOfWork.CompleteAsync();

                return new ConsultancyResponse(existingConsultancy);
            }
            catch (Exception ex)
            {
                return new ConsultancyResponse($"An error ocurred when while saving consultancy: {ex.Message}");

            }
        }

    }
}
