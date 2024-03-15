using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;

namespace CodeCampRestora.Application.Features.Images.Commands.DeleteImage;

public record DeleteImageCommand(Guid Id): ICommand<IResult>;