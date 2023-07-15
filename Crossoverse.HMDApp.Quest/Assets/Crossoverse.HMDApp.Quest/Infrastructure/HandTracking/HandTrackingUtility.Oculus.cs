using Crossoverse.Core.Domain.MotionCapture.HandTracking;
using UnityEngine;

namespace Crossoverse.HMDApp.Quest.Infrastructure.HandTracking
{
    public partial class HandTrackingUtility
    {
        public static OVRPlugin.BoneId GetOVRBone(FingerBone bone)
        {
            var boneId = bone switch
            {
                // Left hand
                FingerBone.LeftThumbMetacarpal => OVRPlugin.BoneId.Body_LeftHandThumbMetacarpal,
                FingerBone.LeftThumbProximal => OVRPlugin.BoneId.Body_LeftHandThumbProximal,
                FingerBone.LeftThumbDistal => OVRPlugin.BoneId.Body_LeftHandThumbDistal,
                FingerBone.LeftIndexProximal => OVRPlugin.BoneId.Body_LeftHandIndexProximal,
                FingerBone.LeftIndexIntermediate => OVRPlugin.BoneId.Body_LeftHandIndexIntermediate,
                FingerBone.LeftIndexDistal => OVRPlugin.BoneId.Body_LeftHandIndexDistal,
                FingerBone.LeftMiddleProximal => OVRPlugin.BoneId.Body_LeftHandMiddleProximal,
                FingerBone.LeftMiddleIntermediate => OVRPlugin.BoneId.Body_LeftHandMiddleIntermediate,
                FingerBone.LeftMiddleDistal => OVRPlugin.BoneId.Body_LeftHandMiddleDistal,
                FingerBone.LeftRingProximal => OVRPlugin.BoneId.Body_LeftHandRingProximal,
                FingerBone.LeftRingIntermediate => OVRPlugin.BoneId.Body_LeftHandRingIntermediate,
                FingerBone.LeftRingDistal => OVRPlugin.BoneId.Body_LeftHandRingDistal,
                FingerBone.LeftLittleProximal => OVRPlugin.BoneId.Body_LeftHandLittleProximal,
                FingerBone.LeftLittleIntermediate => OVRPlugin.BoneId.Body_LeftHandLittleIntermediate,
                FingerBone.LeftLittleDistal => OVRPlugin.BoneId.Body_LeftHandLittleDistal,
                // Right hand
                FingerBone.RightThumbMetacarpal => OVRPlugin.BoneId.Body_RightHandThumbMetacarpal,
                FingerBone.RightThumbProximal => OVRPlugin.BoneId.Body_RightHandThumbProximal,
                FingerBone.RightThumbDistal => OVRPlugin.BoneId.Body_RightHandThumbDistal,
                FingerBone.RightIndexProximal => OVRPlugin.BoneId.Body_RightHandIndexProximal,
                FingerBone.RightIndexIntermediate => OVRPlugin.BoneId.Body_RightHandIndexIntermediate,
                FingerBone.RightIndexDistal => OVRPlugin.BoneId.Body_RightHandIndexDistal,
                FingerBone.RightMiddleProximal => OVRPlugin.BoneId.Body_RightHandMiddleProximal,
                FingerBone.RightMiddleIntermediate => OVRPlugin.BoneId.Body_RightHandMiddleIntermediate,
                FingerBone.RightMiddleDistal => OVRPlugin.BoneId.Body_RightHandMiddleDistal,
                FingerBone.RightRingProximal => OVRPlugin.BoneId.Body_RightHandRingProximal,
                FingerBone.RightRingIntermediate => OVRPlugin.BoneId.Body_RightHandRingIntermediate,
                FingerBone.RightRingDistal => OVRPlugin.BoneId.Body_RightHandRingDistal,
                FingerBone.RightLittleProximal => OVRPlugin.BoneId.Body_RightHandLittleProximal,
                FingerBone.RightLittleIntermediate => OVRPlugin.BoneId.Body_RightHandLittleIntermediate,
                FingerBone.RightLittleDistal => OVRPlugin.BoneId.Body_RightHandLittleDistal,
                // Default
                _ => OVRPlugin.BoneId.Invalid,
            };
            return boneId;
        }

