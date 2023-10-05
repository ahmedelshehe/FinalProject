using FinalProject.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FinalProject.Utilities
{
    public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
    {
        public DateOnlyConverter() : base(
            dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
            dateTime => DateOnly.FromDateTime(dateTime))
        { }


    }

    public class TimeOnlyConverter : ValueConverter<TimeOnly, TimeSpan>
    {
        public TimeOnlyConverter() : base(
            timeOnly => timeOnly.ToTimeSpan(),
            timeSpan => TimeOnly.FromTimeSpan(timeSpan))
        { }
    }
    public static class PermissionExtensions
    {
        public static string HasPermission(this List<Permission> permissions, string entityName, Operation operation)
        {
            return permissions != null ? permissions.Any(p => p.Name == entityName && p.Operation == operation) ? "" : "hidden" : "hidden";
        }
		public static string HasAnyPermission(this List<Permission> permissions, string entityName)
		{
			return permissions != null ? permissions.Any(p => p.Name == entityName) ? "" : "hidden" : "hidden";
		}
	}



}
