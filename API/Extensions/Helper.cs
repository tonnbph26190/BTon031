using System;

namespace API.Extensions
{
    public static class Helper
    {
        private static Random random = new Random();

        public static string GenerateRandomString(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
