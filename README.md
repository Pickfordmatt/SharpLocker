# SharpLocker

SharpLocker helps get current user credentials by popping a fake Windows lock screen, all output is sent to http://requestbin.net link. It is written in C# to allow for direct execution via memory injection using techniques such as execute-assembly found in Cobalt Strike or others, this method prevents the executable from ever touching disk. It is NOT intended to be compilled and run locally on a device. Can be used with BadUSB as seen in this youtube video https://www.youtube.com/watch?v=JYi_H9n5xjw.

# What SharpLocker is
* A .NET application that is supposed to be run in memory on a target device

# What SharpLocker is NOT
* A password stealing tool that emails plain text credentials
* An executable that is supposed to be double clicked

# Works
* Single/Multiple Monitors
* Windows 10
* Main monitor needs to be 1080p otherwise the location of the elements are wrong

![Working SharpLocker](https://github.com/Ascensao/SharpLocker/blob/master/ba-sharpLocker-gui-printscreen.png)

# How to
* Compile SharpLocker from source via VisualStudio etc
* Within a Cobalt Strike implant run execute-assembly C:/{location of exe}
* Pray and wait for creds

# Credits
* This project was originally built by Pickfordmatt.
* This fork was rebuilded by Ascensao specially to be used with BadUSB or other hacking methods.

# This fork Vs Original Project (differences)
* real LockScreen Background.
* real username instead windows user folder name.
* sent password by http request instead console output.
* More realistic GUI with more button and functionalities.
* Code cleanup
