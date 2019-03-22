using System;

namespace MyReadingList.Core
{
    public static class Clock
    {
        private static DateTime? _freezeTime = null;

        public static void Freeze(DateTime? freezeTime = null)
        {
            _freezeTime = freezeTime.GetValueOrDefault();
        }

        public static void Thaw()
        {
            _freezeTime = null;
        }
        public static DateTime Now()
        {
            return _freezeTime ??  DateTime.Now;
        }
    }
}
