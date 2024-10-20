# Unity WebGL Copy and Paste

This package adds support for copy and paste in Unity WebGL builds.

![screenshot](https://user-images.githubusercontent.com/234804/85267132-caa04900-b4af-11ea-821f-921cb7f02f34.gif)

At the moment there is only support for [`InputField`](https://docs.unity3d.com/2019.1/Documentation/Manual/script-InputField.html) and
[`TMPro.TMP_InputField`](https://docs.unity3d.com/Packages/com.unity.textmeshpro@2.1/api/TMPro.TMP_InputField.html)

## Installation

Add the following URL to your Unity Package Manager:
```
https://github.com/kainoo-ch/unity-webgl-copy-and-paste.git?path=Packages/ch.kainoo.webgl.copypaste
```

## Browsers tested

The plugin has been tested an confirmed working on:

* Edge 120.0.2210.61 (Chromium) on Windows 10, Unity 2022.3.10, 2021.3.25 and 2020.3.18.
* Firefox 120.0.1 on Windows 10, Unity 2022.3.10, 2021.3.25 and 2020.3.18.
* Safari 16.6 on macOS Ventura 13.6, Unity 2022.3.10.
* Chrome 118.0.5993.70 on macOS Ventura 13.6, Unity 2022.3.10.
* Firefox 120.0.1 on macOS Ventura 13.6, Unity 2022.3.10.

## Issues

* Non Alphabetic characters

  See [this thread](https://forum.unity.com/threads/japanese-hiragana-characters-dont-work-in-webgl.356097/). Your application needs to support these characters.

* Ctrl-A/⌘-A selects other HTML on the page

  1. Make your own [WebGL template](https://docs.unity3d.com/Manual/webgl-templates.html) that doesn't have
     anything to select. Maybe [this one](https://github.com/greggman/better-unity-webgl-template) though I
     didn't try it.

  2. Make your own [WebGL template](https://docs.unity3d.com/Manual/webgl-templates.html) and
     use [`user-select: none;`](https://developer.mozilla.org/en-US/docs/Web/CSS/user-select) in your CSS
     to make whatever parts of the page you want to prevent from being selected.

## Changelog

* 0.3.1

  * Reshaped the plugin as a package for easy installation in Unity.

  * Added autodiscovery of TextMeshPro in the project

* 0.3.0

  * Added `Preserve` attribute to `WebGLCopyAndPasteAPI` class, and `AlwaysLinkAssembly` to the assembly,
    so Unity doesn't strip the code if the plugin is moved to a package

* 0.2.1

  * Fixed paste not working on some browsers

  * Fixed labels not being visually updated on some browsers

  * Fixed potential null reference exception when `EventSystem.current` is null

  * Substituted deprecated JavaScript `Window.event`

* 0.2.0

  * Fixes for Unity 2021.2

* 0.1.0
  
  * Removed the need for MonoBehaviours
  
  * Replaced messages with proper callbacks

  * Fixed data storing in `window`

* 0.0.2

  * Support cut

  * Support Safari

* 0.0.1

  * Initial Release

## License: BSD-3-Clause
This project is based on the works of [Trisibo](https://github.com/Trisibo/unity-webgl-copy-and-paste) and [greggman](https://github.com/greggman/unity-webgl-copy-and-paste).

All modifications from the original work are licensed under the MIT license.