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





            //if  ((!int.TryParse(config["output"], out int outputChoice))
            //    || !int.TryParse(config["input"], out int inputChoice))
            //{
            //    Console.WriteLine("At least one of them could not be parsed, will handle as if no input");
            //}

            int inputChoice;
            int outputChoice;

            bool inputArgValid = int.TryParse(config["input"], out inputChoice);
            bool outputArgValid = int.TryParse(config["output"], out outputChoice);






            if (inputArgValid
                && outputArgValid
                && inputChoice < controller.InputDevices.Count
                && outputChoice < controller.InputDevices.Count)
            {
                controller.Listen(inputChoice, outputChoice);
            }



            Menu.DrawHeader("Please select an input device. (the device being recorded)");
            inputChoice = Menu.UserChoice(controller.GetDeviceNameList(controller.InputDevices));
            Menu.DrawHeader("Please select an output device (the device where you listen)");
            outputChoice = Menu.UserChoice(controller.GetDeviceNameList(controller.OutputDevices));

            Console.WriteLine($"inputChoice is {inputChoice}");
            Console.WriteLine($"outputChoice is {outputChoice}");


            Console.ReadKey(true);
            Console.ReadKey(true);
            Console.ReadKey(true);
            Console.ReadKey(true);

        }
    }
}
