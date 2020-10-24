using System.Text;
using System.Collections.Generic;

namespace Image_to_ASCII_Cs
{
    public static class PythonMethods
    {
        /// <summary>
        /// Iterates through an enumerable object and counts the number of times an 
        /// element appears.
        /// </summary>
        /// <param name="element">The specified element.</param>
        /// <returns>The number of items (Int32)</returns>
        public static int PyCount<T>(this IEnumerable<T> source, T element)
        {
            int count = 0;
            foreach (T item in source)
            {   
                if (object.Equals(item, element))
                {
                    count++;
                }   
            }
            return count;
        }

        /// <summary>
        /// Reverses a string.
        /// </summary>
        /// <returns> The reversed string. </returns>
        public static string StringReverse(this string source)
        {
            StringBuilder sb = new StringBuilder(source.Length);
            for (int i = source.Length-1; i >= 0; i--)
            {
                sb.Append(source[i]);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Repeats a string a specified number of times.
        /// </summary>
        /// <param name="multiplier"> The number of times the string is to be repeated. </param>
        /// <returns> A string. </returns>
        public static string Repeat(this string source, int multiplier)
        {
            StringBuilder sb = new StringBuilder(multiplier*source.Length);
            for (int i = 0; i <= multiplier; i++)
            {
                sb.Append(source);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Repeats a character a specified number of times.
        /// </summary>
        /// <param name="multiplier"> The number of times the character is to be repeated. </param>
        /// <returns> A string. </returns>
        public static string Repeat(this char character, int multiplier)
        {
            StringBuilder sb = new StringBuilder(multiplier);
            for (int i = 0; i < multiplier; i++)
            {
                sb.Append(character);
            }
            return sb.ToString();
        }
    
    }

}