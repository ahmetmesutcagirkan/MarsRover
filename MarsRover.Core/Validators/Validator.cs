using System;
using System.Text.RegularExpressions;

namespace MarsRover.Core.Validators
{
    public static class Validator
    {
        public static bool ValidatePlateauBoundaries(string boundaries)
        {
            if (String.IsNullOrEmpty(boundaries))
                return false;

            Regex regex = new Regex(@"^\d+ \d+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return regex.IsMatch(boundaries);
        }

        public static bool ValidateRoverPosition(string roverPosition)
        {
            if (String.IsNullOrEmpty(roverPosition))
                return false;

            Regex regex = new Regex(@"^\d+ \d+ [EWSN]$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return regex.IsMatch(roverPosition);
        }

        public static bool ValidateRoverCommands(string commands)
        {
            if (String.IsNullOrEmpty(commands))
                return false;

            Regex regex = new Regex("^[LMR]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            return regex.IsMatch(commands);
        }
    }
}