        public static FingerBone GetFingerBone(OVRPlugin.BoneId boneId)
        {
            var fingerBone = boneId switch
            {
                // Left hand
                OVRPlugin.BoneId.Body_LeftHandThumbMetacarpal => FingerBone.LeftThumbMetacarpal,
                OVRPlugin.BoneId.Body_LeftHandThumbProximal => FingerBone.LeftThumbProximal,
                OVRPlugin.BoneId.Body_LeftHandThumbDistal => FingerBone.LeftThumbDistal,
                OVRPlugin.BoneId.Body_LeftHandIndexProximal => FingerBone.LeftIndexProximal,
                OVRPlugin.BoneId.Body_LeftHandIndexIntermediate => FingerBone.LeftIndexIntermediate,
                OVRPlugin.BoneId.Body_LeftHandIndexDistal => FingerBone.LeftIndexDistal,
                OVRPlugin.BoneId.Body_LeftHandMiddleProximal => FingerBone.LeftMiddleProximal,
                OVRPlugin.BoneId.Body_LeftHandMiddleIntermediate => FingerBone.LeftMiddleIntermediate,
                OVRPlugin.BoneId.Body_LeftHandMiddleDistal => FingerBone.LeftMiddleDistal,
                OVRPlugin.BoneId.Body_LeftHandRingProximal => FingerBone.LeftRingProximal,
                OVRPlugin.BoneId.Body_LeftHandRingIntermediate => FingerBone.LeftRingIntermediate,
                OVRPlugin.BoneId.Body_LeftHandRingDistal => FingerBone.LeftRingDistal,
                OVRPlugin.BoneId.Body_LeftHandLittleProximal => FingerBone.LeftLittleProximal,
                OVRPlugin.BoneId.Body_LeftHandLittleIntermediate => FingerBone.LeftLittleIntermediate,
                OVRPlugin.BoneId.Body_LeftHandLittleDistal => FingerBone.LeftLittleDistal,
                // Right hand
                OVRPlugin.BoneId.Body_RightHandThumbMetacarpal => FingerBone.RightThumbMetacarpal,
                OVRPlugin.BoneId.Body_RightHandThumbProximal => FingerBone.RightThumbProximal,
                OVRPlugin.BoneId.Body_RightHandThumbDistal => FingerBone.RightThumbDistal,
                OVRPlugin.BoneId.Body_RightHandIndexProximal => FingerBone.RightIndexProximal,
                OVRPlugin.BoneId.Body_RightHandIndexIntermediate => FingerBone.RightIndexIntermediate,
                OVRPlugin.BoneId.Body_RightHandIndexDistal => FingerBone.RightIndexDistal,
                OVRPlugin.BoneId.Body_RightHandMiddleProximal => FingerBone.RightMiddleProximal,
                OVRPlugin.BoneId.Body_RightHandMiddleIntermediate => FingerBone.RightMiddleIntermediate,
                OVRPlugin.BoneId.Body_RightHandMiddleDistal => FingerBone.RightMiddleDistal,
                OVRPlugin.BoneId.Body_RightHandRingProximal => FingerBone.RightRingProximal,
                OVRPlugin.BoneId.Body_RightHandRingIntermediate => FingerBone.RightRingIntermediate,
                OVRPlugin.BoneId.Body_RightHandRingDistal => FingerBone.RightRingDistal,
                OVRPlugin.BoneId.Body_RightHandLittleProximal => FingerBone.RightLittleProximal,
                OVRPlugin.BoneId.Body_RightHandLittleIntermediate => FingerBone.RightLittleIntermediate,
                OVRPlugin.BoneId.Body_RightHandLittleDistal => FingerBone.RightLittleDistal,
                // Default
                _ => FingerBone.Invalid,
            };
            return fingerBone;
        }

