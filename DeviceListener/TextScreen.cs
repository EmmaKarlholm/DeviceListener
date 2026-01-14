using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace DeviceListener
{
    internal static class TextScreen
    {
        public static void Help()
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("DeviceListener");
            Console.ResetColor();
            Console.Write(" listens to audio devices and immediately outputs\n" +
                           "what is recorded through another audio device.\n\n");
            Console.Write("USAGE:\n");
            Console.Write("  DeviceListener.exe --output 1\n");
            Console.Write("  DeviceListener.exe --input 2\n");
            Console.Write("  DeviceListener.exe --input 0 --output 2\n");
            Console.Write("  DeviceListener.exe --output 1 --input 3\n");
            Console.Write("  DeviceListener.exe --list\n");
            Console.Write("\n" +
                          "The numbers you supply this way can be found within the application's\n" +
                          "user menus when ran without the appropriate arguments, or by\n" +
                          "running it with the --list argument.\n");
        }

        public static void List(string[] inputDevices, string[] outputDevices)
        {
            Console.Clear();
            Console.Write("Available sound devices:\n");

            Console.Write("\n");
            Console.Write("  Input:\n");
            WriteLines(inputDevices);

            Console.Write("\n");
            Console.Write("  Output:\n");
            WriteLines(outputDevices);
        }

        private static void WriteLines(string[] text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                Console.Write($"    {i}: {text[i]}\n");
            }
        }
    }
}
