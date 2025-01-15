using PersonnelInfo.Core.Enums;
using PersonnelInfo.Shared.Exceptions.Infrastructure;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelInfo.Infrastructure.Configuration.EntitiesConfiguration
{
    public class _Conversions
    {
        public static string GenderType2String(GenderType? gender = GenderType.Unknown)
        {
            return gender switch
            {
                GenderType.Male => "آقای",
                GenderType.Female => "خانم",
                GenderType.Unknown => "نامشخص",
                _ => throw new NotImplementedException()
            };
        }
        public static GenderType String2GenderType(string? gender = "نامشخص")
        {
            return gender switch
            {
                "آقای" => GenderType.Male,
                "خانم" => GenderType.Female,
                "نامشخص" => GenderType.Unknown,
                _ => throw new NotImplementedException()
            };
        }

        public static string WorkingStatus2String(WorkingStatusType? WorkingStatus = WorkingStatusType.Working)
        {
            return WorkingStatus switch
            {
                WorkingStatusType.Working => "سر کار",
                WorkingStatusType.Left => "ترک کار",
                _ => throw new NotImplementedException()
            };
        }

        public static WorkingStatusType String2WorkingStatus(string? WorkingStatus = "سر کار")
        {
            return WorkingStatus switch
            {
                "سر کار" => WorkingStatusType.Working,
                "ترک کار" => WorkingStatusType.Left,
                _ => throw new NotImplementedException()
            };
        }

        public static string Gregorian2Farsi(DateTime gregorianDate, char delimiter)
        {
            var farsiCalendar = new PersianCalendar();
            var date = (farsiCalendar.GetYear(gregorianDate), farsiCalendar.GetMonth(gregorianDate), farsiCalendar.GetDayOfMonth(gregorianDate));
            return $"{date.Item1}{delimiter}{date.Item2:D2}{delimiter}{date.Item3:D2}";
        }

        public static DateTime Farsi2Gregorian(string farsiDate, char delimiter)
        {
            var farsiCalendar = new PersianCalendar();
            string[] dateParts = farsiDate.Split(delimiter);
            if (dateParts.Length != 3) throw new WrongDateFormat("Invalid date format");
            var date = farsiCalendar.ToDateTime(
                int.TryParse(dateParts[0], out var year) ? year : throw new WrongDateFormat("Year"),
                int.TryParse(dateParts[1], out var month) ? month : throw new WrongDateFormat("Month"),
                int.TryParse(dateParts[2], out var day) ? day : throw new WrongDateFormat("Day"), 0, 0, 0, 0
               );
            return date;
        }
    }
}
