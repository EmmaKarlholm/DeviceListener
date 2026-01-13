# Device Listener
A program to emulate the "Listen to this device" feature in Windows without having to go through all the Control Panel menus, allowing you to play back the input of an audio device. Useful for listening to Line-in devices or the like, or to get sidetone for your microphone.

## Usage
Simply start the program to see a menu of input audio devices on your system. Use the arrow keys (or W/S) to select an input device and it will be played through the output device you select in the subsequent menu.

It is possible to skip the menus to go directly to listening. Supply either or both an `--input 0` and/or `--output 0` argument to immediately set the application to use the stated input and/or output device. Start the program normally to see which numbers correspond to which device on your system.

There is also a `--help` command to list help from within your terminal.

## Credits
I'm standing on the shoulder of giants. I couldn't have done any of this without the [NAudio](https://github.com/naudio/NAudio) libraries.