        public static OVRPlugin.BoneId GetOVRBone(HumanBodyBones bone)
        {
            var boneId = bone switch
            {
                // Left hand
                HumanBodyBones.LeftThumbProximal => OVRPlugin.BoneId.Body_LeftHandThumbMetacarpal,
                HumanBodyBones.LeftThumbIntermediate => OVRPlugin.BoneId.Body_LeftHandThumbProximal,
                HumanBodyBones.LeftThumbDistal => OVRPlugin.BoneId.Body_LeftHandThumbDistal,
                HumanBodyBones.LeftIndexProximal => OVRPlugin.BoneId.Body_LeftHandIndexProximal,
                HumanBodyBones.LeftIndexIntermediate => OVRPlugin.BoneId.Body_LeftHandIndexIntermediate,
                HumanBodyBones.LeftIndexDistal => OVRPlugin.BoneId.Body_LeftHandIndexDistal,
                HumanBodyBones.LeftMiddleProximal => OVRPlugin.BoneId.Body_LeftHandMiddleProximal,
                HumanBodyBones.LeftMiddleIntermediate => OVRPlugin.BoneId.Body_LeftHandMiddleIntermediate,
                HumanBodyBones.LeftMiddleDistal => OVRPlugin.BoneId.Body_LeftHandMiddleDistal,
                HumanBodyBones.LeftRingProximal => OVRPlugin.BoneId.Body_LeftHandRingProximal,
                HumanBodyBones.LeftRingIntermediate => OVRPlugin.BoneId.Body_LeftHandRingIntermediate,
                HumanBodyBones.LeftRingDistal => OVRPlugin.BoneId.Body_LeftHandRingDistal,
                HumanBodyBones.LeftLittleProximal => OVRPlugin.BoneId.Body_LeftHandLittleProximal,
                HumanBodyBones.LeftLittleIntermediate => OVRPlugin.BoneId.Body_LeftHandLittleIntermediate,
                HumanBodyBones.LeftLittleDistal => OVRPlugin.BoneId.Body_LeftHandLittleDistal,
                // Right hand
                HumanBodyBones.RightThumbProximal => OVRPlugin.BoneId.Body_RightHandThumbMetacarpal,
                HumanBodyBones.RightThumbIntermediate => OVRPlugin.BoneId.Body_RightHandThumbProximal,
                HumanBodyBones.RightThumbDistal => OVRPlugin.BoneId.Body_RightHandThumbDistal,
                HumanBodyBones.RightIndexProximal => OVRPlugin.BoneId.Body_RightHandIndexProximal,
                HumanBodyBones.RightIndexIntermediate => OVRPlugin.BoneId.Body_RightHandIndexIntermediate,
                HumanBodyBones.RightIndexDistal => OVRPlugin.BoneId.Body_RightHandIndexDistal,
                HumanBodyBones.RightMiddleProximal => OVRPlugin.BoneId.Body_RightHandMiddleProximal,
                HumanBodyBones.RightMiddleIntermediate => OVRPlugin.BoneId.Body_RightHandMiddleIntermediate,
                HumanBodyBones.RightMiddleDistal => OVRPlugin.BoneId.Body_RightHandMiddleDistal,
                HumanBodyBones.RightRingProximal => OVRPlugin.BoneId.Body_RightHandRingProximal,
                HumanBodyBones.RightRingIntermediate => OVRPlugin.BoneId.Body_RightHandRingIntermediate,
                HumanBodyBones.RightRingDistal => OVRPlugin.BoneId.Body_RightHandRingDistal,
                HumanBodyBones.RightLittleProximal => OVRPlugin.BoneId.Body_RightHandLittleProximal,
                HumanBodyBones.RightLittleIntermediate => OVRPlugin.BoneId.Body_RightHandLittleIntermediate,
                HumanBodyBones.RightLittleDistal => OVRPlugin.BoneId.Body_RightHandLittleDistal,
                // Default
                _ => OVRPlugin.BoneId.Invalid,
            };
            return boneId;
        }

