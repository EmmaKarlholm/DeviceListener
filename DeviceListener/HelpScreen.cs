using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceListener
{
    internal static class HelpScreen
    {
        public static void Display()
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
            Console.Write("  DeviceListener.exe --output 1 --input 3 \n");
            Console.Write("\n" +
                          "The numbers you supply this way can be found within the application's\n" +
                          "user menus when ran without the appropriate arguments.\n");
        }
    }
}
