using System;
using System.CodeDom;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

public class AudioController
{

    public MMDeviceCollection Devices { get; private set; }
    public MMDeviceEnumerator DeviceEnumerator { get; private set; }
    private BufferedWaveProvider? _waveProvider = null!;
    private VolumeSampleProvider? _volumeProvider = null!;
    private int _volume = 10;


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

        _volumeProvider = new VolumeSampleProvider(_waveProvider.ToSampleProvider());
        _volumeProvider.Volume = _volume / 10f;

        capture.DataAvailable += CaptureOnDataAvailable!;

        using var playback = new WasapiOut(
            speakers,
            AudioClientShareMode.Shared,
            useEventSync: false,
            latency: 50
        );

        playback.Init(_volumeProvider);
        capture.StartRecording();
        playback.Play();

        Console.Clear();
        int presses = 0;
        bool firstTime = true;
        bool listening = true;
        while (listening)
        {
            _volumeProvider.Volume = _volume / 10f;

            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);

            if (firstTime)
            { 
                Console.Write($"Audio playback started.   Current volume: {DisplayVolume()}\n\n");
                Console.Write("   Increase volume   +1%:   Up / + / W   +10%: PageUp\n");
                Console.Write("   Decreate volume   -1%: Down / - / S   -10%: PageDown\n\n\n");
                Console.Write(" Press the Escape, Space or Enter key to stop listening to this device.\n");
            }
            else // Flicker reduction
            {
                Console.CursorLeft += 42;
                Console.Write(DisplayVolume() + "\n\n\n\n\n\n");
            }

            Console.Write("\n  Presses left to quit: ");
            switch (presses)
            {
                case 0:
                    Console.Write("3");
                    break;
                case 1:
                    Console.Write("2");
                    break;
                case 2:
                    Console.Write("1");
                    break;
            }

            ConsoleKey pressed = Console.ReadKey(true).Key;


            switch (pressed)
            {
                case ConsoleKey.Escape:
                case ConsoleKey.Spacebar:
                case ConsoleKey.Enter:
                    presses++;
                    break;

                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                case ConsoleKey.OemPlus:
                    if (_volume < 100)
                    {
                        _volume++;
                    }
                    presses = 0;
                    break;

                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                case ConsoleKey.OemMinus:
                    if (_volume >= 1)
                    {
                        _volume--;
                    }
                    presses = 0;
                    break;

                case ConsoleKey.PageUp:
                    if (_volume < 100)
                    {
                        _volume = Math.Min(_volume + 10, 100);
                    }
                    presses = 0;
                    break;

                case ConsoleKey.PageDown:
                    if (_volume >= 1)
                    {
                        _volume = Math.Max(_volume - 10, 0);
                    }
                    presses = 0;
                    break;

                default:
                    break;
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

    private string DisplayVolume()
    {
        int filledTenths = (_volume / 10);
        int emptyTenths = (10 - filledTenths);

        string volumeBar = "[" + new string('█', filledTenths) + new string(' ', emptyTenths) + "]";

        int volumeSpaces = 0;
        switch (_volume)
        {
            case 100:
                volumeSpaces = 0;
                break;

            case >= 10:
                volumeSpaces = 1;
                break;

            case >= 0:
                volumeSpaces = 2;
                break;
        }

        string volumeNumber = new string(' ', volumeSpaces) + _volume.ToString() + "%";

        return $"{volumeBar} {volumeNumber}";
    }
}