using CodeCampRestora.Domain.Entities;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Common.Interfaces.Services;

public interface IImageService
{
    Task<IResult<List<string>>> UploadMultipleImagesAsync(List<ImageDTO> images);
    Task<IResult<string>> UploadImageAsync(ImageDTO image);
    Task<IResult<string>> GetImageByFilePathAsync(string filePath);
    Task<IResult<List<string>>> GetAllImagesAsync(List<string> filePaths);
    Task<IResult> DeleteImageAsync(string filePath);
}