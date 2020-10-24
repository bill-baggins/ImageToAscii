using System;
using System.IO;
using System.Collections.Generic;

namespace Image_to_ASCII_Cs
{
    class Program
    {
        static void Main(string[] args)
        {
            // The ascii string. I am trying to decide which one makes the image look best.
            //string ascii = "$@B%8&WM#*oahkbdpqwmZO0QLCJUYXzcvunxrjft/\\|()1}{][?-_+~i!lI;:,\"^`";
            string ascii = "$@B %M#akdq  QCUXcux  \\(1{[-+il;,^ ";
            //string ascii = "$8#hpOLUvr/\\}]?~I^ ";
            //string ascii = "$#pLv/}?I ";
            //string ascii = "$*pQv}?!^ ";
            
            
            // User option: choose the width of the image.
            string stringWidth;
            int width;

            // User Option: choose to invert or not invert the image.
            string invertImage;

            // Relative paths for the image (source directory) and
            // the ASCII images (destination directory)
            string imagePath = @"images\";
            string writingPath = @"ascii\";

            // Stores image names in a directory.
            string[] images = Directory.GetFiles(imagePath, "*.*");

            // Accepted image formats.
            string[] validFileFormats = new string[] { ".jpg", ".png", ".bmp", ".gif", ".JPG", ".PNG", ".BMP", ".GIF"};
            List<string> badFileFormats = new List<string>();

            // Preliminary check to ensure that the files in the image directory are of the types in
            // validFileFormats. If it is not, it adds it to the badFileFormats List.
            Console.WriteLine("Files in the 'image' directory:");
            for(int i = 0; i < images.Length; i++)
            {
                for (int j = 0; j < validFileFormats.Length; j++)
                {
                    if(images[i].Slice(images[i].Length-4, images[i].Length) == validFileFormats[j])
                    {
                        break;
                    }
                    else if (images[i].Slice(images[i].Length-4, images[i].Length) != validFileFormats[j] && j == validFileFormats.Length-1)
                    {
                        badFileFormats.Add(images[i]);
                    }  
                }
                Console.WriteLine("{0}: {1} ", i+1 ,images[i].Replace("images\\", ""));
            }

            // Checks to see if there are files in badFileFormats. If so, it will display
            // the problem files and exit the environment.
            if(badFileFormats.Count > 0)
            {
                Console.WriteLine("\nWARNING: Your 'images' directory contains a file that is not of the following accepted formats: .jpg, .png, .gif, .bmp");
                Console.WriteLine("\nPlease remove the following unwanted file(s) from the 'images' directory:");
                for(int i = 0; i < badFileFormats.Count; i++)
                {
                    Console.WriteLine("{0}: {1}", i+1, badFileFormats[i].Replace("images\\", ""));
                }
                Console.WriteLine("Press the 'enter' key to exit the program...");
                Console.ReadLine();
                Environment.Exit(0);
            }

            // User-Input Loop for width: 
            Console.WriteLine("Enter in the width for your images (300-1024 characters):");
            while(true) 
            {
                stringWidth = Console.ReadLine();
                try 
                { 
                    width = Convert.ToInt32(stringWidth); 
                    if(width > 1024 || width < 300) 
                    {
                        Console.WriteLine("Please input a valid number (300-1024)");
                        continue;
                    }
                    width = width / 3;
                }
                catch 
                { 
                    Console.WriteLine("Please input a valid number (300-1024)");
                    continue;
                }
                break;
            }

            // User-Input Loop for inverted-color images:
            Console.WriteLine("Do you want your images to be inverted? y/n");
            while(true)
            {
                invertImage = Console.ReadLine();
                if(invertImage == "y")
                {
                    ascii = ascii.StringReverse();
                    break;
                }
                else if (invertImage == "n")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Input invalid. Enter in 'y' or 'n'");
                    continue;
                }
            }

            // For each image, it will open a StreamWriter that will create a file in the specified
            // path. Then it loops through the ProcessImage generator and writes each ASCII character 
            // to the file.
            for(int i = 0; i < images.Length; i++)
            {
                images[i] = images[i].Replace("images\\", "");
                string fileName = String.Format("{0}_ascii.txt", images[i]);
                using(StreamWriter file = new StreamWriter(writingPath+fileName))
                {
                    foreach(string element in ImageToASCII.ProcessImage(images[i], width, ascii))
                    {
                        file.Write(element);
                    }
                    Console.WriteLine("Success! Converted {0} to {1}", images[i], fileName);
                }
            }
            Console.WriteLine("All images converted!");
            Console.WriteLine("Press the 'enter' key to exit the program...");
            Console.ReadLine();
        }
    }
}