        public static HumanBodyBones GetHumanBodyBone(OVRPlugin.BoneId boneId)
        {
            var humanBone = boneId switch
            {
                // Left hand
                OVRPlugin.BoneId.Body_LeftHandThumbMetacarpal => HumanBodyBones.LeftThumbProximal,
                OVRPlugin.BoneId.Body_LeftHandThumbProximal => HumanBodyBones.LeftThumbIntermediate,
                OVRPlugin.BoneId.Body_LeftHandThumbDistal => HumanBodyBones.LeftThumbDistal,
                OVRPlugin.BoneId.Body_LeftHandIndexProximal => HumanBodyBones.LeftIndexProximal,
                OVRPlugin.BoneId.Body_LeftHandIndexIntermediate => HumanBodyBones.LeftIndexIntermediate,
                OVRPlugin.BoneId.Body_LeftHandIndexDistal => HumanBodyBones.LeftIndexDistal,
                OVRPlugin.BoneId.Body_LeftHandMiddleProximal => HumanBodyBones.LeftMiddleProximal,
                OVRPlugin.BoneId.Body_LeftHandMiddleIntermediate => HumanBodyBones.LeftMiddleIntermediate,
                OVRPlugin.BoneId.Body_LeftHandMiddleDistal => HumanBodyBones.LeftMiddleDistal,
                OVRPlugin.BoneId.Body_LeftHandRingProximal => HumanBodyBones.LeftRingProximal,
                OVRPlugin.BoneId.Body_LeftHandRingIntermediate => HumanBodyBones.LeftRingIntermediate,
                OVRPlugin.BoneId.Body_LeftHandRingDistal => HumanBodyBones.LeftRingDistal,
                OVRPlugin.BoneId.Body_LeftHandLittleProximal => HumanBodyBones.LeftLittleProximal,
                OVRPlugin.BoneId.Body_LeftHandLittleIntermediate => HumanBodyBones.LeftLittleIntermediate,
                OVRPlugin.BoneId.Body_LeftHandLittleDistal => HumanBodyBones.LeftLittleDistal,
                // Right hand
                OVRPlugin.BoneId.Body_RightHandThumbMetacarpal => HumanBodyBones.RightThumbProximal,
                OVRPlugin.BoneId.Body_RightHandThumbProximal => HumanBodyBones.RightThumbIntermediate,
                OVRPlugin.BoneId.Body_RightHandThumbDistal => HumanBodyBones.RightThumbDistal,
                OVRPlugin.BoneId.Body_RightHandIndexProximal => HumanBodyBones.RightIndexProximal,
                OVRPlugin.BoneId.Body_RightHandIndexIntermediate => HumanBodyBones.RightIndexIntermediate,
                OVRPlugin.BoneId.Body_RightHandIndexDistal => HumanBodyBones.RightIndexDistal,
                OVRPlugin.BoneId.Body_RightHandMiddleProximal => HumanBodyBones.RightMiddleProximal,
                OVRPlugin.BoneId.Body_RightHandMiddleIntermediate => HumanBodyBones.RightMiddleIntermediate,
                OVRPlugin.BoneId.Body_RightHandMiddleDistal => HumanBodyBones.RightMiddleDistal,
                OVRPlugin.BoneId.Body_RightHandRingProximal => HumanBodyBones.RightRingProximal,
                OVRPlugin.BoneId.Body_RightHandRingIntermediate => HumanBodyBones.RightRingIntermediate,
                OVRPlugin.BoneId.Body_RightHandRingDistal => HumanBodyBones.RightRingDistal,
                OVRPlugin.BoneId.Body_RightHandLittleProximal => HumanBodyBones.RightLittleProximal,
                OVRPlugin.BoneId.Body_RightHandLittleIntermediate => HumanBodyBones.RightLittleIntermediate,
                OVRPlugin.BoneId.Body_RightHandLittleDistal => HumanBodyBones.RightLittleDistal,
                // Default
                _ => HumanBodyBones.LastBone,
            };
            return humanBone;
        }
    }
}