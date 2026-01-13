using Microsoft.Extensions.Configuration;
using NAudio.Dmo.Effect;
using System.ComponentModel;

namespace DeviceListener
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartUpManager.Boot(args);
            //Console.WriteLine("input " + config["input"]);
            //Console.WriteLine("output " + config["output"]);


            //Console.WriteLine($"inputChoice = {inputChoice}");
            //Console.WriteLine($"outputChocie = {outputChoice}");

            //string inputArg = config["input"]!;
            //string outputArg = config["output"]!;







            //bool wasSuccessful = int.TryParse(inputArg, out int inputChoice);
            //int outputChoice = 0;
            //if (wasSuccessful)
            //{
            //    wasSuccessful = int.TryParse(outputArg, out outputChoice);
            //}

            //if (wasSuccessful)
            //{
            //    Console.WriteLine("Both could be parsed into integers");
            //}


            //Console.WriteLine(inputArg);
            //Console.WriteLine(outputArg);


            //inputChoice = Menu.UserChoice(controller.GetInputDeviceNameList());
            //int userSelection = 0;
            //if (args.Length == 0)
            //{
            //    Console.WriteLine("Please select an audio input device to listen to.\n");
            //    //userSelection = Menu.UserChoice(controller.GetDeviceNameList());
            //}
            //else if (args.Length == 1)
            //{
            //    bool wasNumber = int.TryParse(args[0], out int deviceNumber);
            //    if (wasNumber && deviceNumber < controller.InputDevices.Count)
            //    {
            //        userSelection = deviceNumber;
            //    }
            //}

            //controller.Listen(userSelection);
        }
    }
}
