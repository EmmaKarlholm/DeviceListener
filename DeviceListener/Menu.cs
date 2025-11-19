using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceListener
{
    public static class Menu
    {
        public static int UserChoice(string[] devices)
        {
            int selectedIndex = 0;

            Console.CursorVisible = false;

            int menuTop = Console.CursorTop;

            RenderMenu(devices, selectedIndex, menuTop);

            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;

                int previousIndex = selectedIndex;

                if (key == ConsoleKey.UpArrow || key == ConsoleKey.W)
                {
                    if (selectedIndex == 0)
                    {
                        selectedIndex = devices.Length - 1;
                    }
                    else
                    {
                        selectedIndex--;
                    }
                }
                else if (key == ConsoleKey.DownArrow || key == ConsoleKey.S)
                {
                    if (selectedIndex == devices.Length - 1)
                    {
                        selectedIndex = 0;
                    }
                    else
                    {
                        selectedIndex++;
                    }
                }

                if (previousIndex != selectedIndex)
                {
                    UpdateMenuLine(devices[previousIndex], false, previousIndex, menuTop + previousIndex);
                    UpdateMenuLine(devices[selectedIndex], true, selectedIndex, menuTop + selectedIndex);
                }

            } while (key != ConsoleKey.Enter);

            Console.SetCursorPosition(0, menuTop + devices.Length);

            return selectedIndex;
        }

        private static void RenderMenu(string[] menuOptions, int selectedIndex, int menuTop)
        {
            for (int i = 0; i < menuOptions.Length; i++)
            {
                bool selected = false;
                if (i == selectedIndex)
                {
                    selected = true;
                }

                UpdateMenuLine(menuOptions[i], selected, i, menuTop + i);
            }
        }

        private static void UpdateMenuLine(string text, bool selected, int menuIndex, int line)
        {
            Console.SetCursorPosition(0, line);

            if (selected)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write($" {menuIndex}: {text} ");
            }
            else
            {
                Console.ResetColor();
                Console.Write($" {menuIndex}: {text} ");
            }

            Console.ResetColor();
        }
    }
}
