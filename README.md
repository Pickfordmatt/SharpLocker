# SharpLocker

SharpLocker helps get current user credentials by popping a fake Windows lock screen, the output can be send via email or requestbin.net. It is written in C# to allow for direct execution via memory injection using techniques such as execute-assembly found in Cobalt Strike or others, this method prevents the executable from ever touching disk. It is NOT intended to be compilled and run locally on a device.

# What SharpLocker is
* A .NET application that is supposed to be run in memory on a target device

# What SharpLocker is NOT
* A password stealing tool that emails plain text credentials
* An executable that is supposed to be double clicked

# Works
* Single/Multiple Monitors
* Windows 10
* Main monitor needs to be 1080p otherwise the location of the elements are wrong
* With any background and profile picture

![Working SharpLocker](https://github.com/3top1a/SharpLocker/blob/master/SharpLocker_example.png)

# How to
* Compile SharpLocker from source via VisualStudio etc
* Within a Cobalt Strike implant run execute-assembly C:/{location of exe}
* Pray and wait for creds

# Credits
* This project was originally built by Pickfordmatt.
* This fork was rebuilded by 3top1a with more features.

Thanks to:
* keldnorman
* Ascensao

# This fork Vs Original Project (differences)
* Background from spotlight
* Major GUI upgrades
* real username instead windows user folder name.
* Password extraction
* Code cleanup

# BadUSB implementation example
https://www.youtube.com/watch?v=JYi_H9n5xjw
