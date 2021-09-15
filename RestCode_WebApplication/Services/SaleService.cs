using RestCode_WebApplication.Domain.Models;
using RestCode_WebApplication.Domain.Repositories;
using RestCode_WebApplication.Domain.Services;
using RestCode_WebApplication.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        public readonly IUnitOfWork _unitOfWork;

        public SaleService(ISaleRepository  saleRepository, IUnitOfWork unitOfWork)
        {
            _saleRepository = saleRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Sale>> ListAsync()
        {
            return await _saleRepository.ListAsync();
        }
                
        public async Task<SaleResponse> GetByIdAsync(int id)
        {
            var existingSale = await _saleRepository.FindById(id);

            if (existingSale == null)
                return new SaleResponse("Sale not found");
            return new SaleResponse(existingSale);
        }

        public async Task<SaleResponse> SaveAsync(Sale sale)
        {
            try
            {
                await _saleRepository.AddAsync(sale);
                await _unitOfWork.CompleteAsync();

                return new SaleResponse(sale);
            }
            catch (Exception ex)
            {
                return new SaleResponse($"An error ocurred while saving the Sale: {ex.Message}");
            }
        }

        public async Task<SaleResponse> UpdateAsync(int id, Sale sale)
        {
            var existingSale = await _saleRepository.FindById(id);

            if (existingSale == null)
                return new SaleResponse("Sale not found");

            existingSale.DateAndTime = sale.DateAndTime;
            existingSale.ClientFullName = sale.ClientFullName;

            try
            {
                _saleRepository.Update(existingSale);
                await _unitOfWork.CompleteAsync();

                return new SaleResponse(existingSale);
            }
            catch (Exception ex)
            {
                return new SaleResponse($"An error ocurred while updating Sale: {ex.Message}");
            }

        }

        public async Task<SaleResponse> DeleteAsync(int id)
        {
            var existingSale = await _saleRepository.FindById(id);

            if (existingSale == null)
                return new SaleResponse("Sale not found");

            try
            {
                _saleRepository.Remove(existingSale);
                await _unitOfWork.CompleteAsync();

                return new SaleResponse(existingSale);
            }
            catch (Exception ex)
            {
                return new SaleResponse($"An error ocurred while deleting Sale: {ex.Message}");
            }
        }

    }
}
