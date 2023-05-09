using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarsNet.Source
{
    public class HumanTimeFormat
    {
        private const int SecondsInYear = 31_536_000;
        private const int SecondsInDay = 86_400;
        private const int SecondsInHour = 3600;
        private const int SecondsInMinute = 60;

        private static (int Total, int RemainingSeconds) GetUnits(int seconds, int secondsInUnit)
        {
            var unit = seconds / secondsInUnit;
            var remainingSeconds = seconds - unit * secondsInUnit;

            return (unit, remainingSeconds);
        }

        public static string formatDuration(int seconds)
        {
            if (seconds == 0) return "now";

            var units = new List<(string Name, int Total)>();

            // Collect all relevant time unit values
            var years = GetUnits(seconds, SecondsInYear);
            if(years.Total > 0) units.Add(("year", years.Total));

            var days = GetUnits(years.RemainingSeconds, SecondsInDay);
            if(days.Total > 0) units.Add(("day", days.Total));

            var hours = GetUnits(days.RemainingSeconds, SecondsInHour);
            if(hours.Total > 0) units.Add(("hour", hours.Total));

            var minutes = GetUnits(hours.RemainingSeconds, SecondsInMinute);
            if(minutes.Total > 0) units.Add(("minute", minutes.Total));

            seconds = minutes.RemainingSeconds;
            if(seconds > 0) units.Add(("second", seconds));

            // Build the result string
            var builder = new StringBuilder();
            void AppendUnit((string Name, int Total) unit)
            {
                if (unit.Total > 0) builder.Append($"{unit.Total} {unit.Name}");
                if (unit.Total > 1) builder.Append("s");
            }

            AppendUnit(units[0]);
            for (int i = 1; i < units.Count; i++)
            {
                // Add unit separator
                builder.Append(i < units.Count - 1 ? ", " : " and ");

                // Add unit
                AppendUnit(units[i]);
            }

            return builder.ToString();
        }
    }
}
