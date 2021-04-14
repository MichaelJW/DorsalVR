# DorsalVR - A VR interface for PC games

[@MichaelJW](https://twitter.com/MichaelJW)

DorsalVR is a Windows VR app that can pass motion data from your HMD and XR controllers to other software running on Windows, and mirror your monitor to a virtual screen inside the VR headset.

This initial version supports outputting motion data via DSU (DualShock over UDP, also known as [cemuhook protocol](https://v1993.github.io/cemuhook-protocol/)), which makes it compatible with [Dolphin Emulator](https://dolphin-emu.org/). Future versions will support output via other means.

## Requirements

DorsalVR uses [OpenXR](https://www.khronos.org/openxr/) and is written in [Unity](https://www.unity.com/), which means that currently it will only run on Windows (64-bit).

It supports any VR equipment that supports OpenXR (that is, any equipment that can use SteamVR, Oculus, or WMD), and so it can be used with the Oculus Quest, but only via [Oculus Link](https://www.oculus.com/accessories/oculus-link/) or [Virtual Desktop](https://www.vrdesktop.net/) (Windows version) - it cannot run natively on the headset, even via sideloading.

## Usage

First, download the latest release's zip file from [the releases page](https://github.com/MichaelJW/DorsalVR/releases/), and unzip it to a folder on your hard drive.

- If using SteamVR: add `DorsalVR.exe` to Steam [as a non-Steam game](https://support.steampowered.com/kb_article.php?ref=2219-YDJV-5557). Right-click it in your library, select **Properties...**, and tick **Include in VR library**.
- If using the Oculus app: add `DorsalVR.exe` to your Library. (Click the **Plus** button, click **App not listed? Add it here**, then find `DorsalVR.exe`.)

Load DorsalVR as you would any VR app or game using SteamVR or Oculus. In your VR headset, you should see a loading screen, and then a purple room with a large screen mirroring your Windows desktop.

(DorsalVR also runs in its own window on the desktop; if it's in the foreground, you'll see it mirroring itself eternally. You can safely `Alt-Tab` to move it to the background and stop this effect.)

Confirm that you can see the virtual screen and that your virtual controllers move when you move the real things, then (in Windows) change your sound output to "Oculus", "Steam", or "Virtual Desktop" (as applicable), and load the app you want to use in VR.

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

### SteamVR and Oculus

SteamVR's OpenXR runtime has problems with Oculus controllers; at time of writing, the face buttons are not recognised when pressed, but when the thumbstick is pressed, it acts as if the thumbstick _and_ both face buttons are pressed.

~~Based on previous experience, I would expect Steam to fix this within a few days.~~ This has been fixed in SteamVR beta v1.16.9; you can switch to the beta branch by following these instructions: https://www.vive.com/us/support/vive/category_howto/optin-to-steamvr-beta.html

In the mean time, try running DorsalVR via the Oculus app. (This is not possible via Virtual Desktop, unfortunately for Oculus Quest users, but can be done via Oculus Link.) If you use [Revive](https://github.com/LibreVR/Revive/wiki) you may need to disable or uninstall it to prevent it automatically opening Oculus VR apps in SteamVR.

### VR Input Not Recognised

Sometimes the screen is mirrored successfully into the HMD, but the controller data is not mirrored back to the target app running on the PC.

The main cause of this is opening the target app before DorsalVR. Always open DorsalVR first, and then the target app. If that doesn't solve the problem, please [report an issue](https://github.com/MichaelJW/DorsalVR/issues).

### Thumbstick Drift

Sometimes the target app will report that one or both thumbsticks are held in the bottom-left or top-right positions.

As above, make sure you open DorsalVR before the target app. (If using Dolphin, try "disconnecting" the emulated controller (or emulated extension controller) in the Controller settings, and then reconnecting.)

### Virtual Controller Angle Mismatch

Different OpenXR runtimes (SteamVR, Oculus, etc) will report the controllers' rotations in different ways. For instance, when an Oculus Touch controller is held so that the handle points directly downwards, SteamVR reports this as you would expect, but Oculus reports this with a ~20 degree pitch.

This may change in future versions of the OpenXR runtimes (as they are still under rapid development), but in the mean time you can use the `-angleX`, `-angleY`, and `-angleZ` command line parameters to try to get the virtual controllers to match the physical ones. To fix the Oculus Touch example mentioned above, you should run DorsalVR with a Launch Option of `-angleX=20` in the Oculus app.

(Note that currently this affects the virtual controllers' positions, rotations, accelerometer values, and pointer values, but _not_ their reported gyroscopic rotation rates. This will be fixed in a future update.)

## In Development

The following features are planned:

- An actual UI for settings options, and the ability to save and load config files.
- A more aesthetic environment.
- Better controller models.
- Adjustable virtual controller rotation and position (via UI).
- Left-handed support.
- Additional controller profiles (such as a two-handed controller simulated as hovering between the real VR controllers.)
- Different forms of controller data output other than DSU.
- Adjustable virtual screen. (Size, shape, and curvature - to allow a FOV-filling screen for better immersion.)
- A second virtual (touch)screen.

## Thanks

Big thanks to the Dolphin team for a tremendously well-written and well-documented emulator. The excellent Dolphin blog post [Mastering Motion](https://dolphin-emu.org/blog/2019/04/26/mastering-motion/) got me interested in this in the first place - read it, it's superb.

In particular, thanks to [iwubcode](https://github.com/iwubcode) and [jordan-woyak](https://github.com/jordan-woyak) for their work on Free Look, which I have learnt so much from.

Thanks also to:

- [https://github.com/ruccho](ruccho) for [UnityGraphicsCapture](https://github.com/ruccho/UnityGraphicsCapture), which does the work of mirroring the desktop to a virtual screen using [Windows.Graphics.Capture](https://blogs.windows.com/windowsdeveloper/2019/09/16/new-ways-to-do-screen-capture/).
- [https://github.com/Davidobot](Davidobot) for [https://github.com/Davidobot/BetterJoy](BetterJoy), which has been very useful for debugging actual movement data.
- Rajkosto and v1993 for [the DSU/Cemuhook protocol](https://cemuhook.sshnuke.net/) and [its documentation](https://v1993.github.io/cemuhook-protocol/).
- NullFX for [this Crc32 implementation](http://sanity-free.org/12/crc32_implementation_in_csharp.html) which is used here to compute the checksum required by the DSU protocol.
