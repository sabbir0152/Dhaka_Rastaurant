namespace CodeCampRestora.Application.Common.Interfaces.Services;

public interface IDateTimeService
{
    public DateTime Now { get; }
    public TimeOnly ConvertToTimeOnly(string timeString);
    public DateTime ConvertToDateOnly(string dateString);
}
