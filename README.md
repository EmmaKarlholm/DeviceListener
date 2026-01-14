# Device Listener
A program which allows you to play back the live input of an audio device. Useful for listening to Line-in devices, or to hear sidetone for your microphone.

## Usage
Simply start the program to see a menu of input audio devices on your system. Use the arrow keys (or W/S) to select an input device and it will be played through the output device you select in the subsequent menu.

It is possible to skip the menus to go directly to listening. Supply either or both an `--input #` and/or `--output #` argument (where # refers to an audio device number) to immediately set the application to use the stated input and/or output device.

To learn which of your audio devices have which device numbers, run the program using `--list` or start the program normally to see which numbers correspond to which device on your system.

There is also a `--help` command to list help on how to use command line arguments from within your terminal.

## Credits
I'm standing on the shoulder of giants. I couldn't have done any of this without the [NAudio](https://github.com/naudio/NAudio) libraries.
