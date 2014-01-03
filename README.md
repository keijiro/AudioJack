AudioJack
=========

**AudioJack** is an external audio processing plugin for Unity. It allows Unity
apps to analyze the external audio signals and obtain frequency spectrum
information. The plugin is highly optimized and utilizes low-latency signal
processing APIs, and therefore allows Unity apps to react to the external audio
signals without any significant delay.

Sample Project
--------------

There is a sample project in [the test branch of this repository]
(https://github.com/keijiro/AudioJack/tree/test).

![Demo](http://keijiro.github.io/AudioJack/demo.png)

It shows the signal levels of each input channel (behind) and each octave
band (front). The color of the bars changes when it exceeds specific levels
(yellow: -3dB, red: 0dB).

System Requirements
-------------------

- Currently supports only Mac OS X.
- Requires Unity Pro.

Setting Up
----------

1. Before launching Unity, select an audio interface for capturing
   audio signals in [the system sound preferences]
   (http://support.apple.com/kb/PH13972).
2. Import **AudioJackPlugin.bundle** into '**Plugins**' folder in
   your project.
3. Import **AudioJack.cs**.
4. Import **AudioJackEditor.cs** into '**Editor**' folder.
5. Create a new game object and add the **AudioJack** script component to it.

Note: *You have to restart Unity to switch to another audio interface.*

Component Properties
--------------------

There are some options in the AudioJack component.

![Inspector](http://keijiro.github.io/AudioJack/inspector2.png)

- Octave Band Type - specifies the number of octave bands.
- Interval - specifies the minimum interval time. You can save CPU load by
  setting a long interval time.
- External Audio - switches the audio input source.
- Mix Mode and Channel Select - The spectrum analyzer can only handle one audio
  stream, so you have to choose whether or not to mix multiple channels before
  spectrum analysis. You can specify one channel (Mono), mix two
  consecutive channels (Mix L + R) or mix the all channels (Mix All).

The analyzer puts the result into three public properties.

- float [] OctaveBandSpectrum - contains the levels of each octave band.
- float [] RawSpectrum - contains the result of Fourier transform.
- float [] ChannelLevels - contains the RMS levels of each channel.

These values are represented in decibel units (dBFS). The maximum value is
+3dB and the lower bound is -infinite.

Related Project
---------------

The source code for the native module is in another repository.

[AudioJackPlugin for OS X]
(https://github.com/keijiro/AudioJackPlugin)

License
-------

Copyright (C) 2013, 2014 Keijiro Takahashi

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
the Software, and to permit persons to whom the Software is furnished to do so,
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
