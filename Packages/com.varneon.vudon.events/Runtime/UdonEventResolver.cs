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
using VRC.SDK3.Midi;
using VRC.SDK3.Video.Components.Base;
using VRC.SDKBase;
using VRC.Udon;
using VRCStation = VRC.SDK3.Components.VRCStation;

namespace Varneon.VUdon.UdonEvents
{
    public partial class UdonEventHandler : UdonSharpBehaviour
    {
        public void VRC_Udon_UdonBehaviour__RequestSerialization() { ((UdonBehaviour)_target).RequestSerialization(); }
        public void VRC_Udon_UdonBehaviour__SendCustomEvent() { ((UdonBehaviour)_target).SendCustomEvent((String)_argument); }
        public void VRC_Udon_UdonBehaviour__set_DisableInteractive() { ((UdonBehaviour)_target).DisableInteractive = (Boolean)_argument; }
        public void VRC_Udon_UdonBehaviour__set_InteractionText() { ((UdonBehaviour)_target).InteractionText = (String)_argument; }
        public void VRC_Udon_UdonBehaviour__set_enabled() { ((UdonBehaviour)_target).enabled = (Boolean)_argument; }
        public void Cinemachine_CinemachineDollyCart__set_enabled() { ((CinemachineDollyCart)_target).enabled = (Boolean)_argument; }
        public void Cinemachine_CinemachineDollyCart__set_m_Path() { ((CinemachineDollyCart)_target).m_Path = (CinemachinePathBase)_argument; }
        public void Cinemachine_CinemachineDollyCart__set_m_Position() { ((CinemachineDollyCart)_target).m_Position = (Single)_argument; }
        public void Cinemachine_CinemachineDollyCart__set_m_Speed() { ((CinemachineDollyCart)_target).m_Speed = (Single)_argument; }
        public void Cinemachine_CinemachineDollyCart__set_name() { ((CinemachineDollyCart)_target).name = (String)_argument; }
        public void Cinemachine_CinemachinePathBase__DistanceCacheIsValid() { ((CinemachinePathBase)_target).DistanceCacheIsValid(); }
        public void Cinemachine_CinemachinePathBase__EvaluateOrientation() { ((CinemachinePathBase)_target).EvaluateOrientation((Single)_argument); }
        public void Cinemachine_CinemachinePathBase__EvaluatePosition() { ((CinemachinePathBase)_target).EvaluatePosition((Single)_argument); }
        public void Cinemachine_CinemachinePathBase__EvaluateTangent() { ((CinemachinePathBase)_target).EvaluateTangent((Single)_argument); }
        public void Cinemachine_CinemachinePathBase__InvalidateDistanceCache() { ((CinemachinePathBase)_target).InvalidateDistanceCache(); }
        public void Cinemachine_CinemachinePathBase__StandardizePathDistance() { ((CinemachinePathBase)_target).StandardizePathDistance((Single)_argument); }
        public void Cinemachine_CinemachinePathBase__StandardizePos() { ((CinemachinePathBase)_target).StandardizePos((Single)_argument); }
        public void Cinemachine_CinemachinePathBase__set_enabled() { ((CinemachinePathBase)_target).enabled = (Boolean)_argument; }
        public void Cinemachine_CinemachinePathBase__set_name() { ((CinemachinePathBase)_target).name = (String)_argument; }
        public void Cinemachine_CinemachineVirtualCamera__MoveToTopOfPrioritySubqueue() { ((CinemachineVirtualCamera)_target).MoveToTopOfPrioritySubqueue(); }
        public void Cinemachine_CinemachineVirtualCamera__ResolveFollow() { ((CinemachineVirtualCamera)_target).ResolveFollow((Transform)_argument); }
        public void Cinemachine_CinemachineVirtualCamera__ResolveLookAt() { ((CinemachineVirtualCamera)_target).ResolveLookAt((Transform)_argument); }
        public void Cinemachine_CinemachineVirtualCamera__set_Follow() { ((CinemachineVirtualCamera)_target).Follow = (Transform)_argument; }
        public void Cinemachine_CinemachineVirtualCamera__set_LookAt() { ((CinemachineVirtualCamera)_target).LookAt = (Transform)_argument; }
        public void Cinemachine_CinemachineVirtualCamera__set_Priority() { ((CinemachineVirtualCamera)_target).Priority = (Int32)_argument; }
        public void Cinemachine_CinemachineVirtualCamera__set_enabled() { ((CinemachineVirtualCamera)_target).enabled = (Boolean)_argument; }
        public void Cinemachine_CinemachineVirtualCamera__set_name() { ((CinemachineVirtualCamera)_target).name = (String)_argument; }
        public void TMPro_TextMeshPro__set_enabled() { ((TextMeshPro)_target).enabled = (Boolean)_argument; }
        public void TMPro_TextMeshPro__set_isMaskingGraphic() { ((TextMeshPro)_target).isMaskingGraphic = (Boolean)_argument; }
        public void TMPro_TextMeshPro__set_isTextObjectScaleStatic() { ((TextMeshPro)_target).isTextObjectScaleStatic = (Boolean)_argument; }
        public void TMPro_TextMeshPro__set_material() { ((TextMeshPro)_target).material = (Material)_argument; }
        public void TMPro_TextMeshPro__set_maxVisibleCharacters() { ((TextMeshPro)_target).maxVisibleCharacters = (Int32)_argument; }
        public void TMPro_TextMeshPro__set_name() { ((TextMeshPro)_target).name = (String)_argument; }
        public void TMPro_TextMeshPro__set_outlineWidth() { ((TextMeshPro)_target).outlineWidth = (Single)_argument; }
        public void TMPro_TextMeshPro__set_text() { ((TextMeshPro)_target).text = (String)_argument; }
        public void TMPro_TextMeshProUGUI__set_enabled() { ((TextMeshProUGUI)_target).enabled = (Boolean)_argument; }
        public void TMPro_TextMeshProUGUI__set_isMaskingGraphic() { ((TextMeshProUGUI)_target).isMaskingGraphic = (Boolean)_argument; }
        public void TMPro_TextMeshProUGUI__set_isTextObjectScaleStatic() { ((TextMeshProUGUI)_target).isTextObjectScaleStatic = (Boolean)_argument; }
        public void TMPro_TextMeshProUGUI__set_material() { ((TextMeshProUGUI)_target).material = (Material)_argument; }
        public void TMPro_TextMeshProUGUI__set_maxVisibleCharacters() { ((TextMeshProUGUI)_target).maxVisibleCharacters = (Int32)_argument; }
        public void TMPro_TextMeshProUGUI__set_name() { ((TextMeshProUGUI)_target).name = (String)_argument; }
        public void TMPro_TextMeshProUGUI__set_outlineWidth() { ((TextMeshProUGUI)_target).outlineWidth = (Single)_argument; }
        public void TMPro_TextMeshProUGUI__set_text() { ((TextMeshProUGUI)_target).text = (String)_argument; }
        public void UnityEngine_AI_NavMeshAgent__ActivateCurrentOffMeshLink() { ((NavMeshAgent)_target).ActivateCurrentOffMeshLink((Boolean)_argument); }
        public void UnityEngine_AI_NavMeshAgent__CompleteOffMeshLink() { ((NavMeshAgent)_target).CompleteOffMeshLink(); }
        public void UnityEngine_AI_NavMeshAgent__ResetPath() { ((NavMeshAgent)_target).ResetPath(); }
        public void UnityEngine_AI_NavMeshAgent__set_acceleration() { ((NavMeshAgent)_target).acceleration = (Single)_argument; }
        public void UnityEngine_AI_NavMeshAgent__set_agentTypeID() { ((NavMeshAgent)_target).agentTypeID = (Int32)_argument; }
        public void UnityEngine_AI_NavMeshAgent__set_angularSpeed() { ((NavMeshAgent)_target).angularSpeed = (Single)_argument; }
        public void UnityEngine_AI_NavMeshAgent__set_areaMask() { ((NavMeshAgent)_target).areaMask = (Int32)_argument; }
        public void UnityEngine_AI_NavMeshAgent__set_autoBraking() { ((NavMeshAgent)_target).autoBraking = (Boolean)_argument; }
        public void UnityEngine_AI_NavMeshAgent__set_autoRepath() { ((NavMeshAgent)_target).autoRepath = (Boolean)_argument; }
        public void UnityEngine_AI_NavMeshAgent__set_autoTraverseOffMeshLink() { ((NavMeshAgent)_target).autoTraverseOffMeshLink = (Boolean)_argument; }
        public void UnityEngine_AI_NavMeshAgent__set_avoidancePriority() { ((NavMeshAgent)_target).avoidancePriority = (Int32)_argument; }
        public void UnityEngine_AI_NavMeshAgent__set_baseOffset() { ((NavMeshAgent)_target).baseOffset = (Single)_argument; }
        public void UnityEngine_AI_NavMeshAgent__set_enabled() { ((NavMeshAgent)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_AI_NavMeshAgent__set_height() { ((NavMeshAgent)_target).height = (Single)_argument; }
        public void UnityEngine_AI_NavMeshAgent__set_isStopped() { ((NavMeshAgent)_target).isStopped = (Boolean)_argument; }
        public void UnityEngine_AI_NavMeshAgent__set_name() { ((NavMeshAgent)_target).name = (String)_argument; }
        public void UnityEngine_AI_NavMeshAgent__set_radius() { ((NavMeshAgent)_target).radius = (Single)_argument; }
        public void UnityEngine_AI_NavMeshAgent__set_speed() { ((NavMeshAgent)_target).speed = (Single)_argument; }
        public void UnityEngine_AI_NavMeshAgent__set_stoppingDistance() { ((NavMeshAgent)_target).stoppingDistance = (Single)_argument; }
        public void UnityEngine_AI_NavMeshAgent__set_updatePosition() { ((NavMeshAgent)_target).updatePosition = (Boolean)_argument; }
        public void UnityEngine_AI_NavMeshAgent__set_updateRotation() { ((NavMeshAgent)_target).updateRotation = (Boolean)_argument; }
        public void UnityEngine_AI_NavMeshAgent__set_updateUpAxis() { ((NavMeshAgent)_target).updateUpAxis = (Boolean)_argument; }
        public void UnityEngine_AI_NavMeshObstacle__set_carveOnlyStationary() { ((NavMeshObstacle)_target).carveOnlyStationary = (Boolean)_argument; }
        public void UnityEngine_AI_NavMeshObstacle__set_carvingMoveThreshold() { ((NavMeshObstacle)_target).carvingMoveThreshold = (Single)_argument; }
        public void UnityEngine_AI_NavMeshObstacle__set_carvingTimeToStationary() { ((NavMeshObstacle)_target).carvingTimeToStationary = (Single)_argument; }
        public void UnityEngine_AI_NavMeshObstacle__set_carving() { ((NavMeshObstacle)_target).carving = (Boolean)_argument; }
        public void UnityEngine_AI_NavMeshObstacle__set_enabled() { ((NavMeshObstacle)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_AI_NavMeshObstacle__set_height() { ((NavMeshObstacle)_target).height = (Single)_argument; }
        public void UnityEngine_AI_NavMeshObstacle__set_name() { ((NavMeshObstacle)_target).name = (String)_argument; }
        public void UnityEngine_AI_NavMeshObstacle__set_radius() { ((NavMeshObstacle)_target).radius = (Single)_argument; }
        public void UnityEngine_AI_OffMeshLink__UpdatePositions() { ((OffMeshLink)_target).UpdatePositions(); }
        public void UnityEngine_AI_OffMeshLink__set_activated() { ((OffMeshLink)_target).activated = (Boolean)_argument; }
        public void UnityEngine_AI_OffMeshLink__set_area() { ((OffMeshLink)_target).area = (Int32)_argument; }
        public void UnityEngine_AI_OffMeshLink__set_autoUpdatePositions() { ((OffMeshLink)_target).autoUpdatePositions = (Boolean)_argument; }
        public void UnityEngine_AI_OffMeshLink__set_biDirectional() { ((OffMeshLink)_target).biDirectional = (Boolean)_argument; }
        public void UnityEngine_AI_OffMeshLink__set_costOverride() { ((OffMeshLink)_target).costOverride = (Single)_argument; }
        public void UnityEngine_AI_OffMeshLink__set_enabled() { ((OffMeshLink)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_AI_OffMeshLink__set_endTransform() { ((OffMeshLink)_target).endTransform = (Transform)_argument; }
        public void UnityEngine_AI_OffMeshLink__set_name() { ((OffMeshLink)_target).name = (String)_argument; }
        public void UnityEngine_AI_OffMeshLink__set_startTransform() { ((OffMeshLink)_target).startTransform = (Transform)_argument; }
        public void UnityEngine_Animations_AimConstraint__RemoveSource() { ((AimConstraint)_target).RemoveSource((Int32)_argument); }
        public void UnityEngine_Animations_AimConstraint__set_constraintActive() { ((AimConstraint)_target).constraintActive = (Boolean)_argument; }
        public void UnityEngine_Animations_AimConstraint__set_enabled() { ((AimConstraint)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_Animations_AimConstraint__set_locked() { ((AimConstraint)_target).locked = (Boolean)_argument; }
        public void UnityEngine_Animations_AimConstraint__set_name() { ((AimConstraint)_target).name = (String)_argument; }
        public void UnityEngine_Animations_AimConstraint__set_weight() { ((AimConstraint)_target).weight = (Single)_argument; }
        public void UnityEngine_Animations_AimConstraint__set_worldUpObject() { ((AimConstraint)_target).worldUpObject = (Transform)_argument; }
        public void UnityEngine_Animations_LookAtConstraint__RemoveSource() { ((LookAtConstraint)_target).RemoveSource((Int32)_argument); }
        public void UnityEngine_Animations_LookAtConstraint__set_constraintActive() { ((LookAtConstraint)_target).constraintActive = (Boolean)_argument; }
        public void UnityEngine_Animations_LookAtConstraint__set_enabled() { ((LookAtConstraint)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_Animations_LookAtConstraint__set_locked() { ((LookAtConstraint)_target).locked = (Boolean)_argument; }
        public void UnityEngine_Animations_LookAtConstraint__set_name() { ((LookAtConstraint)_target).name = (String)_argument; }
        public void UnityEngine_Animations_LookAtConstraint__set_roll() { ((LookAtConstraint)_target).roll = (Single)_argument; }
        public void UnityEngine_Animations_LookAtConstraint__set_useUpObject() { ((LookAtConstraint)_target).useUpObject = (Boolean)_argument; }
        public void UnityEngine_Animations_LookAtConstraint__set_weight() { ((LookAtConstraint)_target).weight = (Single)_argument; }
        public void UnityEngine_Animations_LookAtConstraint__set_worldUpObject() { ((LookAtConstraint)_target).worldUpObject = (Transform)_argument; }
        public void UnityEngine_Animations_ParentConstraint__RemoveSource() { ((ParentConstraint)_target).RemoveSource((Int32)_argument); }
        public void UnityEngine_Animations_ParentConstraint__set_constraintActive() { ((ParentConstraint)_target).constraintActive = (Boolean)_argument; }
        public void UnityEngine_Animations_ParentConstraint__set_enabled() { ((ParentConstraint)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_Animations_ParentConstraint__set_locked() { ((ParentConstraint)_target).locked = (Boolean)_argument; }
        public void UnityEngine_Animations_ParentConstraint__set_name() { ((ParentConstraint)_target).name = (String)_argument; }
        public void UnityEngine_Animations_ParentConstraint__set_weight() { ((ParentConstraint)_target).weight = (Single)_argument; }
        public void UnityEngine_Animations_PositionConstraint__RemoveSource() { ((PositionConstraint)_target).RemoveSource((Int32)_argument); }
        public void UnityEngine_Animations_PositionConstraint__set_constraintActive() { ((PositionConstraint)_target).constraintActive = (Boolean)_argument; }
        public void UnityEngine_Animations_PositionConstraint__set_enabled() { ((PositionConstraint)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_Animations_PositionConstraint__set_locked() { ((PositionConstraint)_target).locked = (Boolean)_argument; }
        public void UnityEngine_Animations_PositionConstraint__set_name() { ((PositionConstraint)_target).name = (String)_argument; }
        public void UnityEngine_Animations_PositionConstraint__set_weight() { ((PositionConstraint)_target).weight = (Single)_argument; }
        public void UnityEngine_Animations_RotationConstraint__RemoveSource() { ((RotationConstraint)_target).RemoveSource((Int32)_argument); }
        public void UnityEngine_Animations_RotationConstraint__set_constraintActive() { ((RotationConstraint)_target).constraintActive = (Boolean)_argument; }
        public void UnityEngine_Animations_RotationConstraint__set_enabled() { ((RotationConstraint)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_Animations_RotationConstraint__set_locked() { ((RotationConstraint)_target).locked = (Boolean)_argument; }
        public void UnityEngine_Animations_RotationConstraint__set_name() { ((RotationConstraint)_target).name = (String)_argument; }
        public void UnityEngine_Animations_RotationConstraint__set_weight() { ((RotationConstraint)_target).weight = (Single)_argument; }
        public void UnityEngine_Animations_ScaleConstraint__RemoveSource() { ((ScaleConstraint)_target).RemoveSource((Int32)_argument); }
        public void UnityEngine_Animations_ScaleConstraint__set_constraintActive() { ((ScaleConstraint)_target).constraintActive = (Boolean)_argument; }
        public void UnityEngine_Animations_ScaleConstraint__set_enabled() { ((ScaleConstraint)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_Animations_ScaleConstraint__set_locked() { ((ScaleConstraint)_target).locked = (Boolean)_argument; }
        public void UnityEngine_Animations_ScaleConstraint__set_name() { ((ScaleConstraint)_target).name = (String)_argument; }
        public void UnityEngine_Animations_ScaleConstraint__set_weight() { ((ScaleConstraint)_target).weight = (Single)_argument; }
        public void UnityEngine_Animator__ApplyBuiltinRootMotion() { ((Animator)_target).ApplyBuiltinRootMotion(); }
        public void UnityEngine_Animator__InterruptMatchTarget() { if (_argument.GetType().Equals(typeof(System.Boolean))) { ((Animator)_target).InterruptMatchTarget((Boolean)_argument); } else { ((Animator)_target).InterruptMatchTarget(); } }
        public void UnityEngine_Animator__PlayInFixedTime() { if (_argument.GetType().Equals(typeof(System.Int32))) { ((Animator)_target).PlayInFixedTime((Int32)_argument); } else { ((Animator)_target).PlayInFixedTime((String)_argument); } }
        public void UnityEngine_Animator__Play() { if (_argument.GetType().Equals(typeof(System.Int32))) { ((Animator)_target).Play((Int32)_argument); } else { ((Animator)_target).Play((String)_argument); } }
        public void UnityEngine_Animator__Rebind() { ((Animator)_target).Rebind(); }
        public void UnityEngine_Animator__ResetTrigger() { if (_argument.GetType().Equals(typeof(System.Int32))) { ((Animator)_target).ResetTrigger((Int32)_argument); } else { ((Animator)_target).ResetTrigger((String)_argument); } }
        public void UnityEngine_Animator__SetLookAtWeight() { ((Animator)_target).SetLookAtWeight((Single)_argument); }
        public void UnityEngine_Animator__SetTrigger() { if (_argument.GetType().Equals(typeof(System.Int32))) { ((Animator)_target).SetTrigger((Int32)_argument); } else { ((Animator)_target).SetTrigger((String)_argument); } }
        public void UnityEngine_Animator__StartPlayback() { ((Animator)_target).StartPlayback(); }
        public void UnityEngine_Animator__StartRecording() { ((Animator)_target).StartRecording((Int32)_argument); }
        public void UnityEngine_Animator__StopPlayback() { ((Animator)_target).StopPlayback(); }
        public void UnityEngine_Animator__StopRecording() { ((Animator)_target).StopRecording(); }
        public void UnityEngine_Animator__Update() { ((Animator)_target).Update((Single)_argument); }
        public void UnityEngine_Animator__WriteDefaultValues() { ((Animator)_target).WriteDefaultValues(); }
        public void UnityEngine_Animator__set_applyRootMotion() { ((Animator)_target).applyRootMotion = (Boolean)_argument; }
        public void UnityEngine_Animator__set_avatar() { ((Animator)_target).avatar = (Avatar)_argument; }
        public void UnityEngine_Animator__set_enabled() { ((Animator)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_Animator__set_feetPivotActive() { ((Animator)_target).feetPivotActive = (Single)_argument; }
        public void UnityEngine_Animator__set_keepAnimatorControllerStateOnDisable() { ((Animator)_target).keepAnimatorControllerStateOnDisable = (Boolean)_argument; }
        public void UnityEngine_Animator__set_layersAffectMassCenter() { ((Animator)_target).layersAffectMassCenter = (Boolean)_argument; }
        public void UnityEngine_Animator__set_logWarnings() { ((Animator)_target).logWarnings = (Boolean)_argument; }
        public void UnityEngine_Animator__set_name() { ((Animator)_target).name = (String)_argument; }
        public void UnityEngine_Animator__set_playbackTime() { ((Animator)_target).playbackTime = (Single)_argument; }
        public void UnityEngine_Animator__set_recorderStartTime() { ((Animator)_target).recorderStartTime = (Single)_argument; }
        public void UnityEngine_Animator__set_recorderStopTime() { ((Animator)_target).recorderStopTime = (Single)_argument; }
        public void UnityEngine_Animator__set_runtimeAnimatorController() { ((Animator)_target).runtimeAnimatorController = (RuntimeAnimatorController)_argument; }
        public void UnityEngine_Animator__set_speed() { ((Animator)_target).speed = (Single)_argument; }
        public void UnityEngine_Animator__set_stabilizeFeet() { ((Animator)_target).stabilizeFeet = (Boolean)_argument; }
        public void UnityEngine_AreaEffector2D__set_angularDrag() { ((AreaEffector2D)_target).angularDrag = (Single)_argument; }
        public void UnityEngine_AreaEffector2D__set_colliderMask() { ((AreaEffector2D)_target).colliderMask = (Int32)_argument; }
        public void UnityEngine_AreaEffector2D__set_drag() { ((AreaEffector2D)_target).drag = (Single)_argument; }
        public void UnityEngine_AreaEffector2D__set_enabled() { ((AreaEffector2D)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_AreaEffector2D__set_forceAngle() { ((AreaEffector2D)_target).forceAngle = (Single)_argument; }
        public void UnityEngine_AreaEffector2D__set_forceMagnitude() { ((AreaEffector2D)_target).forceMagnitude = (Single)_argument; }
        public void UnityEngine_AreaEffector2D__set_forceVariation() { ((AreaEffector2D)_target).forceVariation = (Single)_argument; }
        public void UnityEngine_AreaEffector2D__set_name() { ((AreaEffector2D)_target).name = (String)_argument; }
        public void UnityEngine_AreaEffector2D__set_useColliderMask() { ((AreaEffector2D)_target).useColliderMask = (Boolean)_argument; }
        public void UnityEngine_AreaEffector2D__set_useGlobalAngle() { ((AreaEffector2D)_target).useGlobalAngle = (Boolean)_argument; }
        public void UnityEngine_AudioChorusFilter__set_delay() { ((AudioChorusFilter)_target).delay = (Single)_argument; }
        public void UnityEngine_AudioChorusFilter__set_depth() { ((AudioChorusFilter)_target).depth = (Single)_argument; }
        public void UnityEngine_AudioChorusFilter__set_dryMix() { ((AudioChorusFilter)_target).dryMix = (Single)_argument; }
        public void UnityEngine_AudioChorusFilter__set_enabled() { ((AudioChorusFilter)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_AudioChorusFilter__set_name() { ((AudioChorusFilter)_target).name = (String)_argument; }
        public void UnityEngine_AudioChorusFilter__set_rate() { ((AudioChorusFilter)_target).rate = (Single)_argument; }
        public void UnityEngine_AudioChorusFilter__set_wetMix1() { ((AudioChorusFilter)_target).wetMix1 = (Single)_argument; }
        public void UnityEngine_AudioChorusFilter__set_wetMix2() { ((AudioChorusFilter)_target).wetMix2 = (Single)_argument; }
        public void UnityEngine_AudioChorusFilter__set_wetMix3() { ((AudioChorusFilter)_target).wetMix3 = (Single)_argument; }
        public void UnityEngine_AudioDistortionFilter__set_distortionLevel() { ((AudioDistortionFilter)_target).distortionLevel = (Single)_argument; }
        public void UnityEngine_AudioDistortionFilter__set_enabled() { ((AudioDistortionFilter)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_AudioDistortionFilter__set_name() { ((AudioDistortionFilter)_target).name = (String)_argument; }
        public void UnityEngine_AudioEchoFilter__set_decayRatio() { ((AudioEchoFilter)_target).decayRatio = (Single)_argument; }
        public void UnityEngine_AudioEchoFilter__set_delay() { ((AudioEchoFilter)_target).delay = (Single)_argument; }
        public void UnityEngine_AudioEchoFilter__set_dryMix() { ((AudioEchoFilter)_target).dryMix = (Single)_argument; }
        public void UnityEngine_AudioEchoFilter__set_enabled() { ((AudioEchoFilter)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_AudioEchoFilter__set_name() { ((AudioEchoFilter)_target).name = (String)_argument; }
        public void UnityEngine_AudioEchoFilter__set_wetMix() { ((AudioEchoFilter)_target).wetMix = (Single)_argument; }
        public void UnityEngine_AudioHighPassFilter__set_cutoffFrequency() { ((AudioHighPassFilter)_target).cutoffFrequency = (Single)_argument; }
        public void UnityEngine_AudioHighPassFilter__set_enabled() { ((AudioHighPassFilter)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_AudioHighPassFilter__set_highpassResonanceQ() { ((AudioHighPassFilter)_target).highpassResonanceQ = (Single)_argument; }
        public void UnityEngine_AudioHighPassFilter__set_name() { ((AudioHighPassFilter)_target).name = (String)_argument; }
        public void UnityEngine_AudioLowPassFilter__set_cutoffFrequency() { ((AudioLowPassFilter)_target).cutoffFrequency = (Single)_argument; }
        public void UnityEngine_AudioLowPassFilter__set_enabled() { ((AudioLowPassFilter)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_AudioLowPassFilter__set_lowpassResonanceQ() { ((AudioLowPassFilter)_target).lowpassResonanceQ = (Single)_argument; }
        public void UnityEngine_AudioLowPassFilter__set_name() { ((AudioLowPassFilter)_target).name = (String)_argument; }
        public void UnityEngine_AudioReverbFilter__set_decayHFRatio() { ((AudioReverbFilter)_target).decayHFRatio = (Single)_argument; }
        public void UnityEngine_AudioReverbFilter__set_decayTime() { ((AudioReverbFilter)_target).decayTime = (Single)_argument; }
        public void UnityEngine_AudioReverbFilter__set_density() { ((AudioReverbFilter)_target).density = (Single)_argument; }
        public void UnityEngine_AudioReverbFilter__set_diffusion() { ((AudioReverbFilter)_target).diffusion = (Single)_argument; }
        public void UnityEngine_AudioReverbFilter__set_dryLevel() { ((AudioReverbFilter)_target).dryLevel = (Single)_argument; }
        public void UnityEngine_AudioReverbFilter__set_enabled() { ((AudioReverbFilter)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_AudioReverbFilter__set_hfReference() { ((AudioReverbFilter)_target).hfReference = (Single)_argument; }
        public void UnityEngine_AudioReverbFilter__set_lfReference() { ((AudioReverbFilter)_target).lfReference = (Single)_argument; }
        public void UnityEngine_AudioReverbFilter__set_name() { ((AudioReverbFilter)_target).name = (String)_argument; }
        public void UnityEngine_AudioReverbFilter__set_reflectionsDelay() { ((AudioReverbFilter)_target).reflectionsDelay = (Single)_argument; }
        public void UnityEngine_AudioReverbFilter__set_reflectionsLevel() { ((AudioReverbFilter)_target).reflectionsLevel = (Single)_argument; }
        public void UnityEngine_AudioReverbFilter__set_reverbDelay() { ((AudioReverbFilter)_target).reverbDelay = (Single)_argument; }
        public void UnityEngine_AudioReverbFilter__set_reverbLevel() { ((AudioReverbFilter)_target).reverbLevel = (Single)_argument; }
        public void UnityEngine_AudioReverbFilter__set_roomHF() { ((AudioReverbFilter)_target).roomHF = (Single)_argument; }
        public void UnityEngine_AudioReverbFilter__set_roomLF() { ((AudioReverbFilter)_target).roomLF = (Single)_argument; }
        public void UnityEngine_AudioReverbFilter__set_room() { ((AudioReverbFilter)_target).room = (Single)_argument; }
        public void UnityEngine_AudioReverbZone__set_HFReference() { ((AudioReverbZone)_target).HFReference = (Single)_argument; }
        public void UnityEngine_AudioReverbZone__set_LFReference() { ((AudioReverbZone)_target).LFReference = (Single)_argument; }
        public void UnityEngine_AudioReverbZone__set_decayHFRatio() { ((AudioReverbZone)_target).decayHFRatio = (Single)_argument; }
        public void UnityEngine_AudioReverbZone__set_decayTime() { ((AudioReverbZone)_target).decayTime = (Single)_argument; }
        public void UnityEngine_AudioReverbZone__set_density() { ((AudioReverbZone)_target).density = (Single)_argument; }
        public void UnityEngine_AudioReverbZone__set_diffusion() { ((AudioReverbZone)_target).diffusion = (Single)_argument; }
        public void UnityEngine_AudioReverbZone__set_enabled() { ((AudioReverbZone)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_AudioReverbZone__set_maxDistance() { ((AudioReverbZone)_target).maxDistance = (Single)_argument; }
        public void UnityEngine_AudioReverbZone__set_minDistance() { ((AudioReverbZone)_target).minDistance = (Single)_argument; }
        public void UnityEngine_AudioReverbZone__set_name() { ((AudioReverbZone)_target).name = (String)_argument; }
        public void UnityEngine_AudioReverbZone__set_reflectionsDelay() { ((AudioReverbZone)_target).reflectionsDelay = (Single)_argument; }
        public void UnityEngine_AudioReverbZone__set_reflections() { ((AudioReverbZone)_target).reflections = (Int32)_argument; }
        public void UnityEngine_AudioReverbZone__set_reverbDelay() { ((AudioReverbZone)_target).reverbDelay = (Single)_argument; }
        public void UnityEngine_AudioReverbZone__set_reverb() { ((AudioReverbZone)_target).reverb = (Int32)_argument; }
        public void UnityEngine_AudioReverbZone__set_roomHF() { ((AudioReverbZone)_target).roomHF = (Int32)_argument; }
        public void UnityEngine_AudioReverbZone__set_roomLF() { ((AudioReverbZone)_target).roomLF = (Int32)_argument; }
        public void UnityEngine_AudioReverbZone__set_room() { ((AudioReverbZone)_target).room = (Int32)_argument; }
        public void UnityEngine_AudioSource__Pause() { ((AudioSource)_target).Pause(); }
        public void UnityEngine_AudioSource__PlayDelayed() { ((AudioSource)_target).PlayDelayed((Single)_argument); }
        public void UnityEngine_AudioSource__PlayOneShot() { ((AudioSource)_target).PlayOneShot((AudioClip)_argument); }
        public void UnityEngine_AudioSource__Play() { ((AudioSource)_target).Play(); }
        public void UnityEngine_AudioSource__Stop() { ((AudioSource)_target).Stop(); }
        public void UnityEngine_AudioSource__UnPause() { ((AudioSource)_target).UnPause(); }
        public void UnityEngine_AudioSource__set_bypassReverbZones() { ((AudioSource)_target).bypassReverbZones = (Boolean)_argument; }
        public void UnityEngine_AudioSource__set_clip() { ((AudioSource)_target).clip = (AudioClip)_argument; }
        public void UnityEngine_AudioSource__set_dopplerLevel() { ((AudioSource)_target).dopplerLevel = (Single)_argument; }
        public void UnityEngine_AudioSource__set_enabled() { ((AudioSource)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_AudioSource__set_loop() { ((AudioSource)_target).loop = (Boolean)_argument; }
        public void UnityEngine_AudioSource__set_maxDistance() { ((AudioSource)_target).maxDistance = (Single)_argument; }
        public void UnityEngine_AudioSource__set_minDistance() { ((AudioSource)_target).minDistance = (Single)_argument; }
        public void UnityEngine_AudioSource__set_mute() { ((AudioSource)_target).mute = (Boolean)_argument; }
        public void UnityEngine_AudioSource__set_name() { ((AudioSource)_target).name = (String)_argument; }
        public void UnityEngine_AudioSource__set_panStereo() { ((AudioSource)_target).panStereo = (Single)_argument; }
        public void UnityEngine_AudioSource__set_pitch() { ((AudioSource)_target).pitch = (Single)_argument; }
        public void UnityEngine_AudioSource__set_playOnAwake() { ((AudioSource)_target).playOnAwake = (Boolean)_argument; }
        public void UnityEngine_AudioSource__set_priority() { ((AudioSource)_target).priority = (Int32)_argument; }
        public void UnityEngine_AudioSource__set_reverbZoneMix() { ((AudioSource)_target).reverbZoneMix = (Single)_argument; }
        public void UnityEngine_AudioSource__set_spatialBlend() { ((AudioSource)_target).spatialBlend = (Single)_argument; }
        public void UnityEngine_AudioSource__set_spatializePostEffects() { ((AudioSource)_target).spatializePostEffects = (Boolean)_argument; }
        public void UnityEngine_AudioSource__set_spatialize() { ((AudioSource)_target).spatialize = (Boolean)_argument; }
        public void UnityEngine_AudioSource__set_spread() { ((AudioSource)_target).spread = (Single)_argument; }
        public void UnityEngine_AudioSource__set_timeSamples() { ((AudioSource)_target).timeSamples = (Int32)_argument; }
        public void UnityEngine_AudioSource__set_time() { ((AudioSource)_target).time = (Single)_argument; }
        public void UnityEngine_AudioSource__set_volume() { ((AudioSource)_target).volume = (Single)_argument; }
        public void UnityEngine_BillboardRenderer__HasPropertyBlock() { ((BillboardRenderer)_target).HasPropertyBlock(); }
        public void UnityEngine_BillboardRenderer__set_allowOcclusionWhenDynamic() { ((BillboardRenderer)_target).allowOcclusionWhenDynamic = (Boolean)_argument; }
        public void UnityEngine_BillboardRenderer__set_billboard() { ((BillboardRenderer)_target).billboard = (BillboardAsset)_argument; }
        public void UnityEngine_BillboardRenderer__set_enabled() { ((BillboardRenderer)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_BillboardRenderer__set_forceRenderingOff() { ((BillboardRenderer)_target).forceRenderingOff = (Boolean)_argument; }
        public void UnityEngine_BillboardRenderer__set_lightProbeProxyVolumeOverride() { ((BillboardRenderer)_target).lightProbeProxyVolumeOverride = (GameObject)_argument; }
        public void UnityEngine_BillboardRenderer__set_lightmapIndex() { ((BillboardRenderer)_target).lightmapIndex = (Int32)_argument; }
        public void UnityEngine_BillboardRenderer__set_material() { ((BillboardRenderer)_target).material = (Material)_argument; }
        public void UnityEngine_BillboardRenderer__set_name() { ((BillboardRenderer)_target).name = (String)_argument; }
        public void UnityEngine_BillboardRenderer__set_probeAnchor() { ((BillboardRenderer)_target).probeAnchor = (Transform)_argument; }
        public void UnityEngine_BillboardRenderer__set_realtimeLightmapIndex() { ((BillboardRenderer)_target).realtimeLightmapIndex = (Int32)_argument; }
        public void UnityEngine_BillboardRenderer__set_receiveShadows() { ((BillboardRenderer)_target).receiveShadows = (Boolean)_argument; }
        public void UnityEngine_BillboardRenderer__set_rendererPriority() { ((BillboardRenderer)_target).rendererPriority = (Int32)_argument; }
        public void UnityEngine_BillboardRenderer__set_sharedMaterial() { ((BillboardRenderer)_target).sharedMaterial = (Material)_argument; }
        public void UnityEngine_BillboardRenderer__set_sortingLayerID() { ((BillboardRenderer)_target).sortingLayerID = (Int32)_argument; }
        public void UnityEngine_BillboardRenderer__set_sortingLayerName() { ((BillboardRenderer)_target).sortingLayerName = (String)_argument; }
        public void UnityEngine_BillboardRenderer__set_sortingOrder() { ((BillboardRenderer)_target).sortingOrder = (Int32)_argument; }
        public void UnityEngine_BoxCollider2D__Distance() { ((BoxCollider2D)_target).Distance((Collider2D)_argument); }
        public void UnityEngine_BoxCollider2D__set_autoTiling() { ((BoxCollider2D)_target).autoTiling = (Boolean)_argument; }
        public void UnityEngine_BoxCollider2D__set_density() { ((BoxCollider2D)_target).density = (Single)_argument; }
        public void UnityEngine_BoxCollider2D__set_edgeRadius() { ((BoxCollider2D)_target).edgeRadius = (Single)_argument; }
        public void UnityEngine_BoxCollider2D__set_enabled() { ((BoxCollider2D)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_BoxCollider2D__set_isTrigger() { ((BoxCollider2D)_target).isTrigger = (Boolean)_argument; }
        public void UnityEngine_BoxCollider2D__set_name() { ((BoxCollider2D)_target).name = (String)_argument; }
        public void UnityEngine_BoxCollider2D__set_sharedMaterial() { ((BoxCollider2D)_target).sharedMaterial = (PhysicsMaterial2D)_argument; }
        public void UnityEngine_BoxCollider2D__set_usedByComposite() { ((BoxCollider2D)_target).usedByComposite = (Boolean)_argument; }
        public void UnityEngine_BoxCollider2D__set_usedByEffector() { ((BoxCollider2D)_target).usedByEffector = (Boolean)_argument; }
        public void UnityEngine_BoxCollider__set_contactOffset() { ((BoxCollider)_target).contactOffset = (Single)_argument; }
        public void UnityEngine_BoxCollider__set_enabled() { ((BoxCollider)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_BoxCollider__set_isTrigger() { ((BoxCollider)_target).isTrigger = (Boolean)_argument; }
        public void UnityEngine_BoxCollider__set_material() { ((BoxCollider)_target).material = (PhysicMaterial)_argument; }
        public void UnityEngine_BoxCollider__set_name() { ((BoxCollider)_target).name = (String)_argument; }
        public void UnityEngine_BoxCollider__set_sharedMaterial() { ((BoxCollider)_target).sharedMaterial = (PhysicMaterial)_argument; }
        public void UnityEngine_Camera__CopyFrom() { ((Camera)_target).CopyFrom((Camera)_argument); }
        public void UnityEngine_Camera__RenderDontRestore() { ((Camera)_target).RenderDontRestore(); }
        public void UnityEngine_Camera__RenderToCubemap() { if (_argument.GetType().Equals(typeof(UnityEngine.Cubemap))) { ((Camera)_target).RenderToCubemap((Cubemap)_argument); } else { ((Camera)_target).RenderToCubemap((RenderTexture)_argument); } }
        public void UnityEngine_Camera__Render() { ((Camera)_target).Render(); }
        public void UnityEngine_Camera__ResetAspect() { ((Camera)_target).ResetAspect(); }
        public void UnityEngine_Camera__ResetCullingMatrix() { ((Camera)_target).ResetCullingMatrix(); }
        public void UnityEngine_Camera__ResetProjectionMatrix() { ((Camera)_target).ResetProjectionMatrix(); }
        public void UnityEngine_Camera__ResetReplacementShader() { ((Camera)_target).ResetReplacementShader(); }
        public void UnityEngine_Camera__ResetStereoProjectionMatrices() { ((Camera)_target).ResetStereoProjectionMatrices(); }
        public void UnityEngine_Camera__ResetStereoViewMatrices() { ((Camera)_target).ResetStereoViewMatrices(); }
        public void UnityEngine_Camera__ResetTransparencySortSettings() { ((Camera)_target).ResetTransparencySortSettings(); }
        public void UnityEngine_Camera__ResetWorldToCameraMatrix() { ((Camera)_target).ResetWorldToCameraMatrix(); }
        public void UnityEngine_Camera__Reset() { ((Camera)_target).Reset(); }
        public void UnityEngine_Camera__SetupCurrent() { Camera.SetupCurrent((Camera)_argument); }
        public void UnityEngine_Camera__set_allowDynamicResolution() { ((Camera)_target).allowDynamicResolution = (Boolean)_argument; }
        public void UnityEngine_Camera__set_allowHDR() { ((Camera)_target).allowHDR = (Boolean)_argument; }
        public void UnityEngine_Camera__set_allowMSAA() { ((Camera)_target).allowMSAA = (Boolean)_argument; }
        public void UnityEngine_Camera__set_aspect() { ((Camera)_target).aspect = (Single)_argument; }
        public void UnityEngine_Camera__set_clearStencilAfterLightingPass() { ((Camera)_target).clearStencilAfterLightingPass = (Boolean)_argument; }
        public void UnityEngine_Camera__set_cullingMask() { ((Camera)_target).cullingMask = (Int32)_argument; }
        public void UnityEngine_Camera__set_depth() { ((Camera)_target).depth = (Single)_argument; }
        public void UnityEngine_Camera__set_enabled() { ((Camera)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_Camera__set_eventMask() { ((Camera)_target).eventMask = (Int32)_argument; }
        public void UnityEngine_Camera__set_farClipPlane() { ((Camera)_target).farClipPlane = (Single)_argument; }
        public void UnityEngine_Camera__set_fieldOfView() { ((Camera)_target).fieldOfView = (Single)_argument; }
        public void UnityEngine_Camera__set_focalLength() { ((Camera)_target).focalLength = (Single)_argument; }
        public void UnityEngine_Camera__set_forceIntoRenderTexture() { ((Camera)_target).forceIntoRenderTexture = (Boolean)_argument; }
        public void UnityEngine_Camera__set_layerCullSpherical() { ((Camera)_target).layerCullSpherical = (Boolean)_argument; }
        public void UnityEngine_Camera__set_name() { ((Camera)_target).name = (String)_argument; }
        public void UnityEngine_Camera__set_nearClipPlane() { ((Camera)_target).nearClipPlane = (Single)_argument; }
        public void UnityEngine_Camera__set_orthographicSize() { ((Camera)_target).orthographicSize = (Single)_argument; }
        public void UnityEngine_Camera__set_orthographic() { ((Camera)_target).orthographic = (Boolean)_argument; }
        public void UnityEngine_Camera__set_stereoConvergence() { ((Camera)_target).stereoConvergence = (Single)_argument; }
        public void UnityEngine_Camera__set_stereoSeparation() { ((Camera)_target).stereoSeparation = (Single)_argument; }
        public void UnityEngine_Camera__set_targetDisplay() { ((Camera)_target).targetDisplay = (Int32)_argument; }
        public void UnityEngine_Camera__set_targetTexture() { ((Camera)_target).targetTexture = (RenderTexture)_argument; }
        public void UnityEngine_Camera__set_useJitteredProjectionMatrixForTransparentRendering() { ((Camera)_target).useJitteredProjectionMatrixForTransparentRendering = (Boolean)_argument; }
        public void UnityEngine_Camera__set_useOcclusionCulling() { ((Camera)_target).useOcclusionCulling = (Boolean)_argument; }
        public void UnityEngine_Camera__set_usePhysicalProperties() { ((Camera)_target).usePhysicalProperties = (Boolean)_argument; }
        public void UnityEngine_CanvasGroup__set_alpha() { ((CanvasGroup)_target).alpha = (Single)_argument; }
        public void UnityEngine_CanvasGroup__set_blocksRaycasts() { ((CanvasGroup)_target).blocksRaycasts = (Boolean)_argument; }
        public void UnityEngine_CanvasGroup__set_enabled() { ((CanvasGroup)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_CanvasGroup__set_ignoreParentGroups() { ((CanvasGroup)_target).ignoreParentGroups = (Boolean)_argument; }
        public void UnityEngine_CanvasGroup__set_interactable() { ((CanvasGroup)_target).interactable = (Boolean)_argument; }
        public void UnityEngine_CanvasGroup__set_name() { ((CanvasGroup)_target).name = (String)_argument; }
        public void UnityEngine_Canvas__ForceUpdateCanvases() { Canvas.ForceUpdateCanvases(); }
        public void UnityEngine_Canvas__set_enabled() { ((Canvas)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_Canvas__set_name() { ((Canvas)_target).name = (String)_argument; }
        public void UnityEngine_Canvas__set_normalizedSortingGridSize() { ((Canvas)_target).normalizedSortingGridSize = (Single)_argument; }
        public void UnityEngine_Canvas__set_overridePixelPerfect() { ((Canvas)_target).overridePixelPerfect = (Boolean)_argument; }
        public void UnityEngine_Canvas__set_overrideSorting() { ((Canvas)_target).overrideSorting = (Boolean)_argument; }
        public void UnityEngine_Canvas__set_pixelPerfect() { ((Canvas)_target).pixelPerfect = (Boolean)_argument; }
        public void UnityEngine_Canvas__set_planeDistance() { ((Canvas)_target).planeDistance = (Single)_argument; }
        public void UnityEngine_Canvas__set_referencePixelsPerUnit() { ((Canvas)_target).referencePixelsPerUnit = (Single)_argument; }
        public void UnityEngine_Canvas__set_scaleFactor() { ((Canvas)_target).scaleFactor = (Single)_argument; }
        public void UnityEngine_Canvas__set_sortingLayerID() { ((Canvas)_target).sortingLayerID = (Int32)_argument; }
        public void UnityEngine_Canvas__set_sortingLayerName() { ((Canvas)_target).sortingLayerName = (String)_argument; }
        public void UnityEngine_Canvas__set_sortingOrder() { ((Canvas)_target).sortingOrder = (Int32)_argument; }
        public void UnityEngine_CanvasRenderer__Clear() { ((CanvasRenderer)_target).Clear(); }
        public void UnityEngine_CanvasRenderer__DisableRectClipping() { ((CanvasRenderer)_target).DisableRectClipping(); }
        public void UnityEngine_CanvasRenderer__SetAlphaTexture() { ((CanvasRenderer)_target).SetAlphaTexture((Texture)_argument); }
        public void UnityEngine_CanvasRenderer__SetAlpha() { ((CanvasRenderer)_target).SetAlpha((Single)_argument); }
        public void UnityEngine_CanvasRenderer__SetMesh() { ((CanvasRenderer)_target).SetMesh((Mesh)_argument); }
        public void UnityEngine_CanvasRenderer__SetTexture() { ((CanvasRenderer)_target).SetTexture((Texture)_argument); }
        public void UnityEngine_CanvasRenderer__set_cullTransparentMesh() { ((CanvasRenderer)_target).cullTransparentMesh = (Boolean)_argument; }
        public void UnityEngine_CanvasRenderer__set_cull() { ((CanvasRenderer)_target).cull = (Boolean)_argument; }
        public void UnityEngine_CanvasRenderer__set_hasPopInstruction() { ((CanvasRenderer)_target).hasPopInstruction = (Boolean)_argument; }
        public void UnityEngine_CanvasRenderer__set_materialCount() { ((CanvasRenderer)_target).materialCount = (Int32)_argument; }
        public void UnityEngine_CanvasRenderer__set_name() { ((CanvasRenderer)_target).name = (String)_argument; }
        public void UnityEngine_CanvasRenderer__set_popMaterialCount() { ((CanvasRenderer)_target).popMaterialCount = (Int32)_argument; }
        public void UnityEngine_CapsuleCollider2D__Distance() { ((CapsuleCollider2D)_target).Distance((Collider2D)_argument); }
        public void UnityEngine_CapsuleCollider2D__set_density() { ((CapsuleCollider2D)_target).density = (Single)_argument; }
        public void UnityEngine_CapsuleCollider2D__set_enabled() { ((CapsuleCollider2D)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_CapsuleCollider2D__set_isTrigger() { ((CapsuleCollider2D)_target).isTrigger = (Boolean)_argument; }
        public void UnityEngine_CapsuleCollider2D__set_name() { ((CapsuleCollider2D)_target).name = (String)_argument; }
        public void UnityEngine_CapsuleCollider2D__set_sharedMaterial() { ((CapsuleCollider2D)_target).sharedMaterial = (PhysicsMaterial2D)_argument; }
        public void UnityEngine_CapsuleCollider2D__set_usedByComposite() { ((CapsuleCollider2D)_target).usedByComposite = (Boolean)_argument; }
        public void UnityEngine_CapsuleCollider2D__set_usedByEffector() { ((CapsuleCollider2D)_target).usedByEffector = (Boolean)_argument; }
        public void UnityEngine_CapsuleCollider__set_contactOffset() { ((CapsuleCollider)_target).contactOffset = (Single)_argument; }
        public void UnityEngine_CapsuleCollider__set_direction() { ((CapsuleCollider)_target).direction = (Int32)_argument; }
        public void UnityEngine_CapsuleCollider__set_enabled() { ((CapsuleCollider)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_CapsuleCollider__set_height() { ((CapsuleCollider)_target).height = (Single)_argument; }
        public void UnityEngine_CapsuleCollider__set_isTrigger() { ((CapsuleCollider)_target).isTrigger = (Boolean)_argument; }
        public void UnityEngine_CapsuleCollider__set_material() { ((CapsuleCollider)_target).material = (PhysicMaterial)_argument; }
        public void UnityEngine_CapsuleCollider__set_name() { ((CapsuleCollider)_target).name = (String)_argument; }
        public void UnityEngine_CapsuleCollider__set_radius() { ((CapsuleCollider)_target).radius = (Single)_argument; }
        public void UnityEngine_CapsuleCollider__set_sharedMaterial() { ((CapsuleCollider)_target).sharedMaterial = (PhysicMaterial)_argument; }
        public void UnityEngine_CharacterController__set_contactOffset() { ((CharacterController)_target).contactOffset = (Single)_argument; }
        public void UnityEngine_CharacterController__set_detectCollisions() { ((CharacterController)_target).detectCollisions = (Boolean)_argument; }
        public void UnityEngine_CharacterController__set_enableOverlapRecovery() { ((CharacterController)_target).enableOverlapRecovery = (Boolean)_argument; }
        public void UnityEngine_CharacterController__set_enabled() { ((CharacterController)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_CharacterController__set_height() { ((CharacterController)_target).height = (Single)_argument; }
        public void UnityEngine_CharacterController__set_isTrigger() { ((CharacterController)_target).isTrigger = (Boolean)_argument; }
        public void UnityEngine_CharacterController__set_material() { ((CharacterController)_target).material = (PhysicMaterial)_argument; }
        public void UnityEngine_CharacterController__set_minMoveDistance() { ((CharacterController)_target).minMoveDistance = (Single)_argument; }
        public void UnityEngine_CharacterController__set_name() { ((CharacterController)_target).name = (String)_argument; }
        public void UnityEngine_CharacterController__set_radius() { ((CharacterController)_target).radius = (Single)_argument; }
        public void UnityEngine_CharacterController__set_sharedMaterial() { ((CharacterController)_target).sharedMaterial = (PhysicMaterial)_argument; }
        public void UnityEngine_CharacterController__set_skinWidth() { ((CharacterController)_target).skinWidth = (Single)_argument; }
        public void UnityEngine_CharacterController__set_slopeLimit() { ((CharacterController)_target).slopeLimit = (Single)_argument; }
        public void UnityEngine_CharacterController__set_stepOffset() { ((CharacterController)_target).stepOffset = (Single)_argument; }
        public void UnityEngine_CircleCollider2D__Distance() { ((CircleCollider2D)_target).Distance((Collider2D)_argument); }
        public void UnityEngine_CircleCollider2D__set_density() { ((CircleCollider2D)_target).density = (Single)_argument; }
        public void UnityEngine_CircleCollider2D__set_enabled() { ((CircleCollider2D)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_CircleCollider2D__set_isTrigger() { ((CircleCollider2D)_target).isTrigger = (Boolean)_argument; }
        public void UnityEngine_CircleCollider2D__set_name() { ((CircleCollider2D)_target).name = (String)_argument; }
        public void UnityEngine_CircleCollider2D__set_radius() { ((CircleCollider2D)_target).radius = (Single)_argument; }
        public void UnityEngine_CircleCollider2D__set_sharedMaterial() { ((CircleCollider2D)_target).sharedMaterial = (PhysicsMaterial2D)_argument; }
        public void UnityEngine_CircleCollider2D__set_usedByComposite() { ((CircleCollider2D)_target).usedByComposite = (Boolean)_argument; }
        public void UnityEngine_CircleCollider2D__set_usedByEffector() { ((CircleCollider2D)_target).usedByEffector = (Boolean)_argument; }
        public void UnityEngine_Collider2D__Distance() { ((Collider2D)_target).Distance((Collider2D)_argument); }
        public void UnityEngine_Collider2D__set_density() { ((Collider2D)_target).density = (Single)_argument; }
        public void UnityEngine_Collider2D__set_enabled() { ((Collider2D)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_Collider2D__set_isTrigger() { ((Collider2D)_target).isTrigger = (Boolean)_argument; }
        public void UnityEngine_Collider2D__set_name() { ((Collider2D)_target).name = (String)_argument; }
        public void UnityEngine_Collider2D__set_sharedMaterial() { ((Collider2D)_target).sharedMaterial = (PhysicsMaterial2D)_argument; }
        public void UnityEngine_Collider2D__set_usedByComposite() { ((Collider2D)_target).usedByComposite = (Boolean)_argument; }
        public void UnityEngine_Collider2D__set_usedByEffector() { ((Collider2D)_target).usedByEffector = (Boolean)_argument; }
        public void UnityEngine_Collider__set_contactOffset() { ((Collider)_target).contactOffset = (Single)_argument; }
        public void UnityEngine_Collider__set_enabled() { ((Collider)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_Collider__set_isTrigger() { ((Collider)_target).isTrigger = (Boolean)_argument; }
        public void UnityEngine_Collider__set_material() { ((Collider)_target).material = (PhysicMaterial)_argument; }
        public void UnityEngine_Collider__set_name() { ((Collider)_target).name = (String)_argument; }
        public void UnityEngine_Collider__set_sharedMaterial() { ((Collider)_target).sharedMaterial = (PhysicMaterial)_argument; }
        public void UnityEngine_Component__set_name() { ((Component)_target).name = (String)_argument; }
        public void UnityEngine_CompositeCollider2D__Distance() { ((CompositeCollider2D)_target).Distance((Collider2D)_argument); }
        public void UnityEngine_CompositeCollider2D__GenerateGeometry() { ((CompositeCollider2D)_target).GenerateGeometry(); }
        public void UnityEngine_CompositeCollider2D__set_density() { ((CompositeCollider2D)_target).density = (Single)_argument; }
        public void UnityEngine_CompositeCollider2D__set_edgeRadius() { ((CompositeCollider2D)_target).edgeRadius = (Single)_argument; }
        public void UnityEngine_CompositeCollider2D__set_enabled() { ((CompositeCollider2D)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_CompositeCollider2D__set_isTrigger() { ((CompositeCollider2D)_target).isTrigger = (Boolean)_argument; }
        public void UnityEngine_CompositeCollider2D__set_name() { ((CompositeCollider2D)_target).name = (String)_argument; }
        public void UnityEngine_CompositeCollider2D__set_offsetDistance() { ((CompositeCollider2D)_target).offsetDistance = (Single)_argument; }
        public void UnityEngine_CompositeCollider2D__set_sharedMaterial() { ((CompositeCollider2D)_target).sharedMaterial = (PhysicsMaterial2D)_argument; }
        public void UnityEngine_CompositeCollider2D__set_usedByComposite() { ((CompositeCollider2D)_target).usedByComposite = (Boolean)_argument; }
        public void UnityEngine_CompositeCollider2D__set_usedByEffector() { ((CompositeCollider2D)_target).usedByEffector = (Boolean)_argument; }
        public void UnityEngine_CompositeCollider2D__set_vertexDistance() { ((CompositeCollider2D)_target).vertexDistance = (Single)_argument; }
        public void UnityEngine_ConfigurableJoint__set_autoConfigureConnectedAnchor() { ((ConfigurableJoint)_target).autoConfigureConnectedAnchor = (Boolean)_argument; }
        public void UnityEngine_ConfigurableJoint__set_breakForce() { ((ConfigurableJoint)_target).breakForce = (Single)_argument; }
        public void UnityEngine_ConfigurableJoint__set_breakTorque() { ((ConfigurableJoint)_target).breakTorque = (Single)_argument; }
        public void UnityEngine_ConfigurableJoint__set_configuredInWorldSpace() { ((ConfigurableJoint)_target).configuredInWorldSpace = (Boolean)_argument; }
        public void UnityEngine_ConfigurableJoint__set_connectedBody() { ((ConfigurableJoint)_target).connectedBody = (Rigidbody)_argument; }
        public void UnityEngine_ConfigurableJoint__set_connectedMassScale() { ((ConfigurableJoint)_target).connectedMassScale = (Single)_argument; }
        public void UnityEngine_ConfigurableJoint__set_enableCollision() { ((ConfigurableJoint)_target).enableCollision = (Boolean)_argument; }
        public void UnityEngine_ConfigurableJoint__set_enablePreprocessing() { ((ConfigurableJoint)_target).enablePreprocessing = (Boolean)_argument; }
        public void UnityEngine_ConfigurableJoint__set_massScale() { ((ConfigurableJoint)_target).massScale = (Single)_argument; }
        public void UnityEngine_ConfigurableJoint__set_name() { ((ConfigurableJoint)_target).name = (String)_argument; }
        public void UnityEngine_ConfigurableJoint__set_projectionAngle() { ((ConfigurableJoint)_target).projectionAngle = (Single)_argument; }
        public void UnityEngine_ConfigurableJoint__set_projectionDistance() { ((ConfigurableJoint)_target).projectionDistance = (Single)_argument; }
        public void UnityEngine_ConfigurableJoint__set_swapBodies() { ((ConfigurableJoint)_target).swapBodies = (Boolean)_argument; }
        public void UnityEngine_ConstantForce2D__set_enabled() { ((ConstantForce2D)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_ConstantForce2D__set_name() { ((ConstantForce2D)_target).name = (String)_argument; }
        public void UnityEngine_ConstantForce2D__set_torque() { ((ConstantForce2D)_target).torque = (Single)_argument; }
        public void UnityEngine_ConstantForce__set_enabled() { ((ConstantForce)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_ConstantForce__set_name() { ((ConstantForce)_target).name = (String)_argument; }
        public void UnityEngine_DistanceJoint2D__set_autoConfigureConnectedAnchor() { ((DistanceJoint2D)_target).autoConfigureConnectedAnchor = (Boolean)_argument; }
        public void UnityEngine_DistanceJoint2D__set_autoConfigureDistance() { ((DistanceJoint2D)_target).autoConfigureDistance = (Boolean)_argument; }
        public void UnityEngine_DistanceJoint2D__set_breakForce() { ((DistanceJoint2D)_target).breakForce = (Single)_argument; }
        public void UnityEngine_DistanceJoint2D__set_breakTorque() { ((DistanceJoint2D)_target).breakTorque = (Single)_argument; }
        public void UnityEngine_DistanceJoint2D__set_connectedBody() { ((DistanceJoint2D)_target).connectedBody = (Rigidbody2D)_argument; }
        public void UnityEngine_DistanceJoint2D__set_distance() { ((DistanceJoint2D)_target).distance = (Single)_argument; }
        public void UnityEngine_DistanceJoint2D__set_enableCollision() { ((DistanceJoint2D)_target).enableCollision = (Boolean)_argument; }
        public void UnityEngine_DistanceJoint2D__set_enabled() { ((DistanceJoint2D)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_DistanceJoint2D__set_maxDistanceOnly() { ((DistanceJoint2D)_target).maxDistanceOnly = (Boolean)_argument; }
        public void UnityEngine_DistanceJoint2D__set_name() { ((DistanceJoint2D)_target).name = (String)_argument; }
        public void UnityEngine_EdgeCollider2D__Distance() { ((EdgeCollider2D)_target).Distance((Collider2D)_argument); }
        public void UnityEngine_EdgeCollider2D__Reset() { ((EdgeCollider2D)_target).Reset(); }
        public void UnityEngine_EdgeCollider2D__set_density() { ((EdgeCollider2D)_target).density = (Single)_argument; }
        public void UnityEngine_EdgeCollider2D__set_edgeRadius() { ((EdgeCollider2D)_target).edgeRadius = (Single)_argument; }
        public void UnityEngine_EdgeCollider2D__set_enabled() { ((EdgeCollider2D)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_EdgeCollider2D__set_isTrigger() { ((EdgeCollider2D)_target).isTrigger = (Boolean)_argument; }
        public void UnityEngine_EdgeCollider2D__set_name() { ((EdgeCollider2D)_target).name = (String)_argument; }
        public void UnityEngine_EdgeCollider2D__set_sharedMaterial() { ((EdgeCollider2D)_target).sharedMaterial = (PhysicsMaterial2D)_argument; }
        public void UnityEngine_EdgeCollider2D__set_usedByComposite() { ((EdgeCollider2D)_target).usedByComposite = (Boolean)_argument; }
        public void UnityEngine_EdgeCollider2D__set_usedByEffector() { ((EdgeCollider2D)_target).usedByEffector = (Boolean)_argument; }
        public void UnityEngine_Effector2D__set_colliderMask() { ((Effector2D)_target).colliderMask = (Int32)_argument; }
        public void UnityEngine_Effector2D__set_enabled() { ((Effector2D)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_Effector2D__set_name() { ((Effector2D)_target).name = (String)_argument; }
        public void UnityEngine_Effector2D__set_useColliderMask() { ((Effector2D)_target).useColliderMask = (Boolean)_argument; }
        public void UnityEngine_FixedJoint2D__set_autoConfigureConnectedAnchor() { ((FixedJoint2D)_target).autoConfigureConnectedAnchor = (Boolean)_argument; }
        public void UnityEngine_FixedJoint2D__set_breakForce() { ((FixedJoint2D)_target).breakForce = (Single)_argument; }
        public void UnityEngine_FixedJoint2D__set_breakTorque() { ((FixedJoint2D)_target).breakTorque = (Single)_argument; }
        public void UnityEngine_FixedJoint2D__set_connectedBody() { ((FixedJoint2D)_target).connectedBody = (Rigidbody2D)_argument; }
        public void UnityEngine_FixedJoint2D__set_dampingRatio() { ((FixedJoint2D)_target).dampingRatio = (Single)_argument; }
        public void UnityEngine_FixedJoint2D__set_enableCollision() { ((FixedJoint2D)_target).enableCollision = (Boolean)_argument; }
        public void UnityEngine_FixedJoint2D__set_enabled() { ((FixedJoint2D)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_FixedJoint2D__set_frequency() { ((FixedJoint2D)_target).frequency = (Single)_argument; }
        public void UnityEngine_FixedJoint2D__set_name() { ((FixedJoint2D)_target).name = (String)_argument; }
        public void UnityEngine_FixedJoint__set_autoConfigureConnectedAnchor() { ((FixedJoint)_target).autoConfigureConnectedAnchor = (Boolean)_argument; }
        public void UnityEngine_FixedJoint__set_breakForce() { ((FixedJoint)_target).breakForce = (Single)_argument; }
        public void UnityEngine_FixedJoint__set_breakTorque() { ((FixedJoint)_target).breakTorque = (Single)_argument; }
        public void UnityEngine_FixedJoint__set_connectedBody() { ((FixedJoint)_target).connectedBody = (Rigidbody)_argument; }
        public void UnityEngine_FixedJoint__set_connectedMassScale() { ((FixedJoint)_target).connectedMassScale = (Single)_argument; }
        public void UnityEngine_FixedJoint__set_enableCollision() { ((FixedJoint)_target).enableCollision = (Boolean)_argument; }
        public void UnityEngine_FixedJoint__set_enablePreprocessing() { ((FixedJoint)_target).enablePreprocessing = (Boolean)_argument; }
        public void UnityEngine_FixedJoint__set_massScale() { ((FixedJoint)_target).massScale = (Single)_argument; }
        public void UnityEngine_FixedJoint__set_name() { ((FixedJoint)_target).name = (String)_argument; }
        public void UnityEngine_FrictionJoint2D__set_autoConfigureConnectedAnchor() { ((FrictionJoint2D)_target).autoConfigureConnectedAnchor = (Boolean)_argument; }
        public void UnityEngine_FrictionJoint2D__set_breakForce() { ((FrictionJoint2D)_target).breakForce = (Single)_argument; }
        public void UnityEngine_FrictionJoint2D__set_breakTorque() { ((FrictionJoint2D)_target).breakTorque = (Single)_argument; }
        public void UnityEngine_FrictionJoint2D__set_connectedBody() { ((FrictionJoint2D)_target).connectedBody = (Rigidbody2D)_argument; }
        public void UnityEngine_FrictionJoint2D__set_enableCollision() { ((FrictionJoint2D)_target).enableCollision = (Boolean)_argument; }
        public void UnityEngine_FrictionJoint2D__set_enabled() { ((FrictionJoint2D)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_FrictionJoint2D__set_maxForce() { ((FrictionJoint2D)_target).maxForce = (Single)_argument; }
        public void UnityEngine_FrictionJoint2D__set_maxTorque() { ((FrictionJoint2D)_target).maxTorque = (Single)_argument; }
        public void UnityEngine_FrictionJoint2D__set_name() { ((FrictionJoint2D)_target).name = (String)_argument; }
        public void UnityEngine_GameObject__Find() { GameObject.Find((String)_argument); }
        public void UnityEngine_GameObject__SetActive() { ((GameObject)_target).SetActive((Boolean)_argument); }
        public void UnityEngine_GameObject__set_isStatic() { ((GameObject)_target).isStatic = (Boolean)_argument; }
        public void UnityEngine_GameObject__set_layer() { ((GameObject)_target).layer = (Int32)_argument; }
        public void UnityEngine_GameObject__set_name() { ((GameObject)_target).name = (String)_argument; }
        public void UnityEngine_HingeJoint2D__set_autoConfigureConnectedAnchor() { ((HingeJoint2D)_target).autoConfigureConnectedAnchor = (Boolean)_argument; }
        public void UnityEngine_HingeJoint2D__set_breakForce() { ((HingeJoint2D)_target).breakForce = (Single)_argument; }
        public void UnityEngine_HingeJoint2D__set_breakTorque() { ((HingeJoint2D)_target).breakTorque = (Single)_argument; }
        public void UnityEngine_HingeJoint2D__set_connectedBody() { ((HingeJoint2D)_target).connectedBody = (Rigidbody2D)_argument; }
        public void UnityEngine_HingeJoint2D__set_enableCollision() { ((HingeJoint2D)_target).enableCollision = (Boolean)_argument; }
        public void UnityEngine_HingeJoint2D__set_enabled() { ((HingeJoint2D)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_HingeJoint2D__set_name() { ((HingeJoint2D)_target).name = (String)_argument; }
        public void UnityEngine_HingeJoint2D__set_useLimits() { ((HingeJoint2D)_target).useLimits = (Boolean)_argument; }
        public void UnityEngine_HingeJoint2D__set_useMotor() { ((HingeJoint2D)_target).useMotor = (Boolean)_argument; }
        public void UnityEngine_HingeJoint__set_autoConfigureConnectedAnchor() { ((HingeJoint)_target).autoConfigureConnectedAnchor = (Boolean)_argument; }
        public void UnityEngine_HingeJoint__set_breakForce() { ((HingeJoint)_target).breakForce = (Single)_argument; }
        public void UnityEngine_HingeJoint__set_breakTorque() { ((HingeJoint)_target).breakTorque = (Single)_argument; }
        public void UnityEngine_HingeJoint__set_connectedBody() { ((HingeJoint)_target).connectedBody = (Rigidbody)_argument; }
        public void UnityEngine_HingeJoint__set_connectedMassScale() { ((HingeJoint)_target).connectedMassScale = (Single)_argument; }
        public void UnityEngine_HingeJoint__set_enableCollision() { ((HingeJoint)_target).enableCollision = (Boolean)_argument; }
        public void UnityEngine_HingeJoint__set_enablePreprocessing() { ((HingeJoint)_target).enablePreprocessing = (Boolean)_argument; }
        public void UnityEngine_HingeJoint__set_massScale() { ((HingeJoint)_target).massScale = (Single)_argument; }
        public void UnityEngine_HingeJoint__set_name() { ((HingeJoint)_target).name = (String)_argument; }
        public void UnityEngine_HingeJoint__set_useLimits() { ((HingeJoint)_target).useLimits = (Boolean)_argument; }
        public void UnityEngine_HingeJoint__set_useMotor() { ((HingeJoint)_target).useMotor = (Boolean)_argument; }
        public void UnityEngine_HingeJoint__set_useSpring() { ((HingeJoint)_target).useSpring = (Boolean)_argument; }
        public void UnityEngine_Joint2D__set_breakForce() { ((Joint2D)_target).breakForce = (Single)_argument; }
        public void UnityEngine_Joint2D__set_breakTorque() { ((Joint2D)_target).breakTorque = (Single)_argument; }
        public void UnityEngine_Joint2D__set_connectedBody() { ((Joint2D)_target).connectedBody = (Rigidbody2D)_argument; }
        public void UnityEngine_Joint2D__set_enableCollision() { ((Joint2D)_target).enableCollision = (Boolean)_argument; }
        public void UnityEngine_Joint2D__set_enabled() { ((Joint2D)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_Joint2D__set_name() { ((Joint2D)_target).name = (String)_argument; }
        public void UnityEngine_Joint__set_autoConfigureConnectedAnchor() { ((Joint)_target).autoConfigureConnectedAnchor = (Boolean)_argument; }
        public void UnityEngine_Joint__set_breakForce() { ((Joint)_target).breakForce = (Single)_argument; }
        public void UnityEngine_Joint__set_breakTorque() { ((Joint)_target).breakTorque = (Single)_argument; }
        public void UnityEngine_Joint__set_connectedBody() { ((Joint)_target).connectedBody = (Rigidbody)_argument; }
        public void UnityEngine_Joint__set_connectedMassScale() { ((Joint)_target).connectedMassScale = (Single)_argument; }
        public void UnityEngine_Joint__set_enableCollision() { ((Joint)_target).enableCollision = (Boolean)_argument; }
        public void UnityEngine_Joint__set_enablePreprocessing() { ((Joint)_target).enablePreprocessing = (Boolean)_argument; }
        public void UnityEngine_Joint__set_massScale() { ((Joint)_target).massScale = (Single)_argument; }
        public void UnityEngine_Joint__set_name() { ((Joint)_target).name = (String)_argument; }
        public void UnityEngine_Light__Reset() { ((Light)_target).Reset(); }
        public void UnityEngine_Light__set_bounceIntensity() { ((Light)_target).bounceIntensity = (Single)_argument; }
        public void UnityEngine_Light__set_colorTemperature() { ((Light)_target).colorTemperature = (Single)_argument; }
        public void UnityEngine_Light__set_cookieSize() { ((Light)_target).cookieSize = (Single)_argument; }
        public void UnityEngine_Light__set_cookie() { ((Light)_target).cookie = (Texture)_argument; }
        public void UnityEngine_Light__set_cullingMask() { ((Light)_target).cullingMask = (Int32)_argument; }
        public void UnityEngine_Light__set_enabled() { ((Light)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_Light__set_flare() { ((Light)_target).flare = (Flare)_argument; }
        public void UnityEngine_Light__set_intensity() { ((Light)_target).intensity = (Single)_argument; }
        public void UnityEngine_Light__set_name() { ((Light)_target).name = (String)_argument; }
        public void UnityEngine_Light__set_range() { ((Light)_target).range = (Single)_argument; }
        public void UnityEngine_Light__set_shadowBias() { ((Light)_target).shadowBias = (Single)_argument; }
        public void UnityEngine_Light__set_shadowCustomResolution() { ((Light)_target).shadowCustomResolution = (Int32)_argument; }
        public void UnityEngine_Light__set_shadowNearPlane() { ((Light)_target).shadowNearPlane = (Single)_argument; }
        public void UnityEngine_Light__set_shadowNormalBias() { ((Light)_target).shadowNormalBias = (Single)_argument; }
        public void UnityEngine_Light__set_shadowStrength() { ((Light)_target).shadowStrength = (Single)_argument; }
        public void UnityEngine_Light__set_spotAngle() { ((Light)_target).spotAngle = (Single)_argument; }
        public void UnityEngine_Light__set_useBoundingSphereOverride() { ((Light)_target).useBoundingSphereOverride = (Boolean)_argument; }
        public void UnityEngine_Light__set_useColorTemperature() { ((Light)_target).useColorTemperature = (Boolean)_argument; }
        public void UnityEngine_Light__set_useShadowMatrixOverride() { ((Light)_target).useShadowMatrixOverride = (Boolean)_argument; }
        public void UnityEngine_LineRenderer__HasPropertyBlock() { ((LineRenderer)_target).HasPropertyBlock(); }
        public void UnityEngine_LineRenderer__Simplify() { ((LineRenderer)_target).Simplify((Single)_argument); }
        public void UnityEngine_LineRenderer__set_allowOcclusionWhenDynamic() { ((LineRenderer)_target).allowOcclusionWhenDynamic = (Boolean)_argument; }
        public void UnityEngine_LineRenderer__set_enabled() { ((LineRenderer)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_LineRenderer__set_endWidth() { ((LineRenderer)_target).endWidth = (Single)_argument; }
        public void UnityEngine_LineRenderer__set_forceRenderingOff() { ((LineRenderer)_target).forceRenderingOff = (Boolean)_argument; }
        public void UnityEngine_LineRenderer__set_generateLightingData() { ((LineRenderer)_target).generateLightingData = (Boolean)_argument; }
        public void UnityEngine_LineRenderer__set_lightProbeProxyVolumeOverride() { ((LineRenderer)_target).lightProbeProxyVolumeOverride = (GameObject)_argument; }
        public void UnityEngine_LineRenderer__set_lightmapIndex() { ((LineRenderer)_target).lightmapIndex = (Int32)_argument; }
        public void UnityEngine_LineRenderer__set_loop() { ((LineRenderer)_target).loop = (Boolean)_argument; }
        public void UnityEngine_LineRenderer__set_material() { ((LineRenderer)_target).material = (Material)_argument; }
        public void UnityEngine_LineRenderer__set_name() { ((LineRenderer)_target).name = (String)_argument; }
        public void UnityEngine_LineRenderer__set_numCapVertices() { ((LineRenderer)_target).numCapVertices = (Int32)_argument; }
        public void UnityEngine_LineRenderer__set_numCornerVertices() { ((LineRenderer)_target).numCornerVertices = (Int32)_argument; }
        public void UnityEngine_LineRenderer__set_positionCount() { ((LineRenderer)_target).positionCount = (Int32)_argument; }
        public void UnityEngine_LineRenderer__set_probeAnchor() { ((LineRenderer)_target).probeAnchor = (Transform)_argument; }
        public void UnityEngine_LineRenderer__set_realtimeLightmapIndex() { ((LineRenderer)_target).realtimeLightmapIndex = (Int32)_argument; }
        public void UnityEngine_LineRenderer__set_receiveShadows() { ((LineRenderer)_target).receiveShadows = (Boolean)_argument; }
        public void UnityEngine_LineRenderer__set_rendererPriority() { ((LineRenderer)_target).rendererPriority = (Int32)_argument; }
        public void UnityEngine_LineRenderer__set_shadowBias() { ((LineRenderer)_target).shadowBias = (Single)_argument; }
        public void UnityEngine_LineRenderer__set_sharedMaterial() { ((LineRenderer)_target).sharedMaterial = (Material)_argument; }
        public void UnityEngine_LineRenderer__set_sortingLayerID() { ((LineRenderer)_target).sortingLayerID = (Int32)_argument; }
        public void UnityEngine_LineRenderer__set_sortingLayerName() { ((LineRenderer)_target).sortingLayerName = (String)_argument; }
        public void UnityEngine_LineRenderer__set_sortingOrder() { ((LineRenderer)_target).sortingOrder = (Int32)_argument; }
        public void UnityEngine_LineRenderer__set_startWidth() { ((LineRenderer)_target).startWidth = (Single)_argument; }
        public void UnityEngine_LineRenderer__set_useWorldSpace() { ((LineRenderer)_target).useWorldSpace = (Boolean)_argument; }
        public void UnityEngine_LineRenderer__set_widthMultiplier() { ((LineRenderer)_target).widthMultiplier = (Single)_argument; }
        public void UnityEngine_MeshCollider__set_contactOffset() { ((MeshCollider)_target).contactOffset = (Single)_argument; }
        public void UnityEngine_MeshCollider__set_convex() { ((MeshCollider)_target).convex = (Boolean)_argument; }
        public void UnityEngine_MeshCollider__set_enabled() { ((MeshCollider)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_MeshCollider__set_isTrigger() { ((MeshCollider)_target).isTrigger = (Boolean)_argument; }
        public void UnityEngine_MeshCollider__set_material() { ((MeshCollider)_target).material = (PhysicMaterial)_argument; }
        public void UnityEngine_MeshCollider__set_name() { ((MeshCollider)_target).name = (String)_argument; }
        public void UnityEngine_MeshCollider__set_sharedMaterial() { ((MeshCollider)_target).sharedMaterial = (PhysicMaterial)_argument; }
        public void UnityEngine_MeshCollider__set_sharedMesh() { ((MeshCollider)_target).sharedMesh = (Mesh)_argument; }
        public void UnityEngine_MeshFilter__set_mesh() { ((MeshFilter)_target).mesh = (Mesh)_argument; }
        public void UnityEngine_MeshFilter__set_name() { ((MeshFilter)_target).name = (String)_argument; }
        public void UnityEngine_MeshFilter__set_sharedMesh() { ((MeshFilter)_target).sharedMesh = (Mesh)_argument; }
        public void UnityEngine_MeshRenderer__HasPropertyBlock() { ((MeshRenderer)_target).HasPropertyBlock(); }
        public void UnityEngine_MeshRenderer__set_additionalVertexStreams() { ((MeshRenderer)_target).additionalVertexStreams = (Mesh)_argument; }
        public void UnityEngine_MeshRenderer__set_allowOcclusionWhenDynamic() { ((MeshRenderer)_target).allowOcclusionWhenDynamic = (Boolean)_argument; }
        public void UnityEngine_MeshRenderer__set_enabled() { ((MeshRenderer)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_MeshRenderer__set_forceRenderingOff() { ((MeshRenderer)_target).forceRenderingOff = (Boolean)_argument; }
        public void UnityEngine_MeshRenderer__set_lightProbeProxyVolumeOverride() { ((MeshRenderer)_target).lightProbeProxyVolumeOverride = (GameObject)_argument; }
        public void UnityEngine_MeshRenderer__set_lightmapIndex() { ((MeshRenderer)_target).lightmapIndex = (Int32)_argument; }
        public void UnityEngine_MeshRenderer__set_material() { ((MeshRenderer)_target).material = (Material)_argument; }
        public void UnityEngine_MeshRenderer__set_name() { ((MeshRenderer)_target).name = (String)_argument; }
        public void UnityEngine_MeshRenderer__set_probeAnchor() { ((MeshRenderer)_target).probeAnchor = (Transform)_argument; }
        public void UnityEngine_MeshRenderer__set_realtimeLightmapIndex() { ((MeshRenderer)_target).realtimeLightmapIndex = (Int32)_argument; }
        public void UnityEngine_MeshRenderer__set_receiveShadows() { ((MeshRenderer)_target).receiveShadows = (Boolean)_argument; }
        public void UnityEngine_MeshRenderer__set_rendererPriority() { ((MeshRenderer)_target).rendererPriority = (Int32)_argument; }
        public void UnityEngine_MeshRenderer__set_sharedMaterial() { ((MeshRenderer)_target).sharedMaterial = (Material)_argument; }
        public void UnityEngine_MeshRenderer__set_sortingLayerID() { ((MeshRenderer)_target).sortingLayerID = (Int32)_argument; }
        public void UnityEngine_MeshRenderer__set_sortingLayerName() { ((MeshRenderer)_target).sortingLayerName = (String)_argument; }
        public void UnityEngine_MeshRenderer__set_sortingOrder() { ((MeshRenderer)_target).sortingOrder = (Int32)_argument; }
        public void UnityEngine_OcclusionPortal__set_name() { ((OcclusionPortal)_target).name = (String)_argument; }
        public void UnityEngine_OcclusionPortal__set_open() { ((OcclusionPortal)_target).open = (Boolean)_argument; }
        public void UnityEngine_ParticleSystem__Clear() { if (_argument.GetType().Equals(typeof(System.Boolean))) { ((ParticleSystem)_target).Clear((Boolean)_argument); } else { ((ParticleSystem)_target).Clear(); } }
        public void UnityEngine_ParticleSystem__Emit() { ((ParticleSystem)_target).Emit((Int32)_argument); }
        public void UnityEngine_ParticleSystem__Pause() { if (_argument.GetType().Equals(typeof(System.Boolean))) { ((ParticleSystem)_target).Pause((Boolean)_argument); } else { ((ParticleSystem)_target).Pause(); } }
        public void UnityEngine_ParticleSystem__Play() { if (_argument.GetType().Equals(typeof(System.Boolean))) { ((ParticleSystem)_target).Play((Boolean)_argument); } else { ((ParticleSystem)_target).Play(); } }
        public void UnityEngine_ParticleSystem__Simulate() { ((ParticleSystem)_target).Simulate((Single)_argument); }
        public void UnityEngine_ParticleSystem__Stop() { if (_argument.GetType().Equals(typeof(System.Boolean))) { ((ParticleSystem)_target).Stop((Boolean)_argument); } else { ((ParticleSystem)_target).Stop(); } }
        public void UnityEngine_ParticleSystem__TriggerSubEmitter() { ((ParticleSystem)_target).TriggerSubEmitter((Int32)_argument); }
        public void UnityEngine_ParticleSystem__set_name() { ((ParticleSystem)_target).name = (String)_argument; }
        public void UnityEngine_ParticleSystem__set_time() { ((ParticleSystem)_target).time = (Single)_argument; }
        public void UnityEngine_ParticleSystem__set_useAutoRandomSeed() { ((ParticleSystem)_target).useAutoRandomSeed = (Boolean)_argument; }
        public void UnityEngine_ParticleSystemRenderer__HasPropertyBlock() { ((ParticleSystemRenderer)_target).HasPropertyBlock(); }
        public void UnityEngine_ParticleSystemRenderer__set_allowOcclusionWhenDynamic() { ((ParticleSystemRenderer)_target).allowOcclusionWhenDynamic = (Boolean)_argument; }
        public void UnityEngine_ParticleSystemRenderer__set_allowRoll() { ((ParticleSystemRenderer)_target).allowRoll = (Boolean)_argument; }
        public void UnityEngine_ParticleSystemRenderer__set_cameraVelocityScale() { ((ParticleSystemRenderer)_target).cameraVelocityScale = (Single)_argument; }
        public void UnityEngine_ParticleSystemRenderer__set_enableGPUInstancing() { ((ParticleSystemRenderer)_target).enableGPUInstancing = (Boolean)_argument; }
        public void UnityEngine_ParticleSystemRenderer__set_enabled() { ((ParticleSystemRenderer)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_ParticleSystemRenderer__set_forceRenderingOff() { ((ParticleSystemRenderer)_target).forceRenderingOff = (Boolean)_argument; }
        public void UnityEngine_ParticleSystemRenderer__set_lengthScale() { ((ParticleSystemRenderer)_target).lengthScale = (Single)_argument; }
        public void UnityEngine_ParticleSystemRenderer__set_lightProbeProxyVolumeOverride() { ((ParticleSystemRenderer)_target).lightProbeProxyVolumeOverride = (GameObject)_argument; }
        public void UnityEngine_ParticleSystemRenderer__set_lightmapIndex() { ((ParticleSystemRenderer)_target).lightmapIndex = (Int32)_argument; }
        public void UnityEngine_ParticleSystemRenderer__set_material() { ((ParticleSystemRenderer)_target).material = (Material)_argument; }
        public void UnityEngine_ParticleSystemRenderer__set_maxParticleSize() { ((ParticleSystemRenderer)_target).maxParticleSize = (Single)_argument; }
        public void UnityEngine_ParticleSystemRenderer__set_mesh() { ((ParticleSystemRenderer)_target).mesh = (Mesh)_argument; }
        public void UnityEngine_ParticleSystemRenderer__set_minParticleSize() { ((ParticleSystemRenderer)_target).minParticleSize = (Single)_argument; }
        public void UnityEngine_ParticleSystemRenderer__set_name() { ((ParticleSystemRenderer)_target).name = (String)_argument; }
        public void UnityEngine_ParticleSystemRenderer__set_normalDirection() { ((ParticleSystemRenderer)_target).normalDirection = (Single)_argument; }
        public void UnityEngine_ParticleSystemRenderer__set_probeAnchor() { ((ParticleSystemRenderer)_target).probeAnchor = (Transform)_argument; }
        public void UnityEngine_ParticleSystemRenderer__set_realtimeLightmapIndex() { ((ParticleSystemRenderer)_target).realtimeLightmapIndex = (Int32)_argument; }
        public void UnityEngine_ParticleSystemRenderer__set_receiveShadows() { ((ParticleSystemRenderer)_target).receiveShadows = (Boolean)_argument; }
        public void UnityEngine_ParticleSystemRenderer__set_rendererPriority() { ((ParticleSystemRenderer)_target).rendererPriority = (Int32)_argument; }
        public void UnityEngine_ParticleSystemRenderer__set_shadowBias() { ((ParticleSystemRenderer)_target).shadowBias = (Single)_argument; }
        public void UnityEngine_ParticleSystemRenderer__set_sharedMaterial() { ((ParticleSystemRenderer)_target).sharedMaterial = (Material)_argument; }
        public void UnityEngine_ParticleSystemRenderer__set_sortingFudge() { ((ParticleSystemRenderer)_target).sortingFudge = (Single)_argument; }
        public void UnityEngine_ParticleSystemRenderer__set_sortingLayerID() { ((ParticleSystemRenderer)_target).sortingLayerID = (Int32)_argument; }
        public void UnityEngine_ParticleSystemRenderer__set_sortingLayerName() { ((ParticleSystemRenderer)_target).sortingLayerName = (String)_argument; }
        public void UnityEngine_ParticleSystemRenderer__set_sortingOrder() { ((ParticleSystemRenderer)_target).sortingOrder = (Int32)_argument; }
        public void UnityEngine_ParticleSystemRenderer__set_trailMaterial() { ((ParticleSystemRenderer)_target).trailMaterial = (Material)_argument; }
        public void UnityEngine_ParticleSystemRenderer__set_velocityScale() { ((ParticleSystemRenderer)_target).velocityScale = (Single)_argument; }
        public void UnityEngine_PlatformEffector2D__set_colliderMask() { ((PlatformEffector2D)_target).colliderMask = (Int32)_argument; }
        public void UnityEngine_PlatformEffector2D__set_enabled() { ((PlatformEffector2D)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_PlatformEffector2D__set_name() { ((PlatformEffector2D)_target).name = (String)_argument; }
        public void UnityEngine_PlatformEffector2D__set_rotationalOffset() { ((PlatformEffector2D)_target).rotationalOffset = (Single)_argument; }
        public void UnityEngine_PlatformEffector2D__set_sideArc() { ((PlatformEffector2D)_target).sideArc = (Single)_argument; }
        public void UnityEngine_PlatformEffector2D__set_surfaceArc() { ((PlatformEffector2D)_target).surfaceArc = (Single)_argument; }
        public void UnityEngine_PlatformEffector2D__set_useColliderMask() { ((PlatformEffector2D)_target).useColliderMask = (Boolean)_argument; }
        public void UnityEngine_PlatformEffector2D__set_useOneWayGrouping() { ((PlatformEffector2D)_target).useOneWayGrouping = (Boolean)_argument; }
        public void UnityEngine_PlatformEffector2D__set_useOneWay() { ((PlatformEffector2D)_target).useOneWay = (Boolean)_argument; }
        public void UnityEngine_PlatformEffector2D__set_useSideBounce() { ((PlatformEffector2D)_target).useSideBounce = (Boolean)_argument; }
        public void UnityEngine_PlatformEffector2D__set_useSideFriction() { ((PlatformEffector2D)_target).useSideFriction = (Boolean)_argument; }
        public void UnityEngine_Playables_PlayableDirector__DeferredEvaluate() { ((PlayableDirector)_target).DeferredEvaluate(); }
        public void UnityEngine_Playables_PlayableDirector__Evaluate() { ((PlayableDirector)_target).Evaluate(); }
        public void UnityEngine_Playables_PlayableDirector__Pause() { ((PlayableDirector)_target).Pause(); }
        public void UnityEngine_Playables_PlayableDirector__Play() { ((PlayableDirector)_target).Play(); }
        public void UnityEngine_Playables_PlayableDirector__Resume() { ((PlayableDirector)_target).Resume(); }
        public void UnityEngine_Playables_PlayableDirector__Stop() { ((PlayableDirector)_target).Stop(); }
        public void UnityEngine_Playables_PlayableDirector__set_enabled() { ((PlayableDirector)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_Playables_PlayableDirector__set_name() { ((PlayableDirector)_target).name = (String)_argument; }
        public void UnityEngine_Playables_PlayableDirector__set_playOnAwake() { ((PlayableDirector)_target).playOnAwake = (Boolean)_argument; }
        public void UnityEngine_PointEffector2D__set_angularDrag() { ((PointEffector2D)_target).angularDrag = (Single)_argument; }
        public void UnityEngine_PointEffector2D__set_colliderMask() { ((PointEffector2D)_target).colliderMask = (Int32)_argument; }
        public void UnityEngine_PointEffector2D__set_distanceScale() { ((PointEffector2D)_target).distanceScale = (Single)_argument; }
        public void UnityEngine_PointEffector2D__set_drag() { ((PointEffector2D)_target).drag = (Single)_argument; }
        public void UnityEngine_PointEffector2D__set_enabled() { ((PointEffector2D)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_PointEffector2D__set_forceMagnitude() { ((PointEffector2D)_target).forceMagnitude = (Single)_argument; }
        public void UnityEngine_PointEffector2D__set_forceVariation() { ((PointEffector2D)_target).forceVariation = (Single)_argument; }
        public void UnityEngine_PointEffector2D__set_name() { ((PointEffector2D)_target).name = (String)_argument; }
        public void UnityEngine_PointEffector2D__set_useColliderMask() { ((PointEffector2D)_target).useColliderMask = (Boolean)_argument; }
        public void UnityEngine_PolygonCollider2D__Distance() { ((PolygonCollider2D)_target).Distance((Collider2D)_argument); }
        public void UnityEngine_PolygonCollider2D__set_autoTiling() { ((PolygonCollider2D)_target).autoTiling = (Boolean)_argument; }
        public void UnityEngine_PolygonCollider2D__set_density() { ((PolygonCollider2D)_target).density = (Single)_argument; }
        public void UnityEngine_PolygonCollider2D__set_enabled() { ((PolygonCollider2D)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_PolygonCollider2D__set_isTrigger() { ((PolygonCollider2D)_target).isTrigger = (Boolean)_argument; }
        public void UnityEngine_PolygonCollider2D__set_name() { ((PolygonCollider2D)_target).name = (String)_argument; }
        public void UnityEngine_PolygonCollider2D__set_pathCount() { ((PolygonCollider2D)_target).pathCount = (Int32)_argument; }
        public void UnityEngine_PolygonCollider2D__set_sharedMaterial() { ((PolygonCollider2D)_target).sharedMaterial = (PhysicsMaterial2D)_argument; }
        public void UnityEngine_PolygonCollider2D__set_usedByComposite() { ((PolygonCollider2D)_target).usedByComposite = (Boolean)_argument; }
        public void UnityEngine_PolygonCollider2D__set_usedByEffector() { ((PolygonCollider2D)_target).usedByEffector = (Boolean)_argument; }
        public void UnityEngine_RectTransform__DetachChildren() { ((RectTransform)_target).DetachChildren(); }
        public void UnityEngine_RectTransform__Find() { ((RectTransform)_target).Find((String)_argument); }
        public void UnityEngine_RectTransform__ForceUpdateRectTransforms() { ((RectTransform)_target).ForceUpdateRectTransforms(); }
        public void UnityEngine_RectTransform__LookAt() { ((RectTransform)_target).LookAt((Transform)_argument); }
        public void UnityEngine_RectTransform__SetAsFirstSibling() { ((RectTransform)_target).SetAsFirstSibling(); }
        public void UnityEngine_RectTransform__SetAsLastSibling() { ((RectTransform)_target).SetAsLastSibling(); }
        public void UnityEngine_RectTransform__SetParent() { ((RectTransform)_target).SetParent((Transform)_argument); }
        public void UnityEngine_RectTransform__SetSiblingIndex() { ((RectTransform)_target).SetSiblingIndex((Int32)_argument); }
        public void UnityEngine_RectTransform__set_hasChanged() { ((RectTransform)_target).hasChanged = (Boolean)_argument; }
        public void UnityEngine_RectTransform__set_hierarchyCapacity() { ((RectTransform)_target).hierarchyCapacity = (Int32)_argument; }
        public void UnityEngine_RectTransform__set_name() { ((RectTransform)_target).name = (String)_argument; }
        public void UnityEngine_RectTransform__set_parent() { ((RectTransform)_target).parent = (Transform)_argument; }
        public void UnityEngine_ReflectionProbe__RenderProbe() { if (_argument.GetType().Equals(typeof(UnityEngine.RenderTexture))) { ((ReflectionProbe)_target).RenderProbe((RenderTexture)_argument); } else { ((ReflectionProbe)_target).RenderProbe(); } }
        public void UnityEngine_ReflectionProbe__Reset() { ((ReflectionProbe)_target).Reset(); }
        public void UnityEngine_ReflectionProbe__set_bakedTexture() { ((ReflectionProbe)_target).bakedTexture = (Texture)_argument; }
        public void UnityEngine_ReflectionProbe__set_blendDistance() { ((ReflectionProbe)_target).blendDistance = (Single)_argument; }
        public void UnityEngine_ReflectionProbe__set_boxProjection() { ((ReflectionProbe)_target).boxProjection = (Boolean)_argument; }
        public void UnityEngine_ReflectionProbe__set_cullingMask() { ((ReflectionProbe)_target).cullingMask = (Int32)_argument; }
        public void UnityEngine_ReflectionProbe__set_customBakedTexture() { ((ReflectionProbe)_target).customBakedTexture = (Texture)_argument; }
        public void UnityEngine_ReflectionProbe__set_enabled() { ((ReflectionProbe)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_ReflectionProbe__set_farClipPlane() { ((ReflectionProbe)_target).farClipPlane = (Single)_argument; }
        public void UnityEngine_ReflectionProbe__set_hdr() { ((ReflectionProbe)_target).hdr = (Boolean)_argument; }
        public void UnityEngine_ReflectionProbe__set_importance() { ((ReflectionProbe)_target).importance = (Int32)_argument; }
        public void UnityEngine_ReflectionProbe__set_intensity() { ((ReflectionProbe)_target).intensity = (Single)_argument; }
        public void UnityEngine_ReflectionProbe__set_name() { ((ReflectionProbe)_target).name = (String)_argument; }
        public void UnityEngine_ReflectionProbe__set_nearClipPlane() { ((ReflectionProbe)_target).nearClipPlane = (Single)_argument; }
        public void UnityEngine_ReflectionProbe__set_realtimeTexture() { ((ReflectionProbe)_target).realtimeTexture = (RenderTexture)_argument; }
        public void UnityEngine_ReflectionProbe__set_resolution() { ((ReflectionProbe)_target).resolution = (Int32)_argument; }
        public void UnityEngine_ReflectionProbe__set_shadowDistance() { ((ReflectionProbe)_target).shadowDistance = (Single)_argument; }
        public void UnityEngine_RelativeJoint2D__set_angularOffset() { ((RelativeJoint2D)_target).angularOffset = (Single)_argument; }
        public void UnityEngine_RelativeJoint2D__set_autoConfigureOffset() { ((RelativeJoint2D)_target).autoConfigureOffset = (Boolean)_argument; }
        public void UnityEngine_RelativeJoint2D__set_breakForce() { ((RelativeJoint2D)_target).breakForce = (Single)_argument; }
        public void UnityEngine_RelativeJoint2D__set_breakTorque() { ((RelativeJoint2D)_target).breakTorque = (Single)_argument; }
        public void UnityEngine_RelativeJoint2D__set_connectedBody() { ((RelativeJoint2D)_target).connectedBody = (Rigidbody2D)_argument; }
        public void UnityEngine_RelativeJoint2D__set_correctionScale() { ((RelativeJoint2D)_target).correctionScale = (Single)_argument; }
        public void UnityEngine_RelativeJoint2D__set_enableCollision() { ((RelativeJoint2D)_target).enableCollision = (Boolean)_argument; }
        public void UnityEngine_RelativeJoint2D__set_enabled() { ((RelativeJoint2D)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_RelativeJoint2D__set_maxForce() { ((RelativeJoint2D)_target).maxForce = (Single)_argument; }
        public void UnityEngine_RelativeJoint2D__set_maxTorque() { ((RelativeJoint2D)_target).maxTorque = (Single)_argument; }
        public void UnityEngine_RelativeJoint2D__set_name() { ((RelativeJoint2D)_target).name = (String)_argument; }
        public void UnityEngine_Renderer__HasPropertyBlock() { ((Renderer)_target).HasPropertyBlock(); }
        public void UnityEngine_Renderer__set_allowOcclusionWhenDynamic() { ((Renderer)_target).allowOcclusionWhenDynamic = (Boolean)_argument; }
        public void UnityEngine_Renderer__set_enabled() { ((Renderer)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_Renderer__set_forceRenderingOff() { ((Renderer)_target).forceRenderingOff = (Boolean)_argument; }
        public void UnityEngine_Renderer__set_lightProbeProxyVolumeOverride() { ((Renderer)_target).lightProbeProxyVolumeOverride = (GameObject)_argument; }
        public void UnityEngine_Renderer__set_lightmapIndex() { ((Renderer)_target).lightmapIndex = (Int32)_argument; }
        public void UnityEngine_Renderer__set_material() { ((Renderer)_target).material = (Material)_argument; }
        public void UnityEngine_Renderer__set_name() { ((Renderer)_target).name = (String)_argument; }
        public void UnityEngine_Renderer__set_probeAnchor() { ((Renderer)_target).probeAnchor = (Transform)_argument; }
        public void UnityEngine_Renderer__set_realtimeLightmapIndex() { ((Renderer)_target).realtimeLightmapIndex = (Int32)_argument; }
        public void UnityEngine_Renderer__set_receiveShadows() { ((Renderer)_target).receiveShadows = (Boolean)_argument; }
        public void UnityEngine_Renderer__set_rendererPriority() { ((Renderer)_target).rendererPriority = (Int32)_argument; }
        public void UnityEngine_Renderer__set_sharedMaterial() { ((Renderer)_target).sharedMaterial = (Material)_argument; }
        public void UnityEngine_Renderer__set_sortingLayerID() { ((Renderer)_target).sortingLayerID = (Int32)_argument; }
        public void UnityEngine_Renderer__set_sortingLayerName() { ((Renderer)_target).sortingLayerName = (String)_argument; }
        public void UnityEngine_Renderer__set_sortingOrder() { ((Renderer)_target).sortingOrder = (Int32)_argument; }
        public void UnityEngine_Rendering_PostProcessing_PostProcessVolume__set_blendDistance() { ((PostProcessVolume)_target).blendDistance = (Single)_argument; }
        public void UnityEngine_Rendering_PostProcessing_PostProcessVolume__set_enabled() { ((PostProcessVolume)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_Rendering_PostProcessing_PostProcessVolume__set_isGlobal() { ((PostProcessVolume)_target).isGlobal = (Boolean)_argument; }
        public void UnityEngine_Rendering_PostProcessing_PostProcessVolume__set_name() { ((PostProcessVolume)_target).name = (String)_argument; }
        public void UnityEngine_Rendering_PostProcessing_PostProcessVolume__set_priority() { ((PostProcessVolume)_target).priority = (Single)_argument; }
        public void UnityEngine_Rendering_PostProcessing_PostProcessVolume__set_weight() { ((PostProcessVolume)_target).weight = (Single)_argument; }
        public void UnityEngine_Rigidbody2D__AddTorque() { ((Rigidbody2D)_target).AddTorque((Single)_argument); }
        public void UnityEngine_Rigidbody2D__Distance() { ((Rigidbody2D)_target).Distance((Collider2D)_argument); }
        public void UnityEngine_Rigidbody2D__MoveRotation() { ((Rigidbody2D)_target).MoveRotation((Single)_argument); }
        public void UnityEngine_Rigidbody2D__SetRotation() { ((Rigidbody2D)_target).SetRotation((Single)_argument); }
        public void UnityEngine_Rigidbody2D__Sleep() { ((Rigidbody2D)_target).Sleep(); }
        public void UnityEngine_Rigidbody2D__WakeUp() { ((Rigidbody2D)_target).WakeUp(); }
        public void UnityEngine_Rigidbody2D__set_angularDrag() { ((Rigidbody2D)_target).angularDrag = (Single)_argument; }
        public void UnityEngine_Rigidbody2D__set_angularVelocity() { ((Rigidbody2D)_target).angularVelocity = (Single)_argument; }
        public void UnityEngine_Rigidbody2D__set_drag() { ((Rigidbody2D)_target).drag = (Single)_argument; }
        public void UnityEngine_Rigidbody2D__set_freezeRotation() { ((Rigidbody2D)_target).freezeRotation = (Boolean)_argument; }
        public void UnityEngine_Rigidbody2D__set_gravityScale() { ((Rigidbody2D)_target).gravityScale = (Single)_argument; }
        public void UnityEngine_Rigidbody2D__set_inertia() { ((Rigidbody2D)_target).inertia = (Single)_argument; }
        public void UnityEngine_Rigidbody2D__set_isKinematic() { ((Rigidbody2D)_target).isKinematic = (Boolean)_argument; }
        public void UnityEngine_Rigidbody2D__set_mass() { ((Rigidbody2D)_target).mass = (Single)_argument; }
        public void UnityEngine_Rigidbody2D__set_name() { ((Rigidbody2D)_target).name = (String)_argument; }
        public void UnityEngine_Rigidbody2D__set_rotation() { ((Rigidbody2D)_target).rotation = (Single)_argument; }
        public void UnityEngine_Rigidbody2D__set_sharedMaterial() { ((Rigidbody2D)_target).sharedMaterial = (PhysicsMaterial2D)_argument; }
        public void UnityEngine_Rigidbody2D__set_simulated() { ((Rigidbody2D)_target).simulated = (Boolean)_argument; }
        public void UnityEngine_Rigidbody2D__set_useAutoMass() { ((Rigidbody2D)_target).useAutoMass = (Boolean)_argument; }
        public void UnityEngine_Rigidbody2D__set_useFullKinematicContacts() { ((Rigidbody2D)_target).useFullKinematicContacts = (Boolean)_argument; }
        public void UnityEngine_Rigidbody__ResetCenterOfMass() { ((Rigidbody)_target).ResetCenterOfMass(); }
        public void UnityEngine_Rigidbody__ResetInertiaTensor() { ((Rigidbody)_target).ResetInertiaTensor(); }
        public void UnityEngine_Rigidbody__SetDensity() { ((Rigidbody)_target).SetDensity((Single)_argument); }
        public void UnityEngine_Rigidbody__Sleep() { ((Rigidbody)_target).Sleep(); }
        public void UnityEngine_Rigidbody__WakeUp() { ((Rigidbody)_target).WakeUp(); }
        public void UnityEngine_Rigidbody__set_angularDrag() { ((Rigidbody)_target).angularDrag = (Single)_argument; }
        public void UnityEngine_Rigidbody__set_detectCollisions() { ((Rigidbody)_target).detectCollisions = (Boolean)_argument; }
        public void UnityEngine_Rigidbody__set_drag() { ((Rigidbody)_target).drag = (Single)_argument; }
        public void UnityEngine_Rigidbody__set_freezeRotation() { ((Rigidbody)_target).freezeRotation = (Boolean)_argument; }
        public void UnityEngine_Rigidbody__set_isKinematic() { ((Rigidbody)_target).isKinematic = (Boolean)_argument; }
        public void UnityEngine_Rigidbody__set_mass() { ((Rigidbody)_target).mass = (Single)_argument; }
        public void UnityEngine_Rigidbody__set_maxAngularVelocity() { ((Rigidbody)_target).maxAngularVelocity = (Single)_argument; }
        public void UnityEngine_Rigidbody__set_maxDepenetrationVelocity() { ((Rigidbody)_target).maxDepenetrationVelocity = (Single)_argument; }
        public void UnityEngine_Rigidbody__set_name() { ((Rigidbody)_target).name = (String)_argument; }
        public void UnityEngine_Rigidbody__set_solverIterations() { ((Rigidbody)_target).solverIterations = (Int32)_argument; }
        public void UnityEngine_Rigidbody__set_solverVelocityIterations() { ((Rigidbody)_target).solverVelocityIterations = (Int32)_argument; }
        public void UnityEngine_Rigidbody__set_useGravity() { ((Rigidbody)_target).useGravity = (Boolean)_argument; }
        public void UnityEngine_SkinnedMeshRenderer__BakeMesh() { ((SkinnedMeshRenderer)_target).BakeMesh((Mesh)_argument); }
        public void UnityEngine_SkinnedMeshRenderer__HasPropertyBlock() { ((SkinnedMeshRenderer)_target).HasPropertyBlock(); }
        public void UnityEngine_SkinnedMeshRenderer__set_allowOcclusionWhenDynamic() { ((SkinnedMeshRenderer)_target).allowOcclusionWhenDynamic = (Boolean)_argument; }
        public void UnityEngine_SkinnedMeshRenderer__set_enabled() { ((SkinnedMeshRenderer)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_SkinnedMeshRenderer__set_forceMatrixRecalculationPerRender() { ((SkinnedMeshRenderer)_target).forceMatrixRecalculationPerRender = (Boolean)_argument; }
        public void UnityEngine_SkinnedMeshRenderer__set_forceRenderingOff() { ((SkinnedMeshRenderer)_target).forceRenderingOff = (Boolean)_argument; }
        public void UnityEngine_SkinnedMeshRenderer__set_lightProbeProxyVolumeOverride() { ((SkinnedMeshRenderer)_target).lightProbeProxyVolumeOverride = (GameObject)_argument; }
        public void UnityEngine_SkinnedMeshRenderer__set_lightmapIndex() { ((SkinnedMeshRenderer)_target).lightmapIndex = (Int32)_argument; }
        public void UnityEngine_SkinnedMeshRenderer__set_material() { ((SkinnedMeshRenderer)_target).material = (Material)_argument; }
        public void UnityEngine_SkinnedMeshRenderer__set_name() { ((SkinnedMeshRenderer)_target).name = (String)_argument; }
        public void UnityEngine_SkinnedMeshRenderer__set_probeAnchor() { ((SkinnedMeshRenderer)_target).probeAnchor = (Transform)_argument; }
        public void UnityEngine_SkinnedMeshRenderer__set_realtimeLightmapIndex() { ((SkinnedMeshRenderer)_target).realtimeLightmapIndex = (Int32)_argument; }
        public void UnityEngine_SkinnedMeshRenderer__set_receiveShadows() { ((SkinnedMeshRenderer)_target).receiveShadows = (Boolean)_argument; }
        public void UnityEngine_SkinnedMeshRenderer__set_rendererPriority() { ((SkinnedMeshRenderer)_target).rendererPriority = (Int32)_argument; }
        public void UnityEngine_SkinnedMeshRenderer__set_rootBone() { ((SkinnedMeshRenderer)_target).rootBone = (Transform)_argument; }
        public void UnityEngine_SkinnedMeshRenderer__set_sharedMaterial() { ((SkinnedMeshRenderer)_target).sharedMaterial = (Material)_argument; }
        public void UnityEngine_SkinnedMeshRenderer__set_sharedMesh() { ((SkinnedMeshRenderer)_target).sharedMesh = (Mesh)_argument; }
        public void UnityEngine_SkinnedMeshRenderer__set_skinnedMotionVectors() { ((SkinnedMeshRenderer)_target).skinnedMotionVectors = (Boolean)_argument; }
        public void UnityEngine_SkinnedMeshRenderer__set_sortingLayerID() { ((SkinnedMeshRenderer)_target).sortingLayerID = (Int32)_argument; }
        public void UnityEngine_SkinnedMeshRenderer__set_sortingLayerName() { ((SkinnedMeshRenderer)_target).sortingLayerName = (String)_argument; }
        public void UnityEngine_SkinnedMeshRenderer__set_sortingOrder() { ((SkinnedMeshRenderer)_target).sortingOrder = (Int32)_argument; }
        public void UnityEngine_SkinnedMeshRenderer__set_updateWhenOffscreen() { ((SkinnedMeshRenderer)_target).updateWhenOffscreen = (Boolean)_argument; }
        public void UnityEngine_SliderJoint2D__set_angle() { ((SliderJoint2D)_target).angle = (Single)_argument; }
        public void UnityEngine_SliderJoint2D__set_autoConfigureAngle() { ((SliderJoint2D)_target).autoConfigureAngle = (Boolean)_argument; }
        public void UnityEngine_SliderJoint2D__set_autoConfigureConnectedAnchor() { ((SliderJoint2D)_target).autoConfigureConnectedAnchor = (Boolean)_argument; }
        public void UnityEngine_SliderJoint2D__set_breakForce() { ((SliderJoint2D)_target).breakForce = (Single)_argument; }
        public void UnityEngine_SliderJoint2D__set_breakTorque() { ((SliderJoint2D)_target).breakTorque = (Single)_argument; }
        public void UnityEngine_SliderJoint2D__set_connectedBody() { ((SliderJoint2D)_target).connectedBody = (Rigidbody2D)_argument; }
        public void UnityEngine_SliderJoint2D__set_enableCollision() { ((SliderJoint2D)_target).enableCollision = (Boolean)_argument; }
        public void UnityEngine_SliderJoint2D__set_enabled() { ((SliderJoint2D)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_SliderJoint2D__set_name() { ((SliderJoint2D)_target).name = (String)_argument; }
        public void UnityEngine_SliderJoint2D__set_useLimits() { ((SliderJoint2D)_target).useLimits = (Boolean)_argument; }
        public void UnityEngine_SliderJoint2D__set_useMotor() { ((SliderJoint2D)_target).useMotor = (Boolean)_argument; }
        public void UnityEngine_SphereCollider__set_contactOffset() { ((SphereCollider)_target).contactOffset = (Single)_argument; }
        public void UnityEngine_SphereCollider__set_enabled() { ((SphereCollider)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_SphereCollider__set_isTrigger() { ((SphereCollider)_target).isTrigger = (Boolean)_argument; }
        public void UnityEngine_SphereCollider__set_material() { ((SphereCollider)_target).material = (PhysicMaterial)_argument; }
        public void UnityEngine_SphereCollider__set_name() { ((SphereCollider)_target).name = (String)_argument; }
        public void UnityEngine_SphereCollider__set_radius() { ((SphereCollider)_target).radius = (Single)_argument; }
        public void UnityEngine_SphereCollider__set_sharedMaterial() { ((SphereCollider)_target).sharedMaterial = (PhysicMaterial)_argument; }
        public void UnityEngine_SpringJoint__set_autoConfigureConnectedAnchor() { ((SpringJoint)_target).autoConfigureConnectedAnchor = (Boolean)_argument; }
        public void UnityEngine_SpringJoint__set_breakForce() { ((SpringJoint)_target).breakForce = (Single)_argument; }
        public void UnityEngine_SpringJoint__set_breakTorque() { ((SpringJoint)_target).breakTorque = (Single)_argument; }
        public void UnityEngine_SpringJoint__set_connectedBody() { ((SpringJoint)_target).connectedBody = (Rigidbody)_argument; }
        public void UnityEngine_SpringJoint__set_connectedMassScale() { ((SpringJoint)_target).connectedMassScale = (Single)_argument; }
        public void UnityEngine_SpringJoint__set_damper() { ((SpringJoint)_target).damper = (Single)_argument; }
        public void UnityEngine_SpringJoint__set_enableCollision() { ((SpringJoint)_target).enableCollision = (Boolean)_argument; }
        public void UnityEngine_SpringJoint__set_enablePreprocessing() { ((SpringJoint)_target).enablePreprocessing = (Boolean)_argument; }
        public void UnityEngine_SpringJoint__set_massScale() { ((SpringJoint)_target).massScale = (Single)_argument; }
        public void UnityEngine_SpringJoint__set_maxDistance() { ((SpringJoint)_target).maxDistance = (Single)_argument; }
        public void UnityEngine_SpringJoint__set_minDistance() { ((SpringJoint)_target).minDistance = (Single)_argument; }
        public void UnityEngine_SpringJoint__set_name() { ((SpringJoint)_target).name = (String)_argument; }
        public void UnityEngine_SpringJoint__set_spring() { ((SpringJoint)_target).spring = (Single)_argument; }
        public void UnityEngine_SpringJoint__set_tolerance() { ((SpringJoint)_target).tolerance = (Single)_argument; }
        public void UnityEngine_SpriteRenderer__HasPropertyBlock() { ((SpriteRenderer)_target).HasPropertyBlock(); }
        public void UnityEngine_SpriteRenderer__set_adaptiveModeThreshold() { ((SpriteRenderer)_target).adaptiveModeThreshold = (Single)_argument; }
        public void UnityEngine_SpriteRenderer__set_allowOcclusionWhenDynamic() { ((SpriteRenderer)_target).allowOcclusionWhenDynamic = (Boolean)_argument; }
        public void UnityEngine_SpriteRenderer__set_enabled() { ((SpriteRenderer)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_SpriteRenderer__set_flipX() { ((SpriteRenderer)_target).flipX = (Boolean)_argument; }
        public void UnityEngine_SpriteRenderer__set_flipY() { ((SpriteRenderer)_target).flipY = (Boolean)_argument; }
        public void UnityEngine_SpriteRenderer__set_forceRenderingOff() { ((SpriteRenderer)_target).forceRenderingOff = (Boolean)_argument; }
        public void UnityEngine_SpriteRenderer__set_lightProbeProxyVolumeOverride() { ((SpriteRenderer)_target).lightProbeProxyVolumeOverride = (GameObject)_argument; }
        public void UnityEngine_SpriteRenderer__set_lightmapIndex() { ((SpriteRenderer)_target).lightmapIndex = (Int32)_argument; }
        public void UnityEngine_SpriteRenderer__set_material() { ((SpriteRenderer)_target).material = (Material)_argument; }
        public void UnityEngine_SpriteRenderer__set_name() { ((SpriteRenderer)_target).name = (String)_argument; }
        public void UnityEngine_SpriteRenderer__set_probeAnchor() { ((SpriteRenderer)_target).probeAnchor = (Transform)_argument; }
        public void UnityEngine_SpriteRenderer__set_realtimeLightmapIndex() { ((SpriteRenderer)_target).realtimeLightmapIndex = (Int32)_argument; }
        public void UnityEngine_SpriteRenderer__set_receiveShadows() { ((SpriteRenderer)_target).receiveShadows = (Boolean)_argument; }
        public void UnityEngine_SpriteRenderer__set_rendererPriority() { ((SpriteRenderer)_target).rendererPriority = (Int32)_argument; }
        public void UnityEngine_SpriteRenderer__set_sharedMaterial() { ((SpriteRenderer)_target).sharedMaterial = (Material)_argument; }
        public void UnityEngine_SpriteRenderer__set_sortingLayerID() { ((SpriteRenderer)_target).sortingLayerID = (Int32)_argument; }
        public void UnityEngine_SpriteRenderer__set_sortingLayerName() { ((SpriteRenderer)_target).sortingLayerName = (String)_argument; }
        public void UnityEngine_SpriteRenderer__set_sortingOrder() { ((SpriteRenderer)_target).sortingOrder = (Int32)_argument; }
        public void UnityEngine_SpriteRenderer__set_sprite() { ((SpriteRenderer)_target).sprite = (Sprite)_argument; }
        public void UnityEngine_SurfaceEffector2D__set_colliderMask() { ((SurfaceEffector2D)_target).colliderMask = (Int32)_argument; }
        public void UnityEngine_SurfaceEffector2D__set_enabled() { ((SurfaceEffector2D)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_SurfaceEffector2D__set_forceScale() { ((SurfaceEffector2D)_target).forceScale = (Single)_argument; }
        public void UnityEngine_SurfaceEffector2D__set_name() { ((SurfaceEffector2D)_target).name = (String)_argument; }
        public void UnityEngine_SurfaceEffector2D__set_speedVariation() { ((SurfaceEffector2D)_target).speedVariation = (Single)_argument; }
        public void UnityEngine_SurfaceEffector2D__set_speed() { ((SurfaceEffector2D)_target).speed = (Single)_argument; }
        public void UnityEngine_SurfaceEffector2D__set_useBounce() { ((SurfaceEffector2D)_target).useBounce = (Boolean)_argument; }
        public void UnityEngine_SurfaceEffector2D__set_useColliderMask() { ((SurfaceEffector2D)_target).useColliderMask = (Boolean)_argument; }
        public void UnityEngine_SurfaceEffector2D__set_useContactForce() { ((SurfaceEffector2D)_target).useContactForce = (Boolean)_argument; }
        public void UnityEngine_SurfaceEffector2D__set_useFriction() { ((SurfaceEffector2D)_target).useFriction = (Boolean)_argument; }
        public void UnityEngine_TargetJoint2D__set_autoConfigureTarget() { ((TargetJoint2D)_target).autoConfigureTarget = (Boolean)_argument; }
        public void UnityEngine_TargetJoint2D__set_breakForce() { ((TargetJoint2D)_target).breakForce = (Single)_argument; }
        public void UnityEngine_TargetJoint2D__set_breakTorque() { ((TargetJoint2D)_target).breakTorque = (Single)_argument; }
        public void UnityEngine_TargetJoint2D__set_connectedBody() { ((TargetJoint2D)_target).connectedBody = (Rigidbody2D)_argument; }
        public void UnityEngine_TargetJoint2D__set_dampingRatio() { ((TargetJoint2D)_target).dampingRatio = (Single)_argument; }
        public void UnityEngine_TargetJoint2D__set_enableCollision() { ((TargetJoint2D)_target).enableCollision = (Boolean)_argument; }
        public void UnityEngine_TargetJoint2D__set_enabled() { ((TargetJoint2D)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_TargetJoint2D__set_frequency() { ((TargetJoint2D)_target).frequency = (Single)_argument; }
        public void UnityEngine_TargetJoint2D__set_maxForce() { ((TargetJoint2D)_target).maxForce = (Single)_argument; }
        public void UnityEngine_TargetJoint2D__set_name() { ((TargetJoint2D)_target).name = (String)_argument; }
        public void UnityEngine_TrailRenderer__Clear() { ((TrailRenderer)_target).Clear(); }
        public void UnityEngine_TrailRenderer__HasPropertyBlock() { ((TrailRenderer)_target).HasPropertyBlock(); }
        public void UnityEngine_TrailRenderer__set_allowOcclusionWhenDynamic() { ((TrailRenderer)_target).allowOcclusionWhenDynamic = (Boolean)_argument; }
        public void UnityEngine_TrailRenderer__set_autodestruct() { ((TrailRenderer)_target).autodestruct = (Boolean)_argument; }
        public void UnityEngine_TrailRenderer__set_emitting() { ((TrailRenderer)_target).emitting = (Boolean)_argument; }
        public void UnityEngine_TrailRenderer__set_enabled() { ((TrailRenderer)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_TrailRenderer__set_endWidth() { ((TrailRenderer)_target).endWidth = (Single)_argument; }
        public void UnityEngine_TrailRenderer__set_forceRenderingOff() { ((TrailRenderer)_target).forceRenderingOff = (Boolean)_argument; }
        public void UnityEngine_TrailRenderer__set_generateLightingData() { ((TrailRenderer)_target).generateLightingData = (Boolean)_argument; }
        public void UnityEngine_TrailRenderer__set_lightProbeProxyVolumeOverride() { ((TrailRenderer)_target).lightProbeProxyVolumeOverride = (GameObject)_argument; }
        public void UnityEngine_TrailRenderer__set_lightmapIndex() { ((TrailRenderer)_target).lightmapIndex = (Int32)_argument; }
        public void UnityEngine_TrailRenderer__set_material() { ((TrailRenderer)_target).material = (Material)_argument; }
        public void UnityEngine_TrailRenderer__set_minVertexDistance() { ((TrailRenderer)_target).minVertexDistance = (Single)_argument; }
        public void UnityEngine_TrailRenderer__set_name() { ((TrailRenderer)_target).name = (String)_argument; }
        public void UnityEngine_TrailRenderer__set_numCapVertices() { ((TrailRenderer)_target).numCapVertices = (Int32)_argument; }
        public void UnityEngine_TrailRenderer__set_numCornerVertices() { ((TrailRenderer)_target).numCornerVertices = (Int32)_argument; }
        public void UnityEngine_TrailRenderer__set_probeAnchor() { ((TrailRenderer)_target).probeAnchor = (Transform)_argument; }
        public void UnityEngine_TrailRenderer__set_realtimeLightmapIndex() { ((TrailRenderer)_target).realtimeLightmapIndex = (Int32)_argument; }
        public void UnityEngine_TrailRenderer__set_receiveShadows() { ((TrailRenderer)_target).receiveShadows = (Boolean)_argument; }
        public void UnityEngine_TrailRenderer__set_rendererPriority() { ((TrailRenderer)_target).rendererPriority = (Int32)_argument; }
        public void UnityEngine_TrailRenderer__set_shadowBias() { ((TrailRenderer)_target).shadowBias = (Single)_argument; }
        public void UnityEngine_TrailRenderer__set_sharedMaterial() { ((TrailRenderer)_target).sharedMaterial = (Material)_argument; }
        public void UnityEngine_TrailRenderer__set_sortingLayerID() { ((TrailRenderer)_target).sortingLayerID = (Int32)_argument; }
        public void UnityEngine_TrailRenderer__set_sortingLayerName() { ((TrailRenderer)_target).sortingLayerName = (String)_argument; }
        public void UnityEngine_TrailRenderer__set_sortingOrder() { ((TrailRenderer)_target).sortingOrder = (Int32)_argument; }
        public void UnityEngine_TrailRenderer__set_startWidth() { ((TrailRenderer)_target).startWidth = (Single)_argument; }
        public void UnityEngine_TrailRenderer__set_time() { ((TrailRenderer)_target).time = (Single)_argument; }
        public void UnityEngine_TrailRenderer__set_widthMultiplier() { ((TrailRenderer)_target).widthMultiplier = (Single)_argument; }
        public void UnityEngine_Transform__DetachChildren() { ((Transform)_target).DetachChildren(); }
        public void UnityEngine_Transform__Find() { ((Transform)_target).Find((String)_argument); }
        public void UnityEngine_Transform__LookAt() { ((Transform)_target).LookAt((Transform)_argument); }
        public void UnityEngine_Transform__SetAsFirstSibling() { ((Transform)_target).SetAsFirstSibling(); }
        public void UnityEngine_Transform__SetAsLastSibling() { ((Transform)_target).SetAsLastSibling(); }
        public void UnityEngine_Transform__SetParent() { ((Transform)_target).SetParent((Transform)_argument); }
        public void UnityEngine_Transform__SetSiblingIndex() { ((Transform)_target).SetSiblingIndex((Int32)_argument); }
        public void UnityEngine_Transform__set_hasChanged() { ((Transform)_target).hasChanged = (Boolean)_argument; }
        public void UnityEngine_Transform__set_hierarchyCapacity() { ((Transform)_target).hierarchyCapacity = (Int32)_argument; }
        public void UnityEngine_Transform__set_name() { ((Transform)_target).name = (String)_argument; }
        public void UnityEngine_Transform__set_parent() { ((Transform)_target).parent = (Transform)_argument; }
        public void UnityEngine_UI_AspectRatioFitter__SetLayoutHorizontal() { ((AspectRatioFitter)_target).SetLayoutHorizontal(); }
        public void UnityEngine_UI_AspectRatioFitter__SetLayoutVertical() { ((AspectRatioFitter)_target).SetLayoutVertical(); }
        public void UnityEngine_UI_AspectRatioFitter__set_aspectRatio() { ((AspectRatioFitter)_target).aspectRatio = (Single)_argument; }
        public void UnityEngine_UI_AspectRatioFitter__set_enabled() { ((AspectRatioFitter)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_UI_AspectRatioFitter__set_name() { ((AspectRatioFitter)_target).name = (String)_argument; }
        public void UnityEngine_UI_BaseMeshEffect__ModifyMesh() { ((BaseMeshEffect)_target).ModifyMesh((Mesh)_argument); }
        public void UnityEngine_UI_BaseMeshEffect__set_enabled() { ((BaseMeshEffect)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_UI_BaseMeshEffect__set_name() { ((BaseMeshEffect)_target).name = (String)_argument; }
        public void UnityEngine_UI_Button__FindSelectableOnDown() { ((Button)_target).FindSelectableOnDown(); }
        public void UnityEngine_UI_Button__FindSelectableOnLeft() { ((Button)_target).FindSelectableOnLeft(); }
        public void UnityEngine_UI_Button__FindSelectableOnRight() { ((Button)_target).FindSelectableOnRight(); }
        public void UnityEngine_UI_Button__FindSelectableOnUp() { ((Button)_target).FindSelectableOnUp(); }
        public void UnityEngine_UI_Button__Select() { ((Button)_target).Select(); }
        public void UnityEngine_UI_Button__set_enabled() { ((Button)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_UI_Button__set_image() { ((Button)_target).image = (Image)_argument; }
        public void UnityEngine_UI_Button__set_interactable() { ((Button)_target).interactable = (Boolean)_argument; }
        public void UnityEngine_UI_Button__set_name() { ((Button)_target).name = (String)_argument; }
        public void UnityEngine_UI_Button__set_targetGraphic() { ((Button)_target).targetGraphic = (Graphic)_argument; }
        public void UnityEngine_UI_CanvasScaler__set_defaultSpriteDPI() { ((CanvasScaler)_target).defaultSpriteDPI = (Single)_argument; }
        public void UnityEngine_UI_CanvasScaler__set_dynamicPixelsPerUnit() { ((CanvasScaler)_target).dynamicPixelsPerUnit = (Single)_argument; }
        public void UnityEngine_UI_CanvasScaler__set_enabled() { ((CanvasScaler)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_UI_CanvasScaler__set_fallbackScreenDPI() { ((CanvasScaler)_target).fallbackScreenDPI = (Single)_argument; }
        public void UnityEngine_UI_CanvasScaler__set_matchWidthOrHeight() { ((CanvasScaler)_target).matchWidthOrHeight = (Single)_argument; }
        public void UnityEngine_UI_CanvasScaler__set_name() { ((CanvasScaler)_target).name = (String)_argument; }
        public void UnityEngine_UI_CanvasScaler__set_referencePixelsPerUnit() { ((CanvasScaler)_target).referencePixelsPerUnit = (Single)_argument; }
        public void UnityEngine_UI_CanvasScaler__set_scaleFactor() { ((CanvasScaler)_target).scaleFactor = (Single)_argument; }
        public void UnityEngine_UI_ContentSizeFitter__SetLayoutHorizontal() { ((ContentSizeFitter)_target).SetLayoutHorizontal(); }
        public void UnityEngine_UI_ContentSizeFitter__SetLayoutVertical() { ((ContentSizeFitter)_target).SetLayoutVertical(); }
        public void UnityEngine_UI_ContentSizeFitter__set_enabled() { ((ContentSizeFitter)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_UI_ContentSizeFitter__set_name() { ((ContentSizeFitter)_target).name = (String)_argument; }
        public void UnityEngine_UI_Dropdown__ClearOptions() { ((Dropdown)_target).ClearOptions(); }
        public void UnityEngine_UI_Dropdown__FindSelectableOnDown() { ((Dropdown)_target).FindSelectableOnDown(); }
        public void UnityEngine_UI_Dropdown__FindSelectableOnLeft() { ((Dropdown)_target).FindSelectableOnLeft(); }
        public void UnityEngine_UI_Dropdown__FindSelectableOnRight() { ((Dropdown)_target).FindSelectableOnRight(); }
        public void UnityEngine_UI_Dropdown__FindSelectableOnUp() { ((Dropdown)_target).FindSelectableOnUp(); }
        public void UnityEngine_UI_Dropdown__Hide() { ((Dropdown)_target).Hide(); }
        public void UnityEngine_UI_Dropdown__RefreshShownValue() { ((Dropdown)_target).RefreshShownValue(); }
        public void UnityEngine_UI_Dropdown__Select() { ((Dropdown)_target).Select(); }
        public void UnityEngine_UI_Dropdown__SetValueWithoutNotify() { ((Dropdown)_target).SetValueWithoutNotify((Int32)_argument); }
        public void UnityEngine_UI_Dropdown__Show() { ((Dropdown)_target).Show(); }
        public void UnityEngine_UI_Dropdown__set_alphaFadeSpeed() { ((Dropdown)_target).alphaFadeSpeed = (Single)_argument; }
        public void UnityEngine_UI_Dropdown__set_captionImage() { ((Dropdown)_target).captionImage = (Image)_argument; }
        public void UnityEngine_UI_Dropdown__set_captionText() { ((Dropdown)_target).captionText = (Text)_argument; }
        public void UnityEngine_UI_Dropdown__set_enabled() { ((Dropdown)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_UI_Dropdown__set_image() { ((Dropdown)_target).image = (Image)_argument; }
        public void UnityEngine_UI_Dropdown__set_interactable() { ((Dropdown)_target).interactable = (Boolean)_argument; }
        public void UnityEngine_UI_Dropdown__set_itemImage() { ((Dropdown)_target).itemImage = (Image)_argument; }
        public void UnityEngine_UI_Dropdown__set_itemText() { ((Dropdown)_target).itemText = (Text)_argument; }
        public void UnityEngine_UI_Dropdown__set_name() { ((Dropdown)_target).name = (String)_argument; }
        public void UnityEngine_UI_Dropdown__set_targetGraphic() { ((Dropdown)_target).targetGraphic = (Graphic)_argument; }
        public void UnityEngine_UI_Dropdown__set_value() { ((Dropdown)_target).value = (Int32)_argument; }
        public void UnityEngine_UI_Graphic__GraphicUpdateComplete() { ((Graphic)_target).GraphicUpdateComplete(); }
        public void UnityEngine_UI_Graphic__LayoutComplete() { ((Graphic)_target).LayoutComplete(); }
        public void UnityEngine_UI_Graphic__OnCullingChanged() { ((Graphic)_target).OnCullingChanged(); }
        public void UnityEngine_UI_Graphic__SetAllDirty() { ((Graphic)_target).SetAllDirty(); }
        public void UnityEngine_UI_Graphic__SetLayoutDirty() { ((Graphic)_target).SetLayoutDirty(); }
        public void UnityEngine_UI_Graphic__SetMaterialDirty() { ((Graphic)_target).SetMaterialDirty(); }
        public void UnityEngine_UI_Graphic__SetNativeSize() { ((Graphic)_target).SetNativeSize(); }
        public void UnityEngine_UI_Graphic__SetVerticesDirty() { ((Graphic)_target).SetVerticesDirty(); }
        public void UnityEngine_UI_Graphic__set_enabled() { ((Graphic)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_UI_Graphic__set_material() { ((Graphic)_target).material = (Material)_argument; }
        public void UnityEngine_UI_Graphic__set_name() { ((Graphic)_target).name = (String)_argument; }
        public void UnityEngine_UI_Graphic__set_raycastTarget() { ((Graphic)_target).raycastTarget = (Boolean)_argument; }
        public void UnityEngine_UI_GraphicRaycaster__set_enabled() { ((GraphicRaycaster)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_UI_GraphicRaycaster__set_ignoreReversedGraphics() { ((GraphicRaycaster)_target).ignoreReversedGraphics = (Boolean)_argument; }
        public void UnityEngine_UI_GraphicRaycaster__set_name() { ((GraphicRaycaster)_target).name = (String)_argument; }
        public void UnityEngine_UI_GridLayoutGroup__CalculateLayoutInputHorizontal() { ((GridLayoutGroup)_target).CalculateLayoutInputHorizontal(); }
        public void UnityEngine_UI_GridLayoutGroup__CalculateLayoutInputVertical() { ((GridLayoutGroup)_target).CalculateLayoutInputVertical(); }
        public void UnityEngine_UI_GridLayoutGroup__SetLayoutHorizontal() { ((GridLayoutGroup)_target).SetLayoutHorizontal(); }
        public void UnityEngine_UI_GridLayoutGroup__SetLayoutVertical() { ((GridLayoutGroup)_target).SetLayoutVertical(); }
        public void UnityEngine_UI_GridLayoutGroup__set_constraintCount() { ((GridLayoutGroup)_target).constraintCount = (Int32)_argument; }
        public void UnityEngine_UI_GridLayoutGroup__set_enabled() { ((GridLayoutGroup)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_UI_GridLayoutGroup__set_name() { ((GridLayoutGroup)_target).name = (String)_argument; }
        public void UnityEngine_UI_HorizontalLayoutGroup__CalculateLayoutInputHorizontal() { ((HorizontalLayoutGroup)_target).CalculateLayoutInputHorizontal(); }
        public void UnityEngine_UI_HorizontalLayoutGroup__CalculateLayoutInputVertical() { ((HorizontalLayoutGroup)_target).CalculateLayoutInputVertical(); }
        public void UnityEngine_UI_HorizontalLayoutGroup__SetLayoutHorizontal() { ((HorizontalLayoutGroup)_target).SetLayoutHorizontal(); }
        public void UnityEngine_UI_HorizontalLayoutGroup__SetLayoutVertical() { ((HorizontalLayoutGroup)_target).SetLayoutVertical(); }
        public void UnityEngine_UI_HorizontalLayoutGroup__set_childControlHeight() { ((HorizontalLayoutGroup)_target).childControlHeight = (Boolean)_argument; }
        public void UnityEngine_UI_HorizontalLayoutGroup__set_childControlWidth() { ((HorizontalLayoutGroup)_target).childControlWidth = (Boolean)_argument; }
        public void UnityEngine_UI_HorizontalLayoutGroup__set_childForceExpandHeight() { ((HorizontalLayoutGroup)_target).childForceExpandHeight = (Boolean)_argument; }
        public void UnityEngine_UI_HorizontalLayoutGroup__set_childForceExpandWidth() { ((HorizontalLayoutGroup)_target).childForceExpandWidth = (Boolean)_argument; }
        public void UnityEngine_UI_HorizontalLayoutGroup__set_childScaleHeight() { ((HorizontalLayoutGroup)_target).childScaleHeight = (Boolean)_argument; }
        public void UnityEngine_UI_HorizontalLayoutGroup__set_childScaleWidth() { ((HorizontalLayoutGroup)_target).childScaleWidth = (Boolean)_argument; }
        public void UnityEngine_UI_HorizontalLayoutGroup__set_enabled() { ((HorizontalLayoutGroup)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_UI_HorizontalLayoutGroup__set_name() { ((HorizontalLayoutGroup)_target).name = (String)_argument; }
        public void UnityEngine_UI_HorizontalLayoutGroup__set_spacing() { ((HorizontalLayoutGroup)_target).spacing = (Single)_argument; }
        public void UnityEngine_UI_HorizontalOrVerticalLayoutGroup__CalculateLayoutInputHorizontal() { ((HorizontalOrVerticalLayoutGroup)_target).CalculateLayoutInputHorizontal(); }
        public void UnityEngine_UI_HorizontalOrVerticalLayoutGroup__CalculateLayoutInputVertical() { ((HorizontalOrVerticalLayoutGroup)_target).CalculateLayoutInputVertical(); }
        public void UnityEngine_UI_HorizontalOrVerticalLayoutGroup__SetLayoutHorizontal() { ((HorizontalOrVerticalLayoutGroup)_target).SetLayoutHorizontal(); }
        public void UnityEngine_UI_HorizontalOrVerticalLayoutGroup__SetLayoutVertical() { ((HorizontalOrVerticalLayoutGroup)_target).SetLayoutVertical(); }
        public void UnityEngine_UI_HorizontalOrVerticalLayoutGroup__set_childControlHeight() { ((HorizontalOrVerticalLayoutGroup)_target).childControlHeight = (Boolean)_argument; }
        public void UnityEngine_UI_HorizontalOrVerticalLayoutGroup__set_childControlWidth() { ((HorizontalOrVerticalLayoutGroup)_target).childControlWidth = (Boolean)_argument; }
        public void UnityEngine_UI_HorizontalOrVerticalLayoutGroup__set_childForceExpandHeight() { ((HorizontalOrVerticalLayoutGroup)_target).childForceExpandHeight = (Boolean)_argument; }
        public void UnityEngine_UI_HorizontalOrVerticalLayoutGroup__set_childForceExpandWidth() { ((HorizontalOrVerticalLayoutGroup)_target).childForceExpandWidth = (Boolean)_argument; }
        public void UnityEngine_UI_HorizontalOrVerticalLayoutGroup__set_childScaleHeight() { ((HorizontalOrVerticalLayoutGroup)_target).childScaleHeight = (Boolean)_argument; }
        public void UnityEngine_UI_HorizontalOrVerticalLayoutGroup__set_childScaleWidth() { ((HorizontalOrVerticalLayoutGroup)_target).childScaleWidth = (Boolean)_argument; }
        public void UnityEngine_UI_HorizontalOrVerticalLayoutGroup__set_enabled() { ((HorizontalOrVerticalLayoutGroup)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_UI_HorizontalOrVerticalLayoutGroup__set_name() { ((HorizontalOrVerticalLayoutGroup)_target).name = (String)_argument; }
        public void UnityEngine_UI_HorizontalOrVerticalLayoutGroup__set_spacing() { ((HorizontalOrVerticalLayoutGroup)_target).spacing = (Single)_argument; }
        public void UnityEngine_UI_Image__CalculateLayoutInputHorizontal() { ((Image)_target).CalculateLayoutInputHorizontal(); }
        public void UnityEngine_UI_Image__CalculateLayoutInputVertical() { ((Image)_target).CalculateLayoutInputVertical(); }
        public void UnityEngine_UI_Image__DisableSpriteOptimizations() { ((Image)_target).DisableSpriteOptimizations(); }
        public void UnityEngine_UI_Image__GraphicUpdateComplete() { ((Image)_target).GraphicUpdateComplete(); }
        public void UnityEngine_UI_Image__LayoutComplete() { ((Image)_target).LayoutComplete(); }
        public void UnityEngine_UI_Image__OnAfterDeserialize() { ((Image)_target).OnAfterDeserialize(); }
        public void UnityEngine_UI_Image__OnBeforeSerialize() { ((Image)_target).OnBeforeSerialize(); }
        public void UnityEngine_UI_Image__OnCullingChanged() { ((Image)_target).OnCullingChanged(); }
        public void UnityEngine_UI_Image__RecalculateClipping() { ((Image)_target).RecalculateClipping(); }
        public void UnityEngine_UI_Image__RecalculateMasking() { ((Image)_target).RecalculateMasking(); }
        public void UnityEngine_UI_Image__SetAllDirty() { ((Image)_target).SetAllDirty(); }
        public void UnityEngine_UI_Image__SetLayoutDirty() { ((Image)_target).SetLayoutDirty(); }
        public void UnityEngine_UI_Image__SetMaterialDirty() { ((Image)_target).SetMaterialDirty(); }
        public void UnityEngine_UI_Image__SetNativeSize() { ((Image)_target).SetNativeSize(); }
        public void UnityEngine_UI_Image__SetVerticesDirty() { ((Image)_target).SetVerticesDirty(); }
        public void UnityEngine_UI_Image__set_alphaHitTestMinimumThreshold() { ((Image)_target).alphaHitTestMinimumThreshold = (Single)_argument; }
        public void UnityEngine_UI_Image__set_enabled() { ((Image)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_UI_Image__set_fillAmount() { ((Image)_target).fillAmount = (Single)_argument; }
        public void UnityEngine_UI_Image__set_fillCenter() { ((Image)_target).fillCenter = (Boolean)_argument; }
        public void UnityEngine_UI_Image__set_fillClockwise() { ((Image)_target).fillClockwise = (Boolean)_argument; }
        public void UnityEngine_UI_Image__set_fillOrigin() { ((Image)_target).fillOrigin = (Int32)_argument; }
        public void UnityEngine_UI_Image__set_isMaskingGraphic() { ((Image)_target).isMaskingGraphic = (Boolean)_argument; }
        public void UnityEngine_UI_Image__set_maskable() { ((Image)_target).maskable = (Boolean)_argument; }
        public void UnityEngine_UI_Image__set_material() { ((Image)_target).material = (Material)_argument; }
        public void UnityEngine_UI_Image__set_name() { ((Image)_target).name = (String)_argument; }
        public void UnityEngine_UI_Image__set_overrideSprite() { ((Image)_target).overrideSprite = (Sprite)_argument; }
        public void UnityEngine_UI_Image__set_pixelsPerUnitMultiplier() { ((Image)_target).pixelsPerUnitMultiplier = (Single)_argument; }
        public void UnityEngine_UI_Image__set_preserveAspect() { ((Image)_target).preserveAspect = (Boolean)_argument; }
        public void UnityEngine_UI_Image__set_raycastTarget() { ((Image)_target).raycastTarget = (Boolean)_argument; }
        public void UnityEngine_UI_Image__set_sprite() { ((Image)_target).sprite = (Sprite)_argument; }
        public void UnityEngine_UI_Image__set_useSpriteMesh() { ((Image)_target).useSpriteMesh = (Boolean)_argument; }
        public void UnityEngine_UI_InputField__ActivateInputField() { ((InputField)_target).ActivateInputField(); }
        public void UnityEngine_UI_InputField__CalculateLayoutInputHorizontal() { ((InputField)_target).CalculateLayoutInputHorizontal(); }
        public void UnityEngine_UI_InputField__CalculateLayoutInputVertical() { ((InputField)_target).CalculateLayoutInputVertical(); }
        public void UnityEngine_UI_InputField__DeactivateInputField() { ((InputField)_target).DeactivateInputField(); }
        public void UnityEngine_UI_InputField__FindSelectableOnDown() { ((InputField)_target).FindSelectableOnDown(); }
        public void UnityEngine_UI_InputField__FindSelectableOnLeft() { ((InputField)_target).FindSelectableOnLeft(); }
        public void UnityEngine_UI_InputField__FindSelectableOnRight() { ((InputField)_target).FindSelectableOnRight(); }
        public void UnityEngine_UI_InputField__FindSelectableOnUp() { ((InputField)_target).FindSelectableOnUp(); }
        public void UnityEngine_UI_InputField__ForceLabelUpdate() { ((InputField)_target).ForceLabelUpdate(); }
        public void UnityEngine_UI_InputField__GraphicUpdateComplete() { ((InputField)_target).GraphicUpdateComplete(); }
        public void UnityEngine_UI_InputField__LayoutComplete() { ((InputField)_target).LayoutComplete(); }
        public void UnityEngine_UI_InputField__MoveTextEnd() { ((InputField)_target).MoveTextEnd((Boolean)_argument); }
        public void UnityEngine_UI_InputField__MoveTextStart() { ((InputField)_target).MoveTextStart((Boolean)_argument); }
        public void UnityEngine_UI_InputField__Select() { ((InputField)_target).Select(); }
        public void UnityEngine_UI_InputField__set_caretBlinkRate() { ((InputField)_target).caretBlinkRate = (Single)_argument; }
        public void UnityEngine_UI_InputField__set_caretPosition() { ((InputField)_target).caretPosition = (Int32)_argument; }
        public void UnityEngine_UI_InputField__set_caretWidth() { ((InputField)_target).caretWidth = (Int32)_argument; }
        public void UnityEngine_UI_InputField__set_characterLimit() { ((InputField)_target).characterLimit = (Int32)_argument; }
        public void UnityEngine_UI_InputField__set_customCaretColor() { ((InputField)_target).customCaretColor = (Boolean)_argument; }
        public void UnityEngine_UI_InputField__set_enabled() { ((InputField)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_UI_InputField__set_image() { ((InputField)_target).image = (Image)_argument; }
        public void UnityEngine_UI_InputField__set_interactable() { ((InputField)_target).interactable = (Boolean)_argument; }
        public void UnityEngine_UI_InputField__set_name() { ((InputField)_target).name = (String)_argument; }
        public void UnityEngine_UI_InputField__set_placeholder() { ((InputField)_target).placeholder = (Graphic)_argument; }
        public void UnityEngine_UI_InputField__set_readOnly() { ((InputField)_target).readOnly = (Boolean)_argument; }
        public void UnityEngine_UI_InputField__set_selectionAnchorPosition() { ((InputField)_target).selectionAnchorPosition = (Int32)_argument; }
        public void UnityEngine_UI_InputField__set_selectionFocusPosition() { ((InputField)_target).selectionFocusPosition = (Int32)_argument; }
        public void UnityEngine_UI_InputField__set_shouldActivateOnSelect() { ((InputField)_target).shouldActivateOnSelect = (Boolean)_argument; }
        public void UnityEngine_UI_InputField__set_shouldHideMobileInput() { ((InputField)_target).shouldHideMobileInput = (Boolean)_argument; }
        public void UnityEngine_UI_InputField__set_targetGraphic() { ((InputField)_target).targetGraphic = (Graphic)_argument; }
        public void UnityEngine_UI_InputField__set_textComponent() { ((InputField)_target).textComponent = (Text)_argument; }
        public void UnityEngine_UI_InputField__set_text() { ((InputField)_target).text = (String)_argument; }
        public void UnityEngine_UI_LayoutElement__CalculateLayoutInputHorizontal() { ((LayoutElement)_target).CalculateLayoutInputHorizontal(); }
        public void UnityEngine_UI_LayoutElement__CalculateLayoutInputVertical() { ((LayoutElement)_target).CalculateLayoutInputVertical(); }
        public void UnityEngine_UI_LayoutElement__set_enabled() { ((LayoutElement)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_UI_LayoutElement__set_flexibleHeight() { ((LayoutElement)_target).flexibleHeight = (Single)_argument; }
        public void UnityEngine_UI_LayoutElement__set_flexibleWidth() { ((LayoutElement)_target).flexibleWidth = (Single)_argument; }
        public void UnityEngine_UI_LayoutElement__set_ignoreLayout() { ((LayoutElement)_target).ignoreLayout = (Boolean)_argument; }
        public void UnityEngine_UI_LayoutElement__set_layoutPriority() { ((LayoutElement)_target).layoutPriority = (Int32)_argument; }
        public void UnityEngine_UI_LayoutElement__set_minHeight() { ((LayoutElement)_target).minHeight = (Single)_argument; }
        public void UnityEngine_UI_LayoutElement__set_minWidth() { ((LayoutElement)_target).minWidth = (Single)_argument; }
        public void UnityEngine_UI_LayoutElement__set_name() { ((LayoutElement)_target).name = (String)_argument; }
        public void UnityEngine_UI_LayoutElement__set_preferredHeight() { ((LayoutElement)_target).preferredHeight = (Single)_argument; }
        public void UnityEngine_UI_LayoutElement__set_preferredWidth() { ((LayoutElement)_target).preferredWidth = (Single)_argument; }
        public void UnityEngine_UI_LayoutGroup__CalculateLayoutInputHorizontal() { ((LayoutGroup)_target).CalculateLayoutInputHorizontal(); }
        public void UnityEngine_UI_LayoutGroup__CalculateLayoutInputVertical() { ((LayoutGroup)_target).CalculateLayoutInputVertical(); }
        public void UnityEngine_UI_LayoutGroup__SetLayoutHorizontal() { ((LayoutGroup)_target).SetLayoutHorizontal(); }
        public void UnityEngine_UI_LayoutGroup__SetLayoutVertical() { ((LayoutGroup)_target).SetLayoutVertical(); }
        public void UnityEngine_UI_LayoutGroup__set_enabled() { ((LayoutGroup)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_UI_LayoutGroup__set_name() { ((LayoutGroup)_target).name = (String)_argument; }
        public void UnityEngine_UI_MaskableGraphic__GraphicUpdateComplete() { ((MaskableGraphic)_target).GraphicUpdateComplete(); }
        public void UnityEngine_UI_MaskableGraphic__LayoutComplete() { ((MaskableGraphic)_target).LayoutComplete(); }
        public void UnityEngine_UI_MaskableGraphic__OnCullingChanged() { ((MaskableGraphic)_target).OnCullingChanged(); }
        public void UnityEngine_UI_MaskableGraphic__RecalculateClipping() { ((MaskableGraphic)_target).RecalculateClipping(); }
        public void UnityEngine_UI_MaskableGraphic__RecalculateMasking() { ((MaskableGraphic)_target).RecalculateMasking(); }
        public void UnityEngine_UI_MaskableGraphic__SetAllDirty() { ((MaskableGraphic)_target).SetAllDirty(); }
        public void UnityEngine_UI_MaskableGraphic__SetLayoutDirty() { ((MaskableGraphic)_target).SetLayoutDirty(); }
        public void UnityEngine_UI_MaskableGraphic__SetMaterialDirty() { ((MaskableGraphic)_target).SetMaterialDirty(); }
        public void UnityEngine_UI_MaskableGraphic__SetNativeSize() { ((MaskableGraphic)_target).SetNativeSize(); }
        public void UnityEngine_UI_MaskableGraphic__SetVerticesDirty() { ((MaskableGraphic)_target).SetVerticesDirty(); }
        public void UnityEngine_UI_MaskableGraphic__set_enabled() { ((MaskableGraphic)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_UI_MaskableGraphic__set_isMaskingGraphic() { ((MaskableGraphic)_target).isMaskingGraphic = (Boolean)_argument; }
        public void UnityEngine_UI_MaskableGraphic__set_maskable() { ((MaskableGraphic)_target).maskable = (Boolean)_argument; }
        public void UnityEngine_UI_MaskableGraphic__set_material() { ((MaskableGraphic)_target).material = (Material)_argument; }
        public void UnityEngine_UI_MaskableGraphic__set_name() { ((MaskableGraphic)_target).name = (String)_argument; }
        public void UnityEngine_UI_MaskableGraphic__set_raycastTarget() { ((MaskableGraphic)_target).raycastTarget = (Boolean)_argument; }
        public void UnityEngine_UI_Mask__MaskEnabled() { ((Mask)_target).MaskEnabled(); }
        public void UnityEngine_UI_Mask__set_enabled() { ((Mask)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_UI_Mask__set_name() { ((Mask)_target).name = (String)_argument; }
        public void UnityEngine_UI_Mask__set_showMaskGraphic() { ((Mask)_target).showMaskGraphic = (Boolean)_argument; }
        public void UnityEngine_UI_Outline__ModifyMesh() { ((Outline)_target).ModifyMesh((Mesh)_argument); }
        public void UnityEngine_UI_Outline__set_enabled() { ((Outline)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_UI_Outline__set_name() { ((Outline)_target).name = (String)_argument; }
        public void UnityEngine_UI_Outline__set_useGraphicAlpha() { ((Outline)_target).useGraphicAlpha = (Boolean)_argument; }
        public void UnityEngine_UI_PositionAsUV1__ModifyMesh() { ((PositionAsUV1)_target).ModifyMesh((Mesh)_argument); }
        public void UnityEngine_UI_PositionAsUV1__set_enabled() { ((PositionAsUV1)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_UI_PositionAsUV1__set_name() { ((PositionAsUV1)_target).name = (String)_argument; }
        public void UnityEngine_UI_RawImage__GraphicUpdateComplete() { ((RawImage)_target).GraphicUpdateComplete(); }
        public void UnityEngine_UI_RawImage__LayoutComplete() { ((RawImage)_target).LayoutComplete(); }
        public void UnityEngine_UI_RawImage__OnCullingChanged() { ((RawImage)_target).OnCullingChanged(); }
        public void UnityEngine_UI_RawImage__RecalculateClipping() { ((RawImage)_target).RecalculateClipping(); }
        public void UnityEngine_UI_RawImage__RecalculateMasking() { ((RawImage)_target).RecalculateMasking(); }
        public void UnityEngine_UI_RawImage__SetAllDirty() { ((RawImage)_target).SetAllDirty(); }
        public void UnityEngine_UI_RawImage__SetLayoutDirty() { ((RawImage)_target).SetLayoutDirty(); }
        public void UnityEngine_UI_RawImage__SetMaterialDirty() { ((RawImage)_target).SetMaterialDirty(); }
        public void UnityEngine_UI_RawImage__SetNativeSize() { ((RawImage)_target).SetNativeSize(); }
        public void UnityEngine_UI_RawImage__SetVerticesDirty() { ((RawImage)_target).SetVerticesDirty(); }
        public void UnityEngine_UI_RawImage__set_enabled() { ((RawImage)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_UI_RawImage__set_isMaskingGraphic() { ((RawImage)_target).isMaskingGraphic = (Boolean)_argument; }
        public void UnityEngine_UI_RawImage__set_maskable() { ((RawImage)_target).maskable = (Boolean)_argument; }
        public void UnityEngine_UI_RawImage__set_material() { ((RawImage)_target).material = (Material)_argument; }
        public void UnityEngine_UI_RawImage__set_name() { ((RawImage)_target).name = (String)_argument; }
        public void UnityEngine_UI_RawImage__set_raycastTarget() { ((RawImage)_target).raycastTarget = (Boolean)_argument; }
        public void UnityEngine_UI_RawImage__set_texture() { ((RawImage)_target).texture = (Texture)_argument; }
        public void UnityEngine_UI_RectMask2D__PerformClipping() { ((RectMask2D)_target).PerformClipping(); }
        public void UnityEngine_UI_RectMask2D__UpdateClipSoftness() { ((RectMask2D)_target).UpdateClipSoftness(); }
        public void UnityEngine_UI_RectMask2D__set_enabled() { ((RectMask2D)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_UI_RectMask2D__set_name() { ((RectMask2D)_target).name = (String)_argument; }
        public void UnityEngine_UI_Scrollbar__FindSelectableOnDown() { ((Scrollbar)_target).FindSelectableOnDown(); }
        public void UnityEngine_UI_Scrollbar__FindSelectableOnLeft() { ((Scrollbar)_target).FindSelectableOnLeft(); }
        public void UnityEngine_UI_Scrollbar__FindSelectableOnRight() { ((Scrollbar)_target).FindSelectableOnRight(); }
        public void UnityEngine_UI_Scrollbar__FindSelectableOnUp() { ((Scrollbar)_target).FindSelectableOnUp(); }
        public void UnityEngine_UI_Scrollbar__GraphicUpdateComplete() { ((Scrollbar)_target).GraphicUpdateComplete(); }
        public void UnityEngine_UI_Scrollbar__LayoutComplete() { ((Scrollbar)_target).LayoutComplete(); }
        public void UnityEngine_UI_Scrollbar__Select() { ((Scrollbar)_target).Select(); }
        public void UnityEngine_UI_Scrollbar__SetValueWithoutNotify() { ((Scrollbar)_target).SetValueWithoutNotify((Single)_argument); }
        public void UnityEngine_UI_Scrollbar__set_enabled() { ((Scrollbar)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_UI_Scrollbar__set_handleRect() { ((Scrollbar)_target).handleRect = (RectTransform)_argument; }
        public void UnityEngine_UI_Scrollbar__set_image() { ((Scrollbar)_target).image = (Image)_argument; }
        public void UnityEngine_UI_Scrollbar__set_interactable() { ((Scrollbar)_target).interactable = (Boolean)_argument; }
        public void UnityEngine_UI_Scrollbar__set_name() { ((Scrollbar)_target).name = (String)_argument; }
        public void UnityEngine_UI_Scrollbar__set_numberOfSteps() { ((Scrollbar)_target).numberOfSteps = (Int32)_argument; }
        public void UnityEngine_UI_Scrollbar__set_size() { ((Scrollbar)_target).size = (Single)_argument; }
        public void UnityEngine_UI_Scrollbar__set_targetGraphic() { ((Scrollbar)_target).targetGraphic = (Graphic)_argument; }
        public void UnityEngine_UI_Scrollbar__set_value() { ((Scrollbar)_target).value = (Single)_argument; }
        public void UnityEngine_UI_ScrollRect__CalculateLayoutInputHorizontal() { ((ScrollRect)_target).CalculateLayoutInputHorizontal(); }
        public void UnityEngine_UI_ScrollRect__CalculateLayoutInputVertical() { ((ScrollRect)_target).CalculateLayoutInputVertical(); }
        public void UnityEngine_UI_ScrollRect__GraphicUpdateComplete() { ((ScrollRect)_target).GraphicUpdateComplete(); }
        public void UnityEngine_UI_ScrollRect__LayoutComplete() { ((ScrollRect)_target).LayoutComplete(); }
        public void UnityEngine_UI_ScrollRect__SetLayoutHorizontal() { ((ScrollRect)_target).SetLayoutHorizontal(); }
        public void UnityEngine_UI_ScrollRect__SetLayoutVertical() { ((ScrollRect)_target).SetLayoutVertical(); }
        public void UnityEngine_UI_ScrollRect__StopMovement() { ((ScrollRect)_target).StopMovement(); }
        public void UnityEngine_UI_ScrollRect__set_content() { ((ScrollRect)_target).content = (RectTransform)_argument; }
        public void UnityEngine_UI_ScrollRect__set_decelerationRate() { ((ScrollRect)_target).decelerationRate = (Single)_argument; }
        public void UnityEngine_UI_ScrollRect__set_elasticity() { ((ScrollRect)_target).elasticity = (Single)_argument; }
        public void UnityEngine_UI_ScrollRect__set_enabled() { ((ScrollRect)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_UI_ScrollRect__set_horizontalNormalizedPosition() { ((ScrollRect)_target).horizontalNormalizedPosition = (Single)_argument; }
        public void UnityEngine_UI_ScrollRect__set_horizontalScrollbarSpacing() { ((ScrollRect)_target).horizontalScrollbarSpacing = (Single)_argument; }
        public void UnityEngine_UI_ScrollRect__set_horizontalScrollbar() { ((ScrollRect)_target).horizontalScrollbar = (Scrollbar)_argument; }
        public void UnityEngine_UI_ScrollRect__set_horizontal() { ((ScrollRect)_target).horizontal = (Boolean)_argument; }
        public void UnityEngine_UI_ScrollRect__set_inertia() { ((ScrollRect)_target).inertia = (Boolean)_argument; }
        public void UnityEngine_UI_ScrollRect__set_name() { ((ScrollRect)_target).name = (String)_argument; }
        public void UnityEngine_UI_ScrollRect__set_scrollSensitivity() { ((ScrollRect)_target).scrollSensitivity = (Single)_argument; }
        public void UnityEngine_UI_ScrollRect__set_verticalNormalizedPosition() { ((ScrollRect)_target).verticalNormalizedPosition = (Single)_argument; }
        public void UnityEngine_UI_ScrollRect__set_verticalScrollbarSpacing() { ((ScrollRect)_target).verticalScrollbarSpacing = (Single)_argument; }
        public void UnityEngine_UI_ScrollRect__set_verticalScrollbar() { ((ScrollRect)_target).verticalScrollbar = (Scrollbar)_argument; }
        public void UnityEngine_UI_ScrollRect__set_vertical() { ((ScrollRect)_target).vertical = (Boolean)_argument; }
        public void UnityEngine_UI_ScrollRect__set_viewport() { ((ScrollRect)_target).viewport = (RectTransform)_argument; }
        public void UnityEngine_UI_Selectable__FindSelectableOnDown() { ((Selectable)_target).FindSelectableOnDown(); }
        public void UnityEngine_UI_Selectable__FindSelectableOnLeft() { ((Selectable)_target).FindSelectableOnLeft(); }
        public void UnityEngine_UI_Selectable__FindSelectableOnRight() { ((Selectable)_target).FindSelectableOnRight(); }
        public void UnityEngine_UI_Selectable__FindSelectableOnUp() { ((Selectable)_target).FindSelectableOnUp(); }
        public void UnityEngine_UI_Selectable__Select() { ((Selectable)_target).Select(); }
        public void UnityEngine_UI_Selectable__set_enabled() { ((Selectable)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_UI_Selectable__set_image() { ((Selectable)_target).image = (Image)_argument; }
        public void UnityEngine_UI_Selectable__set_interactable() { ((Selectable)_target).interactable = (Boolean)_argument; }
        public void UnityEngine_UI_Selectable__set_name() { ((Selectable)_target).name = (String)_argument; }
        public void UnityEngine_UI_Selectable__set_targetGraphic() { ((Selectable)_target).targetGraphic = (Graphic)_argument; }
        public void UnityEngine_UI_Shadow__ModifyMesh() { ((Shadow)_target).ModifyMesh((Mesh)_argument); }
        public void UnityEngine_UI_Shadow__set_enabled() { ((Shadow)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_UI_Shadow__set_name() { ((Shadow)_target).name = (String)_argument; }
        public void UnityEngine_UI_Shadow__set_useGraphicAlpha() { ((Shadow)_target).useGraphicAlpha = (Boolean)_argument; }
        public void UnityEngine_UI_Slider__FindSelectableOnDown() { ((Slider)_target).FindSelectableOnDown(); }
        public void UnityEngine_UI_Slider__FindSelectableOnLeft() { ((Slider)_target).FindSelectableOnLeft(); }
        public void UnityEngine_UI_Slider__FindSelectableOnRight() { ((Slider)_target).FindSelectableOnRight(); }
        public void UnityEngine_UI_Slider__FindSelectableOnUp() { ((Slider)_target).FindSelectableOnUp(); }
        public void UnityEngine_UI_Slider__GraphicUpdateComplete() { ((Slider)_target).GraphicUpdateComplete(); }
        public void UnityEngine_UI_Slider__LayoutComplete() { ((Slider)_target).LayoutComplete(); }
        public void UnityEngine_UI_Slider__Select() { ((Slider)_target).Select(); }
        public void UnityEngine_UI_Slider__SetValueWithoutNotify() { ((Slider)_target).SetValueWithoutNotify((Single)_argument); }
        public void UnityEngine_UI_Slider__set_enabled() { ((Slider)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_UI_Slider__set_fillRect() { ((Slider)_target).fillRect = (RectTransform)_argument; }
        public void UnityEngine_UI_Slider__set_handleRect() { ((Slider)_target).handleRect = (RectTransform)_argument; }
        public void UnityEngine_UI_Slider__set_image() { ((Slider)_target).image = (Image)_argument; }
        public void UnityEngine_UI_Slider__set_interactable() { ((Slider)_target).interactable = (Boolean)_argument; }
        public void UnityEngine_UI_Slider__set_maxValue() { ((Slider)_target).maxValue = (Single)_argument; }
        public void UnityEngine_UI_Slider__set_minValue() { ((Slider)_target).minValue = (Single)_argument; }
        public void UnityEngine_UI_Slider__set_name() { ((Slider)_target).name = (String)_argument; }
        public void UnityEngine_UI_Slider__set_normalizedValue() { ((Slider)_target).normalizedValue = (Single)_argument; }
        public void UnityEngine_UI_Slider__set_targetGraphic() { ((Slider)_target).targetGraphic = (Graphic)_argument; }
        public void UnityEngine_UI_Slider__set_value() { ((Slider)_target).value = (Single)_argument; }
        public void UnityEngine_UI_Slider__set_wholeNumbers() { ((Slider)_target).wholeNumbers = (Boolean)_argument; }
        public void UnityEngine_UI_Text__CalculateLayoutInputHorizontal() { ((Text)_target).CalculateLayoutInputHorizontal(); }
        public void UnityEngine_UI_Text__CalculateLayoutInputVertical() { ((Text)_target).CalculateLayoutInputVertical(); }
        public void UnityEngine_UI_Text__FontTextureChanged() { ((Text)_target).FontTextureChanged(); }
        public void UnityEngine_UI_Text__GraphicUpdateComplete() { ((Text)_target).GraphicUpdateComplete(); }
        public void UnityEngine_UI_Text__LayoutComplete() { ((Text)_target).LayoutComplete(); }
        public void UnityEngine_UI_Text__OnCullingChanged() { ((Text)_target).OnCullingChanged(); }
        public void UnityEngine_UI_Text__RecalculateClipping() { ((Text)_target).RecalculateClipping(); }
        public void UnityEngine_UI_Text__RecalculateMasking() { ((Text)_target).RecalculateMasking(); }
        public void UnityEngine_UI_Text__SetAllDirty() { ((Text)_target).SetAllDirty(); }
        public void UnityEngine_UI_Text__SetLayoutDirty() { ((Text)_target).SetLayoutDirty(); }
        public void UnityEngine_UI_Text__SetMaterialDirty() { ((Text)_target).SetMaterialDirty(); }
        public void UnityEngine_UI_Text__SetNativeSize() { ((Text)_target).SetNativeSize(); }
        public void UnityEngine_UI_Text__SetVerticesDirty() { ((Text)_target).SetVerticesDirty(); }
        public void UnityEngine_UI_Text__set_alignByGeometry() { ((Text)_target).alignByGeometry = (Boolean)_argument; }
        public void UnityEngine_UI_Text__set_enabled() { ((Text)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_UI_Text__set_fontSize() { ((Text)_target).fontSize = (Int32)_argument; }
        public void UnityEngine_UI_Text__set_font() { ((Text)_target).font = (Font)_argument; }
        public void UnityEngine_UI_Text__set_isMaskingGraphic() { ((Text)_target).isMaskingGraphic = (Boolean)_argument; }
        public void UnityEngine_UI_Text__set_lineSpacing() { ((Text)_target).lineSpacing = (Single)_argument; }
        public void UnityEngine_UI_Text__set_maskable() { ((Text)_target).maskable = (Boolean)_argument; }
        public void UnityEngine_UI_Text__set_material() { ((Text)_target).material = (Material)_argument; }
        public void UnityEngine_UI_Text__set_name() { ((Text)_target).name = (String)_argument; }
        public void UnityEngine_UI_Text__set_raycastTarget() { ((Text)_target).raycastTarget = (Boolean)_argument; }
        public void UnityEngine_UI_Text__set_resizeTextForBestFit() { ((Text)_target).resizeTextForBestFit = (Boolean)_argument; }
        public void UnityEngine_UI_Text__set_resizeTextMaxSize() { ((Text)_target).resizeTextMaxSize = (Int32)_argument; }
        public void UnityEngine_UI_Text__set_resizeTextMinSize() { ((Text)_target).resizeTextMinSize = (Int32)_argument; }
        public void UnityEngine_UI_Text__set_supportRichText() { ((Text)_target).supportRichText = (Boolean)_argument; }
        public void UnityEngine_UI_Text__set_text() { ((Text)_target).text = (String)_argument; }
        public void UnityEngine_UI_ToggleGroup__ActiveToggles() { ((ToggleGroup)_target).ActiveToggles(); }
        public void UnityEngine_UI_ToggleGroup__AnyTogglesOn() { ((ToggleGroup)_target).AnyTogglesOn(); }
        public void UnityEngine_UI_ToggleGroup__EnsureValidState() { ((ToggleGroup)_target).EnsureValidState(); }
        public void UnityEngine_UI_ToggleGroup__RegisterToggle() { ((ToggleGroup)_target).RegisterToggle((Toggle)_argument); }
        public void UnityEngine_UI_ToggleGroup__SetAllTogglesOff() { ((ToggleGroup)_target).SetAllTogglesOff((Boolean)_argument); }
        public void UnityEngine_UI_ToggleGroup__UnregisterToggle() { ((ToggleGroup)_target).UnregisterToggle((Toggle)_argument); }
        public void UnityEngine_UI_ToggleGroup__set_allowSwitchOff() { ((ToggleGroup)_target).allowSwitchOff = (Boolean)_argument; }
        public void UnityEngine_UI_ToggleGroup__set_enabled() { ((ToggleGroup)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_UI_ToggleGroup__set_name() { ((ToggleGroup)_target).name = (String)_argument; }
        public void UnityEngine_UI_Toggle__FindSelectableOnDown() { ((Toggle)_target).FindSelectableOnDown(); }
        public void UnityEngine_UI_Toggle__FindSelectableOnLeft() { ((Toggle)_target).FindSelectableOnLeft(); }
        public void UnityEngine_UI_Toggle__FindSelectableOnRight() { ((Toggle)_target).FindSelectableOnRight(); }
        public void UnityEngine_UI_Toggle__FindSelectableOnUp() { ((Toggle)_target).FindSelectableOnUp(); }
        public void UnityEngine_UI_Toggle__GraphicUpdateComplete() { ((Toggle)_target).GraphicUpdateComplete(); }
        public void UnityEngine_UI_Toggle__LayoutComplete() { ((Toggle)_target).LayoutComplete(); }
        public void UnityEngine_UI_Toggle__Select() { ((Toggle)_target).Select(); }
        public void UnityEngine_UI_Toggle__SetIsOnWithoutNotify() { ((Toggle)_target).SetIsOnWithoutNotify((Boolean)_argument); }
        public void UnityEngine_UI_Toggle__set_enabled() { ((Toggle)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_UI_Toggle__set_graphic() { ((Toggle)_target).graphic = (Graphic)_argument; }
        public void UnityEngine_UI_Toggle__set_group() { ((Toggle)_target).group = (ToggleGroup)_argument; }
        public void UnityEngine_UI_Toggle__set_image() { ((Toggle)_target).image = (Image)_argument; }
        public void UnityEngine_UI_Toggle__set_interactable() { ((Toggle)_target).interactable = (Boolean)_argument; }
        public void UnityEngine_UI_Toggle__set_isOn() { ((Toggle)_target).isOn = (Boolean)_argument; }
        public void UnityEngine_UI_Toggle__set_name() { ((Toggle)_target).name = (String)_argument; }
        public void UnityEngine_UI_Toggle__set_targetGraphic() { ((Toggle)_target).targetGraphic = (Graphic)_argument; }
        public void UnityEngine_UI_VerticalLayoutGroup__CalculateLayoutInputHorizontal() { ((VerticalLayoutGroup)_target).CalculateLayoutInputHorizontal(); }
        public void UnityEngine_UI_VerticalLayoutGroup__CalculateLayoutInputVertical() { ((VerticalLayoutGroup)_target).CalculateLayoutInputVertical(); }
        public void UnityEngine_UI_VerticalLayoutGroup__SetLayoutHorizontal() { ((VerticalLayoutGroup)_target).SetLayoutHorizontal(); }
        public void UnityEngine_UI_VerticalLayoutGroup__SetLayoutVertical() { ((VerticalLayoutGroup)_target).SetLayoutVertical(); }
        public void UnityEngine_UI_VerticalLayoutGroup__set_childControlHeight() { ((VerticalLayoutGroup)_target).childControlHeight = (Boolean)_argument; }
        public void UnityEngine_UI_VerticalLayoutGroup__set_childControlWidth() { ((VerticalLayoutGroup)_target).childControlWidth = (Boolean)_argument; }
        public void UnityEngine_UI_VerticalLayoutGroup__set_childForceExpandHeight() { ((VerticalLayoutGroup)_target).childForceExpandHeight = (Boolean)_argument; }
        public void UnityEngine_UI_VerticalLayoutGroup__set_childForceExpandWidth() { ((VerticalLayoutGroup)_target).childForceExpandWidth = (Boolean)_argument; }
        public void UnityEngine_UI_VerticalLayoutGroup__set_childScaleHeight() { ((VerticalLayoutGroup)_target).childScaleHeight = (Boolean)_argument; }
        public void UnityEngine_UI_VerticalLayoutGroup__set_childScaleWidth() { ((VerticalLayoutGroup)_target).childScaleWidth = (Boolean)_argument; }
        public void UnityEngine_UI_VerticalLayoutGroup__set_enabled() { ((VerticalLayoutGroup)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_UI_VerticalLayoutGroup__set_name() { ((VerticalLayoutGroup)_target).name = (String)_argument; }
        public void UnityEngine_UI_VerticalLayoutGroup__set_spacing() { ((VerticalLayoutGroup)_target).spacing = (Single)_argument; }
        public void UnityEngine_WheelCollider__ResetSprungMasses() { ((WheelCollider)_target).ResetSprungMasses(); }
        public void UnityEngine_WheelCollider__set_brakeTorque() { ((WheelCollider)_target).brakeTorque = (Single)_argument; }
        public void UnityEngine_WheelCollider__set_contactOffset() { ((WheelCollider)_target).contactOffset = (Single)_argument; }
        public void UnityEngine_WheelCollider__set_enabled() { ((WheelCollider)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_WheelCollider__set_forceAppPointDistance() { ((WheelCollider)_target).forceAppPointDistance = (Single)_argument; }
        public void UnityEngine_WheelCollider__set_isTrigger() { ((WheelCollider)_target).isTrigger = (Boolean)_argument; }
        public void UnityEngine_WheelCollider__set_mass() { ((WheelCollider)_target).mass = (Single)_argument; }
        public void UnityEngine_WheelCollider__set_material() { ((WheelCollider)_target).material = (PhysicMaterial)_argument; }
        public void UnityEngine_WheelCollider__set_motorTorque() { ((WheelCollider)_target).motorTorque = (Single)_argument; }
        public void UnityEngine_WheelCollider__set_name() { ((WheelCollider)_target).name = (String)_argument; }
        public void UnityEngine_WheelCollider__set_radius() { ((WheelCollider)_target).radius = (Single)_argument; }
        public void UnityEngine_WheelCollider__set_sharedMaterial() { ((WheelCollider)_target).sharedMaterial = (PhysicMaterial)_argument; }
        public void UnityEngine_WheelCollider__set_sprungMass() { ((WheelCollider)_target).sprungMass = (Single)_argument; }
        public void UnityEngine_WheelCollider__set_steerAngle() { ((WheelCollider)_target).steerAngle = (Single)_argument; }
        public void UnityEngine_WheelCollider__set_suspensionDistance() { ((WheelCollider)_target).suspensionDistance = (Single)_argument; }
        public void UnityEngine_WheelCollider__set_wheelDampingRate() { ((WheelCollider)_target).wheelDampingRate = (Single)_argument; }
        public void UnityEngine_WheelJoint2D__set_autoConfigureConnectedAnchor() { ((WheelJoint2D)_target).autoConfigureConnectedAnchor = (Boolean)_argument; }
        public void UnityEngine_WheelJoint2D__set_breakForce() { ((WheelJoint2D)_target).breakForce = (Single)_argument; }
        public void UnityEngine_WheelJoint2D__set_breakTorque() { ((WheelJoint2D)_target).breakTorque = (Single)_argument; }
        public void UnityEngine_WheelJoint2D__set_connectedBody() { ((WheelJoint2D)_target).connectedBody = (Rigidbody2D)_argument; }
        public void UnityEngine_WheelJoint2D__set_enableCollision() { ((WheelJoint2D)_target).enableCollision = (Boolean)_argument; }
        public void UnityEngine_WheelJoint2D__set_enabled() { ((WheelJoint2D)_target).enabled = (Boolean)_argument; }
        public void UnityEngine_WheelJoint2D__set_name() { ((WheelJoint2D)_target).name = (String)_argument; }
        public void UnityEngine_WheelJoint2D__set_useMotor() { ((WheelJoint2D)_target).useMotor = (Boolean)_argument; }
        public void VRC_SDK3_Components_VRCAvatarPedestal__SwitchAvatar() { ((VRCAvatarPedestal)_target).SwitchAvatar((String)_argument); }
        public void VRC_SDK3_Components_VRCAvatarPedestal__set_ChangeAvatarsOnUse() { ((VRCAvatarPedestal)_target).ChangeAvatarsOnUse = (Boolean)_argument; }
        public void VRC_SDK3_Components_VRCAvatarPedestal__set_Placement() { ((VRCAvatarPedestal)_target).Placement = (Transform)_argument; }
        public void VRC_SDK3_Components_VRCAvatarPedestal__set_blueprintId() { ((VRCAvatarPedestal)_target).blueprintId = (String)_argument; }
        public void VRC_SDK3_Components_VRCAvatarPedestal__set_enabled() { ((VRCAvatarPedestal)_target).enabled = (Boolean)_argument; }
        public void VRC_SDK3_Components_VRCAvatarPedestal__set_name() { ((VRCAvatarPedestal)_target).name = (String)_argument; }
        public void VRC_SDK3_Components_VRCAvatarPedestal__set_scale() { ((VRCAvatarPedestal)_target).scale = (Single)_argument; }
        public void VRC_SDK3_Components_VRCMirrorReflection__OnWillRenderObject() { ((VRCMirrorReflection)_target).OnWillRenderObject(); }
        public void VRC_SDK3_Components_VRCMirrorReflection__set_TurnOffMirrorOcclusion() { ((VRCMirrorReflection)_target).TurnOffMirrorOcclusion = (Boolean)_argument; }
        public void VRC_SDK3_Components_VRCMirrorReflection__set_customSkybox() { ((VRCMirrorReflection)_target).customSkybox = (Material)_argument; }
        public void VRC_SDK3_Components_VRCMirrorReflection__set_enabled() { ((VRCMirrorReflection)_target).enabled = (Boolean)_argument; }
        public void VRC_SDK3_Components_VRCMirrorReflection__set_m_DisablePixelLights() { ((VRCMirrorReflection)_target).m_DisablePixelLights = (Boolean)_argument; }
        public void VRC_SDK3_Components_VRCMirrorReflection__set_name() { ((VRCMirrorReflection)_target).name = (String)_argument; }
        public void VRC_SDK3_Components_VRCObjectPool__Return() { ((VRCObjectPool)_target).Return((GameObject)_argument); }
        public void VRC_SDK3_Components_VRCObjectPool__Shuffle() { ((VRCObjectPool)_target).Shuffle(); }
        public void VRC_SDK3_Components_VRCObjectPool__TryToSpawn() { ((VRCObjectPool)_target).TryToSpawn(); }
        public void VRC_SDK3_Components_VRCObjectPool__set_enabled() { ((VRCObjectPool)_target).enabled = (Boolean)_argument; }
        public void VRC_SDK3_Components_VRCObjectPool__set_name() { ((VRCObjectPool)_target).name = (String)_argument; }
        public void VRC_SDK3_Components_VRCObjectSync__FlagDiscontinuity() { ((VRCObjectSync)_target).FlagDiscontinuity(); }
        public void VRC_SDK3_Components_VRCObjectSync__Respawn() { ((VRCObjectSync)_target).Respawn(); }
        public void VRC_SDK3_Components_VRCObjectSync__SetGravity() { ((VRCObjectSync)_target).SetGravity((Boolean)_argument); }
        public void VRC_SDK3_Components_VRCObjectSync__SetKinematic() { ((VRCObjectSync)_target).SetKinematic((Boolean)_argument); }
        public void VRC_SDK3_Components_VRCObjectSync__TeleportTo() { ((VRCObjectSync)_target).TeleportTo((Transform)_argument); }
        public void VRC_SDK3_Components_VRCObjectSync__set_AllowCollisionOwnershipTransfer() { ((VRCObjectSync)_target).AllowCollisionOwnershipTransfer = (Boolean)_argument; }
        public void VRC_SDK3_Components_VRCObjectSync__set_enabled() { ((VRCObjectSync)_target).enabled = (Boolean)_argument; }
        public void VRC_SDK3_Components_VRCObjectSync__set_name() { ((VRCObjectSync)_target).name = (String)_argument; }
        public void VRC_SDK3_Components_VRCPickup__Drop() { ((VRCPickup)_target).Drop(); }
        public void VRC_SDK3_Components_VRCPickup__PlayHaptics() { ((VRCPickup)_target).PlayHaptics(); }
        public void VRC_SDK3_Components_VRCPickup__set_DisallowTheft() { ((VRCPickup)_target).DisallowTheft = (Boolean)_argument; }
        public void VRC_SDK3_Components_VRCPickup__set_ExactGrip() { ((VRCPickup)_target).ExactGrip = (Transform)_argument; }
        public void VRC_SDK3_Components_VRCPickup__set_ExactGun() { ((VRCPickup)_target).ExactGun = (Transform)_argument; }
        public void VRC_SDK3_Components_VRCPickup__set_InteractionText() { ((VRCPickup)_target).InteractionText = (String)_argument; }
        public void VRC_SDK3_Components_VRCPickup__set_ThrowVelocityBoostMinSpeed() { ((VRCPickup)_target).ThrowVelocityBoostMinSpeed = (Single)_argument; }
        public void VRC_SDK3_Components_VRCPickup__set_ThrowVelocityBoostScale() { ((VRCPickup)_target).ThrowVelocityBoostScale = (Single)_argument; }
        public void VRC_SDK3_Components_VRCPickup__set_UseText() { ((VRCPickup)_target).UseText = (String)_argument; }
        public void VRC_SDK3_Components_VRCPickup__set_allowManipulationWhenEquipped() { ((VRCPickup)_target).allowManipulationWhenEquipped = (Boolean)_argument; }
        public void VRC_SDK3_Components_VRCPickup__set_enabled() { ((VRCPickup)_target).enabled = (Boolean)_argument; }
        public void VRC_SDK3_Components_VRCPickup__set_name() { ((VRCPickup)_target).name = (String)_argument; }
        public void VRC_SDK3_Components_VRCPickup__set_pickupable() { ((VRCPickup)_target).pickupable = (Boolean)_argument; }
        public void VRC_SDK3_Components_VRCPickup__set_proximity() { ((VRCPickup)_target).proximity = (Single)_argument; }
        public void VRC_SDK3_Components_VRCPortalMarker__RefreshPortal() { ((VRCPortalMarker)_target).RefreshPortal(); }
        public void VRC_SDK3_Components_VRCPortalMarker__set_enabled() { ((VRCPortalMarker)_target).enabled = (Boolean)_argument; }
        public void VRC_SDK3_Components_VRCPortalMarker__set_name() { ((VRCPortalMarker)_target).name = (String)_argument; }
        public void VRC_SDK3_Components_VRCPortalMarker__set_roomId() { ((VRCPortalMarker)_target).roomId = (String)_argument; }
        public void VRC_SDK3_Components_VRCStation__set_animatorController() { ((VRCStation)_target).animatorController = (RuntimeAnimatorController)_argument; }
        public void VRC_SDK3_Components_VRCStation__set_canUseStationFromStation() { ((VRCStation)_target).canUseStationFromStation = (Boolean)_argument; }
        public void VRC_SDK3_Components_VRCStation__set_disableStationExit() { ((VRCStation)_target).disableStationExit = (Boolean)_argument; }
        public void VRC_SDK3_Components_VRCStation__set_enabled() { ((VRCStation)_target).enabled = (Boolean)_argument; }
        public void VRC_SDK3_Components_VRCStation__set_name() { ((VRCStation)_target).name = (String)_argument; }
        public void VRC_SDK3_Components_VRCStation__set_stationEnterPlayerLocation() { ((VRCStation)_target).stationEnterPlayerLocation = (Transform)_argument; }
        public void VRC_SDK3_Components_VRCStation__set_stationExitPlayerLocation() { ((VRCStation)_target).stationExitPlayerLocation = (Transform)_argument; }
        public void VRC_SDK3_Components_VRCUrlInputField__ActivateInputField() { ((VRCUrlInputField)_target).ActivateInputField(); }
        public void VRC_SDK3_Components_VRCUrlInputField__CalculateLayoutInputHorizontal() { ((VRCUrlInputField)_target).CalculateLayoutInputHorizontal(); }
        public void VRC_SDK3_Components_VRCUrlInputField__CalculateLayoutInputVertical() { ((VRCUrlInputField)_target).CalculateLayoutInputVertical(); }
        public void VRC_SDK3_Components_VRCUrlInputField__DeactivateInputField() { ((VRCUrlInputField)_target).DeactivateInputField(); }
        public void VRC_SDK3_Components_VRCUrlInputField__FindSelectableOnDown() { ((VRCUrlInputField)_target).FindSelectableOnDown(); }
        public void VRC_SDK3_Components_VRCUrlInputField__FindSelectableOnLeft() { ((VRCUrlInputField)_target).FindSelectableOnLeft(); }
        public void VRC_SDK3_Components_VRCUrlInputField__FindSelectableOnRight() { ((VRCUrlInputField)_target).FindSelectableOnRight(); }
        public void VRC_SDK3_Components_VRCUrlInputField__FindSelectableOnUp() { ((VRCUrlInputField)_target).FindSelectableOnUp(); }
        public void VRC_SDK3_Components_VRCUrlInputField__ForceLabelUpdate() { ((VRCUrlInputField)_target).ForceLabelUpdate(); }
        public void VRC_SDK3_Components_VRCUrlInputField__GraphicUpdateComplete() { ((VRCUrlInputField)_target).GraphicUpdateComplete(); }
        public void VRC_SDK3_Components_VRCUrlInputField__LayoutComplete() { ((VRCUrlInputField)_target).LayoutComplete(); }
        public void VRC_SDK3_Components_VRCUrlInputField__Select() { ((VRCUrlInputField)_target).Select(); }
        public void VRC_SDK3_Components_VRCUrlInputField__set_caretBlinkRate() { ((VRCUrlInputField)_target).caretBlinkRate = (Single)_argument; }
        public void VRC_SDK3_Components_VRCUrlInputField__set_caretWidth() { ((VRCUrlInputField)_target).caretWidth = (Int32)_argument; }
        public void VRC_SDK3_Components_VRCUrlInputField__set_characterLimit() { ((VRCUrlInputField)_target).characterLimit = (Int32)_argument; }
        public void VRC_SDK3_Components_VRCUrlInputField__set_customCaretColor() { ((VRCUrlInputField)_target).customCaretColor = (Boolean)_argument; }
        public void VRC_SDK3_Components_VRCUrlInputField__set_enabled() { ((VRCUrlInputField)_target).enabled = (Boolean)_argument; }
        public void VRC_SDK3_Components_VRCUrlInputField__set_image() { ((VRCUrlInputField)_target).image = (Image)_argument; }
        public void VRC_SDK3_Components_VRCUrlInputField__set_interactable() { ((VRCUrlInputField)_target).interactable = (Boolean)_argument; }
        public void VRC_SDK3_Components_VRCUrlInputField__set_name() { ((VRCUrlInputField)_target).name = (String)_argument; }
        public void VRC_SDK3_Components_VRCUrlInputField__set_placeholder() { ((VRCUrlInputField)_target).placeholder = (Graphic)_argument; }
        public void VRC_SDK3_Components_VRCUrlInputField__set_readOnly() { ((VRCUrlInputField)_target).readOnly = (Boolean)_argument; }
        public void VRC_SDK3_Components_VRCUrlInputField__set_shouldHideMobileInput() { ((VRCUrlInputField)_target).shouldHideMobileInput = (Boolean)_argument; }
        public void VRC_SDK3_Components_VRCUrlInputField__set_targetGraphic() { ((VRCUrlInputField)_target).targetGraphic = (Graphic)_argument; }
        public void VRC_SDK3_Components_VRCUrlInputField__set_textComponent() { ((VRCUrlInputField)_target).textComponent = (Text)_argument; }
        public void VRC_SDK3_Midi_VRCMidiPlayer__Play() { ((VRCMidiPlayer)_target).Play(); }
        public void VRC_SDK3_Midi_VRCMidiPlayer__Stop() { ((VRCMidiPlayer)_target).Stop(); }
        public void VRC_SDK3_Midi_VRCMidiPlayer__set_Time() { ((VRCMidiPlayer)_target).Time = (Single)_argument; }
        public void VRC_SDK3_Video_Components_Base_BaseVRCVideoPlayer__Pause() { ((BaseVRCVideoPlayer)_target).Pause(); }
        public void VRC_SDK3_Video_Components_Base_BaseVRCVideoPlayer__Play() { ((BaseVRCVideoPlayer)_target).Play(); }
        public void VRC_SDK3_Video_Components_Base_BaseVRCVideoPlayer__SetTime() { ((BaseVRCVideoPlayer)_target).SetTime((Single)_argument); }
        public void VRC_SDK3_Video_Components_Base_BaseVRCVideoPlayer__Stop() { ((BaseVRCVideoPlayer)_target).Stop(); }
        public void VRC_SDK3_Video_Components_Base_BaseVRCVideoPlayer__set_EnableAutomaticResync() { ((BaseVRCVideoPlayer)_target).EnableAutomaticResync = (Boolean)_argument; }
        public void VRC_SDK3_Video_Components_Base_BaseVRCVideoPlayer__set_Loop() { ((BaseVRCVideoPlayer)_target).Loop = (Boolean)_argument; }
        public void VRC_SDK3_Video_Components_Base_BaseVRCVideoPlayer__set_enabled() { ((BaseVRCVideoPlayer)_target).enabled = (Boolean)_argument; }
        public void VRC_SDK3_Video_Components_Base_BaseVRCVideoPlayer__set_name() { ((BaseVRCVideoPlayer)_target).name = (String)_argument; }
        public void VRC_SDKBase_VRCCustomAction__Execute() { if (_argument.GetType().Equals(typeof(System.Int32))) { ((VRCCustomAction)_target).Execute((Int32)_argument); } else { ((VRCCustomAction)_target).Execute((String)_argument); } }
        public void VRC_SDKBase_VRCCustomAction__set_enabled() { ((VRCCustomAction)_target).enabled = (Boolean)_argument; }
        public void VRC_SDKBase_VRCCustomAction__set_name() { ((VRCCustomAction)_target).name = (String)_argument; }
    }
}
