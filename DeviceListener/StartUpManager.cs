using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceListener
{
    internal static class StartUpManager
    {
        public static void Boot(string[] args)
        {
            AudioController controller = new AudioController();
            ParseArguments(args, controller);
        }

        public static void ParseArguments(string[] args, AudioController controller)
        {
            var config = new ConfigurationBuilder()
                .AddCommandLine(args)
                .Build();

            int inputChoice;
            int outputChoice;

            bool inputArgIsInteger = int.TryParse(config["input"], out inputChoice);
            bool outputArgIsInteger = int.TryParse(config["output"], out outputChoice);

            if (!inputArgIsInteger 
                || inputChoice < 0 
                || inputChoice >= controller.InputDevices.Count)
            {
            Menu.DrawHeader("Please select an input device. (the device being recorded)");
            inputChoice = Menu.UserChoice(controller.GetDeviceNameList(controller.InputDevices));                
            }

            if (!outputArgIsInteger
                || outputChoice < 0
                || outputChoice >= controller.OutputDevices.Count)
            {
            Menu.DrawHeader("Please select an output device (the device where you listen)");
            outputChoice = Menu.UserChoice(controller.GetDeviceNameList(controller.OutputDevices));
            }

            controller.Listen(inputChoice, outputChoice);

            Console.WriteLine($"inputChoice is {inputChoice}");
            Console.WriteLine($"outputChoice is {outputChoice}");
        }
    }
}
