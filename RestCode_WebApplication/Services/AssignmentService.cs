using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestCode_WebApplication.Domain.Models;
using RestCode_WebApplication.Domain.Repositories;
using RestCode_WebApplication.Domain.Services;
using RestCode_WebApplication.Domain.Services.Communication;

namespace RestCode_WebApplication.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IAssignmentRepository _assignmentRepository;
        public readonly IUnitOfWork _unitOfWork;

      
        public AssignmentService(IAssignmentRepository assignmentRepository, IUnitOfWork unitOfWork)
        {
            _assignmentRepository = assignmentRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Assignment>> ListAsync()
        {
            return await _assignmentRepository.ListAsync();
        }

        public async Task<AssignmentResponse> GetByIdAsync(int id)
        {
            var existingAssignment = await _assignmentRepository.FindById(id);

            if (existingAssignment == null)
                return new AssignmentResponse("Assignment not found");
            return new AssignmentResponse(existingAssignment);
        }

        public async Task<AssignmentResponse> SaveAsync(Assignment assignment)
        {
            try
            {
                await _assignmentRepository.AddAsync(assignment);
                await _unitOfWork.CompleteAsync();

                return new AssignmentResponse(assignment);
            }
            catch (Exception ex)
            {
                return new AssignmentResponse($"An error ocurred when while saving assignment: {ex.Message}");

            }
        }

        public async Task<AssignmentResponse> UpdateAsync(int id, Assignment assignment)
        {
            var existingAssignment = await _assignmentRepository.FindById(id);
            if (existingAssignment == null)
                return new AssignmentResponse("Assignment not found");

            existingAssignment.State = assignment.State;
            existingAssignment.RestaurantId = assignment.RestaurantId;
            existingAssignment.ConsultantId = assignment.ConsultantId;

            try
            {
                _assignmentRepository.Update(existingAssignment);
                await _unitOfWork.CompleteAsync();

                return new AssignmentResponse(existingAssignment);
            }
            catch (Exception ex)
            {
                return new AssignmentResponse($"An error ocurred when while saving assignment: {ex.Message}");

            }
        }

        public async Task<AssignmentResponse> DeleteAsync(int id)
        {
            var existingAssignment = await _assignmentRepository.FindById(id);
            if (existingAssignment == null)
                return new AssignmentResponse("Assignment not found");

            try
            {
                _assignmentRepository.Remove(existingAssignment);
                await _unitOfWork.CompleteAsync();

                return new AssignmentResponse(existingAssignment);
            }
            catch (Exception ex)
            {
                return new AssignmentResponse($"An error ocurred when while saving assignment: {ex.Message}");

            }
        }
    }
}
