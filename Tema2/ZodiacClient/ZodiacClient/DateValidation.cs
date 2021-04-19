using System.Text.RegularExpressions;

namespace ZodiacClient
{
    class DateValidation
    {
        private Regex yearPattern = new Regex(@"^(((0[13578]|[13578]|1[02])\/(0[1-9]|[1-9]|1\d|2\d|3[01]))|((0[469]|[469]|11)\/(0[1-9]|[1-9]|1\d|2\d|30))|((02|2)\/(0[1-9]|[1-9]|1\d|2[1-8])))\/\d{4}$");
        private Regex leapYearPattern = new Regex(@"^(((0[13578]|[13578]|1[02])\/(0[1-9]|[1-9]|1\d|2\d|3[01]))|((0[469]|[469]|11)\/(0[1-9]|[1-9]|1\d|2\d|30))|((02|2)\/(0[1-9]|[1-9]|1\d|2\d)))\/\d{4}$");

        public bool IsDateValid(string input)
        {
            if (yearPattern.IsMatch(input))
            {
                return true;
            }
            else if (leapYearPattern.IsMatch(input))
            {
                var year = int.Parse(input.Substring(input.Length - 4));

                if (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
