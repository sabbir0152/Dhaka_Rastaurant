using MediatR;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Domain.Entities.Branches;
using CodeCampRestora.Application.Exceptions;
using Microsoft.EntityFrameworkCore;
using Mapster;
using System.Linq.Expressions;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Features.Branches.Queries.GetById
{
    public class GetBranchByIdQueryHandler : IQueryHandler<GetBranchByIdQuery, IResult<BranchDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetBranchByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public async Task<IResult<BranchDTO>> Handle(GetBranchByIdQuery request, CancellationToken cancellationToken)
        {

            var branchEO = await _unitOfWork
                .Branches
                .IncludeProps(
                    branch => branch.Address,
                    branch => branch.CuisineTypes,
                    branch => branch.OpeningClosingTimes)
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (branchEO == null) throw new ResourceNotFoundException("Branch Not found");

            var branchDto = branchEO.Adapt<BranchDTO>();
            
            return Result<BranchDTO>.Success(branchDto);
        }
    }
}
