namespace CodeCampRestora.Application.Common.Interfaces.Services;

public interface ICurrentUserService
{
    public string UserId { get; }
    public string RestaurantId { get; }
    public bool IsInRole(string role);
}