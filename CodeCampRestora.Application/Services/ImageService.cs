using Mapster;
using Microsoft.AspNetCore.Http;
using CodeCampRestora.Domain.Entities;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Attributes;
using IResult = CodeCampRestora.Application.Models.IResult;
using CodeCampRestora.Application.Common.Interfaces.Services;
using CodeCampRestora.Application.Common.Interfaces.Repositories;

namespace CodeCampRestora.Application.Services;

[ScopedLifetime]
public class ImageService : IImageService
{
    

    public async Task<IResult<string>> UploadImageAsync(ImageDTO image)
    {
        byte[] imageData = Convert.FromBase64String(image.Base64Url);
        await SaveImageData(image, imageData);
        string relativePath = GetRelativeImagePath(image);
        return Result<string>.Success(relativePath);
    }

    public async Task<IResult<List<string>>> UploadMultipleImagesAsync(List<ImageDTO> images)
    {
        var relativePaths = new List<string>();
        foreach(var image in images)
        {
            byte[] imageData = Convert.FromBase64String(image.Base64Url);
            await SaveImageData(image, imageData);
            string relativePath = GetRelativeImagePath(image);
            relativePaths.Add(relativePath);
        }
        return Result<List<string>>.Success(relativePaths);
    }

    public async Task<IResult<List<string>>> GetAllImagesAsync(List<string> filePaths)
    {
        var listBase64Url = new List<string>();
        foreach(var filePath in filePaths)
        {
            string imageName = Path.Combine(filePath.Split(Path.DirectorySeparatorChar));
            string rootImagePath = Path.Combine("wwwroot", imageName);
            string newImageName = rootImagePath.Replace("\\", "/");
            string imagesDirectory = "wwwroot/images";
            string base64Url = "";

            if (Directory.Exists(imagesDirectory))
            {
                string[] imageFiles = Directory.GetFiles(imagesDirectory);

                foreach (string imagePath in imageFiles)
                {
                    string newImagePath = imagePath.Replace("\\", "//");
                    if (newImageName == newImagePath)
                    {
                        byte[] imageData = await File.ReadAllBytesAsync(imagePath);


                        base64Url = Convert.ToBase64String(imageData);
                        listBase64Url.Add(base64Url);
                    }
                }
            }
        }

        return Result<List<string>>.Success(listBase64Url);
    }

    public async Task<IResult<string>> GetImageByFilePathAsync(string filePath)
    {
        string imageName = Path.Combine(filePath.Split(Path.DirectorySeparatorChar));
        string rootImagePath = Path.Combine("wwwroot", imageName);
        string newImageName = rootImagePath.Replace("\\", "/");
        string imagesDirectory = "wwwroot/images";
        string base64Url = "";

        if (Directory.Exists(imagesDirectory))
        {
            string[] imageFiles = Directory.GetFiles(imagesDirectory);

            foreach (string imagePath in imageFiles)
            {
                string newImagePath = imagePath.Replace("\\", "//");
                if (newImageName == newImagePath)
                {
                    byte[] imageData = await File.ReadAllBytesAsync(imagePath);

                    
                    base64Url = Convert.ToBase64String(imageData);
                }
            }
        }
        

        return Result<string>.Success(base64Url);
    }

    public async Task<IResult> DeleteImageAsync(string filePath)
    {
        string imageName = Path.Combine(filePath.Split(Path.DirectorySeparatorChar));
        string rootImagePath = Path.Combine("wwwroot", imageName);
        string newImageName = rootImagePath.Replace("\\", "/");

        if (File.Exists(newImageName))
        {
            File.Delete(newImageName);
            return Result.Success();
        }
        else
        {
            return Result.Failure(StatusCodes.Status404NotFound,ImageErrors.NotFound);
        }
        
    }

    private async Task SaveImageData(ImageDTO image, byte[] imageData)
    {
        string uploadDirectory = "wwwroot/images";

        if (!Directory.Exists(uploadDirectory))
        {
            Directory.CreateDirectory(uploadDirectory);
        }
        image.Size = imageData.Length;
        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(image.Name);
        string filePath = Path.Combine(uploadDirectory, $"{image.Id}_{fileNameWithoutExtension}.jpg");

        await File.WriteAllBytesAsync(filePath, imageData);
    }

    private string GetRelativeImagePath(ImageDTO image)
    {
        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(image.Name);
        string filePath = Path.Combine("images", $"{image.Id}_{fileNameWithoutExtension}.jpg");

        return filePath;
    }

    private string GetRelativePath(string fullPath)
    {
        string rootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

        if (fullPath.StartsWith(rootPath, StringComparison.OrdinalIgnoreCase))
        {
            string relativePath = Path.GetRelativePath(rootPath, fullPath);
            return relativePath.Replace('\\', '/'); // Use forward slashes for consistency
        }

        return fullPath;
    }

}