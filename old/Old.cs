using System;
using System.Drawing;
using System.Collections.Generic;

namespace Image_to_ASCII_Cs
{
    public static class Old
    {
        /*
        public static IEnumerable<string> ProcessImage(string imageName, int width, string ascii)
        {
            // Various variable instantiation:
            Bitmap image = new Bitmap(string.Format("images/{0}", imageName));
            Color pixel = new Color();
            byte red, green, blue;
            double rgbLuminosity;
            double rgbToAsciiRatio = 255.0/Convert.ToDouble(ascii.Length);
            int asciiPosition;
            char asciiChar;
            
            // Create a temporary double variable to be used in the modifiedHeight variable.
            // This ensures that Math.Round() doesn't see the result of the modified height
            // variable as both a decimal and double.
            double temp = Convert.ToDouble(width) * Convert.ToDouble(image.Height) / Convert.ToDouble(image.Width);
            int height = Convert.ToInt32(Math.Round(temp)); 
            Bitmap resizedImage = ImageTools.ResizeImage(image, width, height);

            // Loops through each pixel row of the resized image, calculates its luminosity,
            // and picks the appropiate ASCII character.
            for (int y = 0; y < resizedImage.Height; y++)
            {
                for (int x = 0; x < resizedImage.Width; x++)
                {
                    pixel = resizedImage.GetPixel(x, y);
                    red = pixel.R;
                    green = pixel.G;
                    blue = pixel.B;
                    rgbLuminosity = 0.330*red + 0.587*green + 0.083*blue;
                    asciiPosition = Convert.ToInt32((rgbLuminosity / rgbToAsciiRatio));
                    asciiPosition = asciiPosition-1 < 0 ? asciiPosition : asciiPosition-1;
                    asciiChar = ascii[asciiPosition];
                    yield return asciiChar.Repeat(3); 
                }
                yield return "\n";
            }
        }
        */
    }
}