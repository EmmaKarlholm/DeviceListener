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
        }
    }
}
