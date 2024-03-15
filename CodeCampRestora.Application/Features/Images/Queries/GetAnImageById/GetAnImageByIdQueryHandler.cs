using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Services;

namespace CodeCampRestora.Application.Features.Images.Queries.GetAnImageById;

public class GetAnImageByIdQueryHandler : IQueryHandler<GetAnImageByIdQuery, IResult<ImageDTO>>
{
    private readonly IImageService _imageService;

    public GetAnImageByIdQueryHandler(IImageService imageService)
    {
        _imageService = imageService;
    }

    public async Task<IResult<ImageDTO>> Handle(GetAnImageByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _imageService.GetImageByFilePathAsync($"images//{request.Id}_mosabbir.jpg");
        //var result = await _imageService.GetAllImageAsync(new List<string>() { "images//257511e4-8cd1-40de-8814-2e40fa5a5de8_mosabbir.jpg", "images//3581dcfe-f4d9-431b-bef4-b847095afa56_signature.jpg" });

        return (IResult<ImageDTO>)result;
    }
}