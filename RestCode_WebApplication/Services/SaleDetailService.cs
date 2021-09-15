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
    public class SaleDetailService : ISaleDetailService
    {
        private readonly ISaleDetailRepository _saleDetailRepository;
        public readonly IUnitOfWork _unitOfWork;

        public SaleDetailService(ISaleDetailRepository saleDetailRepository, IUnitOfWork unitOfWork)
        {
            _saleDetailRepository = saleDetailRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<SaleDetail>> ListAsync()
        {
            return await _saleDetailRepository.ListAsync();
        }

        public async Task<SaleDetailResponse> GetByIdAsync(int id)
        {
            var existingSaleDetail = await _saleDetailRepository.FindById(id);

            if (existingSaleDetail == null)
                return new SaleDetailResponse("Sale not found");
            return new SaleDetailResponse(existingSaleDetail);
        }

        public async Task<SaleDetailResponse> SaveAsync(SaleDetail saleDetail)
        {
            try
            {
                await _saleDetailRepository.AddAsync(saleDetail);
                await _unitOfWork.CompleteAsync();

                return new SaleDetailResponse(saleDetail);
            }
            catch (Exception ex)
            {
                return new SaleDetailResponse($"An error ocurred while saving the Sale Detail: {ex.Message}");
            }
        }

        public async Task<SaleDetailResponse> UpdateAsync(int id, SaleDetail saleDetail)
        {
            var existingSaleDetail = await _saleDetailRepository.FindById(id);

            if (existingSaleDetail == null)
                return new SaleDetailResponse("Sale Detail not found");

            existingSaleDetail.Description = saleDetail.Description;
            existingSaleDetail.Quantity = saleDetail.Quantity;

            try
            {
                _saleDetailRepository.Update(existingSaleDetail);
                await _unitOfWork.CompleteAsync();

                return new SaleDetailResponse(existingSaleDetail);
            }
            catch (Exception ex)
            {
                return new SaleDetailResponse($"An error ocurred while updating Sale Detail: {ex.Message}");
            }
        }

        public async Task<SaleDetailResponse> DeleteAsync(int id)
        {
            var existingSaleDetail = await _saleDetailRepository.FindById(id);

            if (existingSaleDetail == null)
                return new SaleDetailResponse("Sale Detail not found");

            try
            {
                _saleDetailRepository.Remove(existingSaleDetail);
                await _unitOfWork.CompleteAsync();

                return new SaleDetailResponse(existingSaleDetail);
            }
            catch (Exception ex)
            {
                return new SaleDetailResponse($"An error ocurred while deleting Sale Detail: {ex.Message}");
            }
        }
    }
}
