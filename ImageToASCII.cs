using System;
using System.Drawing;
using System.Collections.Generic;

namespace Image_to_ASCII_Cs
{
    public static class ImageToASCII
    {
        public static IEnumerable<string> ProcessImage(string imageName, int width, string ascii)
        {
            // Various variable instantiation:
            Bitmap image = new Bitmap(string.Format("images/{0}", imageName));
            Color pixel = new Color();
            byte red, green, blue;

            double rLuminosity, bLuminosity, gLuminosity;
            int rAsciiPosition,gAsciiPosition,bAsciiPosition;
            char rAsciiChar, gAsciiChar, bAsciiChar;
            char[] asciiRGB = new char[3];

            double rgbToAsciiRatio = 255.0/Convert.ToDouble(ascii.Length);
            

            // Create a temporary double variable to be used in the modifiedHeight variable.
            // This ensures that Math.Round() doesn't see the result of the modified height
            // variable as both a decimal and double.
            double temp = Convert.ToDouble(width) * Convert.ToDouble(image.Height) / Convert.ToDouble(image.Width);
            int height = Convert.ToInt32(Math.Round(temp)); 
            Bitmap resizedImage = ImageTools.ResizeImage(image, width, height);

            // Loops through each pixel row of the resized image, calculates its luminosity,
            // and picks the appropiate ASCII character for the red, green, and blue pixels.
            for (int y = 0; y < resizedImage.Height; y++)
            {
                for (int x = 0; x < resizedImage.Width; x++)
                {
                    pixel = resizedImage.GetPixel(x, y);
                    red = pixel.R;
                    green = pixel.G;
                    blue = pixel.B;
                    rLuminosity = 0.330*red;
                    gLuminosity = 0.587*green;
                    bLuminosity = 0.087*blue;
                    rAsciiPosition = Convert.ToInt32((rLuminosity / rgbToAsciiRatio));
                    gAsciiPosition = Convert.ToInt32((gLuminosity / rgbToAsciiRatio));
                    bAsciiPosition = Convert.ToInt32((bLuminosity / rgbToAsciiRatio));
                    rAsciiChar = ascii[rAsciiPosition];
                    gAsciiChar = ascii[gAsciiPosition];
                    bAsciiChar = ascii[bAsciiPosition];
                    asciiRGB[0] = rAsciiChar;
                    asciiRGB[1] = gAsciiChar;
                    asciiRGB[2] = bAsciiChar;
                    yield return new string(asciiRGB);
                }
                yield return "\n";
            }
        }
    }
}