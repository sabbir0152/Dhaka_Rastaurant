using Mapster;
using CodeCampRestora.Domain.Entities;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Services;
using CodeCampRestora.Application.DTOs;

namespace CodeCampRestora.Application.Features.Images.Commands.CreateImage;

public class CreateImageCommandHandler : ICommandHandler<CreateImageCommand, IResult<List<ImageDTO>>>
{
    private readonly IImageService _imageService;

    public CreateImageCommandHandler(IImageService imageService)
    {
        _imageService = imageService;
    }

    public async Task<IResult<List<ImageDTO>>> Handle(CreateImageCommand request, CancellationToken cancellationToken)
    {
        //var relativePaths = new List<string>();
        //foreach(var image in request.Images)
        //{
        //    byte[] imageBytes = Convert.FromBase64String(image.Base64Url);
        //}
        //   var imageEO = request.Adapt<List<Image>>();
            var rPaths = await _imageService.UploadMultipleImageAsync(request.Images);
            var relativePaths = rPaths.Data;
        

        
        return Result<List<ImageDTO>>.Success(new List<ImageDTO>());
    }
}