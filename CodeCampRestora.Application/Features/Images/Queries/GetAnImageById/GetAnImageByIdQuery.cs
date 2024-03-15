using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;

namespace CodeCampRestora.Application.Features.Images.Queries.GetAnImageById;

public record GetAnImageByIdQuery(Guid Id) : IQuery<IResult<ImageDTO>>;