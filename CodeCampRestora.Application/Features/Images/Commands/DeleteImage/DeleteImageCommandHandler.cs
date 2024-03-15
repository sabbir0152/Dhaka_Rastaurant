using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Services;

namespace CodeCampRestora.Application.Features.Images.Commands.DeleteImage;

public class DeleteImageCommandHandler : ICommandHandler<DeleteImageCommand, IResult>
{
    private readonly IImageService _imageService;

    public DeleteImageCommandHandler(IImageService imageService)
    {
        _imageService = imageService;
    }

    public async Task<IResult> Handle(DeleteImageCommand request, CancellationToken cancellationToken)
    {
        var result = await _imageService.DeleteImageAsync($"images//{request.Id}_mosabbir.jpg");
        return result;
    }
}