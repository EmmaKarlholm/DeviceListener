# Device Listener
A program to emulate the "Listen to this device" feature in Windows without having to go through all the Control Panel menus, allowing you to play back the input of an audio device. Useful for listening to Line-in devices or the like, or to get sidetone for your microphone.

## Usage
Simply start the program to see a menu of input audio devices on your system. Use the arrow keys (or W/S) to select a device and it will be played through your default audio playback device.

It is possible to skip the menu to go directly to listening. Supply a number on the command line which corresponds to the number shown in the program menu, ie `DeviceListener.exe 0` to start the first device in the list.

## Credits
I'm standing on the shoulder of giants. I couldn't have done any of this without the [NAudio](https://github.com/naudio/NAudio) libraries.
