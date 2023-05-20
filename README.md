> # :warning: VUdon Events is heavily experimental and may break without a notice! Use at your own risk.

<div>

# [VUdon](https://github.com/Varneon/VUdon) - Events [![GitHub Repo stars](https://img.shields.io/github/stars/Varneon/VUdon-Events?style=flat&label=Stars)](https://github.com/Varneon/VUdon-Events/stargazers) [![GitHub all releases](https://img.shields.io/github/downloads/Varneon/VUdon-Events/total?color=blue&label=Downloads&style=flat)](https://github.com/Varneon/VUdon-Events/releases) [![GitHub tag (latest SemVer)](https://img.shields.io/github/v/tag/Varneon/VUdon-Events?color=blue&label=Release&sort=semver&style=flat)](https://github.com/Varneon/VUdon-Events/releases/latest)

</div>

VUdon Events ("UdonEvents") allows you to *nearly natively* implement UnityEvents into UdonSharp.

![image](https://github.com/Varneon/VUdon-Events/assets/26690821/9e9d2f26-edb5-424e-aa21-0cd399aa010e)

# How to use VUdon Events

```csharp
using UdonSharp;
using UnityEngine;
using VRC.SDK3.Data;
using VRC.SDKBase;

namespace Varneon.VUdon.UdonEvents
{
    public class UdonEventTest : UdonSharpBehaviour
    {
        // Declare a serialized hidden field for the event handler singleton
        [SerializeField, HideInInspector]
        private UdonEventHandler udonEventHandler;

        // Declare a serialized hidden DataList field for each UdonEvent
        [SerializeField, HideInInspector]
        private DataList onPlayerTriggerEntered;

        // Each element on the DataList is an individual persistent call from the UnityEvent
        [SerializeField, HideInInspector]
        private DataList onPlayerTriggerExited;


        // Declare UdonEvent fields for each UdonEvent you want to expose in the inspector
        [UdonEventData(nameof(onPlayerTriggerEntered))]
        public UdonEvent OnPlayerTriggerEntered;

        // Add UdonEventDataAttribute to the UdonEvent fields for defining
        // the DataList field for storing the persistent calls for runtime
        [UdonEventData(nameof(onPlayerTriggerExited))]
        public UdonEvent OnPlayerTriggerExited;


        public override void OnPlayerTriggerEnter(VRCPlayerApi player)
        {
            // Invoke the UdonEvent's persistent calls stored in the DataList field
            udonEventHandler.Invoke(onPlayerTriggerEntered);
        }

        public override void OnPlayerTriggerExit(VRCPlayerApi player)
        {
            // UdonEventHandler can invoke a list of calls by providing it the DataList
            udonEventHandler.Invoke(onPlayerTriggerExited);
        }
    }
}
```

> :package: UdonSharp scripts in a UPM package will need an assembly definition reference to `Varneon.VUdon.Events.Runtime`
>
> ![image](https://github.com/Varneon/VUdon-Events/assets/26690821/86dbbc17-bbc5-4ddb-b596-5dd7a402b0f6)

# Known issues

> `1` UdonSharp isn't too happy about the UdonEvent fields in the class
>
>![image](https://github.com/Varneon/VUdon-Events/assets/26690821/df445881-dbf4-4f18-bd62-358838cef300)

> `2` There is no way to know if UdonEventHandler was able to successfully invoke a call

# Installation

<details><summary>

### Import with [VRChat Creator Companion](https://vcc.docs.vrchat.com/vpm/packages#user-packages):</summary>

> 1. Download `com.varneon.vudon.events.zip` from [here](https://github.com/Varneon/VUdon-Events/releases/latest)
> 2. Unpack the .zip somewhere
> 3. In VRChat Creator Companion, navigate to `Settings` > `User Packages` > `Add`
> 4. Navigate to the unpacked folder, `com.varneon.vudon.events` and click `Select Folder`
> 5. `VUdon - Events` should now be visible under `Local User Packages` in the project view in VRChat Creator Companion
> 6. Click `Add`

</details><details><summary>

### Import with [Unity Package Manager (git)](https://docs.unity3d.com/2019.4/Documentation/Manual/upm-ui-giturl.html):</summary>

> 1. In the Unity toolbar, select `Window` > `Package Manager` > `[+]` > `Add package from git URL...` 
> 2. Copy and paste the following link into the URL input field: <pre lang="md">https://github.com/Varneon/VUdon-Events.git?path=/Packages/com.varneon.vudon.events</pre>

</details><details><summary>

### Import from [Unitypackage](https://docs.unity3d.com/2019.4/Documentation/Manual/AssetPackagesImport.html):</summary>

> 1. Download latest `com.varneon.vudon.events.unitypackage` from [here](https://github.com/Varneon/VUdon-Events/releases/latest)
> 2. Import the downloaded .unitypackage into your Unity project

</details>

<div align="center">

## Developed by Varneon with :hearts:

![Twitter Follow](https://img.shields.io/twitter/follow/Varneon?color=%231c9cea&label=%40Varneon&logo=Twitter&style=for-the-badge)
![YouTube Channel Subscribers](https://img.shields.io/youtube/channel/subscribers/UCKTxeXy7gyaxr-YA9qGWOYg?color=%23FF0000&label=Varneon&logo=YouTube&style=for-the-badge)
![GitHub followers](https://img.shields.io/github/followers/Varneon?color=%23303030&label=Varneon&logo=GitHub&style=for-the-badge)

</div>
