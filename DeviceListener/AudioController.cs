using System;
using System.CodeDom;
using NAudio.CoreAudioApi;
using NAudio.Wave;

public class AudioController
{

    public MMDeviceCollection Devices { get; private set; }
    public MMDeviceEnumerator DeviceEnumerator { get; private set; }
    private BufferedWaveProvider? _waveProvider = null!;


    public AudioController()
    {
        DeviceEnumerator = new MMDeviceEnumerator();
        Devices = GetInputDeviceList();
    }

    public MMDeviceCollection GetInputDeviceList()
    {
        var devices = DeviceEnumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active);
        return devices;
    }

    public string[] GetInputDeviceNameList()
    {
        string[] deviceNames = new string[Devices.Count];
        for (int i = 0; i < Devices.Count; i++)
        {
            deviceNames[i] = Devices[i].FriendlyName;
        }

        return deviceNames;
    }

    public void Listen(int deviceNumber)
    {
        var speakers = DeviceEnumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Console);

        using var capture = new WasapiCapture(Devices[deviceNumber]);

        _waveProvider = new BufferedWaveProvider(capture.WaveFormat);

        capture.DataAvailable += CaptureOnDataAvailable!;

        using var playback = new WasapiOut(
            speakers,
            AudioClientShareMode.Shared,
            useEventSync: false,
            latency: 50
        );

        playback.Init(_waveProvider);
        capture.StartRecording();
        playback.Play();

        Console.Clear();
        int presses = 0;

        bool listening = true;
        while (listening)
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            Console.Write("Audio playback started.\n\n");
            Console.Write("Press the Escape, Space or Enter key three times\nto stop listening to this device   ");
            Console.CursorLeft -= 3;

            switch (presses)
            {
                case 0:
                    Console.Write(".");
                    break;
                case 1:
                    Console.Write("..");
                    break;
                case 2:
                    Console.Write("...");
                    break;
            }


            ConsoleKey pressed = Console.ReadKey(true).Key;

            if (pressed == ConsoleKey.Escape || pressed == ConsoleKey.Spacebar ||  pressed == ConsoleKey.Enter)
            {
                presses++;
            }
            else
            {
                presses = 0;
            }

            if (presses >= 3)
            {
                listening = false;
            }

        }

        Console.Clear();
        capture.StopRecording();
        playback.Stop();

    }

    private void CaptureOnDataAvailable(object sender, WaveInEventArgs e)
    {
        _waveProvider!.AddSamples(e.Buffer, 0, e.BytesRecorded);
    }
}