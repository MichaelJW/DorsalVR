# DorsalVR - A VR interface for PC games

[@MichaelJW](https://twitter.com/MichaelJW)

DorsalVR is a Windows VR app that can pass motion data from your HMD and XR controllers to other software running on Windows, and mirror your monitor to a virtual screen inside the VR headset.

It currently supports outputting motion data via DSU (DualShock over UDP, also known as [cemuhook protocol](https://v1993.github.io/cemuhook-protocol/)), which makes it compatible with [Dolphin Emulator](https://dolphin-emu.org/). Future versions will support output via other means.

## Requirements

DorsalVR uses [OpenXR](https://www.khronos.org/openxr/) and is written in [Unity](https://www.unity.com/); currently it will only run on Windows (64-bit).

It supports any VR equipment that supports OpenXR (that is, any equipment that can use SteamVR, Oculus, or WMD), and so it can be used with the Oculus Quest or Quest 2, but only via [Oculus Link](https://www.oculus.com/accessories/oculus-link/), [Air Link](https://www.oculus.com/blog/introducing-oculus-air-link-a-wireless-way-to-play-pc-vr-games-on-oculus-quest-2-plus-infinite-office-updates-support-for-120-hz-on-quest-2-and-more/), or [Virtual Desktop](https://www.vrdesktop.net/) (Windows version) - it cannot run natively on the headset, even via sideloading.

## Usage

First, download the latest release's zip file from [the releases page](https://github.com/MichaelJW/DorsalVR/releases/), and unzip it to a folder on your hard drive.

- If using SteamVR: add `DorsalVR.exe` to Steam [as a non-Steam game](https://support.steampowered.com/kb_article.php?ref=2219-YDJV-5557). Right-click it in your library, select **Properties...**, and tick **Include in VR library**.
- If using the Oculus app: add `DorsalVR.exe` to your Library. (Click the **Plus** button, click **App not listed? Add it here**, then find `DorsalVR.exe`.)

Load DorsalVR as you would any VR app or game using SteamVR or Oculus. The first time you load it, it will do some setup in the background, immediately quit, and open a folder in Explorer, ready for you to set up your desired config.

### Dolphin

Currently, the only app actively supported is [Dolphin Emulator](https://dolphin-emu.org/); see [this page in the Wiki](https://github.com/MichaelJW/DorsalVR/wiki/Dolphin-Usage-Instructions) for instructions on setting that up.

### Command Line Parameters

Three command line parameters are supported:

- `-sbs`: enable side-by-side stereoscopic 3D support.
- `-selfie`: make the screen move with the HMD, as though attached via a selfie stick.
- `-port=NNNNN`: set the DSU server to use port NNNNN. (Default: `26659`)
- `-angleX=XXX`: apply a permanent tilt backwards to the virtual controller by the angle specified. (Degrees; default: `0`.)

You can set these command line parameters via the app's Properties in Steam or via Menu > Edit in Oculus - in either case, put the parameters in the Launch Options box.

## Known Bugs

### Virtual Controller Angle Mismatch

Different OpenXR runtimes (SteamVR, Oculus, etc) can report the controllers' rotations in different ways; the specifics of this can change between one version of the runtime and the next.

If your virtual controller does not seem to match the angle or position of your real controller, please [report it as an issue](https://github.com/MichaelJW/DorsalVR/issues), and supply the details of the controllers and runtime you are using.

## In Development

The following features are planned:

- An actual UI for choosing config files.
- A more aesthetic environment.
- Better controller models.
- Different forms of controller data output other than DSU.
- Built-in support for other apps (to begin with: Citra, Cemu, Yuzu, and Ryujinx).
- More tweaks to the controllers, to allow mapping, say, a virtual steering wheel.

Take a look at the [open enhancements](https://github.com/MichaelJW/DorsalVR/labels/enhancement) to see how progress is going, and feel free to suggest your own ideas.

## Thanks

Big thanks to the Dolphin team for a tremendously well-written and well-documented emulator. The excellent Dolphin blog post [Mastering Motion](https://dolphin-emu.org/blog/2019/04/26/mastering-motion/) got me interested in this in the first place - read it, it's superb.

In particular, thanks to [iwubcode](https://github.com/iwubcode), [jordan-woyak](https://github.com/jordan-woyak), and Filoppi for their work on Free Look, motion input, and DSU, which I have learnt so much from.

Thanks also to:

- [https://github.com/ruccho](ruccho) for [UnityGraphicsCapture](https://github.com/ruccho/UnityGraphicsCapture), which does the work of mirroring the desktop to a virtual screen using [Windows.Graphics.Capture](https://blogs.windows.com/windowsdeveloper/2019/09/16/new-ways-to-do-screen-capture/).
- [https://github.com/Davidobot](Davidobot) for [https://github.com/Davidobot/BetterJoy](BetterJoy), which has been very useful for debugging actual movement data.
- Rajkosto and v1993 for [the DSU/Cemuhook protocol](https://cemuhook.sshnuke.net/) and [its documentation](https://v1993.github.io/cemuhook-protocol/).
- NullFX for [this Crc32 implementation](http://sanity-free.org/12/crc32_implementation_in_csharp.html) which is used here to compute the checksum required by the DSU protocol.
- Antoine Aubry for [YamlDotNet](https://github.com/aaubry/YamlDotNet), which I use (albeit clumsily) to parse the config files.
