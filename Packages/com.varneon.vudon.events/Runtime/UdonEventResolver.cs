using Cinemachine;
using System;
using TMPro;
using UdonSharp;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;
using UnityEngine.Playables;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;
using VRC.SDK3.Components;
using VRC.SDK3.Data;
using VRC.SDK3.Midi;
using VRC.SDK3.Video.Components.Base;
using VRC.SDKBase;
using VRC.Udon;
using VRCStation = VRC.SDK3.Components.VRCStation;

namespace Varneon.VUdon.UdonEvents
{
    public partial class UdonEventHandler : UdonSharpBehaviour
    {
        private readonly DataDictionary typeMethodTree = new DataDictionary()
        {
            {"VRC.Udon.UdonBehaviour", new DataDictionary() {
                {"RequestSerialization", "00"},
                {"SendCustomEvent", "01"},
                {"set_DisableInteractive", "02"},
                {"set_InteractionText", "03"},
                {"set_enabled", "04"}
            }},
            {"Cinemachine.CinemachineDollyCart", new DataDictionary() {
                {"set_enabled", "05"},
                {"set_m_Path", "06"},
                {"set_m_Position", "07"},
                {"set_m_Speed", "08"},
                {"set_name", "09"}
            }},
            {"Cinemachine.CinemachinePathBase", new DataDictionary() {
                {"DistanceCacheIsValid", "0A"},
                {"EvaluateOrientation", "0B"},
                {"EvaluatePosition", "0C"},
                {"EvaluateTangent", "0D"},
                {"InvalidateDistanceCache", "0E"},
                {"StandardizePathDistance", "0F"},
                {"StandardizePos", "10"},
                {"set_enabled", "11"},
                {"set_name", "12"}
            }},
            {"Cinemachine.CinemachineVirtualCamera", new DataDictionary() {
                {"MoveToTopOfPrioritySubqueue", "13"},
                {"ResolveFollow", "14"},
                {"ResolveLookAt", "15"},
                {"set_Follow", "16"},
                {"set_LookAt", "17"},
                {"set_Priority", "18"},
                {"set_enabled", "19"},
                {"set_name", "1A"}
            }},
            {"TMPro.TextMeshPro", new DataDictionary() {
                {"set_enabled", "1B"},
                {"set_isMaskingGraphic", "1C"},
                {"set_isTextObjectScaleStatic", "1D"},
                {"set_material", "1E"},
                {"set_maxVisibleCharacters", "1F"},
                {"set_name", "20"},
                {"set_outlineWidth", "21"},
                {"set_text", "22"}
            }},
            {"TMPro.TextMeshProUGUI", new DataDictionary() {
                {"set_enabled", "23"},
                {"set_isMaskingGraphic", "24"},
                {"set_isTextObjectScaleStatic", "25"},
                {"set_material", "26"},
                {"set_maxVisibleCharacters", "27"},
                {"set_name", "28"},
                {"set_outlineWidth", "29"},
                {"set_text", "2A"}
            }},
            {"UnityEngine.AI.NavMeshAgent", new DataDictionary() {
                {"ActivateCurrentOffMeshLink", "2B"},
                {"CompleteOffMeshLink", "2C"},
                {"ResetPath", "2D"},
                {"set_acceleration", "2E"},
                {"set_agentTypeID", "2F"},
                {"set_angularSpeed", "30"},
                {"set_areaMask", "31"},
                {"set_autoBraking", "32"},
                {"set_autoRepath", "33"},
                {"set_autoTraverseOffMeshLink", "34"},
                {"set_avoidancePriority", "35"},
                {"set_baseOffset", "36"},
                {"set_enabled", "37"},
                {"set_height", "38"},
                {"set_isStopped", "39"},
                {"set_name", "3A"},
                {"set_radius", "3B"},
                {"set_speed", "3C"},
                {"set_stoppingDistance", "3D"},
                {"set_updatePosition", "3E"},
                {"set_updateRotation", "3F"},
                {"set_updateUpAxis", "40"}
            }},
            {"UnityEngine.AI.NavMeshObstacle", new DataDictionary() {
                {"set_carveOnlyStationary", "41"},
                {"set_carvingMoveThreshold", "42"},
                {"set_carvingTimeToStationary", "43"},
                {"set_carving", "44"},
                {"set_enabled", "45"},
                {"set_height", "46"},
                {"set_name", "47"},
                {"set_radius", "48"}
            }},
            {"UnityEngine.AI.OffMeshLink", new DataDictionary() {
                {"UpdatePositions", "49"},
                {"set_activated", "4A"},
                {"set_area", "4B"},
                {"set_autoUpdatePositions", "4C"},
                {"set_biDirectional", "4D"},
                {"set_costOverride", "4E"},
                {"set_enabled", "4F"},
                {"set_endTransform", "50"},
                {"set_name", "51"},
                {"set_startTransform", "52"}
            }},
            {"UnityEngine.Animations.AimConstraint", new DataDictionary() {
                {"RemoveSource", "53"},
                {"set_constraintActive", "54"},
                {"set_enabled", "55"},
                {"set_locked", "56"},
                {"set_name", "57"},
                {"set_weight", "58"},
                {"set_worldUpObject", "59"}
            }},
            {"UnityEngine.Animations.LookAtConstraint", new DataDictionary() {
                {"RemoveSource", "5A"},
                {"set_constraintActive", "5B"},
                {"set_enabled", "5C"},
                {"set_locked", "5D"},
                {"set_name", "5E"},
                {"set_roll", "5F"},
                {"set_useUpObject", "60"},
                {"set_weight", "61"},
                {"set_worldUpObject", "62"}
            }},
            {"UnityEngine.Animations.ParentConstraint", new DataDictionary() {
                {"RemoveSource", "63"},
                {"set_constraintActive", "64"},
                {"set_enabled", "65"},
                {"set_locked", "66"},
                {"set_name", "67"},
                {"set_weight", "68"}
            }},
            {"UnityEngine.Animations.PositionConstraint", new DataDictionary() {
                {"RemoveSource", "69"},
                {"set_constraintActive", "6A"},
                {"set_enabled", "6B"},
                {"set_locked", "6C"},
                {"set_name", "6D"},
                {"set_weight", "6E"}
            }},
            {"UnityEngine.Animations.RotationConstraint", new DataDictionary() {
                {"RemoveSource", "6F"},
                {"set_constraintActive", "70"},
                {"set_enabled", "71"},
                {"set_locked", "72"},
                {"set_name", "73"},
                {"set_weight", "74"}
            }},
            {"UnityEngine.Animations.ScaleConstraint", new DataDictionary() {
                {"RemoveSource", "75"},
                {"set_constraintActive", "76"},
                {"set_enabled", "77"},
                {"set_locked", "78"},
                {"set_name", "79"},
                {"set_weight", "7A"}
            }},
            {"UnityEngine.Animator", new DataDictionary() {
                {"ApplyBuiltinRootMotion", "7B"},
                {"InterruptMatchTarget", "7C"},
                {"PlayInFixedTime", "7D"},
                {"Play", "7E"},
                {"Rebind", "7F"},
                {"ResetTrigger", "80"},
                {"SetLookAtWeight", "81"},
                {"SetTrigger", "82"},
                {"StartPlayback", "83"},
                {"StartRecording", "84"},
                {"StopPlayback", "85"},
                {"StopRecording", "86"},
                {"Update", "87"},
                {"WriteDefaultValues", "88"},
                {"set_applyRootMotion", "89"},
                {"set_avatar", "8A"},
                {"set_enabled", "8B"},
                {"set_feetPivotActive", "8C"},
                {"set_keepAnimatorControllerStateOnDisable", "8D"},
                {"set_layersAffectMassCenter", "8E"},
                {"set_logWarnings", "8F"},
                {"set_name", "90"},
                {"set_playbackTime", "91"},
                {"set_recorderStartTime", "92"},
                {"set_recorderStopTime", "93"},
                {"set_runtimeAnimatorController", "94"},
                {"set_speed", "95"},
                {"set_stabilizeFeet", "96"}
            }},
            {"UnityEngine.AreaEffector2D", new DataDictionary() {
                {"set_angularDrag", "97"},
                {"set_colliderMask", "98"},
                {"set_drag", "99"},
                {"set_enabled", "9A"},
                {"set_forceAngle", "9B"},
                {"set_forceMagnitude", "9C"},
                {"set_forceVariation", "9D"},
                {"set_name", "9E"},
                {"set_useColliderMask", "9F"},
                {"set_useGlobalAngle", "A0"}
            }},
            {"UnityEngine.AudioChorusFilter", new DataDictionary() {
                {"set_delay", "A1"},
                {"set_depth", "A2"},
                {"set_dryMix", "A3"},
                {"set_enabled", "A4"},
                {"set_name", "A5"},
                {"set_rate", "A6"},
                {"set_wetMix1", "A7"},
                {"set_wetMix2", "A8"},
                {"set_wetMix3", "A9"}
            }},
            {"UnityEngine.AudioDistortionFilter", new DataDictionary() {
                {"set_distortionLevel", "AA"},
                {"set_enabled", "AB"},
                {"set_name", "AC"}
            }},
            {"UnityEngine.AudioEchoFilter", new DataDictionary() {
                {"set_decayRatio", "AD"},
                {"set_delay", "AE"},
                {"set_dryMix", "AF"},
                {"set_enabled", "B0"},
                {"set_name", "B1"},
                {"set_wetMix", "B2"}
            }},
            {"UnityEngine.AudioHighPassFilter", new DataDictionary() {
                {"set_cutoffFrequency", "B3"},
                {"set_enabled", "B4"},
                {"set_highpassResonanceQ", "B5"},
                {"set_name", "B6"}
            }},
            {"UnityEngine.AudioLowPassFilter", new DataDictionary() {
                {"set_cutoffFrequency", "B7"},
                {"set_enabled", "B8"},
                {"set_lowpassResonanceQ", "B9"},
                {"set_name", "BA"}
            }},
            {"UnityEngine.AudioReverbFilter", new DataDictionary() {
                {"set_decayHFRatio", "BB"},
                {"set_decayTime", "BC"},
                {"set_density", "BD"},
                {"set_diffusion", "BE"},
                {"set_dryLevel", "BF"},
                {"set_enabled", "C0"},
                {"set_hfReference", "C1"},
                {"set_lfReference", "C2"},
                {"set_name", "C3"},
                {"set_reflectionsDelay", "C4"},
                {"set_reflectionsLevel", "C5"},
                {"set_reverbDelay", "C6"},
                {"set_reverbLevel", "C7"},
                {"set_roomHF", "C8"},
                {"set_roomLF", "C9"},
                {"set_room", "CA"}
            }},
            {"UnityEngine.AudioReverbZone", new DataDictionary() {
                {"set_HFReference", "CB"},
                {"set_LFReference", "CC"},
                {"set_decayHFRatio", "CD"},
                {"set_decayTime", "CE"},
                {"set_density", "CF"},
                {"set_diffusion", "D0"},
                {"set_enabled", "D1"},
                {"set_maxDistance", "D2"},
                {"set_minDistance", "D3"},
                {"set_name", "D4"},
                {"set_reflectionsDelay", "D5"},
                {"set_reflections", "D6"},
                {"set_reverbDelay", "D7"},
                {"set_reverb", "D8"},
                {"set_roomHF", "D9"},
                {"set_roomLF", "DA"},
                {"set_room", "DB"}
            }},
            {"UnityEngine.AudioSource", new DataDictionary() {
                {"Pause", "DC"},
                {"PlayDelayed", "DD"},
                {"PlayOneShot", "DE"},
                {"Play", "DF"},
                {"Stop", "E0"},
                {"UnPause", "E1"},
                {"set_bypassReverbZones", "E2"},
                {"set_clip", "E3"},
                {"set_dopplerLevel", "E4"},
                {"set_enabled", "E5"},
                {"set_loop", "E6"},
                {"set_maxDistance", "E7"},
                {"set_minDistance", "E8"},
                {"set_mute", "E9"},
                {"set_name", "EA"},
                {"set_panStereo", "EB"},
                {"set_pitch", "EC"},
                {"set_playOnAwake", "ED"},
                {"set_priority", "EE"},
                {"set_reverbZoneMix", "EF"},
                {"set_spatialBlend", "F0"},
                {"set_spatializePostEffects", "F1"},
                {"set_spatialize", "F2"},
                {"set_spread", "F3"},
                {"set_timeSamples", "F4"},
                {"set_time", "F5"},
                {"set_volume", "F6"}
            }},
            {"UnityEngine.BillboardRenderer", new DataDictionary() {
                {"HasPropertyBlock", "F7"},
                {"set_allowOcclusionWhenDynamic", "F8"},
                {"set_billboard", "F9"},
                {"set_enabled", "FA"},
                {"set_forceRenderingOff", "FB"},
                {"set_lightProbeProxyVolumeOverride", "FC"},
                {"set_lightmapIndex", "FD"},
                {"set_material", "FE"},
                {"set_name", "FF"},
                {"set_probeAnchor", "100"},
                {"set_realtimeLightmapIndex", "101"},
                {"set_receiveShadows", "102"},
                {"set_rendererPriority", "103"},
                {"set_sharedMaterial", "104"},
                {"set_sortingLayerID", "105"},
                {"set_sortingLayerName", "106"},
                {"set_sortingOrder", "107"}
            }},
            {"UnityEngine.BoxCollider2D", new DataDictionary() {
                {"Distance", "108"},
                {"set_autoTiling", "109"},
                {"set_density", "10A"},
                {"set_edgeRadius", "10B"},
                {"set_enabled", "10C"},
                {"set_isTrigger", "10D"},
                {"set_name", "10E"},
                {"set_sharedMaterial", "10F"},
                {"set_usedByComposite", "110"},
                {"set_usedByEffector", "111"}
            }},
            {"UnityEngine.BoxCollider", new DataDictionary() {
                {"set_contactOffset", "112"},
                {"set_enabled", "113"},
                {"set_isTrigger", "114"},
                {"set_material", "115"},
                {"set_name", "116"},
                {"set_sharedMaterial", "117"}
            }},
            {"UnityEngine.Camera", new DataDictionary() {
                {"CopyFrom", "118"},
                {"RenderDontRestore", "119"},
                {"RenderToCubemap", "11A"},
                {"Render", "11B"},
                {"ResetAspect", "11C"},
                {"ResetCullingMatrix", "11D"},
                {"ResetProjectionMatrix", "11E"},
                {"ResetReplacementShader", "11F"},
                {"ResetStereoProjectionMatrices", "120"},
                {"ResetStereoViewMatrices", "121"},
                {"ResetTransparencySortSettings", "122"},
                {"ResetWorldToCameraMatrix", "123"},
                {"Reset", "124"},
                {"SetupCurrent", "125"},
                {"set_allowDynamicResolution", "126"},
                {"set_allowHDR", "127"},
                {"set_allowMSAA", "128"},
                {"set_aspect", "129"},
                {"set_clearStencilAfterLightingPass", "12A"},
                {"set_cullingMask", "12B"},
                {"set_depth", "12C"},
                {"set_enabled", "12D"},
                {"set_eventMask", "12E"},
                {"set_farClipPlane", "12F"},
                {"set_fieldOfView", "130"},
                {"set_focalLength", "131"},
                {"set_forceIntoRenderTexture", "132"},
                {"set_layerCullSpherical", "133"},
                {"set_name", "134"},
                {"set_nearClipPlane", "135"},
                {"set_orthographicSize", "136"},
                {"set_orthographic", "137"},
                {"set_stereoConvergence", "138"},
                {"set_stereoSeparation", "139"},
                {"set_targetDisplay", "13A"},
                {"set_targetTexture", "13B"},
                {"set_useJitteredProjectionMatrixForTransparentRendering", "13C"},
                {"set_useOcclusionCulling", "13D"},
                {"set_usePhysicalProperties", "13E"}
            }},
            {"UnityEngine.CanvasGroup", new DataDictionary() {
                {"set_alpha", "13F"},
                {"set_blocksRaycasts", "140"},
                {"set_enabled", "141"},
                {"set_ignoreParentGroups", "142"},
                {"set_interactable", "143"},
                {"set_name", "144"}
            }},
            {"UnityEngine.Canvas", new DataDictionary() {
                {"ForceUpdateCanvases", "145"},
                {"set_enabled", "146"},
                {"set_name", "147"},
                {"set_normalizedSortingGridSize", "148"},
                {"set_overridePixelPerfect", "149"},
                {"set_overrideSorting", "14A"},
                {"set_pixelPerfect", "14B"},
                {"set_planeDistance", "14C"},
                {"set_referencePixelsPerUnit", "14D"},
                {"set_scaleFactor", "14E"},
                {"set_sortingLayerID", "14F"},
                {"set_sortingLayerName", "150"},
                {"set_sortingOrder", "151"}
            }},
            {"UnityEngine.CanvasRenderer", new DataDictionary() {
                {"Clear", "152"},
                {"DisableRectClipping", "153"},
                {"SetAlphaTexture", "154"},
                {"SetAlpha", "155"},
                {"SetMesh", "156"},
                {"SetTexture", "157"},
                {"set_cullTransparentMesh", "158"},
                {"set_cull", "159"},
                {"set_hasPopInstruction", "15A"},
                {"set_materialCount", "15B"},
                {"set_name", "15C"},
                {"set_popMaterialCount", "15D"}
            }},
            {"UnityEngine.CapsuleCollider2D", new DataDictionary() {
                {"Distance", "15E"},
                {"set_density", "15F"},
                {"set_enabled", "160"},
                {"set_isTrigger", "161"},
                {"set_name", "162"},
                {"set_sharedMaterial", "163"},
                {"set_usedByComposite", "164"},
                {"set_usedByEffector", "165"}
            }},
            {"UnityEngine.CapsuleCollider", new DataDictionary() {
                {"set_contactOffset", "166"},
                {"set_direction", "167"},
                {"set_enabled", "168"},
                {"set_height", "169"},
                {"set_isTrigger", "16A"},
                {"set_material", "16B"},
                {"set_name", "16C"},
                {"set_radius", "16D"},
                {"set_sharedMaterial", "16E"}
            }},
            {"UnityEngine.CharacterController", new DataDictionary() {
                {"set_contactOffset", "16F"},
                {"set_detectCollisions", "170"},
                {"set_enableOverlapRecovery", "171"},
                {"set_enabled", "172"},
                {"set_height", "173"},
                {"set_isTrigger", "174"},
                {"set_material", "175"},
                {"set_minMoveDistance", "176"},
                {"set_name", "177"},
                {"set_radius", "178"},
                {"set_sharedMaterial", "179"},
                {"set_skinWidth", "17A"},
                {"set_slopeLimit", "17B"},
                {"set_stepOffset", "17C"}
            }},
            {"UnityEngine.CircleCollider2D", new DataDictionary() {
                {"Distance", "17D"},
                {"set_density", "17E"},
                {"set_enabled", "17F"},
                {"set_isTrigger", "180"},
                {"set_name", "181"},
                {"set_radius", "182"},
                {"set_sharedMaterial", "183"},
                {"set_usedByComposite", "184"},
                {"set_usedByEffector", "185"}
            }},
            {"UnityEngine.Collider2D", new DataDictionary() {
                {"Distance", "186"},
                {"set_density", "187"},
                {"set_enabled", "188"},
                {"set_isTrigger", "189"},
                {"set_name", "18A"},
                {"set_sharedMaterial", "18B"},
                {"set_usedByComposite", "18C"},
                {"set_usedByEffector", "18D"}
            }},
            {"UnityEngine.Collider", new DataDictionary() {
                {"set_contactOffset", "18E"},
                {"set_enabled", "18F"},
                {"set_isTrigger", "190"},
                {"set_material", "191"},
                {"set_name", "192"},
                {"set_sharedMaterial", "193"}
            }},
            {"UnityEngine.Component", new DataDictionary() {
                {"set_name", "194"}
            }},
            {"UnityEngine.CompositeCollider2D", new DataDictionary() {
                {"Distance", "195"},
                {"GenerateGeometry", "196"},
                {"set_density", "197"},
                {"set_edgeRadius", "198"},
                {"set_enabled", "199"},
                {"set_isTrigger", "19A"},
                {"set_name", "19B"},
                {"set_offsetDistance", "19C"},
                {"set_sharedMaterial", "19D"},
                {"set_usedByComposite", "19E"},
                {"set_usedByEffector", "19F"},
                {"set_vertexDistance", "1A0"}
            }},
            {"UnityEngine.ConfigurableJoint", new DataDictionary() {
                {"set_autoConfigureConnectedAnchor", "1A1"},
                {"set_breakForce", "1A2"},
                {"set_breakTorque", "1A3"},
                {"set_configuredInWorldSpace", "1A4"},
                {"set_connectedBody", "1A5"},
                {"set_connectedMassScale", "1A6"},
                {"set_enableCollision", "1A7"},
                {"set_enablePreprocessing", "1A8"},
                {"set_massScale", "1A9"},
                {"set_name", "1AA"},
                {"set_projectionAngle", "1AB"},
                {"set_projectionDistance", "1AC"},
                {"set_swapBodies", "1AD"}
            }},
            {"UnityEngine.ConstantForce2D", new DataDictionary() {
                {"set_enabled", "1AE"},
                {"set_name", "1AF"},
                {"set_torque", "1B0"}
            }},
            {"UnityEngine.ConstantForce", new DataDictionary() {
                {"set_enabled", "1B1"},
                {"set_name", "1B2"}
            }},
            {"UnityEngine.DistanceJoint2D", new DataDictionary() {
                {"set_autoConfigureConnectedAnchor", "1B3"},
                {"set_autoConfigureDistance", "1B4"},
                {"set_breakForce", "1B5"},
                {"set_breakTorque", "1B6"},
                {"set_connectedBody", "1B7"},
                {"set_distance", "1B8"},
                {"set_enableCollision", "1B9"},
                {"set_enabled", "1BA"},
                {"set_maxDistanceOnly", "1BB"},
                {"set_name", "1BC"}
            }},
            {"UnityEngine.EdgeCollider2D", new DataDictionary() {
                {"Distance", "1BD"},
                {"Reset", "1BE"},
                {"set_density", "1BF"},
                {"set_edgeRadius", "1C0"},
                {"set_enabled", "1C1"},
                {"set_isTrigger", "1C2"},
                {"set_name", "1C3"},
                {"set_sharedMaterial", "1C4"},
                {"set_usedByComposite", "1C5"},
                {"set_usedByEffector", "1C6"}
            }},
            {"UnityEngine.Effector2D", new DataDictionary() {
                {"set_colliderMask", "1C7"},
                {"set_enabled", "1C8"},
                {"set_name", "1C9"},
                {"set_useColliderMask", "1CA"}
            }},
            {"UnityEngine.FixedJoint2D", new DataDictionary() {
                {"set_autoConfigureConnectedAnchor", "1CB"},
                {"set_breakForce", "1CC"},
                {"set_breakTorque", "1CD"},
                {"set_connectedBody", "1CE"},
                {"set_dampingRatio", "1CF"},
                {"set_enableCollision", "1D0"},
                {"set_enabled", "1D1"},
                {"set_frequency", "1D2"},
                {"set_name", "1D3"}
            }},
            {"UnityEngine.FixedJoint", new DataDictionary() {
                {"set_autoConfigureConnectedAnchor", "1D4"},
                {"set_breakForce", "1D5"},
                {"set_breakTorque", "1D6"},
                {"set_connectedBody", "1D7"},
                {"set_connectedMassScale", "1D8"},
                {"set_enableCollision", "1D9"},
                {"set_enablePreprocessing", "1DA"},
                {"set_massScale", "1DB"},
                {"set_name", "1DC"}
            }},
            {"UnityEngine.FrictionJoint2D", new DataDictionary() {
                {"set_autoConfigureConnectedAnchor", "1DD"},
                {"set_breakForce", "1DE"},
                {"set_breakTorque", "1DF"},
                {"set_connectedBody", "1E0"},
                {"set_enableCollision", "1E1"},
                {"set_enabled", "1E2"},
                {"set_maxForce", "1E3"},
                {"set_maxTorque", "1E4"},
                {"set_name", "1E5"}
            }},
            {"UnityEngine.GameObject", new DataDictionary() {
                {"Find", "1E6"},
                {"SetActive", "1E7"},
                {"set_isStatic", "1E8"},
                {"set_layer", "1E9"},
                {"set_name", "1EA"}
            }},
            {"UnityEngine.HingeJoint2D", new DataDictionary() {
                {"set_autoConfigureConnectedAnchor", "1EB"},
                {"set_breakForce", "1EC"},
                {"set_breakTorque", "1ED"},
                {"set_connectedBody", "1EE"},
                {"set_enableCollision", "1EF"},
                {"set_enabled", "1F0"},
                {"set_name", "1F1"},
                {"set_useLimits", "1F2"},
                {"set_useMotor", "1F3"}
            }},
            {"UnityEngine.HingeJoint", new DataDictionary() {
                {"set_autoConfigureConnectedAnchor", "1F4"},
                {"set_breakForce", "1F5"},
                {"set_breakTorque", "1F6"},
                {"set_connectedBody", "1F7"},
                {"set_connectedMassScale", "1F8"},
                {"set_enableCollision", "1F9"},
                {"set_enablePreprocessing", "1FA"},
                {"set_massScale", "1FB"},
                {"set_name", "1FC"},
                {"set_useLimits", "1FD"},
                {"set_useMotor", "1FE"},
                {"set_useSpring", "1FF"}
            }},
            {"UnityEngine.Joint2D", new DataDictionary() {
                {"set_breakForce", "200"},
                {"set_breakTorque", "201"},
                {"set_connectedBody", "202"},
                {"set_enableCollision", "203"},
                {"set_enabled", "204"},
                {"set_name", "205"}
            }},
            {"UnityEngine.Joint", new DataDictionary() {
                {"set_autoConfigureConnectedAnchor", "206"},
                {"set_breakForce", "207"},
                {"set_breakTorque", "208"},
                {"set_connectedBody", "209"},
                {"set_connectedMassScale", "20A"},
                {"set_enableCollision", "20B"},
                {"set_enablePreprocessing", "20C"},
                {"set_massScale", "20D"},
                {"set_name", "20E"}
            }},
            {"UnityEngine.Light", new DataDictionary() {
                {"Reset", "20F"},
                {"set_bounceIntensity", "210"},
                {"set_colorTemperature", "211"},
                {"set_cookieSize", "212"},
                {"set_cookie", "213"},
                {"set_cullingMask", "214"},
                {"set_enabled", "215"},
                {"set_flare", "216"},
                {"set_intensity", "217"},
                {"set_name", "218"},
                {"set_range", "219"},
                {"set_shadowBias", "21A"},
                {"set_shadowCustomResolution", "21B"},
                {"set_shadowNearPlane", "21C"},
                {"set_shadowNormalBias", "21D"},
                {"set_shadowStrength", "21E"},
                {"set_spotAngle", "21F"},
                {"set_useBoundingSphereOverride", "220"},
                {"set_useColorTemperature", "221"},
                {"set_useShadowMatrixOverride", "222"}
            }},
            {"UnityEngine.LineRenderer", new DataDictionary() {
                {"HasPropertyBlock", "223"},
                {"Simplify", "224"},
                {"set_allowOcclusionWhenDynamic", "225"},
                {"set_enabled", "226"},
                {"set_endWidth", "227"},
                {"set_forceRenderingOff", "228"},
                {"set_generateLightingData", "229"},
                {"set_lightProbeProxyVolumeOverride", "22A"},
                {"set_lightmapIndex", "22B"},
                {"set_loop", "22C"},
                {"set_material", "22D"},
                {"set_name", "22E"},
                {"set_numCapVertices", "22F"},
                {"set_numCornerVertices", "230"},
                {"set_positionCount", "231"},
                {"set_probeAnchor", "232"},
                {"set_realtimeLightmapIndex", "233"},
                {"set_receiveShadows", "234"},
                {"set_rendererPriority", "235"},
                {"set_shadowBias", "236"},
                {"set_sharedMaterial", "237"},
                {"set_sortingLayerID", "238"},
                {"set_sortingLayerName", "239"},
                {"set_sortingOrder", "23A"},
                {"set_startWidth", "23B"},
                {"set_useWorldSpace", "23C"},
                {"set_widthMultiplier", "23D"}
            }},
            {"UnityEngine.MeshCollider", new DataDictionary() {
                {"set_contactOffset", "23E"},
                {"set_convex", "23F"},
                {"set_enabled", "240"},
                {"set_isTrigger", "241"},
                {"set_material", "242"},
                {"set_name", "243"},
                {"set_sharedMaterial", "244"},
                {"set_sharedMesh", "245"}
            }},
            {"UnityEngine.MeshFilter", new DataDictionary() {
                {"set_mesh", "246"},
                {"set_name", "247"},
                {"set_sharedMesh", "248"}
            }},
            {"UnityEngine.MeshRenderer", new DataDictionary() {
                {"HasPropertyBlock", "249"},
                {"set_additionalVertexStreams", "24A"},
                {"set_allowOcclusionWhenDynamic", "24B"},
                {"set_enabled", "24C"},
                {"set_forceRenderingOff", "24D"},
                {"set_lightProbeProxyVolumeOverride", "24E"},
                {"set_lightmapIndex", "24F"},
                {"set_material", "250"},
                {"set_name", "251"},
                {"set_probeAnchor", "252"},
                {"set_realtimeLightmapIndex", "253"},
                {"set_receiveShadows", "254"},
                {"set_rendererPriority", "255"},
                {"set_sharedMaterial", "256"},
                {"set_sortingLayerID", "257"},
                {"set_sortingLayerName", "258"},
                {"set_sortingOrder", "259"}
            }},
            {"UnityEngine.OcclusionPortal", new DataDictionary() {
                {"set_name", "25A"},
                {"set_open", "25B"}
            }},
            {"UnityEngine.ParticleSystem", new DataDictionary() {
                {"Clear", "25C"},
                {"Emit", "25D"},
                {"Pause", "25E"},
                {"Play", "25F"},
                {"Simulate", "260"},
                {"Stop", "261"},
                {"TriggerSubEmitter", "262"},
                {"set_name", "263"},
                {"set_time", "264"},
                {"set_useAutoRandomSeed", "265"}
            }},
            {"UnityEngine.ParticleSystemRenderer", new DataDictionary() {
                {"HasPropertyBlock", "266"},
                {"set_allowOcclusionWhenDynamic", "267"},
                {"set_allowRoll", "268"},
                {"set_cameraVelocityScale", "269"},
                {"set_enableGPUInstancing", "26A"},
                {"set_enabled", "26B"},
                {"set_forceRenderingOff", "26C"},
                {"set_lengthScale", "26D"},
                {"set_lightProbeProxyVolumeOverride", "26E"},
                {"set_lightmapIndex", "26F"},
                {"set_material", "270"},
                {"set_maxParticleSize", "271"},
                {"set_mesh", "272"},
                {"set_minParticleSize", "273"},
                {"set_name", "274"},
                {"set_normalDirection", "275"},
                {"set_probeAnchor", "276"},
                {"set_realtimeLightmapIndex", "277"},
                {"set_receiveShadows", "278"},
                {"set_rendererPriority", "279"},
                {"set_shadowBias", "27A"},
                {"set_sharedMaterial", "27B"},
                {"set_sortingFudge", "27C"},
                {"set_sortingLayerID", "27D"},
                {"set_sortingLayerName", "27E"},
                {"set_sortingOrder", "27F"},
                {"set_trailMaterial", "280"},
                {"set_velocityScale", "281"}
            }},
            {"UnityEngine.PlatformEffector2D", new DataDictionary() {
                {"set_colliderMask", "282"},
                {"set_enabled", "283"},
                {"set_name", "284"},
                {"set_rotationalOffset", "285"},
                {"set_sideArc", "286"},
                {"set_surfaceArc", "287"},
                {"set_useColliderMask", "288"},
                {"set_useOneWayGrouping", "289"},
                {"set_useOneWay", "28A"},
                {"set_useSideBounce", "28B"},
                {"set_useSideFriction", "28C"}
            }},
            {"UnityEngine.Playables.PlayableDirector", new DataDictionary() {
                {"DeferredEvaluate", "28D"},
                {"Evaluate", "28E"},
                {"Pause", "28F"},
                {"Play", "290"},
                {"Resume", "291"},
                {"Stop", "292"},
                {"set_enabled", "293"},
                {"set_name", "294"},
                {"set_playOnAwake", "295"}
            }},
            {"UnityEngine.PointEffector2D", new DataDictionary() {
                {"set_angularDrag", "296"},
                {"set_colliderMask", "297"},
                {"set_distanceScale", "298"},
                {"set_drag", "299"},
                {"set_enabled", "29A"},
                {"set_forceMagnitude", "29B"},
                {"set_forceVariation", "29C"},
                {"set_name", "29D"},
                {"set_useColliderMask", "29E"}
            }},
            {"UnityEngine.PolygonCollider2D", new DataDictionary() {
                {"Distance", "29F"},
                {"set_autoTiling", "2A0"},
                {"set_density", "2A1"},
                {"set_enabled", "2A2"},
                {"set_isTrigger", "2A3"},
                {"set_name", "2A4"},
                {"set_pathCount", "2A5"},
                {"set_sharedMaterial", "2A6"},
                {"set_usedByComposite", "2A7"},
                {"set_usedByEffector", "2A8"}
            }},
            {"UnityEngine.RectTransform", new DataDictionary() {
                {"DetachChildren", "2A9"},
                {"Find", "2AA"},
                {"ForceUpdateRectTransforms", "2AB"},
                {"LookAt", "2AC"},
                {"SetAsFirstSibling", "2AD"},
                {"SetAsLastSibling", "2AE"},
                {"SetParent", "2AF"},
                {"SetSiblingIndex", "2B0"},
                {"set_hasChanged", "2B1"},
                {"set_hierarchyCapacity", "2B2"},
                {"set_name", "2B3"},
                {"set_parent", "2B4"}
            }},
            {"UnityEngine.ReflectionProbe", new DataDictionary() {
                {"RenderProbe", "2B5"},
                {"Reset", "2B6"},
                {"set_bakedTexture", "2B7"},
                {"set_blendDistance", "2B8"},
                {"set_boxProjection", "2B9"},
                {"set_cullingMask", "2BA"},
                {"set_customBakedTexture", "2BB"},
                {"set_enabled", "2BC"},
                {"set_farClipPlane", "2BD"},
                {"set_hdr", "2BE"},
                {"set_importance", "2BF"},
                {"set_intensity", "2C0"},
                {"set_name", "2C1"},
                {"set_nearClipPlane", "2C2"},
                {"set_realtimeTexture", "2C3"},
                {"set_resolution", "2C4"},
                {"set_shadowDistance", "2C5"}
            }},
            {"UnityEngine.RelativeJoint2D", new DataDictionary() {
                {"set_angularOffset", "2C6"},
                {"set_autoConfigureOffset", "2C7"},
                {"set_breakForce", "2C8"},
                {"set_breakTorque", "2C9"},
                {"set_connectedBody", "2CA"},
                {"set_correctionScale", "2CB"},
                {"set_enableCollision", "2CC"},
                {"set_enabled", "2CD"},
                {"set_maxForce", "2CE"},
                {"set_maxTorque", "2CF"},
                {"set_name", "2D0"}
            }},
            {"UnityEngine.Renderer", new DataDictionary() {
                {"HasPropertyBlock", "2D1"},
                {"set_allowOcclusionWhenDynamic", "2D2"},
                {"set_enabled", "2D3"},
                {"set_forceRenderingOff", "2D4"},
                {"set_lightProbeProxyVolumeOverride", "2D5"},
                {"set_lightmapIndex", "2D6"},
                {"set_material", "2D7"},
                {"set_name", "2D8"},
                {"set_probeAnchor", "2D9"},
                {"set_realtimeLightmapIndex", "2DA"},
                {"set_receiveShadows", "2DB"},
                {"set_rendererPriority", "2DC"},
                {"set_sharedMaterial", "2DD"},
                {"set_sortingLayerID", "2DE"},
                {"set_sortingLayerName", "2DF"},
                {"set_sortingOrder", "2E0"}
            }},
            {"UnityEngine.Rendering.PostProcessing.PostProcessVolume", new DataDictionary() {
                {"set_blendDistance", "2E1"},
                {"set_enabled", "2E2"},
                {"set_isGlobal", "2E3"},
                {"set_name", "2E4"},
                {"set_priority", "2E5"},
                {"set_weight", "2E6"}
            }},
            {"UnityEngine.Rigidbody2D", new DataDictionary() {
                {"AddTorque", "2E7"},
                {"Distance", "2E8"},
                {"MoveRotation", "2E9"},
                {"SetRotation", "2EA"},
                {"Sleep", "2EB"},
                {"WakeUp", "2EC"},
                {"set_angularDrag", "2ED"},
                {"set_angularVelocity", "2EE"},
                {"set_drag", "2EF"},
                {"set_freezeRotation", "2F0"},
                {"set_gravityScale", "2F1"},
                {"set_inertia", "2F2"},
                {"set_isKinematic", "2F3"},
                {"set_mass", "2F4"},
                {"set_name", "2F5"},
                {"set_rotation", "2F6"},
                {"set_sharedMaterial", "2F7"},
                {"set_simulated", "2F8"},
                {"set_useAutoMass", "2F9"},
                {"set_useFullKinematicContacts", "2FA"}
            }},
            {"UnityEngine.Rigidbody", new DataDictionary() {
                {"ResetCenterOfMass", "2FB"},
                {"ResetInertiaTensor", "2FC"},
                {"SetDensity", "2FD"},
                {"Sleep", "2FE"},
                {"WakeUp", "2FF"},
                {"set_angularDrag", "300"},
                {"set_detectCollisions", "301"},
                {"set_drag", "302"},
                {"set_freezeRotation", "303"},
                {"set_isKinematic", "304"},
                {"set_mass", "305"},
                {"set_maxAngularVelocity", "306"},
                {"set_maxDepenetrationVelocity", "307"},
                {"set_name", "308"},
                {"set_solverIterations", "309"},
                {"set_solverVelocityIterations", "30A"},
                {"set_useGravity", "30B"}
            }},
            {"UnityEngine.SkinnedMeshRenderer", new DataDictionary() {
                {"BakeMesh", "30C"},
                {"HasPropertyBlock", "30D"},
                {"set_allowOcclusionWhenDynamic", "30E"},
                {"set_enabled", "30F"},
                {"set_forceMatrixRecalculationPerRender", "310"},
                {"set_forceRenderingOff", "311"},
                {"set_lightProbeProxyVolumeOverride", "312"},
                {"set_lightmapIndex", "313"},
                {"set_material", "314"},
                {"set_name", "315"},
                {"set_probeAnchor", "316"},
                {"set_realtimeLightmapIndex", "317"},
                {"set_receiveShadows", "318"},
                {"set_rendererPriority", "319"},
                {"set_rootBone", "31A"},
                {"set_sharedMaterial", "31B"},
                {"set_sharedMesh", "31C"},
                {"set_skinnedMotionVectors", "31D"},
                {"set_sortingLayerID", "31E"},
                {"set_sortingLayerName", "31F"},
                {"set_sortingOrder", "320"},
                {"set_updateWhenOffscreen", "321"}
            }},
            {"UnityEngine.SliderJoint2D", new DataDictionary() {
                {"set_angle", "322"},
                {"set_autoConfigureAngle", "323"},
                {"set_autoConfigureConnectedAnchor", "324"},
                {"set_breakForce", "325"},
                {"set_breakTorque", "326"},
                {"set_connectedBody", "327"},
                {"set_enableCollision", "328"},
                {"set_enabled", "329"},
                {"set_name", "32A"},
                {"set_useLimits", "32B"},
                {"set_useMotor", "32C"}
            }},
            {"UnityEngine.SphereCollider", new DataDictionary() {
                {"set_contactOffset", "32D"},
                {"set_enabled", "32E"},
                {"set_isTrigger", "32F"},
                {"set_material", "330"},
                {"set_name", "331"},
                {"set_radius", "332"},
                {"set_sharedMaterial", "333"}
            }},
            {"UnityEngine.SpringJoint", new DataDictionary() {
                {"set_autoConfigureConnectedAnchor", "334"},
                {"set_breakForce", "335"},
                {"set_breakTorque", "336"},
                {"set_connectedBody", "337"},
                {"set_connectedMassScale", "338"},
                {"set_damper", "339"},
                {"set_enableCollision", "33A"},
                {"set_enablePreprocessing", "33B"},
                {"set_massScale", "33C"},
                {"set_maxDistance", "33D"},
                {"set_minDistance", "33E"},
                {"set_name", "33F"},
                {"set_spring", "340"},
                {"set_tolerance", "341"}
            }},
            {"UnityEngine.SpriteRenderer", new DataDictionary() {
                {"HasPropertyBlock", "342"},
                {"set_adaptiveModeThreshold", "343"},
                {"set_allowOcclusionWhenDynamic", "344"},
                {"set_enabled", "345"},
                {"set_flipX", "346"},
                {"set_flipY", "347"},
                {"set_forceRenderingOff", "348"},
                {"set_lightProbeProxyVolumeOverride", "349"},
                {"set_lightmapIndex", "34A"},
                {"set_material", "34B"},
                {"set_name", "34C"},
                {"set_probeAnchor", "34D"},
                {"set_realtimeLightmapIndex", "34E"},
                {"set_receiveShadows", "34F"},
                {"set_rendererPriority", "350"},
                {"set_sharedMaterial", "351"},
                {"set_sortingLayerID", "352"},
                {"set_sortingLayerName", "353"},
                {"set_sortingOrder", "354"},
                {"set_sprite", "355"}
            }},
            {"UnityEngine.SurfaceEffector2D", new DataDictionary() {
                {"set_colliderMask", "356"},
                {"set_enabled", "357"},
                {"set_forceScale", "358"},
                {"set_name", "359"},
                {"set_speedVariation", "35A"},
                {"set_speed", "35B"},
                {"set_useBounce", "35C"},
                {"set_useColliderMask", "35D"},
                {"set_useContactForce", "35E"},
                {"set_useFriction", "35F"}
            }},
            {"UnityEngine.TargetJoint2D", new DataDictionary() {
                {"set_autoConfigureTarget", "360"},
                {"set_breakForce", "361"},
                {"set_breakTorque", "362"},
                {"set_connectedBody", "363"},
                {"set_dampingRatio", "364"},
                {"set_enableCollision", "365"},
                {"set_enabled", "366"},
                {"set_frequency", "367"},
                {"set_maxForce", "368"},
                {"set_name", "369"}
            }},
            {"UnityEngine.TrailRenderer", new DataDictionary() {
                {"Clear", "36A"},
                {"HasPropertyBlock", "36B"},
                {"set_allowOcclusionWhenDynamic", "36C"},
                {"set_autodestruct", "36D"},
                {"set_emitting", "36E"},
                {"set_enabled", "36F"},
                {"set_endWidth", "370"},
                {"set_forceRenderingOff", "371"},
                {"set_generateLightingData", "372"},
                {"set_lightProbeProxyVolumeOverride", "373"},
                {"set_lightmapIndex", "374"},
                {"set_material", "375"},
                {"set_minVertexDistance", "376"},
                {"set_name", "377"},
                {"set_numCapVertices", "378"},
                {"set_numCornerVertices", "379"},
                {"set_probeAnchor", "37A"},
                {"set_realtimeLightmapIndex", "37B"},
                {"set_receiveShadows", "37C"},
                {"set_rendererPriority", "37D"},
                {"set_shadowBias", "37E"},
                {"set_sharedMaterial", "37F"},
                {"set_sortingLayerID", "380"},
                {"set_sortingLayerName", "381"},
                {"set_sortingOrder", "382"},
                {"set_startWidth", "383"},
                {"set_time", "384"},
                {"set_widthMultiplier", "385"}
            }},
            {"UnityEngine.Transform", new DataDictionary() {
                {"DetachChildren", "386"},
                {"Find", "387"},
                {"LookAt", "388"},
                {"SetAsFirstSibling", "389"},
                {"SetAsLastSibling", "38A"},
                {"SetParent", "38B"},
                {"SetSiblingIndex", "38C"},
                {"set_hasChanged", "38D"},
                {"set_hierarchyCapacity", "38E"},
                {"set_name", "38F"},
                {"set_parent", "390"}
            }},
            {"UnityEngine.UI.AspectRatioFitter", new DataDictionary() {
                {"SetLayoutHorizontal", "391"},
                {"SetLayoutVertical", "392"},
                {"set_aspectRatio", "393"},
                {"set_enabled", "394"},
                {"set_name", "395"}
            }},
            {"UnityEngine.UI.BaseMeshEffect", new DataDictionary() {
                {"ModifyMesh", "396"},
                {"set_enabled", "397"},
                {"set_name", "398"}
            }},
            {"UnityEngine.UI.Button", new DataDictionary() {
                {"FindSelectableOnDown", "399"},
                {"FindSelectableOnLeft", "39A"},
                {"FindSelectableOnRight", "39B"},
                {"FindSelectableOnUp", "39C"},
                {"Select", "39D"},
                {"set_enabled", "39E"},
                {"set_image", "39F"},
                {"set_interactable", "3A0"},
                {"set_name", "3A1"},
                {"set_targetGraphic", "3A2"}
            }},
            {"UnityEngine.UI.CanvasScaler", new DataDictionary() {
                {"set_defaultSpriteDPI", "3A3"},
                {"set_dynamicPixelsPerUnit", "3A4"},
                {"set_enabled", "3A5"},
                {"set_fallbackScreenDPI", "3A6"},
                {"set_matchWidthOrHeight", "3A7"},
                {"set_name", "3A8"},
                {"set_referencePixelsPerUnit", "3A9"},
                {"set_scaleFactor", "3AA"}
            }},
            {"UnityEngine.UI.ContentSizeFitter", new DataDictionary() {
                {"SetLayoutHorizontal", "3AB"},
                {"SetLayoutVertical", "3AC"},
                {"set_enabled", "3AD"},
                {"set_name", "3AE"}
            }},
            {"UnityEngine.UI.Dropdown", new DataDictionary() {
                {"ClearOptions", "3AF"},
                {"FindSelectableOnDown", "3B0"},
                {"FindSelectableOnLeft", "3B1"},
                {"FindSelectableOnRight", "3B2"},
                {"FindSelectableOnUp", "3B3"},
                {"Hide", "3B4"},
                {"RefreshShownValue", "3B5"},
                {"Select", "3B6"},
                {"SetValueWithoutNotify", "3B7"},
                {"Show", "3B8"},
                {"set_alphaFadeSpeed", "3B9"},
                {"set_captionImage", "3BA"},
                {"set_captionText", "3BB"},
                {"set_enabled", "3BC"},
                {"set_image", "3BD"},
                {"set_interactable", "3BE"},
                {"set_itemImage", "3BF"},
                {"set_itemText", "3C0"},
                {"set_name", "3C1"},
                {"set_targetGraphic", "3C2"},
                {"set_value", "3C3"}
            }},
            {"UnityEngine.UI.Graphic", new DataDictionary() {
                {"GraphicUpdateComplete", "3C4"},
                {"LayoutComplete", "3C5"},
                {"OnCullingChanged", "3C6"},
                {"SetAllDirty", "3C7"},
                {"SetLayoutDirty", "3C8"},
                {"SetMaterialDirty", "3C9"},
                {"SetNativeSize", "3CA"},
                {"SetVerticesDirty", "3CB"},
                {"set_enabled", "3CC"},
                {"set_material", "3CD"},
                {"set_name", "3CE"},
                {"set_raycastTarget", "3CF"}
            }},
            {"UnityEngine.UI.GraphicRaycaster", new DataDictionary() {
                {"set_enabled", "3D0"},
                {"set_ignoreReversedGraphics", "3D1"},
                {"set_name", "3D2"}
            }},
            {"UnityEngine.UI.GridLayoutGroup", new DataDictionary() {
                {"CalculateLayoutInputHorizontal", "3D3"},
                {"CalculateLayoutInputVertical", "3D4"},
                {"SetLayoutHorizontal", "3D5"},
                {"SetLayoutVertical", "3D6"},
                {"set_constraintCount", "3D7"},
                {"set_enabled", "3D8"},
                {"set_name", "3D9"}
            }},
            {"UnityEngine.UI.HorizontalLayoutGroup", new DataDictionary() {
                {"CalculateLayoutInputHorizontal", "3DA"},
                {"CalculateLayoutInputVertical", "3DB"},
                {"SetLayoutHorizontal", "3DC"},
                {"SetLayoutVertical", "3DD"},
                {"set_childControlHeight", "3DE"},
                {"set_childControlWidth", "3DF"},
                {"set_childForceExpandHeight", "3E0"},
                {"set_childForceExpandWidth", "3E1"},
                {"set_childScaleHeight", "3E2"},
                {"set_childScaleWidth", "3E3"},
                {"set_enabled", "3E4"},
                {"set_name", "3E5"},
                {"set_spacing", "3E6"}
            }},
            {"UnityEngine.UI.HorizontalOrVerticalLayoutGroup", new DataDictionary() {
                {"CalculateLayoutInputHorizontal", "3E7"},
                {"CalculateLayoutInputVertical", "3E8"},
                {"SetLayoutHorizontal", "3E9"},
                {"SetLayoutVertical", "3EA"},
                {"set_childControlHeight", "3EB"},
                {"set_childControlWidth", "3EC"},
                {"set_childForceExpandHeight", "3ED"},
                {"set_childForceExpandWidth", "3EE"},
                {"set_childScaleHeight", "3EF"},
                {"set_childScaleWidth", "3F0"},
                {"set_enabled", "3F1"},
                {"set_name", "3F2"},
                {"set_spacing", "3F3"}
            }},
            {"UnityEngine.UI.Image", new DataDictionary() {
                {"CalculateLayoutInputHorizontal", "3F4"},
                {"CalculateLayoutInputVertical", "3F5"},
                {"DisableSpriteOptimizations", "3F6"},
                {"GraphicUpdateComplete", "3F7"},
                {"LayoutComplete", "3F8"},
                {"OnAfterDeserialize", "3F9"},
                {"OnBeforeSerialize", "3FA"},
                {"OnCullingChanged", "3FB"},
                {"RecalculateClipping", "3FC"},
                {"RecalculateMasking", "3FD"},
                {"SetAllDirty", "3FE"},
                {"SetLayoutDirty", "3FF"},
                {"SetMaterialDirty", "400"},
                {"SetNativeSize", "401"},
                {"SetVerticesDirty", "402"},
                {"set_alphaHitTestMinimumThreshold", "403"},
                {"set_enabled", "404"},
                {"set_fillAmount", "405"},
                {"set_fillCenter", "406"},
                {"set_fillClockwise", "407"},
                {"set_fillOrigin", "408"},
                {"set_isMaskingGraphic", "409"},
                {"set_maskable", "40A"},
                {"set_material", "40B"},
                {"set_name", "40C"},
                {"set_overrideSprite", "40D"},
                {"set_pixelsPerUnitMultiplier", "40E"},
                {"set_preserveAspect", "40F"},
                {"set_raycastTarget", "410"},
                {"set_sprite", "411"},
                {"set_useSpriteMesh", "412"}
            }},
            {"UnityEngine.UI.InputField", new DataDictionary() {
                {"ActivateInputField", "413"},
                {"CalculateLayoutInputHorizontal", "414"},
                {"CalculateLayoutInputVertical", "415"},
                {"DeactivateInputField", "416"},
                {"FindSelectableOnDown", "417"},
                {"FindSelectableOnLeft", "418"},
                {"FindSelectableOnRight", "419"},
                {"FindSelectableOnUp", "41A"},
                {"ForceLabelUpdate", "41B"},
                {"GraphicUpdateComplete", "41C"},
                {"LayoutComplete", "41D"},
                {"MoveTextEnd", "41E"},
                {"MoveTextStart", "41F"},
                {"Select", "420"},
                {"set_caretBlinkRate", "421"},
                {"set_caretPosition", "422"},
                {"set_caretWidth", "423"},
                {"set_characterLimit", "424"},
                {"set_customCaretColor", "425"},
                {"set_enabled", "426"},
                {"set_image", "427"},
                {"set_interactable", "428"},
                {"set_name", "429"},
                {"set_placeholder", "42A"},
                {"set_readOnly", "42B"},
                {"set_selectionAnchorPosition", "42C"},
                {"set_selectionFocusPosition", "42D"},
                {"set_shouldActivateOnSelect", "42E"},
                {"set_shouldHideMobileInput", "42F"},
                {"set_targetGraphic", "430"},
                {"set_textComponent", "431"},
                {"set_text", "432"}
            }},
            {"UnityEngine.UI.LayoutElement", new DataDictionary() {
                {"CalculateLayoutInputHorizontal", "433"},
                {"CalculateLayoutInputVertical", "434"},
                {"set_enabled", "435"},
                {"set_flexibleHeight", "436"},
                {"set_flexibleWidth", "437"},
                {"set_ignoreLayout", "438"},
                {"set_layoutPriority", "439"},
                {"set_minHeight", "43A"},
                {"set_minWidth", "43B"},
                {"set_name", "43C"},
                {"set_preferredHeight", "43D"},
                {"set_preferredWidth", "43E"}
            }},
            {"UnityEngine.UI.LayoutGroup", new DataDictionary() {
                {"CalculateLayoutInputHorizontal", "43F"},
                {"CalculateLayoutInputVertical", "440"},
                {"SetLayoutHorizontal", "441"},
                {"SetLayoutVertical", "442"},
                {"set_enabled", "443"},
                {"set_name", "444"}
            }},
            {"UnityEngine.UI.MaskableGraphic", new DataDictionary() {
                {"GraphicUpdateComplete", "445"},
                {"LayoutComplete", "446"},
                {"OnCullingChanged", "447"},
                {"RecalculateClipping", "448"},
                {"RecalculateMasking", "449"},
                {"SetAllDirty", "44A"},
                {"SetLayoutDirty", "44B"},
                {"SetMaterialDirty", "44C"},
                {"SetNativeSize", "44D"},
                {"SetVerticesDirty", "44E"},
                {"set_enabled", "44F"},
                {"set_isMaskingGraphic", "450"},
                {"set_maskable", "451"},
                {"set_material", "452"},
                {"set_name", "453"},
                {"set_raycastTarget", "454"}
            }},
            {"UnityEngine.UI.Mask", new DataDictionary() {
                {"MaskEnabled", "455"},
                {"set_enabled", "456"},
                {"set_name", "457"},
                {"set_showMaskGraphic", "458"}
            }},
            {"UnityEngine.UI.Outline", new DataDictionary() {
                {"ModifyMesh", "459"},
                {"set_enabled", "45A"},
                {"set_name", "45B"},
                {"set_useGraphicAlpha", "45C"}
            }},
            {"UnityEngine.UI.PositionAsUV1", new DataDictionary() {
                {"ModifyMesh", "45D"},
                {"set_enabled", "45E"},
                {"set_name", "45F"}
            }},
            {"UnityEngine.UI.RawImage", new DataDictionary() {
                {"GraphicUpdateComplete", "460"},
                {"LayoutComplete", "461"},
                {"OnCullingChanged", "462"},
                {"RecalculateClipping", "463"},
                {"RecalculateMasking", "464"},
                {"SetAllDirty", "465"},
                {"SetLayoutDirty", "466"},
                {"SetMaterialDirty", "467"},
                {"SetNativeSize", "468"},
                {"SetVerticesDirty", "469"},
                {"set_enabled", "46A"},
                {"set_isMaskingGraphic", "46B"},
                {"set_maskable", "46C"},
                {"set_material", "46D"},
                {"set_name", "46E"},
                {"set_raycastTarget", "46F"},
                {"set_texture", "470"}
            }},
            {"UnityEngine.UI.RectMask2D", new DataDictionary() {
                {"PerformClipping", "471"},
                {"UpdateClipSoftness", "472"},
                {"set_enabled", "473"},
                {"set_name", "474"}
            }},
            {"UnityEngine.UI.Scrollbar", new DataDictionary() {
                {"FindSelectableOnDown", "475"},
                {"FindSelectableOnLeft", "476"},
                {"FindSelectableOnRight", "477"},
                {"FindSelectableOnUp", "478"},
                {"GraphicUpdateComplete", "479"},
                {"LayoutComplete", "47A"},
                {"Select", "47B"},
                {"SetValueWithoutNotify", "47C"},
                {"set_enabled", "47D"},
                {"set_handleRect", "47E"},
                {"set_image", "47F"},
                {"set_interactable", "480"},
                {"set_name", "481"},
                {"set_numberOfSteps", "482"},
                {"set_size", "483"},
                {"set_targetGraphic", "484"},
                {"set_value", "485"}
            }},
            {"UnityEngine.UI.ScrollRect", new DataDictionary() {
                {"CalculateLayoutInputHorizontal", "486"},
                {"CalculateLayoutInputVertical", "487"},
                {"GraphicUpdateComplete", "488"},
                {"LayoutComplete", "489"},
                {"SetLayoutHorizontal", "48A"},
                {"SetLayoutVertical", "48B"},
                {"StopMovement", "48C"},
                {"set_content", "48D"},
                {"set_decelerationRate", "48E"},
                {"set_elasticity", "48F"},
                {"set_enabled", "490"},
                {"set_horizontalNormalizedPosition", "491"},
                {"set_horizontalScrollbarSpacing", "492"},
                {"set_horizontalScrollbar", "493"},
                {"set_horizontal", "494"},
                {"set_inertia", "495"},
                {"set_name", "496"},
                {"set_scrollSensitivity", "497"},
                {"set_verticalNormalizedPosition", "498"},
                {"set_verticalScrollbarSpacing", "499"},
                {"set_verticalScrollbar", "49A"},
                {"set_vertical", "49B"},
                {"set_viewport", "49C"}
            }},
            {"UnityEngine.UI.Selectable", new DataDictionary() {
                {"FindSelectableOnDown", "49D"},
                {"FindSelectableOnLeft", "49E"},
                {"FindSelectableOnRight", "49F"},
                {"FindSelectableOnUp", "4A0"},
                {"Select", "4A1"},
                {"set_enabled", "4A2"},
                {"set_image", "4A3"},
                {"set_interactable", "4A4"},
                {"set_name", "4A5"},
                {"set_targetGraphic", "4A6"}
            }},
            {"UnityEngine.UI.Shadow", new DataDictionary() {
                {"ModifyMesh", "4A7"},
                {"set_enabled", "4A8"},
                {"set_name", "4A9"},
                {"set_useGraphicAlpha", "4AA"}
            }},
            {"UnityEngine.UI.Slider", new DataDictionary() {
                {"FindSelectableOnDown", "4AB"},
                {"FindSelectableOnLeft", "4AC"},
                {"FindSelectableOnRight", "4AD"},
                {"FindSelectableOnUp", "4AE"},
                {"GraphicUpdateComplete", "4AF"},
                {"LayoutComplete", "4B0"},
                {"Select", "4B1"},
                {"SetValueWithoutNotify", "4B2"},
                {"set_enabled", "4B3"},
                {"set_fillRect", "4B4"},
                {"set_handleRect", "4B5"},
                {"set_image", "4B6"},
                {"set_interactable", "4B7"},
                {"set_maxValue", "4B8"},
                {"set_minValue", "4B9"},
                {"set_name", "4BA"},
                {"set_normalizedValue", "4BB"},
                {"set_targetGraphic", "4BC"},
                {"set_value", "4BD"},
                {"set_wholeNumbers", "4BE"}
            }},
            {"UnityEngine.UI.Text", new DataDictionary() {
                {"CalculateLayoutInputHorizontal", "4BF"},
                {"CalculateLayoutInputVertical", "4C0"},
                {"FontTextureChanged", "4C1"},
                {"GraphicUpdateComplete", "4C2"},
                {"LayoutComplete", "4C3"},
                {"OnCullingChanged", "4C4"},
                {"RecalculateClipping", "4C5"},
                {"RecalculateMasking", "4C6"},
                {"SetAllDirty", "4C7"},
                {"SetLayoutDirty", "4C8"},
                {"SetMaterialDirty", "4C9"},
                {"SetNativeSize", "4CA"},
                {"SetVerticesDirty", "4CB"},
                {"set_alignByGeometry", "4CC"},
                {"set_enabled", "4CD"},
                {"set_fontSize", "4CE"},
                {"set_font", "4CF"},
                {"set_isMaskingGraphic", "4D0"},
                {"set_lineSpacing", "4D1"},
                {"set_maskable", "4D2"},
                {"set_material", "4D3"},
                {"set_name", "4D4"},
                {"set_raycastTarget", "4D5"},
                {"set_resizeTextForBestFit", "4D6"},
                {"set_resizeTextMaxSize", "4D7"},
                {"set_resizeTextMinSize", "4D8"},
                {"set_supportRichText", "4D9"},
                {"set_text", "4DA"}
            }},
            {"UnityEngine.UI.ToggleGroup", new DataDictionary() {
                {"ActiveToggles", "4DB"},
                {"AnyTogglesOn", "4DC"},
                {"EnsureValidState", "4DD"},
                {"RegisterToggle", "4DE"},
                {"SetAllTogglesOff", "4DF"},
                {"UnregisterToggle", "4E0"},
                {"set_allowSwitchOff", "4E1"},
                {"set_enabled", "4E2"},
                {"set_name", "4E3"}
            }},
            {"UnityEngine.UI.Toggle", new DataDictionary() {
                {"FindSelectableOnDown", "4E4"},
                {"FindSelectableOnLeft", "4E5"},
                {"FindSelectableOnRight", "4E6"},
                {"FindSelectableOnUp", "4E7"},
                {"GraphicUpdateComplete", "4E8"},
                {"LayoutComplete", "4E9"},
                {"Select", "4EA"},
                {"SetIsOnWithoutNotify", "4EB"},
                {"set_enabled", "4EC"},
                {"set_graphic", "4ED"},
                {"set_group", "4EE"},
                {"set_image", "4EF"},
                {"set_interactable", "4F0"},
                {"set_isOn", "4F1"},
                {"set_name", "4F2"},
                {"set_targetGraphic", "4F3"}
            }},
            {"UnityEngine.UI.VerticalLayoutGroup", new DataDictionary() {
                {"CalculateLayoutInputHorizontal", "4F4"},
                {"CalculateLayoutInputVertical", "4F5"},
                {"SetLayoutHorizontal", "4F6"},
                {"SetLayoutVertical", "4F7"},
                {"set_childControlHeight", "4F8"},
                {"set_childControlWidth", "4F9"},
                {"set_childForceExpandHeight", "4FA"},
                {"set_childForceExpandWidth", "4FB"},
                {"set_childScaleHeight", "4FC"},
                {"set_childScaleWidth", "4FD"},
                {"set_enabled", "4FE"},
                {"set_name", "4FF"},
                {"set_spacing", "500"}
            }},
            {"UnityEngine.WheelCollider", new DataDictionary() {
                {"ResetSprungMasses", "501"},
                {"set_brakeTorque", "502"},
                {"set_contactOffset", "503"},
                {"set_enabled", "504"},
                {"set_forceAppPointDistance", "505"},
                {"set_isTrigger", "506"},
                {"set_mass", "507"},
                {"set_material", "508"},
                {"set_motorTorque", "509"},
                {"set_name", "50A"},
                {"set_radius", "50B"},
                {"set_sharedMaterial", "50C"},
                {"set_sprungMass", "50D"},
                {"set_steerAngle", "50E"},
                {"set_suspensionDistance", "50F"},
                {"set_wheelDampingRate", "510"}
            }},
            {"UnityEngine.WheelJoint2D", new DataDictionary() {
                {"set_autoConfigureConnectedAnchor", "511"},
                {"set_breakForce", "512"},
                {"set_breakTorque", "513"},
                {"set_connectedBody", "514"},
                {"set_enableCollision", "515"},
                {"set_enabled", "516"},
                {"set_name", "517"},
                {"set_useMotor", "518"}
            }},
            {"VRC.SDK3.Components.VRCAvatarPedestal", new DataDictionary() {
                {"SwitchAvatar", "519"},
                {"set_ChangeAvatarsOnUse", "51A"},
                {"set_Placement", "51B"},
                {"set_blueprintId", "51C"},
                {"set_enabled", "51D"},
                {"set_name", "51E"},
                {"set_scale", "51F"}
            }},
            {"VRC.SDK3.Components.VRCMirrorReflection", new DataDictionary() {
                {"OnWillRenderObject", "520"},
                {"set_TurnOffMirrorOcclusion", "521"},
                {"set_customSkybox", "522"},
                {"set_enabled", "523"},
                {"set_m_DisablePixelLights", "524"},
                {"set_name", "525"}
            }},
            {"VRC.SDK3.Components.VRCObjectPool", new DataDictionary() {
                {"Return", "526"},
                {"Shuffle", "527"},
                {"TryToSpawn", "528"},
                {"set_enabled", "529"},
                {"set_name", "52A"}
            }},
            {"VRC.SDK3.Components.VRCObjectSync", new DataDictionary() {
                {"FlagDiscontinuity", "52B"},
                {"Respawn", "52C"},
                {"SetGravity", "52D"},
                {"SetKinematic", "52E"},
                {"TeleportTo", "52F"},
                {"set_AllowCollisionOwnershipTransfer", "530"},
                {"set_enabled", "531"},
                {"set_name", "532"}
            }},
            {"VRC.SDK3.Components.VRCPickup", new DataDictionary() {
                {"Drop", "533"},
                {"PlayHaptics", "534"},
                {"set_DisallowTheft", "535"},
                {"set_ExactGrip", "536"},
                {"set_ExactGun", "537"},
                {"set_InteractionText", "538"},
                {"set_ThrowVelocityBoostMinSpeed", "539"},
                {"set_ThrowVelocityBoostScale", "53A"},
                {"set_UseText", "53B"},
                {"set_allowManipulationWhenEquipped", "53C"},
                {"set_enabled", "53D"},
                {"set_name", "53E"},
                {"set_pickupable", "53F"},
                {"set_proximity", "540"}
            }},
            {"VRC.SDK3.Components.VRCPortalMarker", new DataDictionary() {
                {"RefreshPortal", "541"},
                {"set_enabled", "542"},
                {"set_name", "543"},
                {"set_roomId", "544"}
            }},
            {"VRC.SDK3.Components.VRCStation", new DataDictionary() {
                {"set_animatorController", "545"},
                {"set_canUseStationFromStation", "546"},
                {"set_disableStationExit", "547"},
                {"set_enabled", "548"},
                {"set_name", "549"},
                {"set_stationEnterPlayerLocation", "54A"},
                {"set_stationExitPlayerLocation", "54B"}
            }},
            {"VRC.SDK3.Components.VRCUrlInputField", new DataDictionary() {
                {"ActivateInputField", "54C"},
                {"CalculateLayoutInputHorizontal", "54D"},
                {"CalculateLayoutInputVertical", "54E"},
                {"DeactivateInputField", "54F"},
                {"FindSelectableOnDown", "550"},
                {"FindSelectableOnLeft", "551"},
                {"FindSelectableOnRight", "552"},
                {"FindSelectableOnUp", "553"},
                {"ForceLabelUpdate", "554"},
                {"GraphicUpdateComplete", "555"},
                {"LayoutComplete", "556"},
                {"Select", "557"},
                {"set_caretBlinkRate", "558"},
                {"set_caretWidth", "559"},
                {"set_characterLimit", "55A"},
                {"set_customCaretColor", "55B"},
                {"set_enabled", "55C"},
                {"set_image", "55D"},
                {"set_interactable", "55E"},
                {"set_name", "55F"},
                {"set_placeholder", "560"},
                {"set_readOnly", "561"},
                {"set_shouldHideMobileInput", "562"},
                {"set_targetGraphic", "563"},
                {"set_textComponent", "564"}
            }},
            {"VRC.SDK3.Midi.VRCMidiPlayer", new DataDictionary() {
                {"Play", "565"},
                {"Stop", "566"},
                {"set_Time", "567"}
            }},
            {"VRC.SDK3.Video.Components.Base.BaseVRCVideoPlayer", new DataDictionary() {
                {"Pause", "568"},
                {"Play", "569"},
                {"SetTime", "56A"},
                {"Stop", "56B"},
                {"set_EnableAutomaticResync", "56C"},
                {"set_Loop", "56D"},
                {"set_enabled", "56E"},
                {"set_name", "56F"}
            }},
            {"VRC.SDKBase.VRCCustomAction", new DataDictionary() {
                {"Execute", "570"},
                {"set_enabled", "571"},
                {"set_name", "572"}
            }}
        };

