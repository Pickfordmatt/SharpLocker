# SharpLocker

SharpLocker helps get current user credentials by popping a fake Windows lock screen, all output is sent to Console which works perfect for Cobalt Strike. It is written in C# to allow for direct execution via memory injection using techniques such as execute-assembly found in Cobalt Strike or others, this method prevents the executable from ever touching disk. It is NOT intended to be compilled and run locally on a device. 

## Works
* Single/Multiple Monitors
* Windows 10
* Main monitor needs to be 1080p otherwise the location of the elements are wrong

![Working SharpLocker](https://github.com/Pickfordmatt/SharpLocker/blob/master/sharplocker.png?raw=true)

## How to
* Compile SharpLocker from source via VisualStudio etc
* Go to http://requestbin.net/ and create a new requestbin
* Change "xxxxxxx" in theLockScreenForm.cs on line 232 to your valid requestbin-ID (number at the end of the link)
* Within a Cobalt Strike implant run execute-assembly C:/{location of exe}
* Pray and wait for creds

