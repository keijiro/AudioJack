AudioJack - External Audio Analyzer for Unity
=============================================

**AudioJack** is an external audio processing plug-in for Unity.
It analyzes the external audio input and provides audio spectrum data for
Unity apps. It is highly optimized and uses low-latency audio APIs to process
the audio input. And therefore you can use the plug-in to make
well-synchronized audio-visual apps.

Demo
----

There is a demo project in [the test branch of the repository]
(https://github.com/keijiro/AudioJack/tree/test).

![Demo](http://keijiro.github.io/AudioJack/demo.png)

It shows the signal levels of each input channel (behind) and each octave
band (front). The color of the bars changes when it exceeds specified levels
(yellow: -3db, red: 0db).

System Requirement
------------------

- Currently supports only Mac OS X.
- Requires Unity Pro to enable native plug-in feature.

Setting Up
----------

1. Before launching Unity, select an audio interface for capturing the
   audio signals in [the system sound preferences]
   (http://support.apple.com/kb/PH13972).
2. Import **AudioJackPlugin.bundle** into '**Plugins**' folder in
   your project.
3. Import **AudioJack.cs**.
4. Create a new game object and add the **AudioJack** script component to it.

Note: *You have to restart Unity to switch to another audio interface.*

Component Properties
--------------------

There are some parameters in the AudioJack component.

![Inspector](http://keijiro.github.io/AudioJack/inspector.png)

- Band Type - specifies the number of octave bands.
- Channel Select - The spectrum analyzer can only handle one audio stream, so
  you have to choose whether or not to mix multiple channels before analysis.
  You can specify one channel (Discrete), mix two consecutive channels
  (MixStereo) or mix the all channels (MixAll).
- Channel To Analyze - specifies a channel for analyzing spectrum.
- Minimum Interval - specifies the minimum interval time. You can save CPU
  load by setting a long interval time.
- Internal Mode - analyzes the audio output from Unity instead of the
  external audio input.

The analyzer puts the result into two public properties.

- float [] BandLevels - The levels of each octave band.
- float [] ChannelLevels - The RMS levels of each channel.

These values are represented in decibel units (dbFS). The maximum value is
+3db and the lower bound is -infinite.

See Also
--------

The source code for the native module is stored in another repository.

[AudioJackPlugin for OS X]
(https://github.com/keijiro/AudioJackPlugin)

License
-------

Copyright (C) 2013 Keijiro Takahashi

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
