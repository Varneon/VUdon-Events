>[!CAUTION]
>VUdon Events is heavily experimental and may break without a notice! Use at your own risk.

<div>

# [VUdon](https://github.com/Varneon/VUdon) - Events [![GitHub Repo stars](https://img.shields.io/github/stars/Varneon/VUdon-Events?style=flat&label=Stars)](https://github.com/Varneon/VUdon-Events/stargazers) [![GitHub all releases](https://img.shields.io/github/downloads/Varneon/VUdon-Events/total?color=blue&label=Downloads&style=flat)](https://github.com/Varneon/VUdon-Events/releases) [![GitHub tag (latest SemVer)](https://img.shields.io/github/v/tag/Varneon/VUdon-Events?color=blue&label=Release&sort=semver&style=flat)](https://github.com/Varneon/VUdon-Events/releases/latest)

</div>

VUdon Events ("**UdonEvents**") allows you to *nearly natively* implement [UnityEvents](https://docs.unity3d.com/2022.3/Documentation/ScriptReference/Events.UnityEvent.html) into UdonSharpBehaviours.

![image](https://github.com/Varneon/VUdon-Events/assets/26690821/9e9d2f26-edb5-424e-aa21-0cd399aa010e)

# How to use VUdon Events in your own UdonSharpBehaviours

### 1) Declare a field for [**UdonEventHandler**](https://github.com/Varneon/VUdon-Events/blob/main/Packages/com.varneon.vudon.events/Runtime/Udon%20Programs/UdonEventHandler.cs) singleton

UdonEvents work by sending the event data to an UdonBehaviour in the scene which is responsible for invoking all of the events in a performant way, your class needs to have a reference to it so declare a field in your script for an [`UdonEventHandler`](https://github.com/Varneon/VUdon-Events/blob/main/Packages/com.varneon.vudon.events/Runtime/Udon%20Programs/UdonEventHandler.cs)

```csharp
[SerializeField, HideInInspector]
private UdonEventHandler udonEventHandler;
```

>[!TIP]
>The event handler gets automatically assigned to this field on build, so it is a good idea to keep it hidden by using [`[SerializeField]`](https://docs.unity3d.com/2022.3/Documentation/ScriptReference/SerializeField.html) and [`[HideInInspector]`](https://docs.unity3d.com/2022.3/Documentation/ScriptReference/HideInInspector.html) attributes

### 2) Declare a `DataList` field for your own event

For each UnityEvent you want to be visible in the inspector you have to declare a `DataList` field with a name that you want to be displayed in the property header.

```csharp
[SerializeField, UdonEvent]
private DataList myUdonEvent;
```

>[!IMPORTANT]
>[`[UdonEvent]` attribute](https://github.com/Varneon/VUdon-Events/blob/main/Packages/com.varneon.vudon.events/Runtime/UdonEventAttribute.cs) must be attached to the field in order for the custom [`PropertyDrawer`](https://github.com/Varneon/VUdon-Events/blob/main/Packages/com.varneon.vudon.events/Editor/UdonEventPropertyDrawer.cs) to override the inspector with the native UnityEvent field

>[!NOTE]
>Due to limitations with Udon the actual data contained in the UnityEvents must be packed into a type that Udon supports so [`DataList`](https://creators.vrchat.com/worlds/udon/data-containers/data-lists) is used for this.

### 3) Invoke your event via [`UdonEventHandler`](https://github.com/Varneon/VUdon-Events/blob/main/Packages/com.varneon.vudon.events/Runtime/Udon%20Programs/UdonEventHandler.cs)

In order to invoke your event, call the [`Invoke(DataList)` method](https://github.com/Varneon/VUdon-Events/blob/1b1b1ece29353f4b72265f2599e6f2ec00c4bbc7/Packages/com.varneon.vudon.events/Runtime/Udon%20Programs/UdonEventHandler.cs#L69) on the `UdonEventHandler`

```csharp
udonEventHandler.Invoke(myUdonEvent);
```

## Example Script

This script will invoke an event for any player entering or exiting a trigger collider attached to the object

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

>[!IMPORTANT]
> :package: UdonSharp scripts in a UPM package will need an assembly definition reference to `Varneon.VUdon.Events.Runtime`
>
> ![image](https://github.com/Varneon/VUdon-Events/assets/26690821/86dbbc17-bbc5-4ddb-b596-5dd7a402b0f6)

# Installation

### Import with [VRChat Creator Companion](https://vcc.docs.vrchat.com/)

> Coming Soon™

### Import from [Unitypackage](https://docs.unity3d.com/2019.4/Documentation/Manual/AssetPackagesImport.html)

> 1. Download latest `com.varneon.vudon.events.unitypackage` from [here](https://github.com/Varneon/VUdon-Events/releases/latest)
> 2. Import the downloaded .unitypackage into your Unity project

<div align="center">

## Developed by Varneon with :hearts:

[![Twitter Follow](https://img.shields.io/static/v1?style=for-the-badge&label=@Varneon&message=7.7K&color=1b9df0&logo=twitter)](https://twitter.com/Varneon)
[![YouTube Channel Subscribers](https://img.shields.io/youtube/channel/subscribers/UCKTxeXy7gyaxr-YA9qGWOYg?color=%23FF0000&label=Varneon&logo=YouTube&style=for-the-badge)](https://www.youtube.com/Varneon)
[![GitHub followers](https://img.shields.io/github/followers/Varneon?color=%23303030&label=Varneon&logo=GitHub&style=for-the-badge)](https://github.com/Varneon)

</div>
