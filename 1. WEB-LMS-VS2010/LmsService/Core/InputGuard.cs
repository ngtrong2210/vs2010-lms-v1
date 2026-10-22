using System;

namespace LmsService.Core
{
    internal static class InputGuard
    {
        public static string RequiredText(string value, int maxLength, string displayName)
        {
            string result = (value ?? string.Empty).Trim();
            if (result.Length == 0) throw new ArgumentException("Vui lòng nhập " + displayName + ".");
            if (result.Length > maxLength) throw new ArgumentException(displayName + " không được vượt quá " + maxLength + " ký tự.");
            return result;
        }

        public static long PositiveId(long value, string displayName)
        {
            if (value <= 0) throw new ArgumentException(displayName + " không hợp lệ.");
            return value;
        }
    }
}
