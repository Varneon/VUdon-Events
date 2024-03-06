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

        // Declare a serialized DataList field for each UdonEvent
        [SerializeField, UdonEvent]
        private DataList onPlayerTriggerEntered;

        // Add UdonEventAttribute to the DataList fields for overriding
        // the property drawer with the UdonEvent drawer
        [SerializeField, UdonEvent]
        private DataList onPlayerTriggerExited;

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

# Installation

### Import from [Unitypackage](https://docs.unity3d.com/2019.4/Documentation/Manual/AssetPackagesImport.html):</summary>

> 1. Download latest `com.varneon.vudon.events.unitypackage` from [here](https://github.com/Varneon/VUdon-Events/releases/latest)
> 2. Import the downloaded .unitypackage into your Unity project

<div align="center">

## Developed by Varneon with :hearts:

[![Twitter Follow](https://img.shields.io/static/v1?style=for-the-badge&label=@Varneon&message=5.4K&color=1b9df0&logo=twitter)](https://twitter.com/Varneon)
[![YouTube Channel Subscribers](https://img.shields.io/youtube/channel/subscribers/UCKTxeXy7gyaxr-YA9qGWOYg?color=%23FF0000&label=Varneon&logo=YouTube&style=for-the-badge)](https://www.youtube.com/Varneon)
[![GitHub followers](https://img.shields.io/github/followers/Varneon?color=%23303030&label=Varneon&logo=GitHub&style=for-the-badge)](https://github.com/Varneon)

</div>
