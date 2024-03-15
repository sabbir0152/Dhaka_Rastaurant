

using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using MediatR;

namespace CodeCampRestora.Application.Features.Branches.Queries.GetById;

public record GetBranchByIdQuery(Guid Id) : IQuery<IResult<BranchDTO>>;
