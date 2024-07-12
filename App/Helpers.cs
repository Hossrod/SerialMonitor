namespace SerialMonitor
{
    /// <summary>
    /// The Helpers class provides utility methods for the application.
    /// </summary>
    public class Helpers
    {
        /// <summary>
        /// The factor used for converting bytes to higher units (KB, MB, GB, etc.). 
        /// Each unit is 1024 times larger than the previous unit.
        /// </summary>
        private const int ByteConversionFactor = 1024;

        /// <summary>
        /// Converts the size in bytes to a human-readable string.
        /// </summary>
        /// <param name="bytes">The size in bytes.</param>
        /// <returns>A string representing the size in a human-readable format (e.g., KB, MB, GB, etc.).</returns>
        public static string ConvertBytesToHumanReadable(long bytes)
        {
            string[] sizeSuffixes = { "bytes", "KB", "MB", "GB", "TB" };
            double size = bytes >= 0 ? bytes : 0;
            int order = 0;

            while (size >= ByteConversionFactor && order < sizeSuffixes.Length - 1)
            {
                order++;
                size /= ByteConversionFactor;
            }

            // Format output string.
            string result = $"{size:0.##} {sizeSuffixes[order]}";
            return result;
        }
    }
}