![License](https://img.shields.io/github/license/joaoborks/myunitytools-fps-counter)
![Release](https://img.shields.io/github/v/release/joaoborks/myunitytools-fps-counter?sort=semver)
![Last Commit](https://img.shields.io/github/last-commit/joaoborks/myunitytools-fps-counter)

My Unity Tools - FPS Counter
===

_A package to measure the average, highest and lowest frames per second in any Unity Application._

Installation
---

#### - For 2019.1+: [Installing from a git URL](https://docs.unity3d.com/Manual/upm-ui-giturl.html) _(requires [Git](https://git-scm.com/) installed and added to the PATH)_
You can open the Package Manager and then click on the `+` button on the top left corner. 
From there select `Add package from git URL...`, type `https://github.com/joaoborks/myunitytools-fps-counter.git` and click `Add`. 
The package will be imported by the Package Manager.

#### - Other Package Manager supported versions: Add manually to manifest
You should add this to your `manifest.json` under the `Packages` folder on the root of your Unity Project:
```
{
  "dependencies": {
	  "com.joaoborks.fpscounter": "https://github.com/joaoborks/myunitytools-fps-counter.git"
  }
}
```

Usage
---

Add the component `FPSCounter` to any `GameObject` by manually dragging the script or via `Add Component/Stats/FPS Counter`. 
Then, add a `FPSDisplay` component to the same `GameObject` the same way you just did with `FPSCounter`.
Now, you'll need to assign **3** `TextMeshProUGUI` objects in the `FPSDisplay` inspector to serve as output for the **average**, **highest** and **lowest** FPS counts respectively.

You can also configure the other settings to fit your needs:
- The `Color Gradient` can alter the label color based on the target FPS where the **leftmost** value is the **closest** FPS value to **0**, 
and the **rightmost** value is the **closest** FPS value to the `Target Framerate`.
- The `Refresh Rate` controls how often the `FPSDisplay` updates its values.
- The `Target Framerate` is a guide to the `Color Gradient` property. It will be the reference for the value of 1 in the color gradient.
- The `Max Tracked Fps` controls what should be the maximum FPS to track.

Advanced Usage
---

The core FPS counter feature lies in the `FPSBuffer`. 
It needs a `bufferSize` to be provided on creation, and then it will fill this buffer with FPS values to calculate the average, highest and lowest framerates.
You need to call `UpdateBuffer` every Unity `Update` to accurately calculate the FPS.
The `FPSCounter` component simply creates a `FPSBuffer` object on `Awake` with the provided `Buffer Size` in the inspector, 
and runs `FPSBuffer.UpdateBuffer` on its `Update`. 
You can use any other structure as an alternative to the `FPSCounter` or even integrate to your existing systems just by using a `FPSBuffer` object.

The `FPSDisplay` component reads from the `FPSCounter` component directly and outputs the average, highest and lowest fps.
You can also create another component to display the values either from the `FPSCounter` or from another system you created that uses a `FPSBuffer` object.
The `FPSDisplay` class was created with an array of strings with numbers up to **300**, to avoid string allocation in runtime.

---

Don't hesitate to create [issues](https://github.com/joaoborks/myunitytools-fps-counter/issues) for suggestions and bugs. Have fun!
