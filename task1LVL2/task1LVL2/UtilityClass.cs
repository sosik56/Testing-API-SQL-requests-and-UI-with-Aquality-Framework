using System;

namespace task1LVL2
{
    public static class UtilityClass
    {
        public static string GetRandomGuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
