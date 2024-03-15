using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Domain.Entities;

namespace CodeCampRestora.Application.Features.Images.Commands.CreateImage;

public record CreateImageCommand : ICommand<IResult<List<ImageDTO>>>
{
    public List<ImageDTO> Images { get; set; }
    public CreateImageCommand(List<ImageDTO> images)
    {
        Images = images;
    }
}