        public void _00() { ((UdonBehaviour)_target).RequestSerialization(); }
        public void _01() { ((UdonBehaviour)_target).SendCustomEvent((String)_argument); }
        public void _02() { ((UdonBehaviour)_target).DisableInteractive = (Boolean)_argument; }
        public void _03() { ((UdonBehaviour)_target).InteractionText = (String)_argument; }
        public void _04() { ((UdonBehaviour)_target).enabled = (Boolean)_argument; }
        public void _05() { ((CinemachineDollyCart)_target).enabled = (Boolean)_argument; }
        public void _06() { ((CinemachineDollyCart)_target).m_Path = (CinemachinePathBase)_argument; }
        public void _07() { ((CinemachineDollyCart)_target).m_Position = (Single)_argument; }
        public void _08() { ((CinemachineDollyCart)_target).m_Speed = (Single)_argument; }
        public void _09() { ((CinemachineDollyCart)_target).name = (String)_argument; }
        public void _0A() { ((CinemachinePathBase)_target).DistanceCacheIsValid(); }
        public void _0B() { ((CinemachinePathBase)_target).EvaluateOrientation((Single)_argument); }
        public void _0C() { ((CinemachinePathBase)_target).EvaluatePosition((Single)_argument); }
        public void _0D() { ((CinemachinePathBase)_target).EvaluateTangent((Single)_argument); }
        public void _0E() { ((CinemachinePathBase)_target).InvalidateDistanceCache(); }
        public void _0F() { ((CinemachinePathBase)_target).StandardizePathDistance((Single)_argument); }
        public void _10() { ((CinemachinePathBase)_target).StandardizePos((Single)_argument); }
        public void _11() { ((CinemachinePathBase)_target).enabled = (Boolean)_argument; }
        public void _12() { ((CinemachinePathBase)_target).name = (String)_argument; }
        public void _13() { ((CinemachineVirtualCamera)_target).MoveToTopOfPrioritySubqueue(); }
        public void _14() { ((CinemachineVirtualCamera)_target).ResolveFollow((Transform)_argument); }
        public void _15() { ((CinemachineVirtualCamera)_target).ResolveLookAt((Transform)_argument); }
        public void _16() { ((CinemachineVirtualCamera)_target).Follow = (Transform)_argument; }
        public void _17() { ((CinemachineVirtualCamera)_target).LookAt = (Transform)_argument; }
        public void _18() { ((CinemachineVirtualCamera)_target).Priority = (Int32)_argument; }
        public void _19() { ((CinemachineVirtualCamera)_target).enabled = (Boolean)_argument; }
        public void _1A() { ((CinemachineVirtualCamera)_target).name = (String)_argument; }
        public void _1B() { ((TextMeshPro)_target).enabled = (Boolean)_argument; }
        public void _1C() { ((TextMeshPro)_target).isMaskingGraphic = (Boolean)_argument; }
        public void _1D() { ((TextMeshPro)_target).isTextObjectScaleStatic = (Boolean)_argument; }
        public void _1E() { ((TextMeshPro)_target).material = (Material)_argument; }
        public void _1F() { ((TextMeshPro)_target).maxVisibleCharacters = (Int32)_argument; }
        public void _20() { ((TextMeshPro)_target).name = (String)_argument; }
        public void _21() { ((TextMeshPro)_target).outlineWidth = (Single)_argument; }
        public void _22() { ((TextMeshPro)_target).text = (String)_argument; }
        public void _23() { ((TextMeshProUGUI)_target).enabled = (Boolean)_argument; }
        public void _24() { ((TextMeshProUGUI)_target).isMaskingGraphic = (Boolean)_argument; }
        public void _25() { ((TextMeshProUGUI)_target).isTextObjectScaleStatic = (Boolean)_argument; }
        public void _26() { ((TextMeshProUGUI)_target).material = (Material)_argument; }
        public void _27() { ((TextMeshProUGUI)_target).maxVisibleCharacters = (Int32)_argument; }
        public void _28() { ((TextMeshProUGUI)_target).name = (String)_argument; }
        public void _29() { ((TextMeshProUGUI)_target).outlineWidth = (Single)_argument; }
        public void _2A() { ((TextMeshProUGUI)_target).text = (String)_argument; }
        public void _2B() { ((NavMeshAgent)_target).ActivateCurrentOffMeshLink((Boolean)_argument); }
        public void _2C() { ((NavMeshAgent)_target).CompleteOffMeshLink(); }
        public void _2D() { ((NavMeshAgent)_target).ResetPath(); }
        public void _2E() { ((NavMeshAgent)_target).acceleration = (Single)_argument; }
        public void _2F() { ((NavMeshAgent)_target).agentTypeID = (Int32)_argument; }
        public void _30() { ((NavMeshAgent)_target).angularSpeed = (Single)_argument; }
        public void _31() { ((NavMeshAgent)_target).areaMask = (Int32)_argument; }
        public void _32() { ((NavMeshAgent)_target).autoBraking = (Boolean)_argument; }
        public void _33() { ((NavMeshAgent)_target).autoRepath = (Boolean)_argument; }
        public void _34() { ((NavMeshAgent)_target).autoTraverseOffMeshLink = (Boolean)_argument; }
        public void _35() { ((NavMeshAgent)_target).avoidancePriority = (Int32)_argument; }
        public void _36() { ((NavMeshAgent)_target).baseOffset = (Single)_argument; }
        public void _37() { ((NavMeshAgent)_target).enabled = (Boolean)_argument; }
        public void _38() { ((NavMeshAgent)_target).height = (Single)_argument; }
        public void _39() { ((NavMeshAgent)_target).isStopped = (Boolean)_argument; }
        public void _3A() { ((NavMeshAgent)_target).name = (String)_argument; }
        public void _3B() { ((NavMeshAgent)_target).radius = (Single)_argument; }
        public void _3C() { ((NavMeshAgent)_target).speed = (Single)_argument; }
        public void _3D() { ((NavMeshAgent)_target).stoppingDistance = (Single)_argument; }
        public void _3E() { ((NavMeshAgent)_target).updatePosition = (Boolean)_argument; }
        public void _3F() { ((NavMeshAgent)_target).updateRotation = (Boolean)_argument; }
        public void _40() { ((NavMeshAgent)_target).updateUpAxis = (Boolean)_argument; }
        public void _41() { ((NavMeshObstacle)_target).carveOnlyStationary = (Boolean)_argument; }
        public void _42() { ((NavMeshObstacle)_target).carvingMoveThreshold = (Single)_argument; }
        public void _43() { ((NavMeshObstacle)_target).carvingTimeToStationary = (Single)_argument; }
        public void _44() { ((NavMeshObstacle)_target).carving = (Boolean)_argument; }
        public void _45() { ((NavMeshObstacle)_target).enabled = (Boolean)_argument; }
        public void _46() { ((NavMeshObstacle)_target).height = (Single)_argument; }
        public void _47() { ((NavMeshObstacle)_target).name = (String)_argument; }
        public void _48() { ((NavMeshObstacle)_target).radius = (Single)_argument; }
        public void _49() { ((OffMeshLink)_target).UpdatePositions(); }
        public void _4A() { ((OffMeshLink)_target).activated = (Boolean)_argument; }
        public void _4B() { ((OffMeshLink)_target).area = (Int32)_argument; }
        public void _4C() { ((OffMeshLink)_target).autoUpdatePositions = (Boolean)_argument; }
        public void _4D() { ((OffMeshLink)_target).biDirectional = (Boolean)_argument; }
        public void _4E() { ((OffMeshLink)_target).costOverride = (Single)_argument; }
        public void _4F() { ((OffMeshLink)_target).enabled = (Boolean)_argument; }
        public void _50() { ((OffMeshLink)_target).endTransform = (Transform)_argument; }
        public void _51() { ((OffMeshLink)_target).name = (String)_argument; }
        public void _52() { ((OffMeshLink)_target).startTransform = (Transform)_argument; }
        public void _53() { ((AimConstraint)_target).RemoveSource((Int32)_argument); }
        public void _54() { ((AimConstraint)_target).constraintActive = (Boolean)_argument; }
        public void _55() { ((AimConstraint)_target).enabled = (Boolean)_argument; }
        public void _56() { ((AimConstraint)_target).locked = (Boolean)_argument; }
        public void _57() { ((AimConstraint)_target).name = (String)_argument; }
        public void _58() { ((AimConstraint)_target).weight = (Single)_argument; }
        public void _59() { ((AimConstraint)_target).worldUpObject = (Transform)_argument; }
        public void _5A() { ((LookAtConstraint)_target).RemoveSource((Int32)_argument); }
        public void _5B() { ((LookAtConstraint)_target).constraintActive = (Boolean)_argument; }
        public void _5C() { ((LookAtConstraint)_target).enabled = (Boolean)_argument; }
        public void _5D() { ((LookAtConstraint)_target).locked = (Boolean)_argument; }
        public void _5E() { ((LookAtConstraint)_target).name = (String)_argument; }
        public void _5F() { ((LookAtConstraint)_target).roll = (Single)_argument; }
        public void _60() { ((LookAtConstraint)_target).useUpObject = (Boolean)_argument; }
        public void _61() { ((LookAtConstraint)_target).weight = (Single)_argument; }
        public void _62() { ((LookAtConstraint)_target).worldUpObject = (Transform)_argument; }
        public void _63() { ((ParentConstraint)_target).RemoveSource((Int32)_argument); }
        public void _64() { ((ParentConstraint)_target).constraintActive = (Boolean)_argument; }
        public void _65() { ((ParentConstraint)_target).enabled = (Boolean)_argument; }
        public void _66() { ((ParentConstraint)_target).locked = (Boolean)_argument; }
        public void _67() { ((ParentConstraint)_target).name = (String)_argument; }
        public void _68() { ((ParentConstraint)_target).weight = (Single)_argument; }
        public void _69() { ((PositionConstraint)_target).RemoveSource((Int32)_argument); }
        public void _6A() { ((PositionConstraint)_target).constraintActive = (Boolean)_argument; }
        public void _6B() { ((PositionConstraint)_target).enabled = (Boolean)_argument; }
        public void _6C() { ((PositionConstraint)_target).locked = (Boolean)_argument; }
        public void _6D() { ((PositionConstraint)_target).name = (String)_argument; }
        public void _6E() { ((PositionConstraint)_target).weight = (Single)_argument; }
        public void _6F() { ((RotationConstraint)_target).RemoveSource((Int32)_argument); }
        public void _70() { ((RotationConstraint)_target).constraintActive = (Boolean)_argument; }
        public void _71() { ((RotationConstraint)_target).enabled = (Boolean)_argument; }
        public void _72() { ((RotationConstraint)_target).locked = (Boolean)_argument; }
        public void _73() { ((RotationConstraint)_target).name = (String)_argument; }
        public void _74() { ((RotationConstraint)_target).weight = (Single)_argument; }
        public void _75() { ((ScaleConstraint)_target).RemoveSource((Int32)_argument); }
        public void _76() { ((ScaleConstraint)_target).constraintActive = (Boolean)_argument; }
        public void _77() { ((ScaleConstraint)_target).enabled = (Boolean)_argument; }
        public void _78() { ((ScaleConstraint)_target).locked = (Boolean)_argument; }
        public void _79() { ((ScaleConstraint)_target).name = (String)_argument; }
        public void _7A() { ((ScaleConstraint)_target).weight = (Single)_argument; }
        public void _7B() { ((Animator)_target).ApplyBuiltinRootMotion(); }
        public void _7C() { if (_argument.GetType().Equals(typeof(System.Boolean))) { ((Animator)_target).InterruptMatchTarget((Boolean)_argument); } else { ((Animator)_target).InterruptMatchTarget(); } }
        public void _7D() { if (_argument.GetType().Equals(typeof(System.Int32))) { ((Animator)_target).PlayInFixedTime((Int32)_argument); } else { ((Animator)_target).PlayInFixedTime((String)_argument); } }
        public void _7E() { if (_argument.GetType().Equals(typeof(System.Int32))) { ((Animator)_target).Play((Int32)_argument); } else { ((Animator)_target).Play((String)_argument); } }
        public void _7F() { ((Animator)_target).Rebind(); }
        public void _80() { if (_argument.GetType().Equals(typeof(System.Int32))) { ((Animator)_target).ResetTrigger((Int32)_argument); } else { ((Animator)_target).ResetTrigger((String)_argument); } }
        public void _81() { ((Animator)_target).SetLookAtWeight((Single)_argument); }
        public void _82() { if (_argument.GetType().Equals(typeof(System.Int32))) { ((Animator)_target).SetTrigger((Int32)_argument); } else { ((Animator)_target).SetTrigger((String)_argument); } }
        public void _83() { ((Animator)_target).StartPlayback(); }
        public void _84() { ((Animator)_target).StartRecording((Int32)_argument); }
        public void _85() { ((Animator)_target).StopPlayback(); }
        public void _86() { ((Animator)_target).StopRecording(); }
        public void _87() { ((Animator)_target).Update((Single)_argument); }
        public void _88() { ((Animator)_target).WriteDefaultValues(); }
        public void _89() { ((Animator)_target).applyRootMotion = (Boolean)_argument; }
        public void _8A() { ((Animator)_target).avatar = (Avatar)_argument; }
        public void _8B() { ((Animator)_target).enabled = (Boolean)_argument; }
        public void _8C() { ((Animator)_target).feetPivotActive = (Single)_argument; }
        public void _8D() { ((Animator)_target).keepAnimatorControllerStateOnDisable = (Boolean)_argument; }
        public void _8E() { ((Animator)_target).layersAffectMassCenter = (Boolean)_argument; }
        public void _8F() { ((Animator)_target).logWarnings = (Boolean)_argument; }
        public void _90() { ((Animator)_target).name = (String)_argument; }
        public void _91() { ((Animator)_target).playbackTime = (Single)_argument; }
        public void _92() { ((Animator)_target).recorderStartTime = (Single)_argument; }
        public void _93() { ((Animator)_target).recorderStopTime = (Single)_argument; }
        public void _94() { ((Animator)_target).runtimeAnimatorController = (RuntimeAnimatorController)_argument; }
        public void _95() { ((Animator)_target).speed = (Single)_argument; }
        public void _96() { ((Animator)_target).stabilizeFeet = (Boolean)_argument; }
        public void _97() { ((AreaEffector2D)_target).angularDrag = (Single)_argument; }
        public void _98() { ((AreaEffector2D)_target).colliderMask = (Int32)_argument; }
        public void _99() { ((AreaEffector2D)_target).drag = (Single)_argument; }
        public void _9A() { ((AreaEffector2D)_target).enabled = (Boolean)_argument; }
        public void _9B() { ((AreaEffector2D)_target).forceAngle = (Single)_argument; }
        public void _9C() { ((AreaEffector2D)_target).forceMagnitude = (Single)_argument; }
        public void _9D() { ((AreaEffector2D)_target).forceVariation = (Single)_argument; }
        public void _9E() { ((AreaEffector2D)_target).name = (String)_argument; }
        public void _9F() { ((AreaEffector2D)_target).useColliderMask = (Boolean)_argument; }
        public void _A0() { ((AreaEffector2D)_target).useGlobalAngle = (Boolean)_argument; }
        public void _A1() { ((AudioChorusFilter)_target).delay = (Single)_argument; }
        public void _A2() { ((AudioChorusFilter)_target).depth = (Single)_argument; }
        public void _A3() { ((AudioChorusFilter)_target).dryMix = (Single)_argument; }
        public void _A4() { ((AudioChorusFilter)_target).enabled = (Boolean)_argument; }
        public void _A5() { ((AudioChorusFilter)_target).name = (String)_argument; }
        public void _A6() { ((AudioChorusFilter)_target).rate = (Single)_argument; }
        public void _A7() { ((AudioChorusFilter)_target).wetMix1 = (Single)_argument; }
        public void _A8() { ((AudioChorusFilter)_target).wetMix2 = (Single)_argument; }
        public void _A9() { ((AudioChorusFilter)_target).wetMix3 = (Single)_argument; }
        public void _AA() { ((AudioDistortionFilter)_target).distortionLevel = (Single)_argument; }
        public void _AB() { ((AudioDistortionFilter)_target).enabled = (Boolean)_argument; }
        public void _AC() { ((AudioDistortionFilter)_target).name = (String)_argument; }
        public void _AD() { ((AudioEchoFilter)_target).decayRatio = (Single)_argument; }
        public void _AE() { ((AudioEchoFilter)_target).delay = (Single)_argument; }
        public void _AF() { ((AudioEchoFilter)_target).dryMix = (Single)_argument; }
        public void _B0() { ((AudioEchoFilter)_target).enabled = (Boolean)_argument; }
        public void _B1() { ((AudioEchoFilter)_target).name = (String)_argument; }
        public void _B2() { ((AudioEchoFilter)_target).wetMix = (Single)_argument; }
        public void _B3() { ((AudioHighPassFilter)_target).cutoffFrequency = (Single)_argument; }
        public void _B4() { ((AudioHighPassFilter)_target).enabled = (Boolean)_argument; }
        public void _B5() { ((AudioHighPassFilter)_target).highpassResonanceQ = (Single)_argument; }
        public void _B6() { ((AudioHighPassFilter)_target).name = (String)_argument; }
        public void _B7() { ((AudioLowPassFilter)_target).cutoffFrequency = (Single)_argument; }
        public void _B8() { ((AudioLowPassFilter)_target).enabled = (Boolean)_argument; }
        public void _B9() { ((AudioLowPassFilter)_target).lowpassResonanceQ = (Single)_argument; }
        public void _BA() { ((AudioLowPassFilter)_target).name = (String)_argument; }
        public void _BB() { ((AudioReverbFilter)_target).decayHFRatio = (Single)_argument; }
        public void _BC() { ((AudioReverbFilter)_target).decayTime = (Single)_argument; }
        public void _BD() { ((AudioReverbFilter)_target).density = (Single)_argument; }
        public void _BE() { ((AudioReverbFilter)_target).diffusion = (Single)_argument; }
        public void _BF() { ((AudioReverbFilter)_target).dryLevel = (Single)_argument; }
        public void _C0() { ((AudioReverbFilter)_target).enabled = (Boolean)_argument; }
        public void _C1() { ((AudioReverbFilter)_target).hfReference = (Single)_argument; }
        public void _C2() { ((AudioReverbFilter)_target).lfReference = (Single)_argument; }
        public void _C3() { ((AudioReverbFilter)_target).name = (String)_argument; }
        public void _C4() { ((AudioReverbFilter)_target).reflectionsDelay = (Single)_argument; }
        public void _C5() { ((AudioReverbFilter)_target).reflectionsLevel = (Single)_argument; }
        public void _C6() { ((AudioReverbFilter)_target).reverbDelay = (Single)_argument; }
        public void _C7() { ((AudioReverbFilter)_target).reverbLevel = (Single)_argument; }
        public void _C8() { ((AudioReverbFilter)_target).roomHF = (Single)_argument; }
        public void _C9() { ((AudioReverbFilter)_target).roomLF = (Single)_argument; }
        public void _CA() { ((AudioReverbFilter)_target).room = (Single)_argument; }
        public void _CB() { ((AudioReverbZone)_target).HFReference = (Single)_argument; }
        public void _CC() { ((AudioReverbZone)_target).LFReference = (Single)_argument; }
        public void _CD() { ((AudioReverbZone)_target).decayHFRatio = (Single)_argument; }
        public void _CE() { ((AudioReverbZone)_target).decayTime = (Single)_argument; }
        public void _CF() { ((AudioReverbZone)_target).density = (Single)_argument; }
        public void _D0() { ((AudioReverbZone)_target).diffusion = (Single)_argument; }
        public void _D1() { ((AudioReverbZone)_target).enabled = (Boolean)_argument; }
        public void _D2() { ((AudioReverbZone)_target).maxDistance = (Single)_argument; }
        public void _D3() { ((AudioReverbZone)_target).minDistance = (Single)_argument; }
        public void _D4() { ((AudioReverbZone)_target).name = (String)_argument; }
        public void _D5() { ((AudioReverbZone)_target).reflectionsDelay = (Single)_argument; }
        public void _D6() { ((AudioReverbZone)_target).reflections = (Int32)_argument; }
        public void _D7() { ((AudioReverbZone)_target).reverbDelay = (Single)_argument; }
        public void _D8() { ((AudioReverbZone)_target).reverb = (Int32)_argument; }
        public void _D9() { ((AudioReverbZone)_target).roomHF = (Int32)_argument; }
        public void _DA() { ((AudioReverbZone)_target).roomLF = (Int32)_argument; }
        public void _DB() { ((AudioReverbZone)_target).room = (Int32)_argument; }
        public void _DC() { ((AudioSource)_target).Pause(); }
        public void _DD() { ((AudioSource)_target).PlayDelayed((Single)_argument); }
        public void _DE() { ((AudioSource)_target).PlayOneShot((AudioClip)_argument); }
        public void _DF() { ((AudioSource)_target).Play(); }
        public void _E0() { ((AudioSource)_target).Stop(); }
        public void _E1() { ((AudioSource)_target).UnPause(); }
        public void _E2() { ((AudioSource)_target).bypassReverbZones = (Boolean)_argument; }
        public void _E3() { ((AudioSource)_target).clip = (AudioClip)_argument; }
        public void _E4() { ((AudioSource)_target).dopplerLevel = (Single)_argument; }
        public void _E5() { ((AudioSource)_target).enabled = (Boolean)_argument; }
        public void _E6() { ((AudioSource)_target).loop = (Boolean)_argument; }
        public void _E7() { ((AudioSource)_target).maxDistance = (Single)_argument; }
        public void _E8() { ((AudioSource)_target).minDistance = (Single)_argument; }
        public void _E9() { ((AudioSource)_target).mute = (Boolean)_argument; }
        public void _EA() { ((AudioSource)_target).name = (String)_argument; }
        public void _EB() { ((AudioSource)_target).panStereo = (Single)_argument; }
        public void _EC() { ((AudioSource)_target).pitch = (Single)_argument; }
        public void _ED() { ((AudioSource)_target).playOnAwake = (Boolean)_argument; }
        public void _EE() { ((AudioSource)_target).priority = (Int32)_argument; }
        public void _EF() { ((AudioSource)_target).reverbZoneMix = (Single)_argument; }
        public void _F0() { ((AudioSource)_target).spatialBlend = (Single)_argument; }
        public void _F1() { ((AudioSource)_target).spatializePostEffects = (Boolean)_argument; }
        public void _F2() { ((AudioSource)_target).spatialize = (Boolean)_argument; }
        public void _F3() { ((AudioSource)_target).spread = (Single)_argument; }
        public void _F4() { ((AudioSource)_target).timeSamples = (Int32)_argument; }
        public void _F5() { ((AudioSource)_target).time = (Single)_argument; }
        public void _F6() { ((AudioSource)_target).volume = (Single)_argument; }
        public void _F7() { ((BillboardRenderer)_target).HasPropertyBlock(); }
        public void _F8() { ((BillboardRenderer)_target).allowOcclusionWhenDynamic = (Boolean)_argument; }
        public void _F9() { ((BillboardRenderer)_target).billboard = (BillboardAsset)_argument; }
        public void _FA() { ((BillboardRenderer)_target).enabled = (Boolean)_argument; }
        public void _FB() { ((BillboardRenderer)_target).forceRenderingOff = (Boolean)_argument; }
        public void _FC() { ((BillboardRenderer)_target).lightProbeProxyVolumeOverride = (GameObject)_argument; }
        public void _FD() { ((BillboardRenderer)_target).lightmapIndex = (Int32)_argument; }
        public void _FE() { ((BillboardRenderer)_target).material = (Material)_argument; }
        public void _FF() { ((BillboardRenderer)_target).name = (String)_argument; }
        public void _100() { ((BillboardRenderer)_target).probeAnchor = (Transform)_argument; }
        public void _101() { ((BillboardRenderer)_target).realtimeLightmapIndex = (Int32)_argument; }
        public void _102() { ((BillboardRenderer)_target).receiveShadows = (Boolean)_argument; }
        public void _103() { ((BillboardRenderer)_target).rendererPriority = (Int32)_argument; }
        public void _104() { ((BillboardRenderer)_target).sharedMaterial = (Material)_argument; }
        public void _105() { ((BillboardRenderer)_target).sortingLayerID = (Int32)_argument; }
        public void _106() { ((BillboardRenderer)_target).sortingLayerName = (String)_argument; }
        public void _107() { ((BillboardRenderer)_target).sortingOrder = (Int32)_argument; }
        public void _108() { ((BoxCollider2D)_target).Distance((Collider2D)_argument); }
        public void _109() { ((BoxCollider2D)_target).autoTiling = (Boolean)_argument; }
        public void _10A() { ((BoxCollider2D)_target).density = (Single)_argument; }
        public void _10B() { ((BoxCollider2D)_target).edgeRadius = (Single)_argument; }
        public void _10C() { ((BoxCollider2D)_target).enabled = (Boolean)_argument; }
        public void _10D() { ((BoxCollider2D)_target).isTrigger = (Boolean)_argument; }
        public void _10E() { ((BoxCollider2D)_target).name = (String)_argument; }
        public void _10F() { ((BoxCollider2D)_target).sharedMaterial = (PhysicsMaterial2D)_argument; }
        public void _110() { ((BoxCollider2D)_target).usedByComposite = (Boolean)_argument; }
        public void _111() { ((BoxCollider2D)_target).usedByEffector = (Boolean)_argument; }
        public void _112() { ((BoxCollider)_target).contactOffset = (Single)_argument; }
        public void _113() { ((BoxCollider)_target).enabled = (Boolean)_argument; }
        public void _114() { ((BoxCollider)_target).isTrigger = (Boolean)_argument; }
        public void _115() { ((BoxCollider)_target).material = (PhysicMaterial)_argument; }
        public void _116() { ((BoxCollider)_target).name = (String)_argument; }
        public void _117() { ((BoxCollider)_target).sharedMaterial = (PhysicMaterial)_argument; }
        public void _118() { ((Camera)_target).CopyFrom((Camera)_argument); }
        public void _119() { ((Camera)_target).RenderDontRestore(); }
        public void _11A() { if (_argument.GetType().Equals(typeof(UnityEngine.Cubemap))) { ((Camera)_target).RenderToCubemap((Cubemap)_argument); } else { ((Camera)_target).RenderToCubemap((RenderTexture)_argument); } }
        public void _11B() { ((Camera)_target).Render(); }
        public void _11C() { ((Camera)_target).ResetAspect(); }
        public void _11D() { ((Camera)_target).ResetCullingMatrix(); }
        public void _11E() { ((Camera)_target).ResetProjectionMatrix(); }
        public void _11F() { ((Camera)_target).ResetReplacementShader(); }
        public void _120() { ((Camera)_target).ResetStereoProjectionMatrices(); }
        public void _121() { ((Camera)_target).ResetStereoViewMatrices(); }
        public void _122() { ((Camera)_target).ResetTransparencySortSettings(); }
        public void _123() { ((Camera)_target).ResetWorldToCameraMatrix(); }
        public void _124() { ((Camera)_target).Reset(); }
        public void _125() { Camera.SetupCurrent((Camera)_argument); }
        public void _126() { ((Camera)_target).allowDynamicResolution = (Boolean)_argument; }
        public void _127() { ((Camera)_target).allowHDR = (Boolean)_argument; }
        public void _128() { ((Camera)_target).allowMSAA = (Boolean)_argument; }
        public void _129() { ((Camera)_target).aspect = (Single)_argument; }
        public void _12A() { ((Camera)_target).clearStencilAfterLightingPass = (Boolean)_argument; }
        public void _12B() { ((Camera)_target).cullingMask = (Int32)_argument; }
        public void _12C() { ((Camera)_target).depth = (Single)_argument; }
        public void _12D() { ((Camera)_target).enabled = (Boolean)_argument; }
        public void _12E() { ((Camera)_target).eventMask = (Int32)_argument; }
        public void _12F() { ((Camera)_target).farClipPlane = (Single)_argument; }
        public void _130() { ((Camera)_target).fieldOfView = (Single)_argument; }
        public void _131() { ((Camera)_target).focalLength = (Single)_argument; }
        public void _132() { ((Camera)_target).forceIntoRenderTexture = (Boolean)_argument; }
        public void _133() { ((Camera)_target).layerCullSpherical = (Boolean)_argument; }
        public void _134() { ((Camera)_target).name = (String)_argument; }
        public void _135() { ((Camera)_target).nearClipPlane = (Single)_argument; }
        public void _136() { ((Camera)_target).orthographicSize = (Single)_argument; }
        public void _137() { ((Camera)_target).orthographic = (Boolean)_argument; }
        public void _138() { ((Camera)_target).stereoConvergence = (Single)_argument; }
        public void _139() { ((Camera)_target).stereoSeparation = (Single)_argument; }
        public void _13A() { ((Camera)_target).targetDisplay = (Int32)_argument; }
        public void _13B() { ((Camera)_target).targetTexture = (RenderTexture)_argument; }
        public void _13C() { ((Camera)_target).useJitteredProjectionMatrixForTransparentRendering = (Boolean)_argument; }
        public void _13D() { ((Camera)_target).useOcclusionCulling = (Boolean)_argument; }
        public void _13E() { ((Camera)_target).usePhysicalProperties = (Boolean)_argument; }
        public void _13F() { ((CanvasGroup)_target).alpha = (Single)_argument; }
        public void _140() { ((CanvasGroup)_target).blocksRaycasts = (Boolean)_argument; }
        public void _141() { ((CanvasGroup)_target).enabled = (Boolean)_argument; }
        public void _142() { ((CanvasGroup)_target).ignoreParentGroups = (Boolean)_argument; }
        public void _143() { ((CanvasGroup)_target).interactable = (Boolean)_argument; }
        public void _144() { ((CanvasGroup)_target).name = (String)_argument; }
        public void _145() { Canvas.ForceUpdateCanvases(); }
        public void _146() { ((Canvas)_target).enabled = (Boolean)_argument; }
        public void _147() { ((Canvas)_target).name = (String)_argument; }
        public void _148() { ((Canvas)_target).normalizedSortingGridSize = (Single)_argument; }
        public void _149() { ((Canvas)_target).overridePixelPerfect = (Boolean)_argument; }
        public void _14A() { ((Canvas)_target).overrideSorting = (Boolean)_argument; }
        public void _14B() { ((Canvas)_target).pixelPerfect = (Boolean)_argument; }
        public void _14C() { ((Canvas)_target).planeDistance = (Single)_argument; }
        public void _14D() { ((Canvas)_target).referencePixelsPerUnit = (Single)_argument; }
        public void _14E() { ((Canvas)_target).scaleFactor = (Single)_argument; }
        public void _14F() { ((Canvas)_target).sortingLayerID = (Int32)_argument; }
        public void _150() { ((Canvas)_target).sortingLayerName = (String)_argument; }
        public void _151() { ((Canvas)_target).sortingOrder = (Int32)_argument; }
        public void _152() { ((CanvasRenderer)_target).Clear(); }
        public void _153() { ((CanvasRenderer)_target).DisableRectClipping(); }
        public void _154() { ((CanvasRenderer)_target).SetAlphaTexture((Texture)_argument); }
        public void _155() { ((CanvasRenderer)_target).SetAlpha((Single)_argument); }
        public void _156() { ((CanvasRenderer)_target).SetMesh((Mesh)_argument); }
        public void _157() { ((CanvasRenderer)_target).SetTexture((Texture)_argument); }
        public void _158() { ((CanvasRenderer)_target).cullTransparentMesh = (Boolean)_argument; }
        public void _159() { ((CanvasRenderer)_target).cull = (Boolean)_argument; }
        public void _15A() { ((CanvasRenderer)_target).hasPopInstruction = (Boolean)_argument; }
        public void _15B() { ((CanvasRenderer)_target).materialCount = (Int32)_argument; }
        public void _15C() { ((CanvasRenderer)_target).name = (String)_argument; }
        public void _15D() { ((CanvasRenderer)_target).popMaterialCount = (Int32)_argument; }
        public void _15E() { ((CapsuleCollider2D)_target).Distance((Collider2D)_argument); }
        public void _15F() { ((CapsuleCollider2D)_target).density = (Single)_argument; }
        public void _160() { ((CapsuleCollider2D)_target).enabled = (Boolean)_argument; }
        public void _161() { ((CapsuleCollider2D)_target).isTrigger = (Boolean)_argument; }
        public void _162() { ((CapsuleCollider2D)_target).name = (String)_argument; }
        public void _163() { ((CapsuleCollider2D)_target).sharedMaterial = (PhysicsMaterial2D)_argument; }
        public void _164() { ((CapsuleCollider2D)_target).usedByComposite = (Boolean)_argument; }
        public void _165() { ((CapsuleCollider2D)_target).usedByEffector = (Boolean)_argument; }
        public void _166() { ((CapsuleCollider)_target).contactOffset = (Single)_argument; }
        public void _167() { ((CapsuleCollider)_target).direction = (Int32)_argument; }
        public void _168() { ((CapsuleCollider)_target).enabled = (Boolean)_argument; }
        public void _169() { ((CapsuleCollider)_target).height = (Single)_argument; }
        public void _16A() { ((CapsuleCollider)_target).isTrigger = (Boolean)_argument; }
        public void _16B() { ((CapsuleCollider)_target).material = (PhysicMaterial)_argument; }
        public void _16C() { ((CapsuleCollider)_target).name = (String)_argument; }
        public void _16D() { ((CapsuleCollider)_target).radius = (Single)_argument; }
        public void _16E() { ((CapsuleCollider)_target).sharedMaterial = (PhysicMaterial)_argument; }
        public void _16F() { ((CharacterController)_target).contactOffset = (Single)_argument; }
        public void _170() { ((CharacterController)_target).detectCollisions = (Boolean)_argument; }
        public void _171() { ((CharacterController)_target).enableOverlapRecovery = (Boolean)_argument; }
        public void _172() { ((CharacterController)_target).enabled = (Boolean)_argument; }
        public void _173() { ((CharacterController)_target).height = (Single)_argument; }
        public void _174() { ((CharacterController)_target).isTrigger = (Boolean)_argument; }
        public void _175() { ((CharacterController)_target).material = (PhysicMaterial)_argument; }
        public void _176() { ((CharacterController)_target).minMoveDistance = (Single)_argument; }
        public void _177() { ((CharacterController)_target).name = (String)_argument; }
        public void _178() { ((CharacterController)_target).radius = (Single)_argument; }
        public void _179() { ((CharacterController)_target).sharedMaterial = (PhysicMaterial)_argument; }
        public void _17A() { ((CharacterController)_target).skinWidth = (Single)_argument; }
        public void _17B() { ((CharacterController)_target).slopeLimit = (Single)_argument; }
        public void _17C() { ((CharacterController)_target).stepOffset = (Single)_argument; }
        public void _17D() { ((CircleCollider2D)_target).Distance((Collider2D)_argument); }
        public void _17E() { ((CircleCollider2D)_target).density = (Single)_argument; }
        public void _17F() { ((CircleCollider2D)_target).enabled = (Boolean)_argument; }
        public void _180() { ((CircleCollider2D)_target).isTrigger = (Boolean)_argument; }
        public void _181() { ((CircleCollider2D)_target).name = (String)_argument; }
        public void _182() { ((CircleCollider2D)_target).radius = (Single)_argument; }
        public void _183() { ((CircleCollider2D)_target).sharedMaterial = (PhysicsMaterial2D)_argument; }
        public void _184() { ((CircleCollider2D)_target).usedByComposite = (Boolean)_argument; }
        public void _185() { ((CircleCollider2D)_target).usedByEffector = (Boolean)_argument; }
        public void _186() { ((Collider2D)_target).Distance((Collider2D)_argument); }
        public void _187() { ((Collider2D)_target).density = (Single)_argument; }
        public void _188() { ((Collider2D)_target).enabled = (Boolean)_argument; }
        public void _189() { ((Collider2D)_target).isTrigger = (Boolean)_argument; }
        public void _18A() { ((Collider2D)_target).name = (String)_argument; }
        public void _18B() { ((Collider2D)_target).sharedMaterial = (PhysicsMaterial2D)_argument; }
        public void _18C() { ((Collider2D)_target).usedByComposite = (Boolean)_argument; }
        public void _18D() { ((Collider2D)_target).usedByEffector = (Boolean)_argument; }
        public void _18E() { ((Collider)_target).contactOffset = (Single)_argument; }
        public void _18F() { ((Collider)_target).enabled = (Boolean)_argument; }
        public void _190() { ((Collider)_target).isTrigger = (Boolean)_argument; }
        public void _191() { ((Collider)_target).material = (PhysicMaterial)_argument; }
        public void _192() { ((Collider)_target).name = (String)_argument; }
        public void _193() { ((Collider)_target).sharedMaterial = (PhysicMaterial)_argument; }
        public void _194() { ((Component)_target).name = (String)_argument; }
        public void _195() { ((CompositeCollider2D)_target).Distance((Collider2D)_argument); }
        public void _196() { ((CompositeCollider2D)_target).GenerateGeometry(); }
        public void _197() { ((CompositeCollider2D)_target).density = (Single)_argument; }
        public void _198() { ((CompositeCollider2D)_target).edgeRadius = (Single)_argument; }
        public void _199() { ((CompositeCollider2D)_target).enabled = (Boolean)_argument; }
        public void _19A() { ((CompositeCollider2D)_target).isTrigger = (Boolean)_argument; }
        public void _19B() { ((CompositeCollider2D)_target).name = (String)_argument; }
        public void _19C() { ((CompositeCollider2D)_target).offsetDistance = (Single)_argument; }
        public void _19D() { ((CompositeCollider2D)_target).sharedMaterial = (PhysicsMaterial2D)_argument; }
        public void _19E() { ((CompositeCollider2D)_target).usedByComposite = (Boolean)_argument; }
        public void _19F() { ((CompositeCollider2D)_target).usedByEffector = (Boolean)_argument; }
        public void _1A0() { ((CompositeCollider2D)_target).vertexDistance = (Single)_argument; }
        public void _1A1() { ((ConfigurableJoint)_target).autoConfigureConnectedAnchor = (Boolean)_argument; }
        public void _1A2() { ((ConfigurableJoint)_target).breakForce = (Single)_argument; }
        public void _1A3() { ((ConfigurableJoint)_target).breakTorque = (Single)_argument; }
        public void _1A4() { ((ConfigurableJoint)_target).configuredInWorldSpace = (Boolean)_argument; }
        public void _1A5() { ((ConfigurableJoint)_target).connectedBody = (Rigidbody)_argument; }
        public void _1A6() { ((ConfigurableJoint)_target).connectedMassScale = (Single)_argument; }
        public void _1A7() { ((ConfigurableJoint)_target).enableCollision = (Boolean)_argument; }
        public void _1A8() { ((ConfigurableJoint)_target).enablePreprocessing = (Boolean)_argument; }
        public void _1A9() { ((ConfigurableJoint)_target).massScale = (Single)_argument; }
        public void _1AA() { ((ConfigurableJoint)_target).name = (String)_argument; }
        public void _1AB() { ((ConfigurableJoint)_target).projectionAngle = (Single)_argument; }
        public void _1AC() { ((ConfigurableJoint)_target).projectionDistance = (Single)_argument; }
        public void _1AD() { ((ConfigurableJoint)_target).swapBodies = (Boolean)_argument; }
        public void _1AE() { ((ConstantForce2D)_target).enabled = (Boolean)_argument; }
        public void _1AF() { ((ConstantForce2D)_target).name = (String)_argument; }
        public void _1B0() { ((ConstantForce2D)_target).torque = (Single)_argument; }
        public void _1B1() { ((ConstantForce)_target).enabled = (Boolean)_argument; }
        public void _1B2() { ((ConstantForce)_target).name = (String)_argument; }
        public void _1B3() { ((DistanceJoint2D)_target).autoConfigureConnectedAnchor = (Boolean)_argument; }
        public void _1B4() { ((DistanceJoint2D)_target).autoConfigureDistance = (Boolean)_argument; }
        public void _1B5() { ((DistanceJoint2D)_target).breakForce = (Single)_argument; }
        public void _1B6() { ((DistanceJoint2D)_target).breakTorque = (Single)_argument; }
        public void _1B7() { ((DistanceJoint2D)_target).connectedBody = (Rigidbody2D)_argument; }
        public void _1B8() { ((DistanceJoint2D)_target).distance = (Single)_argument; }
        public void _1B9() { ((DistanceJoint2D)_target).enableCollision = (Boolean)_argument; }
        public void _1BA() { ((DistanceJoint2D)_target).enabled = (Boolean)_argument; }
        public void _1BB() { ((DistanceJoint2D)_target).maxDistanceOnly = (Boolean)_argument; }
        public void _1BC() { ((DistanceJoint2D)_target).name = (String)_argument; }
        public void _1BD() { ((EdgeCollider2D)_target).Distance((Collider2D)_argument); }
        public void _1BE() { ((EdgeCollider2D)_target).Reset(); }
        public void _1BF() { ((EdgeCollider2D)_target).density = (Single)_argument; }
        public void _1C0() { ((EdgeCollider2D)_target).edgeRadius = (Single)_argument; }
        public void _1C1() { ((EdgeCollider2D)_target).enabled = (Boolean)_argument; }
        public void _1C2() { ((EdgeCollider2D)_target).isTrigger = (Boolean)_argument; }
        public void _1C3() { ((EdgeCollider2D)_target).name = (String)_argument; }
        public void _1C4() { ((EdgeCollider2D)_target).sharedMaterial = (PhysicsMaterial2D)_argument; }
        public void _1C5() { ((EdgeCollider2D)_target).usedByComposite = (Boolean)_argument; }
        public void _1C6() { ((EdgeCollider2D)_target).usedByEffector = (Boolean)_argument; }
        public void _1C7() { ((Effector2D)_target).colliderMask = (Int32)_argument; }
        public void _1C8() { ((Effector2D)_target).enabled = (Boolean)_argument; }
        public void _1C9() { ((Effector2D)_target).name = (String)_argument; }
        public void _1CA() { ((Effector2D)_target).useColliderMask = (Boolean)_argument; }
        public void _1CB() { ((FixedJoint2D)_target).autoConfigureConnectedAnchor = (Boolean)_argument; }
        public void _1CC() { ((FixedJoint2D)_target).breakForce = (Single)_argument; }
        public void _1CD() { ((FixedJoint2D)_target).breakTorque = (Single)_argument; }
        public void _1CE() { ((FixedJoint2D)_target).connectedBody = (Rigidbody2D)_argument; }
        public void _1CF() { ((FixedJoint2D)_target).dampingRatio = (Single)_argument; }
        public void _1D0() { ((FixedJoint2D)_target).enableCollision = (Boolean)_argument; }
        public void _1D1() { ((FixedJoint2D)_target).enabled = (Boolean)_argument; }
        public void _1D2() { ((FixedJoint2D)_target).frequency = (Single)_argument; }
        public void _1D3() { ((FixedJoint2D)_target).name = (String)_argument; }
        public void _1D4() { ((FixedJoint)_target).autoConfigureConnectedAnchor = (Boolean)_argument; }
        public void _1D5() { ((FixedJoint)_target).breakForce = (Single)_argument; }
        public void _1D6() { ((FixedJoint)_target).breakTorque = (Single)_argument; }
        public void _1D7() { ((FixedJoint)_target).connectedBody = (Rigidbody)_argument; }
        public void _1D8() { ((FixedJoint)_target).connectedMassScale = (Single)_argument; }
        public void _1D9() { ((FixedJoint)_target).enableCollision = (Boolean)_argument; }
        public void _1DA() { ((FixedJoint)_target).enablePreprocessing = (Boolean)_argument; }
        public void _1DB() { ((FixedJoint)_target).massScale = (Single)_argument; }
        public void _1DC() { ((FixedJoint)_target).name = (String)_argument; }
        public void _1DD() { ((FrictionJoint2D)_target).autoConfigureConnectedAnchor = (Boolean)_argument; }
        public void _1DE() { ((FrictionJoint2D)_target).breakForce = (Single)_argument; }
        public void _1DF() { ((FrictionJoint2D)_target).breakTorque = (Single)_argument; }
        public void _1E0() { ((FrictionJoint2D)_target).connectedBody = (Rigidbody2D)_argument; }
        public void _1E1() { ((FrictionJoint2D)_target).enableCollision = (Boolean)_argument; }
        public void _1E2() { ((FrictionJoint2D)_target).enabled = (Boolean)_argument; }
        public void _1E3() { ((FrictionJoint2D)_target).maxForce = (Single)_argument; }
        public void _1E4() { ((FrictionJoint2D)_target).maxTorque = (Single)_argument; }
        public void _1E5() { ((FrictionJoint2D)_target).name = (String)_argument; }
        public void _1E6() { GameObject.Find((String)_argument); }
        public void _1E7() { ((GameObject)_target).SetActive((Boolean)_argument); }
        public void _1E8() { ((GameObject)_target).isStatic = (Boolean)_argument; }
        public void _1E9() { ((GameObject)_target).layer = (Int32)_argument; }
        public void _1EA() { ((GameObject)_target).name = (String)_argument; }
        public void _1EB() { ((HingeJoint2D)_target).autoConfigureConnectedAnchor = (Boolean)_argument; }
        public void _1EC() { ((HingeJoint2D)_target).breakForce = (Single)_argument; }
        public void _1ED() { ((HingeJoint2D)_target).breakTorque = (Single)_argument; }
        public void _1EE() { ((HingeJoint2D)_target).connectedBody = (Rigidbody2D)_argument; }
        public void _1EF() { ((HingeJoint2D)_target).enableCollision = (Boolean)_argument; }
        public void _1F0() { ((HingeJoint2D)_target).enabled = (Boolean)_argument; }
        public void _1F1() { ((HingeJoint2D)_target).name = (String)_argument; }
        public void _1F2() { ((HingeJoint2D)_target).useLimits = (Boolean)_argument; }
        public void _1F3() { ((HingeJoint2D)_target).useMotor = (Boolean)_argument; }
        public void _1F4() { ((HingeJoint)_target).autoConfigureConnectedAnchor = (Boolean)_argument; }
        public void _1F5() { ((HingeJoint)_target).breakForce = (Single)_argument; }
        public void _1F6() { ((HingeJoint)_target).breakTorque = (Single)_argument; }
        public void _1F7() { ((HingeJoint)_target).connectedBody = (Rigidbody)_argument; }
        public void _1F8() { ((HingeJoint)_target).connectedMassScale = (Single)_argument; }
        public void _1F9() { ((HingeJoint)_target).enableCollision = (Boolean)_argument; }
        public void _1FA() { ((HingeJoint)_target).enablePreprocessing = (Boolean)_argument; }
        public void _1FB() { ((HingeJoint)_target).massScale = (Single)_argument; }
        public void _1FC() { ((HingeJoint)_target).name = (String)_argument; }
        public void _1FD() { ((HingeJoint)_target).useLimits = (Boolean)_argument; }
        public void _1FE() { ((HingeJoint)_target).useMotor = (Boolean)_argument; }
        public void _1FF() { ((HingeJoint)_target).useSpring = (Boolean)_argument; }
        public void _200() { ((Joint2D)_target).breakForce = (Single)_argument; }
        public void _201() { ((Joint2D)_target).breakTorque = (Single)_argument; }
        public void _202() { ((Joint2D)_target).connectedBody = (Rigidbody2D)_argument; }
        public void _203() { ((Joint2D)_target).enableCollision = (Boolean)_argument; }
        public void _204() { ((Joint2D)_target).enabled = (Boolean)_argument; }
        public void _205() { ((Joint2D)_target).name = (String)_argument; }
        public void _206() { ((Joint)_target).autoConfigureConnectedAnchor = (Boolean)_argument; }
        public void _207() { ((Joint)_target).breakForce = (Single)_argument; }
        public void _208() { ((Joint)_target).breakTorque = (Single)_argument; }
        public void _209() { ((Joint)_target).connectedBody = (Rigidbody)_argument; }
        public void _20A() { ((Joint)_target).connectedMassScale = (Single)_argument; }
        public void _20B() { ((Joint)_target).enableCollision = (Boolean)_argument; }
        public void _20C() { ((Joint)_target).enablePreprocessing = (Boolean)_argument; }
        public void _20D() { ((Joint)_target).massScale = (Single)_argument; }
        public void _20E() { ((Joint)_target).name = (String)_argument; }
        public void _20F() { ((Light)_target).Reset(); }
        public void _210() { ((Light)_target).bounceIntensity = (Single)_argument; }
        public void _211() { ((Light)_target).colorTemperature = (Single)_argument; }
        public void _212() { ((Light)_target).cookieSize = (Single)_argument; }
        public void _213() { ((Light)_target).cookie = (Texture)_argument; }
        public void _214() { ((Light)_target).cullingMask = (Int32)_argument; }
        public void _215() { ((Light)_target).enabled = (Boolean)_argument; }
        public void _216() { ((Light)_target).flare = (Flare)_argument; }
        public void _217() { ((Light)_target).intensity = (Single)_argument; }
        public void _218() { ((Light)_target).name = (String)_argument; }
        public void _219() { ((Light)_target).range = (Single)_argument; }
        public void _21A() { ((Light)_target).shadowBias = (Single)_argument; }
        public void _21B() { ((Light)_target).shadowCustomResolution = (Int32)_argument; }
        public void _21C() { ((Light)_target).shadowNearPlane = (Single)_argument; }
        public void _21D() { ((Light)_target).shadowNormalBias = (Single)_argument; }
        public void _21E() { ((Light)_target).shadowStrength = (Single)_argument; }
        public void _21F() { ((Light)_target).spotAngle = (Single)_argument; }
        public void _220() { ((Light)_target).useBoundingSphereOverride = (Boolean)_argument; }
        public void _221() { ((Light)_target).useColorTemperature = (Boolean)_argument; }
        public void _222() { ((Light)_target).useShadowMatrixOverride = (Boolean)_argument; }
        public void _223() { ((LineRenderer)_target).HasPropertyBlock(); }
        public void _224() { ((LineRenderer)_target).Simplify((Single)_argument); }
        public void _225() { ((LineRenderer)_target).allowOcclusionWhenDynamic = (Boolean)_argument; }
        public void _226() { ((LineRenderer)_target).enabled = (Boolean)_argument; }
        public void _227() { ((LineRenderer)_target).endWidth = (Single)_argument; }
        public void _228() { ((LineRenderer)_target).forceRenderingOff = (Boolean)_argument; }
        public void _229() { ((LineRenderer)_target).generateLightingData = (Boolean)_argument; }
        public void _22A() { ((LineRenderer)_target).lightProbeProxyVolumeOverride = (GameObject)_argument; }
        public void _22B() { ((LineRenderer)_target).lightmapIndex = (Int32)_argument; }
        public void _22C() { ((LineRenderer)_target).loop = (Boolean)_argument; }
        public void _22D() { ((LineRenderer)_target).material = (Material)_argument; }
        public void _22E() { ((LineRenderer)_target).name = (String)_argument; }
        public void _22F() { ((LineRenderer)_target).numCapVertices = (Int32)_argument; }
        public void _230() { ((LineRenderer)_target).numCornerVertices = (Int32)_argument; }
        public void _231() { ((LineRenderer)_target).positionCount = (Int32)_argument; }
        public void _232() { ((LineRenderer)_target).probeAnchor = (Transform)_argument; }
        public void _233() { ((LineRenderer)_target).realtimeLightmapIndex = (Int32)_argument; }
        public void _234() { ((LineRenderer)_target).receiveShadows = (Boolean)_argument; }
        public void _235() { ((LineRenderer)_target).rendererPriority = (Int32)_argument; }
        public void _236() { ((LineRenderer)_target).shadowBias = (Single)_argument; }
        public void _237() { ((LineRenderer)_target).sharedMaterial = (Material)_argument; }
        public void _238() { ((LineRenderer)_target).sortingLayerID = (Int32)_argument; }
        public void _239() { ((LineRenderer)_target).sortingLayerName = (String)_argument; }
        public void _23A() { ((LineRenderer)_target).sortingOrder = (Int32)_argument; }
        public void _23B() { ((LineRenderer)_target).startWidth = (Single)_argument; }
        public void _23C() { ((LineRenderer)_target).useWorldSpace = (Boolean)_argument; }
        public void _23D() { ((LineRenderer)_target).widthMultiplier = (Single)_argument; }
        public void _23E() { ((MeshCollider)_target).contactOffset = (Single)_argument; }
        public void _23F() { ((MeshCollider)_target).convex = (Boolean)_argument; }
        public void _240() { ((MeshCollider)_target).enabled = (Boolean)_argument; }
        public void _241() { ((MeshCollider)_target).isTrigger = (Boolean)_argument; }
        public void _242() { ((MeshCollider)_target).material = (PhysicMaterial)_argument; }
        public void _243() { ((MeshCollider)_target).name = (String)_argument; }
        public void _244() { ((MeshCollider)_target).sharedMaterial = (PhysicMaterial)_argument; }
        public void _245() { ((MeshCollider)_target).sharedMesh = (Mesh)_argument; }
        public void _246() { ((MeshFilter)_target).mesh = (Mesh)_argument; }
        public void _247() { ((MeshFilter)_target).name = (String)_argument; }
        public void _248() { ((MeshFilter)_target).sharedMesh = (Mesh)_argument; }
        public void _249() { ((MeshRenderer)_target).HasPropertyBlock(); }
        public void _24A() { ((MeshRenderer)_target).additionalVertexStreams = (Mesh)_argument; }
        public void _24B() { ((MeshRenderer)_target).allowOcclusionWhenDynamic = (Boolean)_argument; }
        public void _24C() { ((MeshRenderer)_target).enabled = (Boolean)_argument; }
        public void _24D() { ((MeshRenderer)_target).forceRenderingOff = (Boolean)_argument; }
        public void _24E() { ((MeshRenderer)_target).lightProbeProxyVolumeOverride = (GameObject)_argument; }
        public void _24F() { ((MeshRenderer)_target).lightmapIndex = (Int32)_argument; }
        public void _250() { ((MeshRenderer)_target).material = (Material)_argument; }
        public void _251() { ((MeshRenderer)_target).name = (String)_argument; }
        public void _252() { ((MeshRenderer)_target).probeAnchor = (Transform)_argument; }
        public void _253() { ((MeshRenderer)_target).realtimeLightmapIndex = (Int32)_argument; }
        public void _254() { ((MeshRenderer)_target).receiveShadows = (Boolean)_argument; }
        public void _255() { ((MeshRenderer)_target).rendererPriority = (Int32)_argument; }
        public void _256() { ((MeshRenderer)_target).sharedMaterial = (Material)_argument; }
        public void _257() { ((MeshRenderer)_target).sortingLayerID = (Int32)_argument; }
        public void _258() { ((MeshRenderer)_target).sortingLayerName = (String)_argument; }
        public void _259() { ((MeshRenderer)_target).sortingOrder = (Int32)_argument; }
        public void _25A() { ((OcclusionPortal)_target).name = (String)_argument; }
        public void _25B() { ((OcclusionPortal)_target).open = (Boolean)_argument; }
        public void _25C() { if (_argument.GetType().Equals(typeof(System.Boolean))) { ((ParticleSystem)_target).Clear((Boolean)_argument); } else { ((ParticleSystem)_target).Clear(); } }
        public void _25D() { ((ParticleSystem)_target).Emit((Int32)_argument); }
        public void _25E() { if (_argument.GetType().Equals(typeof(System.Boolean))) { ((ParticleSystem)_target).Pause((Boolean)_argument); } else { ((ParticleSystem)_target).Pause(); } }
        public void _25F() { if (_argument.GetType().Equals(typeof(System.Boolean))) { ((ParticleSystem)_target).Play((Boolean)_argument); } else { ((ParticleSystem)_target).Play(); } }
        public void _260() { ((ParticleSystem)_target).Simulate((Single)_argument); }
        public void _261() { if (_argument.GetType().Equals(typeof(System.Boolean))) { ((ParticleSystem)_target).Stop((Boolean)_argument); } else { ((ParticleSystem)_target).Stop(); } }
        public void _262() { ((ParticleSystem)_target).TriggerSubEmitter((Int32)_argument); }
        public void _263() { ((ParticleSystem)_target).name = (String)_argument; }
        public void _264() { ((ParticleSystem)_target).time = (Single)_argument; }
        public void _265() { ((ParticleSystem)_target).useAutoRandomSeed = (Boolean)_argument; }
        public void _266() { ((ParticleSystemRenderer)_target).HasPropertyBlock(); }
        public void _267() { ((ParticleSystemRenderer)_target).allowOcclusionWhenDynamic = (Boolean)_argument; }
        public void _268() { ((ParticleSystemRenderer)_target).allowRoll = (Boolean)_argument; }
        public void _269() { ((ParticleSystemRenderer)_target).cameraVelocityScale = (Single)_argument; }
        public void _26A() { ((ParticleSystemRenderer)_target).enableGPUInstancing = (Boolean)_argument; }
        public void _26B() { ((ParticleSystemRenderer)_target).enabled = (Boolean)_argument; }
        public void _26C() { ((ParticleSystemRenderer)_target).forceRenderingOff = (Boolean)_argument; }
        public void _26D() { ((ParticleSystemRenderer)_target).lengthScale = (Single)_argument; }
        public void _26E() { ((ParticleSystemRenderer)_target).lightProbeProxyVolumeOverride = (GameObject)_argument; }
        public void _26F() { ((ParticleSystemRenderer)_target).lightmapIndex = (Int32)_argument; }
        public void _270() { ((ParticleSystemRenderer)_target).material = (Material)_argument; }
        public void _271() { ((ParticleSystemRenderer)_target).maxParticleSize = (Single)_argument; }
        public void _272() { ((ParticleSystemRenderer)_target).mesh = (Mesh)_argument; }
        public void _273() { ((ParticleSystemRenderer)_target).minParticleSize = (Single)_argument; }
        public void _274() { ((ParticleSystemRenderer)_target).name = (String)_argument; }
        public void _275() { ((ParticleSystemRenderer)_target).normalDirection = (Single)_argument; }
        public void _276() { ((ParticleSystemRenderer)_target).probeAnchor = (Transform)_argument; }
        public void _277() { ((ParticleSystemRenderer)_target).realtimeLightmapIndex = (Int32)_argument; }
        public void _278() { ((ParticleSystemRenderer)_target).receiveShadows = (Boolean)_argument; }
        public void _279() { ((ParticleSystemRenderer)_target).rendererPriority = (Int32)_argument; }
        public void _27A() { ((ParticleSystemRenderer)_target).shadowBias = (Single)_argument; }
        public void _27B() { ((ParticleSystemRenderer)_target).sharedMaterial = (Material)_argument; }
        public void _27C() { ((ParticleSystemRenderer)_target).sortingFudge = (Single)_argument; }
        public void _27D() { ((ParticleSystemRenderer)_target).sortingLayerID = (Int32)_argument; }
        public void _27E() { ((ParticleSystemRenderer)_target).sortingLayerName = (String)_argument; }
        public void _27F() { ((ParticleSystemRenderer)_target).sortingOrder = (Int32)_argument; }
        public void _280() { ((ParticleSystemRenderer)_target).trailMaterial = (Material)_argument; }
        public void _281() { ((ParticleSystemRenderer)_target).velocityScale = (Single)_argument; }
        public void _282() { ((PlatformEffector2D)_target).colliderMask = (Int32)_argument; }
        public void _283() { ((PlatformEffector2D)_target).enabled = (Boolean)_argument; }
        public void _284() { ((PlatformEffector2D)_target).name = (String)_argument; }
        public void _285() { ((PlatformEffector2D)_target).rotationalOffset = (Single)_argument; }
        public void _286() { ((PlatformEffector2D)_target).sideArc = (Single)_argument; }
        public void _287() { ((PlatformEffector2D)_target).surfaceArc = (Single)_argument; }
        public void _288() { ((PlatformEffector2D)_target).useColliderMask = (Boolean)_argument; }
        public void _289() { ((PlatformEffector2D)_target).useOneWayGrouping = (Boolean)_argument; }
        public void _28A() { ((PlatformEffector2D)_target).useOneWay = (Boolean)_argument; }
        public void _28B() { ((PlatformEffector2D)_target).useSideBounce = (Boolean)_argument; }
        public void _28C() { ((PlatformEffector2D)_target).useSideFriction = (Boolean)_argument; }
        public void _28D() { ((PlayableDirector)_target).DeferredEvaluate(); }
        public void _28E() { ((PlayableDirector)_target).Evaluate(); }
        public void _28F() { ((PlayableDirector)_target).Pause(); }
        public void _290() { ((PlayableDirector)_target).Play(); }
        public void _291() { ((PlayableDirector)_target).Resume(); }
        public void _292() { ((PlayableDirector)_target).Stop(); }
        public void _293() { ((PlayableDirector)_target).enabled = (Boolean)_argument; }
        public void _294() { ((PlayableDirector)_target).name = (String)_argument; }
        public void _295() { ((PlayableDirector)_target).playOnAwake = (Boolean)_argument; }
        public void _296() { ((PointEffector2D)_target).angularDrag = (Single)_argument; }
        public void _297() { ((PointEffector2D)_target).colliderMask = (Int32)_argument; }
        public void _298() { ((PointEffector2D)_target).distanceScale = (Single)_argument; }
        public void _299() { ((PointEffector2D)_target).drag = (Single)_argument; }
        public void _29A() { ((PointEffector2D)_target).enabled = (Boolean)_argument; }
        public void _29B() { ((PointEffector2D)_target).forceMagnitude = (Single)_argument; }
        public void _29C() { ((PointEffector2D)_target).forceVariation = (Single)_argument; }
        public void _29D() { ((PointEffector2D)_target).name = (String)_argument; }
        public void _29E() { ((PointEffector2D)_target).useColliderMask = (Boolean)_argument; }
        public void _29F() { ((PolygonCollider2D)_target).Distance((Collider2D)_argument); }
        public void _2A0() { ((PolygonCollider2D)_target).autoTiling = (Boolean)_argument; }
        public void _2A1() { ((PolygonCollider2D)_target).density = (Single)_argument; }
        public void _2A2() { ((PolygonCollider2D)_target).enabled = (Boolean)_argument; }
        public void _2A3() { ((PolygonCollider2D)_target).isTrigger = (Boolean)_argument; }
        public void _2A4() { ((PolygonCollider2D)_target).name = (String)_argument; }
        public void _2A5() { ((PolygonCollider2D)_target).pathCount = (Int32)_argument; }
        public void _2A6() { ((PolygonCollider2D)_target).sharedMaterial = (PhysicsMaterial2D)_argument; }
        public void _2A7() { ((PolygonCollider2D)_target).usedByComposite = (Boolean)_argument; }
        public void _2A8() { ((PolygonCollider2D)_target).usedByEffector = (Boolean)_argument; }
        public void _2A9() { ((RectTransform)_target).DetachChildren(); }
        public void _2AA() { ((RectTransform)_target).Find((String)_argument); }
        public void _2AB() { ((RectTransform)_target).ForceUpdateRectTransforms(); }
        public void _2AC() { ((RectTransform)_target).LookAt((Transform)_argument); }
        public void _2AD() { ((RectTransform)_target).SetAsFirstSibling(); }
        public void _2AE() { ((RectTransform)_target).SetAsLastSibling(); }
        public void _2AF() { ((RectTransform)_target).SetParent((Transform)_argument); }
        public void _2B0() { ((RectTransform)_target).SetSiblingIndex((Int32)_argument); }
        public void _2B1() { ((RectTransform)_target).hasChanged = (Boolean)_argument; }
        public void _2B2() { ((RectTransform)_target).hierarchyCapacity = (Int32)_argument; }
        public void _2B3() { ((RectTransform)_target).name = (String)_argument; }
        public void _2B4() { ((RectTransform)_target).parent = (Transform)_argument; }
        public void _2B5() { if (_argument.GetType().Equals(typeof(UnityEngine.RenderTexture))) { ((ReflectionProbe)_target).RenderProbe((RenderTexture)_argument); } else { ((ReflectionProbe)_target).RenderProbe(); } }
        public void _2B6() { ((ReflectionProbe)_target).Reset(); }
        public void _2B7() { ((ReflectionProbe)_target).bakedTexture = (Texture)_argument; }
        public void _2B8() { ((ReflectionProbe)_target).blendDistance = (Single)_argument; }
        public void _2B9() { ((ReflectionProbe)_target).boxProjection = (Boolean)_argument; }
        public void _2BA() { ((ReflectionProbe)_target).cullingMask = (Int32)_argument; }
        public void _2BB() { ((ReflectionProbe)_target).customBakedTexture = (Texture)_argument; }
        public void _2BC() { ((ReflectionProbe)_target).enabled = (Boolean)_argument; }
        public void _2BD() { ((ReflectionProbe)_target).farClipPlane = (Single)_argument; }
        public void _2BE() { ((ReflectionProbe)_target).hdr = (Boolean)_argument; }
        public void _2BF() { ((ReflectionProbe)_target).importance = (Int32)_argument; }
        public void _2C0() { ((ReflectionProbe)_target).intensity = (Single)_argument; }
        public void _2C1() { ((ReflectionProbe)_target).name = (String)_argument; }
        public void _2C2() { ((ReflectionProbe)_target).nearClipPlane = (Single)_argument; }
        public void _2C3() { ((ReflectionProbe)_target).realtimeTexture = (RenderTexture)_argument; }
        public void _2C4() { ((ReflectionProbe)_target).resolution = (Int32)_argument; }
        public void _2C5() { ((ReflectionProbe)_target).shadowDistance = (Single)_argument; }
        public void _2C6() { ((RelativeJoint2D)_target).angularOffset = (Single)_argument; }
        public void _2C7() { ((RelativeJoint2D)_target).autoConfigureOffset = (Boolean)_argument; }
        public void _2C8() { ((RelativeJoint2D)_target).breakForce = (Single)_argument; }
        public void _2C9() { ((RelativeJoint2D)_target).breakTorque = (Single)_argument; }
        public void _2CA() { ((RelativeJoint2D)_target).connectedBody = (Rigidbody2D)_argument; }
        public void _2CB() { ((RelativeJoint2D)_target).correctionScale = (Single)_argument; }
        public void _2CC() { ((RelativeJoint2D)_target).enableCollision = (Boolean)_argument; }
        public void _2CD() { ((RelativeJoint2D)_target).enabled = (Boolean)_argument; }
        public void _2CE() { ((RelativeJoint2D)_target).maxForce = (Single)_argument; }
        public void _2CF() { ((RelativeJoint2D)_target).maxTorque = (Single)_argument; }
        public void _2D0() { ((RelativeJoint2D)_target).name = (String)_argument; }
        public void _2D1() { ((Renderer)_target).HasPropertyBlock(); }
        public void _2D2() { ((Renderer)_target).allowOcclusionWhenDynamic = (Boolean)_argument; }
        public void _2D3() { ((Renderer)_target).enabled = (Boolean)_argument; }
        public void _2D4() { ((Renderer)_target).forceRenderingOff = (Boolean)_argument; }
        public void _2D5() { ((Renderer)_target).lightProbeProxyVolumeOverride = (GameObject)_argument; }
        public void _2D6() { ((Renderer)_target).lightmapIndex = (Int32)_argument; }
        public void _2D7() { ((Renderer)_target).material = (Material)_argument; }
        public void _2D8() { ((Renderer)_target).name = (String)_argument; }
        public void _2D9() { ((Renderer)_target).probeAnchor = (Transform)_argument; }
        public void _2DA() { ((Renderer)_target).realtimeLightmapIndex = (Int32)_argument; }
        public void _2DB() { ((Renderer)_target).receiveShadows = (Boolean)_argument; }
        public void _2DC() { ((Renderer)_target).rendererPriority = (Int32)_argument; }
        public void _2DD() { ((Renderer)_target).sharedMaterial = (Material)_argument; }
        public void _2DE() { ((Renderer)_target).sortingLayerID = (Int32)_argument; }
        public void _2DF() { ((Renderer)_target).sortingLayerName = (String)_argument; }
        public void _2E0() { ((Renderer)_target).sortingOrder = (Int32)_argument; }
        public void _2E1() { ((PostProcessVolume)_target).blendDistance = (Single)_argument; }
        public void _2E2() { ((PostProcessVolume)_target).enabled = (Boolean)_argument; }
        public void _2E3() { ((PostProcessVolume)_target).isGlobal = (Boolean)_argument; }
        public void _2E4() { ((PostProcessVolume)_target).name = (String)_argument; }
        public void _2E5() { ((PostProcessVolume)_target).priority = (Single)_argument; }
        public void _2E6() { ((PostProcessVolume)_target).weight = (Single)_argument; }
        public void _2E7() { ((Rigidbody2D)_target).AddTorque((Single)_argument); }
        public void _2E8() { ((Rigidbody2D)_target).Distance((Collider2D)_argument); }
        public void _2E9() { ((Rigidbody2D)_target).MoveRotation((Single)_argument); }
        public void _2EA() { ((Rigidbody2D)_target).SetRotation((Single)_argument); }
        public void _2EB() { ((Rigidbody2D)_target).Sleep(); }
        public void _2EC() { ((Rigidbody2D)_target).WakeUp(); }
        public void _2ED() { ((Rigidbody2D)_target).angularDrag = (Single)_argument; }
        public void _2EE() { ((Rigidbody2D)_target).angularVelocity = (Single)_argument; }
        public void _2EF() { ((Rigidbody2D)_target).drag = (Single)_argument; }
        public void _2F0() { ((Rigidbody2D)_target).freezeRotation = (Boolean)_argument; }
        public void _2F1() { ((Rigidbody2D)_target).gravityScale = (Single)_argument; }
        public void _2F2() { ((Rigidbody2D)_target).inertia = (Single)_argument; }
        public void _2F3() { ((Rigidbody2D)_target).isKinematic = (Boolean)_argument; }
        public void _2F4() { ((Rigidbody2D)_target).mass = (Single)_argument; }
        public void _2F5() { ((Rigidbody2D)_target).name = (String)_argument; }
        public void _2F6() { ((Rigidbody2D)_target).rotation = (Single)_argument; }
        public void _2F7() { ((Rigidbody2D)_target).sharedMaterial = (PhysicsMaterial2D)_argument; }
        public void _2F8() { ((Rigidbody2D)_target).simulated = (Boolean)_argument; }
        public void _2F9() { ((Rigidbody2D)_target).useAutoMass = (Boolean)_argument; }
        public void _2FA() { ((Rigidbody2D)_target).useFullKinematicContacts = (Boolean)_argument; }
        public void _2FB() { ((Rigidbody)_target).ResetCenterOfMass(); }
        public void _2FC() { ((Rigidbody)_target).ResetInertiaTensor(); }
        public void _2FD() { ((Rigidbody)_target).SetDensity((Single)_argument); }
        public void _2FE() { ((Rigidbody)_target).Sleep(); }
        public void _2FF() { ((Rigidbody)_target).WakeUp(); }
        public void _300() { ((Rigidbody)_target).angularDrag = (Single)_argument; }
        public void _301() { ((Rigidbody)_target).detectCollisions = (Boolean)_argument; }
        public void _302() { ((Rigidbody)_target).drag = (Single)_argument; }
        public void _303() { ((Rigidbody)_target).freezeRotation = (Boolean)_argument; }
        public void _304() { ((Rigidbody)_target).isKinematic = (Boolean)_argument; }
        public void _305() { ((Rigidbody)_target).mass = (Single)_argument; }
        public void _306() { ((Rigidbody)_target).maxAngularVelocity = (Single)_argument; }
        public void _307() { ((Rigidbody)_target).maxDepenetrationVelocity = (Single)_argument; }
        public void _308() { ((Rigidbody)_target).name = (String)_argument; }
        public void _309() { ((Rigidbody)_target).solverIterations = (Int32)_argument; }
        public void _30A() { ((Rigidbody)_target).solverVelocityIterations = (Int32)_argument; }
        public void _30B() { ((Rigidbody)_target).useGravity = (Boolean)_argument; }
        public void _30C() { ((SkinnedMeshRenderer)_target).BakeMesh((Mesh)_argument); }
        public void _30D() { ((SkinnedMeshRenderer)_target).HasPropertyBlock(); }
        public void _30E() { ((SkinnedMeshRenderer)_target).allowOcclusionWhenDynamic = (Boolean)_argument; }
        public void _30F() { ((SkinnedMeshRenderer)_target).enabled = (Boolean)_argument; }
        public void _310() { ((SkinnedMeshRenderer)_target).forceMatrixRecalculationPerRender = (Boolean)_argument; }
        public void _311() { ((SkinnedMeshRenderer)_target).forceRenderingOff = (Boolean)_argument; }
        public void _312() { ((SkinnedMeshRenderer)_target).lightProbeProxyVolumeOverride = (GameObject)_argument; }
        public void _313() { ((SkinnedMeshRenderer)_target).lightmapIndex = (Int32)_argument; }
        public void _314() { ((SkinnedMeshRenderer)_target).material = (Material)_argument; }
        public void _315() { ((SkinnedMeshRenderer)_target).name = (String)_argument; }
        public void _316() { ((SkinnedMeshRenderer)_target).probeAnchor = (Transform)_argument; }
        public void _317() { ((SkinnedMeshRenderer)_target).realtimeLightmapIndex = (Int32)_argument; }
        public void _318() { ((SkinnedMeshRenderer)_target).receiveShadows = (Boolean)_argument; }
        public void _319() { ((SkinnedMeshRenderer)_target).rendererPriority = (Int32)_argument; }
        public void _31A() { ((SkinnedMeshRenderer)_target).rootBone = (Transform)_argument; }
        public void _31B() { ((SkinnedMeshRenderer)_target).sharedMaterial = (Material)_argument; }
        public void _31C() { ((SkinnedMeshRenderer)_target).sharedMesh = (Mesh)_argument; }
        public void _31D() { ((SkinnedMeshRenderer)_target).skinnedMotionVectors = (Boolean)_argument; }
        public void _31E() { ((SkinnedMeshRenderer)_target).sortingLayerID = (Int32)_argument; }
        public void _31F() { ((SkinnedMeshRenderer)_target).sortingLayerName = (String)_argument; }
        public void _320() { ((SkinnedMeshRenderer)_target).sortingOrder = (Int32)_argument; }
        public void _321() { ((SkinnedMeshRenderer)_target).updateWhenOffscreen = (Boolean)_argument; }
        public void _322() { ((SliderJoint2D)_target).angle = (Single)_argument; }
        public void _323() { ((SliderJoint2D)_target).autoConfigureAngle = (Boolean)_argument; }
        public void _324() { ((SliderJoint2D)_target).autoConfigureConnectedAnchor = (Boolean)_argument; }
        public void _325() { ((SliderJoint2D)_target).breakForce = (Single)_argument; }
        public void _326() { ((SliderJoint2D)_target).breakTorque = (Single)_argument; }
        public void _327() { ((SliderJoint2D)_target).connectedBody = (Rigidbody2D)_argument; }
        public void _328() { ((SliderJoint2D)_target).enableCollision = (Boolean)_argument; }
        public void _329() { ((SliderJoint2D)_target).enabled = (Boolean)_argument; }
        public void _32A() { ((SliderJoint2D)_target).name = (String)_argument; }
        public void _32B() { ((SliderJoint2D)_target).useLimits = (Boolean)_argument; }
        public void _32C() { ((SliderJoint2D)_target).useMotor = (Boolean)_argument; }
        public void _32D() { ((SphereCollider)_target).contactOffset = (Single)_argument; }
        public void _32E() { ((SphereCollider)_target).enabled = (Boolean)_argument; }
        public void _32F() { ((SphereCollider)_target).isTrigger = (Boolean)_argument; }
        public void _330() { ((SphereCollider)_target).material = (PhysicMaterial)_argument; }
        public void _331() { ((SphereCollider)_target).name = (String)_argument; }
        public void _332() { ((SphereCollider)_target).radius = (Single)_argument; }
        public void _333() { ((SphereCollider)_target).sharedMaterial = (PhysicMaterial)_argument; }
        public void _334() { ((SpringJoint)_target).autoConfigureConnectedAnchor = (Boolean)_argument; }
        public void _335() { ((SpringJoint)_target).breakForce = (Single)_argument; }
        public void _336() { ((SpringJoint)_target).breakTorque = (Single)_argument; }
        public void _337() { ((SpringJoint)_target).connectedBody = (Rigidbody)_argument; }
        public void _338() { ((SpringJoint)_target).connectedMassScale = (Single)_argument; }
        public void _339() { ((SpringJoint)_target).damper = (Single)_argument; }
        public void _33A() { ((SpringJoint)_target).enableCollision = (Boolean)_argument; }
        public void _33B() { ((SpringJoint)_target).enablePreprocessing = (Boolean)_argument; }
        public void _33C() { ((SpringJoint)_target).massScale = (Single)_argument; }
        public void _33D() { ((SpringJoint)_target).maxDistance = (Single)_argument; }
        public void _33E() { ((SpringJoint)_target).minDistance = (Single)_argument; }
        public void _33F() { ((SpringJoint)_target).name = (String)_argument; }
        public void _340() { ((SpringJoint)_target).spring = (Single)_argument; }
        public void _341() { ((SpringJoint)_target).tolerance = (Single)_argument; }
        public void _342() { ((SpriteRenderer)_target).HasPropertyBlock(); }
        public void _343() { ((SpriteRenderer)_target).adaptiveModeThreshold = (Single)_argument; }
        public void _344() { ((SpriteRenderer)_target).allowOcclusionWhenDynamic = (Boolean)_argument; }
        public void _345() { ((SpriteRenderer)_target).enabled = (Boolean)_argument; }
        public void _346() { ((SpriteRenderer)_target).flipX = (Boolean)_argument; }
        public void _347() { ((SpriteRenderer)_target).flipY = (Boolean)_argument; }
        public void _348() { ((SpriteRenderer)_target).forceRenderingOff = (Boolean)_argument; }
        public void _349() { ((SpriteRenderer)_target).lightProbeProxyVolumeOverride = (GameObject)_argument; }
        public void _34A() { ((SpriteRenderer)_target).lightmapIndex = (Int32)_argument; }
        public void _34B() { ((SpriteRenderer)_target).material = (Material)_argument; }
        public void _34C() { ((SpriteRenderer)_target).name = (String)_argument; }
        public void _34D() { ((SpriteRenderer)_target).probeAnchor = (Transform)_argument; }
        public void _34E() { ((SpriteRenderer)_target).realtimeLightmapIndex = (Int32)_argument; }
        public void _34F() { ((SpriteRenderer)_target).receiveShadows = (Boolean)_argument; }
        public void _350() { ((SpriteRenderer)_target).rendererPriority = (Int32)_argument; }
        public void _351() { ((SpriteRenderer)_target).sharedMaterial = (Material)_argument; }
        public void _352() { ((SpriteRenderer)_target).sortingLayerID = (Int32)_argument; }
        public void _353() { ((SpriteRenderer)_target).sortingLayerName = (String)_argument; }
        public void _354() { ((SpriteRenderer)_target).sortingOrder = (Int32)_argument; }
        public void _355() { ((SpriteRenderer)_target).sprite = (Sprite)_argument; }
        public void _356() { ((SurfaceEffector2D)_target).colliderMask = (Int32)_argument; }
        public void _357() { ((SurfaceEffector2D)_target).enabled = (Boolean)_argument; }
        public void _358() { ((SurfaceEffector2D)_target).forceScale = (Single)_argument; }
        public void _359() { ((SurfaceEffector2D)_target).name = (String)_argument; }
        public void _35A() { ((SurfaceEffector2D)_target).speedVariation = (Single)_argument; }
        public void _35B() { ((SurfaceEffector2D)_target).speed = (Single)_argument; }
        public void _35C() { ((SurfaceEffector2D)_target).useBounce = (Boolean)_argument; }
        public void _35D() { ((SurfaceEffector2D)_target).useColliderMask = (Boolean)_argument; }
        public void _35E() { ((SurfaceEffector2D)_target).useContactForce = (Boolean)_argument; }
        public void _35F() { ((SurfaceEffector2D)_target).useFriction = (Boolean)_argument; }
        public void _360() { ((TargetJoint2D)_target).autoConfigureTarget = (Boolean)_argument; }
        public void _361() { ((TargetJoint2D)_target).breakForce = (Single)_argument; }
        public void _362() { ((TargetJoint2D)_target).breakTorque = (Single)_argument; }
        public void _363() { ((TargetJoint2D)_target).connectedBody = (Rigidbody2D)_argument; }
        public void _364() { ((TargetJoint2D)_target).dampingRatio = (Single)_argument; }
        public void _365() { ((TargetJoint2D)_target).enableCollision = (Boolean)_argument; }
        public void _366() { ((TargetJoint2D)_target).enabled = (Boolean)_argument; }
        public void _367() { ((TargetJoint2D)_target).frequency = (Single)_argument; }
        public void _368() { ((TargetJoint2D)_target).maxForce = (Single)_argument; }
        public void _369() { ((TargetJoint2D)_target).name = (String)_argument; }
        public void _36A() { ((TrailRenderer)_target).Clear(); }
        public void _36B() { ((TrailRenderer)_target).HasPropertyBlock(); }
        public void _36C() { ((TrailRenderer)_target).allowOcclusionWhenDynamic = (Boolean)_argument; }
        public void _36D() { ((TrailRenderer)_target).autodestruct = (Boolean)_argument; }
        public void _36E() { ((TrailRenderer)_target).emitting = (Boolean)_argument; }
        public void _36F() { ((TrailRenderer)_target).enabled = (Boolean)_argument; }
        public void _370() { ((TrailRenderer)_target).endWidth = (Single)_argument; }
        public void _371() { ((TrailRenderer)_target).forceRenderingOff = (Boolean)_argument; }
        public void _372() { ((TrailRenderer)_target).generateLightingData = (Boolean)_argument; }
        public void _373() { ((TrailRenderer)_target).lightProbeProxyVolumeOverride = (GameObject)_argument; }
        public void _374() { ((TrailRenderer)_target).lightmapIndex = (Int32)_argument; }
        public void _375() { ((TrailRenderer)_target).material = (Material)_argument; }
        public void _376() { ((TrailRenderer)_target).minVertexDistance = (Single)_argument; }
        public void _377() { ((TrailRenderer)_target).name = (String)_argument; }
        public void _378() { ((TrailRenderer)_target).numCapVertices = (Int32)_argument; }
        public void _379() { ((TrailRenderer)_target).numCornerVertices = (Int32)_argument; }
        public void _37A() { ((TrailRenderer)_target).probeAnchor = (Transform)_argument; }
        public void _37B() { ((TrailRenderer)_target).realtimeLightmapIndex = (Int32)_argument; }
        public void _37C() { ((TrailRenderer)_target).receiveShadows = (Boolean)_argument; }
        public void _37D() { ((TrailRenderer)_target).rendererPriority = (Int32)_argument; }
        public void _37E() { ((TrailRenderer)_target).shadowBias = (Single)_argument; }
        public void _37F() { ((TrailRenderer)_target).sharedMaterial = (Material)_argument; }
        public void _380() { ((TrailRenderer)_target).sortingLayerID = (Int32)_argument; }
        public void _381() { ((TrailRenderer)_target).sortingLayerName = (String)_argument; }
        public void _382() { ((TrailRenderer)_target).sortingOrder = (Int32)_argument; }
        public void _383() { ((TrailRenderer)_target).startWidth = (Single)_argument; }
        public void _384() { ((TrailRenderer)_target).time = (Single)_argument; }
        public void _385() { ((TrailRenderer)_target).widthMultiplier = (Single)_argument; }
        public void _386() { ((Transform)_target).DetachChildren(); }
        public void _387() { ((Transform)_target).Find((String)_argument); }
        public void _388() { ((Transform)_target).LookAt((Transform)_argument); }
        public void _389() { ((Transform)_target).SetAsFirstSibling(); }
        public void _38A() { ((Transform)_target).SetAsLastSibling(); }
        public void _38B() { ((Transform)_target).SetParent((Transform)_argument); }
        public void _38C() { ((Transform)_target).SetSiblingIndex((Int32)_argument); }
        public void _38D() { ((Transform)_target).hasChanged = (Boolean)_argument; }
        public void _38E() { ((Transform)_target).hierarchyCapacity = (Int32)_argument; }
        public void _38F() { ((Transform)_target).name = (String)_argument; }
        public void _390() { ((Transform)_target).parent = (Transform)_argument; }
        public void _391() { ((AspectRatioFitter)_target).SetLayoutHorizontal(); }
        public void _392() { ((AspectRatioFitter)_target).SetLayoutVertical(); }
        public void _393() { ((AspectRatioFitter)_target).aspectRatio = (Single)_argument; }
        public void _394() { ((AspectRatioFitter)_target).enabled = (Boolean)_argument; }
        public void _395() { ((AspectRatioFitter)_target).name = (String)_argument; }
        public void _396() { ((BaseMeshEffect)_target).ModifyMesh((Mesh)_argument); }
        public void _397() { ((BaseMeshEffect)_target).enabled = (Boolean)_argument; }
        public void _398() { ((BaseMeshEffect)_target).name = (String)_argument; }
        public void _399() { ((Button)_target).FindSelectableOnDown(); }
        public void _39A() { ((Button)_target).FindSelectableOnLeft(); }
        public void _39B() { ((Button)_target).FindSelectableOnRight(); }
        public void _39C() { ((Button)_target).FindSelectableOnUp(); }
        public void _39D() { ((Button)_target).Select(); }
        public void _39E() { ((Button)_target).enabled = (Boolean)_argument; }
        public void _39F() { ((Button)_target).image = (Image)_argument; }
        public void _3A0() { ((Button)_target).interactable = (Boolean)_argument; }
        public void _3A1() { ((Button)_target).name = (String)_argument; }
        public void _3A2() { ((Button)_target).targetGraphic = (Graphic)_argument; }
        public void _3A3() { ((CanvasScaler)_target).defaultSpriteDPI = (Single)_argument; }
        public void _3A4() { ((CanvasScaler)_target).dynamicPixelsPerUnit = (Single)_argument; }
        public void _3A5() { ((CanvasScaler)_target).enabled = (Boolean)_argument; }
        public void _3A6() { ((CanvasScaler)_target).fallbackScreenDPI = (Single)_argument; }
        public void _3A7() { ((CanvasScaler)_target).matchWidthOrHeight = (Single)_argument; }
        public void _3A8() { ((CanvasScaler)_target).name = (String)_argument; }
        public void _3A9() { ((CanvasScaler)_target).referencePixelsPerUnit = (Single)_argument; }
        public void _3AA() { ((CanvasScaler)_target).scaleFactor = (Single)_argument; }
        public void _3AB() { ((ContentSizeFitter)_target).SetLayoutHorizontal(); }
        public void _3AC() { ((ContentSizeFitter)_target).SetLayoutVertical(); }
        public void _3AD() { ((ContentSizeFitter)_target).enabled = (Boolean)_argument; }
        public void _3AE() { ((ContentSizeFitter)_target).name = (String)_argument; }
        public void _3AF() { ((Dropdown)_target).ClearOptions(); }
        public void _3B0() { ((Dropdown)_target).FindSelectableOnDown(); }
        public void _3B1() { ((Dropdown)_target).FindSelectableOnLeft(); }
        public void _3B2() { ((Dropdown)_target).FindSelectableOnRight(); }
        public void _3B3() { ((Dropdown)_target).FindSelectableOnUp(); }
        public void _3B4() { ((Dropdown)_target).Hide(); }
        public void _3B5() { ((Dropdown)_target).RefreshShownValue(); }
        public void _3B6() { ((Dropdown)_target).Select(); }
        public void _3B7() { ((Dropdown)_target).SetValueWithoutNotify((Int32)_argument); }
        public void _3B8() { ((Dropdown)_target).Show(); }
        public void _3B9() { ((Dropdown)_target).alphaFadeSpeed = (Single)_argument; }
        public void _3BA() { ((Dropdown)_target).captionImage = (Image)_argument; }
        public void _3BB() { ((Dropdown)_target).captionText = (Text)_argument; }
        public void _3BC() { ((Dropdown)_target).enabled = (Boolean)_argument; }
        public void _3BD() { ((Dropdown)_target).image = (Image)_argument; }
        public void _3BE() { ((Dropdown)_target).interactable = (Boolean)_argument; }
        public void _3BF() { ((Dropdown)_target).itemImage = (Image)_argument; }
        public void _3C0() { ((Dropdown)_target).itemText = (Text)_argument; }
        public void _3C1() { ((Dropdown)_target).name = (String)_argument; }
        public void _3C2() { ((Dropdown)_target).targetGraphic = (Graphic)_argument; }
        public void _3C3() { ((Dropdown)_target).value = (Int32)_argument; }
        public void _3C4() { ((Graphic)_target).GraphicUpdateComplete(); }
        public void _3C5() { ((Graphic)_target).LayoutComplete(); }
        public void _3C6() { ((Graphic)_target).OnCullingChanged(); }
        public void _3C7() { ((Graphic)_target).SetAllDirty(); }
        public void _3C8() { ((Graphic)_target).SetLayoutDirty(); }
        public void _3C9() { ((Graphic)_target).SetMaterialDirty(); }
        public void _3CA() { ((Graphic)_target).SetNativeSize(); }
        public void _3CB() { ((Graphic)_target).SetVerticesDirty(); }
        public void _3CC() { ((Graphic)_target).enabled = (Boolean)_argument; }
        public void _3CD() { ((Graphic)_target).material = (Material)_argument; }
        public void _3CE() { ((Graphic)_target).name = (String)_argument; }
        public void _3CF() { ((Graphic)_target).raycastTarget = (Boolean)_argument; }
        public void _3D0() { ((GraphicRaycaster)_target).enabled = (Boolean)_argument; }
        public void _3D1() { ((GraphicRaycaster)_target).ignoreReversedGraphics = (Boolean)_argument; }
        public void _3D2() { ((GraphicRaycaster)_target).name = (String)_argument; }
        public void _3D3() { ((GridLayoutGroup)_target).CalculateLayoutInputHorizontal(); }
        public void _3D4() { ((GridLayoutGroup)_target).CalculateLayoutInputVertical(); }
        public void _3D5() { ((GridLayoutGroup)_target).SetLayoutHorizontal(); }
        public void _3D6() { ((GridLayoutGroup)_target).SetLayoutVertical(); }
        public void _3D7() { ((GridLayoutGroup)_target).constraintCount = (Int32)_argument; }
        public void _3D8() { ((GridLayoutGroup)_target).enabled = (Boolean)_argument; }
        public void _3D9() { ((GridLayoutGroup)_target).name = (String)_argument; }
        public void _3DA() { ((HorizontalLayoutGroup)_target).CalculateLayoutInputHorizontal(); }
        public void _3DB() { ((HorizontalLayoutGroup)_target).CalculateLayoutInputVertical(); }
        public void _3DC() { ((HorizontalLayoutGroup)_target).SetLayoutHorizontal(); }
        public void _3DD() { ((HorizontalLayoutGroup)_target).SetLayoutVertical(); }
        public void _3DE() { ((HorizontalLayoutGroup)_target).childControlHeight = (Boolean)_argument; }
        public void _3DF() { ((HorizontalLayoutGroup)_target).childControlWidth = (Boolean)_argument; }
        public void _3E0() { ((HorizontalLayoutGroup)_target).childForceExpandHeight = (Boolean)_argument; }
        public void _3E1() { ((HorizontalLayoutGroup)_target).childForceExpandWidth = (Boolean)_argument; }
        public void _3E2() { ((HorizontalLayoutGroup)_target).childScaleHeight = (Boolean)_argument; }
        public void _3E3() { ((HorizontalLayoutGroup)_target).childScaleWidth = (Boolean)_argument; }
        public void _3E4() { ((HorizontalLayoutGroup)_target).enabled = (Boolean)_argument; }
        public void _3E5() { ((HorizontalLayoutGroup)_target).name = (String)_argument; }
        public void _3E6() { ((HorizontalLayoutGroup)_target).spacing = (Single)_argument; }
        public void _3E7() { ((HorizontalOrVerticalLayoutGroup)_target).CalculateLayoutInputHorizontal(); }
        public void _3E8() { ((HorizontalOrVerticalLayoutGroup)_target).CalculateLayoutInputVertical(); }
        public void _3E9() { ((HorizontalOrVerticalLayoutGroup)_target).SetLayoutHorizontal(); }
        public void _3EA() { ((HorizontalOrVerticalLayoutGroup)_target).SetLayoutVertical(); }
        public void _3EB() { ((HorizontalOrVerticalLayoutGroup)_target).childControlHeight = (Boolean)_argument; }
        public void _3EC() { ((HorizontalOrVerticalLayoutGroup)_target).childControlWidth = (Boolean)_argument; }
        public void _3ED() { ((HorizontalOrVerticalLayoutGroup)_target).childForceExpandHeight = (Boolean)_argument; }
        public void _3EE() { ((HorizontalOrVerticalLayoutGroup)_target).childForceExpandWidth = (Boolean)_argument; }
        public void _3EF() { ((HorizontalOrVerticalLayoutGroup)_target).childScaleHeight = (Boolean)_argument; }
        public void _3F0() { ((HorizontalOrVerticalLayoutGroup)_target).childScaleWidth = (Boolean)_argument; }
        public void _3F1() { ((HorizontalOrVerticalLayoutGroup)_target).enabled = (Boolean)_argument; }
        public void _3F2() { ((HorizontalOrVerticalLayoutGroup)_target).name = (String)_argument; }
        public void _3F3() { ((HorizontalOrVerticalLayoutGroup)_target).spacing = (Single)_argument; }
        public void _3F4() { ((Image)_target).CalculateLayoutInputHorizontal(); }
        public void _3F5() { ((Image)_target).CalculateLayoutInputVertical(); }
        public void _3F6() { ((Image)_target).DisableSpriteOptimizations(); }
        public void _3F7() { ((Image)_target).GraphicUpdateComplete(); }
        public void _3F8() { ((Image)_target).LayoutComplete(); }
        public void _3F9() { ((Image)_target).OnAfterDeserialize(); }
        public void _3FA() { ((Image)_target).OnBeforeSerialize(); }
        public void _3FB() { ((Image)_target).OnCullingChanged(); }
        public void _3FC() { ((Image)_target).RecalculateClipping(); }
        public void _3FD() { ((Image)_target).RecalculateMasking(); }
        public void _3FE() { ((Image)_target).SetAllDirty(); }
        public void _3FF() { ((Image)_target).SetLayoutDirty(); }
        public void _400() { ((Image)_target).SetMaterialDirty(); }
        public void _401() { ((Image)_target).SetNativeSize(); }
        public void _402() { ((Image)_target).SetVerticesDirty(); }
        public void _403() { ((Image)_target).alphaHitTestMinimumThreshold = (Single)_argument; }
        public void _404() { ((Image)_target).enabled = (Boolean)_argument; }
        public void _405() { ((Image)_target).fillAmount = (Single)_argument; }
        public void _406() { ((Image)_target).fillCenter = (Boolean)_argument; }
        public void _407() { ((Image)_target).fillClockwise = (Boolean)_argument; }
        public void _408() { ((Image)_target).fillOrigin = (Int32)_argument; }
        public void _409() { ((Image)_target).isMaskingGraphic = (Boolean)_argument; }
        public void _40A() { ((Image)_target).maskable = (Boolean)_argument; }
        public void _40B() { ((Image)_target).material = (Material)_argument; }
        public void _40C() { ((Image)_target).name = (String)_argument; }
        public void _40D() { ((Image)_target).overrideSprite = (Sprite)_argument; }
        public void _40E() { ((Image)_target).pixelsPerUnitMultiplier = (Single)_argument; }
        public void _40F() { ((Image)_target).preserveAspect = (Boolean)_argument; }
        public void _410() { ((Image)_target).raycastTarget = (Boolean)_argument; }
        public void _411() { ((Image)_target).sprite = (Sprite)_argument; }
        public void _412() { ((Image)_target).useSpriteMesh = (Boolean)_argument; }
        public void _413() { ((InputField)_target).ActivateInputField(); }
        public void _414() { ((InputField)_target).CalculateLayoutInputHorizontal(); }
        public void _415() { ((InputField)_target).CalculateLayoutInputVertical(); }
        public void _416() { ((InputField)_target).DeactivateInputField(); }
        public void _417() { ((InputField)_target).FindSelectableOnDown(); }
        public void _418() { ((InputField)_target).FindSelectableOnLeft(); }
        public void _419() { ((InputField)_target).FindSelectableOnRight(); }
        public void _41A() { ((InputField)_target).FindSelectableOnUp(); }
        public void _41B() { ((InputField)_target).ForceLabelUpdate(); }
        public void _41C() { ((InputField)_target).GraphicUpdateComplete(); }
        public void _41D() { ((InputField)_target).LayoutComplete(); }
        public void _41E() { ((InputField)_target).MoveTextEnd((Boolean)_argument); }
        public void _41F() { ((InputField)_target).MoveTextStart((Boolean)_argument); }
        public void _420() { ((InputField)_target).Select(); }
        public void _421() { ((InputField)_target).caretBlinkRate = (Single)_argument; }
        public void _422() { ((InputField)_target).caretPosition = (Int32)_argument; }
        public void _423() { ((InputField)_target).caretWidth = (Int32)_argument; }
        public void _424() { ((InputField)_target).characterLimit = (Int32)_argument; }
        public void _425() { ((InputField)_target).customCaretColor = (Boolean)_argument; }
        public void _426() { ((InputField)_target).enabled = (Boolean)_argument; }
        public void _427() { ((InputField)_target).image = (Image)_argument; }
        public void _428() { ((InputField)_target).interactable = (Boolean)_argument; }
        public void _429() { ((InputField)_target).name = (String)_argument; }
        public void _42A() { ((InputField)_target).placeholder = (Graphic)_argument; }
        public void _42B() { ((InputField)_target).readOnly = (Boolean)_argument; }
        public void _42C() { ((InputField)_target).selectionAnchorPosition = (Int32)_argument; }
        public void _42D() { ((InputField)_target).selectionFocusPosition = (Int32)_argument; }
        public void _42E() { ((InputField)_target).shouldActivateOnSelect = (Boolean)_argument; }
        public void _42F() { ((InputField)_target).shouldHideMobileInput = (Boolean)_argument; }
        public void _430() { ((InputField)_target).targetGraphic = (Graphic)_argument; }
        public void _431() { ((InputField)_target).textComponent = (Text)_argument; }
        public void _432() { ((InputField)_target).text = (String)_argument; }
        public void _433() { ((LayoutElement)_target).CalculateLayoutInputHorizontal(); }
        public void _434() { ((LayoutElement)_target).CalculateLayoutInputVertical(); }
        public void _435() { ((LayoutElement)_target).enabled = (Boolean)_argument; }
        public void _436() { ((LayoutElement)_target).flexibleHeight = (Single)_argument; }
        public void _437() { ((LayoutElement)_target).flexibleWidth = (Single)_argument; }
        public void _438() { ((LayoutElement)_target).ignoreLayout = (Boolean)_argument; }
        public void _439() { ((LayoutElement)_target).layoutPriority = (Int32)_argument; }
        public void _43A() { ((LayoutElement)_target).minHeight = (Single)_argument; }
        public void _43B() { ((LayoutElement)_target).minWidth = (Single)_argument; }
        public void _43C() { ((LayoutElement)_target).name = (String)_argument; }
        public void _43D() { ((LayoutElement)_target).preferredHeight = (Single)_argument; }
        public void _43E() { ((LayoutElement)_target).preferredWidth = (Single)_argument; }
        public void _43F() { ((LayoutGroup)_target).CalculateLayoutInputHorizontal(); }
        public void _440() { ((LayoutGroup)_target).CalculateLayoutInputVertical(); }
        public void _441() { ((LayoutGroup)_target).SetLayoutHorizontal(); }
        public void _442() { ((LayoutGroup)_target).SetLayoutVertical(); }
        public void _443() { ((LayoutGroup)_target).enabled = (Boolean)_argument; }
        public void _444() { ((LayoutGroup)_target).name = (String)_argument; }
        public void _445() { ((MaskableGraphic)_target).GraphicUpdateComplete(); }
        public void _446() { ((MaskableGraphic)_target).LayoutComplete(); }
        public void _447() { ((MaskableGraphic)_target).OnCullingChanged(); }
        public void _448() { ((MaskableGraphic)_target).RecalculateClipping(); }
        public void _449() { ((MaskableGraphic)_target).RecalculateMasking(); }
        public void _44A() { ((MaskableGraphic)_target).SetAllDirty(); }
        public void _44B() { ((MaskableGraphic)_target).SetLayoutDirty(); }
        public void _44C() { ((MaskableGraphic)_target).SetMaterialDirty(); }
        public void _44D() { ((MaskableGraphic)_target).SetNativeSize(); }
        public void _44E() { ((MaskableGraphic)_target).SetVerticesDirty(); }
        public void _44F() { ((MaskableGraphic)_target).enabled = (Boolean)_argument; }
        public void _450() { ((MaskableGraphic)_target).isMaskingGraphic = (Boolean)_argument; }
        public void _451() { ((MaskableGraphic)_target).maskable = (Boolean)_argument; }
        public void _452() { ((MaskableGraphic)_target).material = (Material)_argument; }
        public void _453() { ((MaskableGraphic)_target).name = (String)_argument; }
        public void _454() { ((MaskableGraphic)_target).raycastTarget = (Boolean)_argument; }
        public void _455() { ((Mask)_target).MaskEnabled(); }
        public void _456() { ((Mask)_target).enabled = (Boolean)_argument; }
        public void _457() { ((Mask)_target).name = (String)_argument; }
        public void _458() { ((Mask)_target).showMaskGraphic = (Boolean)_argument; }
        public void _459() { ((Outline)_target).ModifyMesh((Mesh)_argument); }
        public void _45A() { ((Outline)_target).enabled = (Boolean)_argument; }
        public void _45B() { ((Outline)_target).name = (String)_argument; }
        public void _45C() { ((Outline)_target).useGraphicAlpha = (Boolean)_argument; }
        public void _45D() { ((PositionAsUV1)_target).ModifyMesh((Mesh)_argument); }
        public void _45E() { ((PositionAsUV1)_target).enabled = (Boolean)_argument; }
        public void _45F() { ((PositionAsUV1)_target).name = (String)_argument; }
        public void _460() { ((RawImage)_target).GraphicUpdateComplete(); }
        public void _461() { ((RawImage)_target).LayoutComplete(); }
        public void _462() { ((RawImage)_target).OnCullingChanged(); }
        public void _463() { ((RawImage)_target).RecalculateClipping(); }
        public void _464() { ((RawImage)_target).RecalculateMasking(); }
        public void _465() { ((RawImage)_target).SetAllDirty(); }
        public void _466() { ((RawImage)_target).SetLayoutDirty(); }
        public void _467() { ((RawImage)_target).SetMaterialDirty(); }
        public void _468() { ((RawImage)_target).SetNativeSize(); }
        public void _469() { ((RawImage)_target).SetVerticesDirty(); }
        public void _46A() { ((RawImage)_target).enabled = (Boolean)_argument; }
        public void _46B() { ((RawImage)_target).isMaskingGraphic = (Boolean)_argument; }
        public void _46C() { ((RawImage)_target).maskable = (Boolean)_argument; }
        public void _46D() { ((RawImage)_target).material = (Material)_argument; }
        public void _46E() { ((RawImage)_target).name = (String)_argument; }
        public void _46F() { ((RawImage)_target).raycastTarget = (Boolean)_argument; }
        public void _470() { ((RawImage)_target).texture = (Texture)_argument; }
        public void _471() { ((RectMask2D)_target).PerformClipping(); }
        public void _472() { ((RectMask2D)_target).UpdateClipSoftness(); }
        public void _473() { ((RectMask2D)_target).enabled = (Boolean)_argument; }
        public void _474() { ((RectMask2D)_target).name = (String)_argument; }
        public void _475() { ((Scrollbar)_target).FindSelectableOnDown(); }
        public void _476() { ((Scrollbar)_target).FindSelectableOnLeft(); }
        public void _477() { ((Scrollbar)_target).FindSelectableOnRight(); }
        public void _478() { ((Scrollbar)_target).FindSelectableOnUp(); }
        public void _479() { ((Scrollbar)_target).GraphicUpdateComplete(); }
        public void _47A() { ((Scrollbar)_target).LayoutComplete(); }
        public void _47B() { ((Scrollbar)_target).Select(); }
        public void _47C() { ((Scrollbar)_target).SetValueWithoutNotify((Single)_argument); }
        public void _47D() { ((Scrollbar)_target).enabled = (Boolean)_argument; }
        public void _47E() { ((Scrollbar)_target).handleRect = (RectTransform)_argument; }
        public void _47F() { ((Scrollbar)_target).image = (Image)_argument; }
        public void _480() { ((Scrollbar)_target).interactable = (Boolean)_argument; }
        public void _481() { ((Scrollbar)_target).name = (String)_argument; }
        public void _482() { ((Scrollbar)_target).numberOfSteps = (Int32)_argument; }
        public void _483() { ((Scrollbar)_target).size = (Single)_argument; }
        public void _484() { ((Scrollbar)_target).targetGraphic = (Graphic)_argument; }
        public void _485() { ((Scrollbar)_target).value = (Single)_argument; }
        public void _486() { ((ScrollRect)_target).CalculateLayoutInputHorizontal(); }
        public void _487() { ((ScrollRect)_target).CalculateLayoutInputVertical(); }
        public void _488() { ((ScrollRect)_target).GraphicUpdateComplete(); }
        public void _489() { ((ScrollRect)_target).LayoutComplete(); }
        public void _48A() { ((ScrollRect)_target).SetLayoutHorizontal(); }
        public void _48B() { ((ScrollRect)_target).SetLayoutVertical(); }
        public void _48C() { ((ScrollRect)_target).StopMovement(); }
        public void _48D() { ((ScrollRect)_target).content = (RectTransform)_argument; }
        public void _48E() { ((ScrollRect)_target).decelerationRate = (Single)_argument; }
        public void _48F() { ((ScrollRect)_target).elasticity = (Single)_argument; }
        public void _490() { ((ScrollRect)_target).enabled = (Boolean)_argument; }
        public void _491() { ((ScrollRect)_target).horizontalNormalizedPosition = (Single)_argument; }
        public void _492() { ((ScrollRect)_target).horizontalScrollbarSpacing = (Single)_argument; }
        public void _493() { ((ScrollRect)_target).horizontalScrollbar = (Scrollbar)_argument; }
        public void _494() { ((ScrollRect)_target).horizontal = (Boolean)_argument; }
        public void _495() { ((ScrollRect)_target).inertia = (Boolean)_argument; }
        public void _496() { ((ScrollRect)_target).name = (String)_argument; }
        public void _497() { ((ScrollRect)_target).scrollSensitivity = (Single)_argument; }
        public void _498() { ((ScrollRect)_target).verticalNormalizedPosition = (Single)_argument; }
        public void _499() { ((ScrollRect)_target).verticalScrollbarSpacing = (Single)_argument; }
        public void _49A() { ((ScrollRect)_target).verticalScrollbar = (Scrollbar)_argument; }
        public void _49B() { ((ScrollRect)_target).vertical = (Boolean)_argument; }
        public void _49C() { ((ScrollRect)_target).viewport = (RectTransform)_argument; }
        public void _49D() { ((Selectable)_target).FindSelectableOnDown(); }
        public void _49E() { ((Selectable)_target).FindSelectableOnLeft(); }
        public void _49F() { ((Selectable)_target).FindSelectableOnRight(); }
        public void _4A0() { ((Selectable)_target).FindSelectableOnUp(); }
        public void _4A1() { ((Selectable)_target).Select(); }
        public void _4A2() { ((Selectable)_target).enabled = (Boolean)_argument; }
        public void _4A3() { ((Selectable)_target).image = (Image)_argument; }
        public void _4A4() { ((Selectable)_target).interactable = (Boolean)_argument; }
        public void _4A5() { ((Selectable)_target).name = (String)_argument; }
        public void _4A6() { ((Selectable)_target).targetGraphic = (Graphic)_argument; }
        public void _4A7() { ((Shadow)_target).ModifyMesh((Mesh)_argument); }
        public void _4A8() { ((Shadow)_target).enabled = (Boolean)_argument; }
        public void _4A9() { ((Shadow)_target).name = (String)_argument; }
        public void _4AA() { ((Shadow)_target).useGraphicAlpha = (Boolean)_argument; }
        public void _4AB() { ((Slider)_target).FindSelectableOnDown(); }
        public void _4AC() { ((Slider)_target).FindSelectableOnLeft(); }
        public void _4AD() { ((Slider)_target).FindSelectableOnRight(); }
        public void _4AE() { ((Slider)_target).FindSelectableOnUp(); }
        public void _4AF() { ((Slider)_target).GraphicUpdateComplete(); }
        public void _4B0() { ((Slider)_target).LayoutComplete(); }
        public void _4B1() { ((Slider)_target).Select(); }
        public void _4B2() { ((Slider)_target).SetValueWithoutNotify((Single)_argument); }
        public void _4B3() { ((Slider)_target).enabled = (Boolean)_argument; }
        public void _4B4() { ((Slider)_target).fillRect = (RectTransform)_argument; }
        public void _4B5() { ((Slider)_target).handleRect = (RectTransform)_argument; }
        public void _4B6() { ((Slider)_target).image = (Image)_argument; }
        public void _4B7() { ((Slider)_target).interactable = (Boolean)_argument; }
        public void _4B8() { ((Slider)_target).maxValue = (Single)_argument; }
        public void _4B9() { ((Slider)_target).minValue = (Single)_argument; }
        public void _4BA() { ((Slider)_target).name = (String)_argument; }
        public void _4BB() { ((Slider)_target).normalizedValue = (Single)_argument; }
        public void _4BC() { ((Slider)_target).targetGraphic = (Graphic)_argument; }
        public void _4BD() { ((Slider)_target).value = (Single)_argument; }
        public void _4BE() { ((Slider)_target).wholeNumbers = (Boolean)_argument; }
        public void _4BF() { ((Text)_target).CalculateLayoutInputHorizontal(); }
        public void _4C0() { ((Text)_target).CalculateLayoutInputVertical(); }
        public void _4C1() { ((Text)_target).FontTextureChanged(); }
        public void _4C2() { ((Text)_target).GraphicUpdateComplete(); }
        public void _4C3() { ((Text)_target).LayoutComplete(); }
        public void _4C4() { ((Text)_target).OnCullingChanged(); }
        public void _4C5() { ((Text)_target).RecalculateClipping(); }
        public void _4C6() { ((Text)_target).RecalculateMasking(); }
        public void _4C7() { ((Text)_target).SetAllDirty(); }
        public void _4C8() { ((Text)_target).SetLayoutDirty(); }
        public void _4C9() { ((Text)_target).SetMaterialDirty(); }
        public void _4CA() { ((Text)_target).SetNativeSize(); }
        public void _4CB() { ((Text)_target).SetVerticesDirty(); }
        public void _4CC() { ((Text)_target).alignByGeometry = (Boolean)_argument; }
        public void _4CD() { ((Text)_target).enabled = (Boolean)_argument; }
        public void _4CE() { ((Text)_target).fontSize = (Int32)_argument; }
        public void _4CF() { ((Text)_target).font = (Font)_argument; }
        public void _4D0() { ((Text)_target).isMaskingGraphic = (Boolean)_argument; }
        public void _4D1() { ((Text)_target).lineSpacing = (Single)_argument; }
        public void _4D2() { ((Text)_target).maskable = (Boolean)_argument; }
        public void _4D3() { ((Text)_target).material = (Material)_argument; }
        public void _4D4() { ((Text)_target).name = (String)_argument; }
        public void _4D5() { ((Text)_target).raycastTarget = (Boolean)_argument; }
        public void _4D6() { ((Text)_target).resizeTextForBestFit = (Boolean)_argument; }
        public void _4D7() { ((Text)_target).resizeTextMaxSize = (Int32)_argument; }
        public void _4D8() { ((Text)_target).resizeTextMinSize = (Int32)_argument; }
        public void _4D9() { ((Text)_target).supportRichText = (Boolean)_argument; }
        public void _4DA() { ((Text)_target).text = (String)_argument; }
        public void _4DB() { ((ToggleGroup)_target).ActiveToggles(); }
        public void _4DC() { ((ToggleGroup)_target).AnyTogglesOn(); }
        public void _4DD() { ((ToggleGroup)_target).EnsureValidState(); }
        public void _4DE() { ((ToggleGroup)_target).RegisterToggle((Toggle)_argument); }
        public void _4DF() { ((ToggleGroup)_target).SetAllTogglesOff((Boolean)_argument); }
        public void _4E0() { ((ToggleGroup)_target).UnregisterToggle((Toggle)_argument); }
        public void _4E1() { ((ToggleGroup)_target).allowSwitchOff = (Boolean)_argument; }
        public void _4E2() { ((ToggleGroup)_target).enabled = (Boolean)_argument; }
        public void _4E3() { ((ToggleGroup)_target).name = (String)_argument; }
        public void _4E4() { ((Toggle)_target).FindSelectableOnDown(); }
        public void _4E5() { ((Toggle)_target).FindSelectableOnLeft(); }
        public void _4E6() { ((Toggle)_target).FindSelectableOnRight(); }
        public void _4E7() { ((Toggle)_target).FindSelectableOnUp(); }
        public void _4E8() { ((Toggle)_target).GraphicUpdateComplete(); }
        public void _4E9() { ((Toggle)_target).LayoutComplete(); }
        public void _4EA() { ((Toggle)_target).Select(); }
        public void _4EB() { ((Toggle)_target).SetIsOnWithoutNotify((Boolean)_argument); }
        public void _4EC() { ((Toggle)_target).enabled = (Boolean)_argument; }
        public void _4ED() { ((Toggle)_target).graphic = (Graphic)_argument; }
        public void _4EE() { ((Toggle)_target).group = (ToggleGroup)_argument; }
        public void _4EF() { ((Toggle)_target).image = (Image)_argument; }
        public void _4F0() { ((Toggle)_target).interactable = (Boolean)_argument; }
        public void _4F1() { ((Toggle)_target).isOn = (Boolean)_argument; }
        public void _4F2() { ((Toggle)_target).name = (String)_argument; }
        public void _4F3() { ((Toggle)_target).targetGraphic = (Graphic)_argument; }
        public void _4F4() { ((VerticalLayoutGroup)_target).CalculateLayoutInputHorizontal(); }
        public void _4F5() { ((VerticalLayoutGroup)_target).CalculateLayoutInputVertical(); }
        public void _4F6() { ((VerticalLayoutGroup)_target).SetLayoutHorizontal(); }
        public void _4F7() { ((VerticalLayoutGroup)_target).SetLayoutVertical(); }
        public void _4F8() { ((VerticalLayoutGroup)_target).childControlHeight = (Boolean)_argument; }
        public void _4F9() { ((VerticalLayoutGroup)_target).childControlWidth = (Boolean)_argument; }
        public void _4FA() { ((VerticalLayoutGroup)_target).childForceExpandHeight = (Boolean)_argument; }
        public void _4FB() { ((VerticalLayoutGroup)_target).childForceExpandWidth = (Boolean)_argument; }
        public void _4FC() { ((VerticalLayoutGroup)_target).childScaleHeight = (Boolean)_argument; }
        public void _4FD() { ((VerticalLayoutGroup)_target).childScaleWidth = (Boolean)_argument; }
        public void _4FE() { ((VerticalLayoutGroup)_target).enabled = (Boolean)_argument; }
        public void _4FF() { ((VerticalLayoutGroup)_target).name = (String)_argument; }
        public void _500() { ((VerticalLayoutGroup)_target).spacing = (Single)_argument; }
        public void _501() { ((WheelCollider)_target).ResetSprungMasses(); }
        public void _502() { ((WheelCollider)_target).brakeTorque = (Single)_argument; }
        public void _503() { ((WheelCollider)_target).contactOffset = (Single)_argument; }
        public void _504() { ((WheelCollider)_target).enabled = (Boolean)_argument; }
        public void _505() { ((WheelCollider)_target).forceAppPointDistance = (Single)_argument; }
        public void _506() { ((WheelCollider)_target).isTrigger = (Boolean)_argument; }
        public void _507() { ((WheelCollider)_target).mass = (Single)_argument; }
        public void _508() { ((WheelCollider)_target).material = (PhysicMaterial)_argument; }
        public void _509() { ((WheelCollider)_target).motorTorque = (Single)_argument; }
        public void _50A() { ((WheelCollider)_target).name = (String)_argument; }
        public void _50B() { ((WheelCollider)_target).radius = (Single)_argument; }
        public void _50C() { ((WheelCollider)_target).sharedMaterial = (PhysicMaterial)_argument; }
        public void _50D() { ((WheelCollider)_target).sprungMass = (Single)_argument; }
        public void _50E() { ((WheelCollider)_target).steerAngle = (Single)_argument; }
        public void _50F() { ((WheelCollider)_target).suspensionDistance = (Single)_argument; }
        public void _510() { ((WheelCollider)_target).wheelDampingRate = (Single)_argument; }
        public void _511() { ((WheelJoint2D)_target).autoConfigureConnectedAnchor = (Boolean)_argument; }
        public void _512() { ((WheelJoint2D)_target).breakForce = (Single)_argument; }
        public void _513() { ((WheelJoint2D)_target).breakTorque = (Single)_argument; }
        public void _514() { ((WheelJoint2D)_target).connectedBody = (Rigidbody2D)_argument; }
        public void _515() { ((WheelJoint2D)_target).enableCollision = (Boolean)_argument; }
        public void _516() { ((WheelJoint2D)_target).enabled = (Boolean)_argument; }
        public void _517() { ((WheelJoint2D)_target).name = (String)_argument; }
        public void _518() { ((WheelJoint2D)_target).useMotor = (Boolean)_argument; }
        public void _519() { ((VRCAvatarPedestal)_target).SwitchAvatar((String)_argument); }
        public void _51A() { ((VRCAvatarPedestal)_target).ChangeAvatarsOnUse = (Boolean)_argument; }
        public void _51B() { ((VRCAvatarPedestal)_target).Placement = (Transform)_argument; }
        public void _51C() { ((VRCAvatarPedestal)_target).blueprintId = (String)_argument; }
        public void _51D() { ((VRCAvatarPedestal)_target).enabled = (Boolean)_argument; }
        public void _51E() { ((VRCAvatarPedestal)_target).name = (String)_argument; }
        public void _51F() { ((VRCAvatarPedestal)_target).scale = (Single)_argument; }
        public void _520() { ((VRCMirrorReflection)_target).OnWillRenderObject(); }
        public void _521() { ((VRCMirrorReflection)_target).TurnOffMirrorOcclusion = (Boolean)_argument; }
        public void _522() { ((VRCMirrorReflection)_target).customSkybox = (Material)_argument; }
        public void _523() { ((VRCMirrorReflection)_target).enabled = (Boolean)_argument; }
        public void _524() { ((VRCMirrorReflection)_target).m_DisablePixelLights = (Boolean)_argument; }
        public void _525() { ((VRCMirrorReflection)_target).name = (String)_argument; }
        public void _526() { ((VRCObjectPool)_target).Return((GameObject)_argument); }
        public void _527() { ((VRCObjectPool)_target).Shuffle(); }
        public void _528() { ((VRCObjectPool)_target).TryToSpawn(); }
        public void _529() { ((VRCObjectPool)_target).enabled = (Boolean)_argument; }
        public void _52A() { ((VRCObjectPool)_target).name = (String)_argument; }
        public void _52B() { ((VRCObjectSync)_target).FlagDiscontinuity(); }
        public void _52C() { ((VRCObjectSync)_target).Respawn(); }
        public void _52D() { ((VRCObjectSync)_target).SetGravity((Boolean)_argument); }
        public void _52E() { ((VRCObjectSync)_target).SetKinematic((Boolean)_argument); }
        public void _52F() { ((VRCObjectSync)_target).TeleportTo((Transform)_argument); }
        public void _530() { ((VRCObjectSync)_target).AllowCollisionOwnershipTransfer = (Boolean)_argument; }
        public void _531() { ((VRCObjectSync)_target).enabled = (Boolean)_argument; }
        public void _532() { ((VRCObjectSync)_target).name = (String)_argument; }
        public void _533() { ((VRCPickup)_target).Drop(); }
        public void _534() { ((VRCPickup)_target).PlayHaptics(); }
        public void _535() { ((VRCPickup)_target).DisallowTheft = (Boolean)_argument; }
        public void _536() { ((VRCPickup)_target).ExactGrip = (Transform)_argument; }
        public void _537() { ((VRCPickup)_target).ExactGun = (Transform)_argument; }
        public void _538() { ((VRCPickup)_target).InteractionText = (String)_argument; }
        public void _539() { ((VRCPickup)_target).ThrowVelocityBoostMinSpeed = (Single)_argument; }
        public void _53A() { ((VRCPickup)_target).ThrowVelocityBoostScale = (Single)_argument; }
        public void _53B() { ((VRCPickup)_target).UseText = (String)_argument; }
        public void _53C() { ((VRCPickup)_target).allowManipulationWhenEquipped = (Boolean)_argument; }
        public void _53D() { ((VRCPickup)_target).enabled = (Boolean)_argument; }
        public void _53E() { ((VRCPickup)_target).name = (String)_argument; }
        public void _53F() { ((VRCPickup)_target).pickupable = (Boolean)_argument; }
        public void _540() { ((VRCPickup)_target).proximity = (Single)_argument; }
        public void _541() { ((VRCPortalMarker)_target).RefreshPortal(); }
        public void _542() { ((VRCPortalMarker)_target).enabled = (Boolean)_argument; }
        public void _543() { ((VRCPortalMarker)_target).name = (String)_argument; }
        public void _544() { ((VRCPortalMarker)_target).roomId = (String)_argument; }
        public void _545() { ((VRCStation)_target).animatorController = (RuntimeAnimatorController)_argument; }
        public void _546() { ((VRCStation)_target).canUseStationFromStation = (Boolean)_argument; }
        public void _547() { ((VRCStation)_target).disableStationExit = (Boolean)_argument; }
        public void _548() { ((VRCStation)_target).enabled = (Boolean)_argument; }
        public void _549() { ((VRCStation)_target).name = (String)_argument; }
        public void _54A() { ((VRCStation)_target).stationEnterPlayerLocation = (Transform)_argument; }
        public void _54B() { ((VRCStation)_target).stationExitPlayerLocation = (Transform)_argument; }
        public void _54C() { ((VRCUrlInputField)_target).ActivateInputField(); }
        public void _54D() { ((VRCUrlInputField)_target).CalculateLayoutInputHorizontal(); }
        public void _54E() { ((VRCUrlInputField)_target).CalculateLayoutInputVertical(); }
        public void _54F() { ((VRCUrlInputField)_target).DeactivateInputField(); }
        public void _550() { ((VRCUrlInputField)_target).FindSelectableOnDown(); }
        public void _551() { ((VRCUrlInputField)_target).FindSelectableOnLeft(); }
        public void _552() { ((VRCUrlInputField)_target).FindSelectableOnRight(); }
        public void _553() { ((VRCUrlInputField)_target).FindSelectableOnUp(); }
        public void _554() { ((VRCUrlInputField)_target).ForceLabelUpdate(); }
        public void _555() { ((VRCUrlInputField)_target).GraphicUpdateComplete(); }
        public void _556() { ((VRCUrlInputField)_target).LayoutComplete(); }
        public void _557() { ((VRCUrlInputField)_target).Select(); }
        public void _558() { ((VRCUrlInputField)_target).caretBlinkRate = (Single)_argument; }
        public void _559() { ((VRCUrlInputField)_target).caretWidth = (Int32)_argument; }
        public void _55A() { ((VRCUrlInputField)_target).characterLimit = (Int32)_argument; }
        public void _55B() { ((VRCUrlInputField)_target).customCaretColor = (Boolean)_argument; }
        public void _55C() { ((VRCUrlInputField)_target).enabled = (Boolean)_argument; }
        public void _55D() { ((VRCUrlInputField)_target).image = (Image)_argument; }
        public void _55E() { ((VRCUrlInputField)_target).interactable = (Boolean)_argument; }
        public void _55F() { ((VRCUrlInputField)_target).name = (String)_argument; }
        public void _560() { ((VRCUrlInputField)_target).placeholder = (Graphic)_argument; }
        public void _561() { ((VRCUrlInputField)_target).readOnly = (Boolean)_argument; }
        public void _562() { ((VRCUrlInputField)_target).shouldHideMobileInput = (Boolean)_argument; }
        public void _563() { ((VRCUrlInputField)_target).targetGraphic = (Graphic)_argument; }
        public void _564() { ((VRCUrlInputField)_target).textComponent = (Text)_argument; }
        public void _565() { ((VRCMidiPlayer)_target).Play(); }
        public void _566() { ((VRCMidiPlayer)_target).Stop(); }
        public void _567() { ((VRCMidiPlayer)_target).Time = (Single)_argument; }
        public void _568() { ((BaseVRCVideoPlayer)_target).Pause(); }
        public void _569() { ((BaseVRCVideoPlayer)_target).Play(); }
        public void _56A() { ((BaseVRCVideoPlayer)_target).SetTime((Single)_argument); }
        public void _56B() { ((BaseVRCVideoPlayer)_target).Stop(); }
        public void _56C() { ((BaseVRCVideoPlayer)_target).EnableAutomaticResync = (Boolean)_argument; }
        public void _56D() { ((BaseVRCVideoPlayer)_target).Loop = (Boolean)_argument; }
        public void _56E() { ((BaseVRCVideoPlayer)_target).enabled = (Boolean)_argument; }
        public void _56F() { ((BaseVRCVideoPlayer)_target).name = (String)_argument; }
        public void _570() { if (_argument.GetType().Equals(typeof(System.Int32))) { ((VRCCustomAction)_target).Execute((Int32)_argument); } else { ((VRCCustomAction)_target).Execute((String)_argument); } }
        public void _571() { ((VRCCustomAction)_target).enabled = (Boolean)_argument; }
        public void _572() { ((VRCCustomAction)_target).name = (String)_argument; }

    }
}
