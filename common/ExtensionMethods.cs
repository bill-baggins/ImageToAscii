using System.Collections.Generic;

namespace Image_to_ASCII_Cs
{
    /// <summary>
    /// Contains custom methods for IEnumerable types.
    /// </summary>
    public static class ExtensionMethods
    {
        
        /// <summary>
        /// Creates a slice of a list from the specified start and end point.
        /// </summary>
        /// <param name="start"> Starting point of the slice.</param>
        /// <param name="end"> Ending point of the slice.</param>
        /// <returns>The list slice.</returns>
        public static List<T> Slice<T> (this List<T> source, int start, int end)
        {
            // Handles negative ends.
            if (end < 0)
            {
                end = source.Count + end;
            }
            int len = end - start;

            // Return new List.
            List<T> res = new List<T>();
            for (int i = 0; i < len; i++)
            {
                res.Add(source[i + start]);
            }
            return res;
        }

        /// <summary>
        /// Creates a slice of an array from the specified start and end point.
        /// </summary>
        /// <param name="start"> Starting point of the slice.</param>
        /// <param name="end"> Ending point of the sluce.</param>
        /// <returns>The array slice.</returns>
        public static T[] Slice<T> (this T[] source, int start, int end)
        {
            if (end < 0)
            {
                end = source.Length + end;
            }
            int len = end - start;

            T[] res = new T[end-start];
            for (int i = 0; i < len; i++)
            {
                res[i] = source[i + start];
            }
            return res;
        }
        
        /// <summary>
        /// Creates a slice of a string from the specified start and end point.
        /// </summary>
        /// <param name="start"> Starting point of the slice.</param>
        /// <param name="end"> Ending point of the slice.</param>
        /// <returns>The string slice.</returns>
        public static string Slice (this string source, int start, int end)
        {
            if (end < 0)
            {
                end = source.Length + end;
            }
            int len = end - start;

            string res = "";
            for (int i = 0; i < len; i++)
            {
                res += source[i + start];
                
            }
            return res;
        }
    }
}