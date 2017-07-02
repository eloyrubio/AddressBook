using System;

namespace UBSWebApplication.Core.Helpers
{
    public static class RandomNumber
    {
        private static readonly Random Instance = new Random();

        public static int Next()
        {
            return Instance.Next(1, 99);
        }
    }
}