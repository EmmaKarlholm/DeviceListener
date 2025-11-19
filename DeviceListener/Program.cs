namespace DeviceListener
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AudioController controller = new AudioController();

            int userSelection = 0;
            if (args.Length == 0)
            {
                Console.WriteLine("Please select an audio input device to listen to.\n");
                userSelection = Menu.UserChoice(controller.GetInputDeviceNameList());
            }
            else if (args.Length == 1)
            {
                bool wasNumber = int.TryParse(args[0], out int deviceNumber);
                if (wasNumber && deviceNumber < controller.Devices.Count)
                {
                    userSelection = deviceNumber;
                }
            }

            controller.Listen(userSelection);
        }
    }
}
