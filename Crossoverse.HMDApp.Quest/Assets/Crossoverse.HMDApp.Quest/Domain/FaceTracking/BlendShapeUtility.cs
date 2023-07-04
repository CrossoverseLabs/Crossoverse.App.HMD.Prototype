namespace Crossoverse.HMDApp.Quest.Domain.FaceTracking
{
    public class BlendShapeUtility
    {
        public static int GetBlendShapeIndex(string blendShapeName)
        {
            var index = blendShapeName switch
            {
                nameof(BlendShapeName.browDownLeft)        => (int)BlendShapeName.browDownLeft,
                nameof(BlendShapeName.browDownRight)       => (int)BlendShapeName.browDownRight,
                nameof(BlendShapeName.browInnerUp)         => (int)BlendShapeName.browInnerUp,
                nameof(BlendShapeName.browOuterUpLeft)     => (int)BlendShapeName.browOuterUpLeft,
                nameof(BlendShapeName.browOuterUpRight)    => (int)BlendShapeName.browOuterUpRight,
                nameof(BlendShapeName.cheekPuff)           => (int)BlendShapeName.cheekPuff,
                nameof(BlendShapeName.cheekSquintLeft)     => (int)BlendShapeName.cheekSquintLeft,
                nameof(BlendShapeName.cheekSquintRight)    => (int)BlendShapeName.cheekSquintRight,
                nameof(BlendShapeName.eyeBlinkLeft)        => (int)BlendShapeName.eyeBlinkLeft,
                nameof(BlendShapeName.eyeBlinkRight)       => (int)BlendShapeName.eyeBlinkRight,
                nameof(BlendShapeName.eyeLookDownLeft)     => (int)BlendShapeName.eyeLookDownLeft,
                nameof(BlendShapeName.eyeLookDownRight)    => (int)BlendShapeName.eyeLookDownRight,
                nameof(BlendShapeName.eyeLookInLeft)       => (int)BlendShapeName.eyeLookInLeft,
                nameof(BlendShapeName.eyeLookInRight)      => (int)BlendShapeName.eyeLookInRight,
                nameof(BlendShapeName.eyeLookOutLeft)      => (int)BlendShapeName.eyeLookOutLeft,
                nameof(BlendShapeName.eyeLookOutRight)     => (int)BlendShapeName.eyeLookOutRight,
                nameof(BlendShapeName.eyeLookUpLeft)       => (int)BlendShapeName.eyeLookUpLeft,
                nameof(BlendShapeName.eyeLookUpRight)      => (int)BlendShapeName.eyeLookUpRight,
                nameof(BlendShapeName.eyeSquintLeft)       => (int)BlendShapeName.eyeSquintLeft,
                nameof(BlendShapeName.eyeSquintRight)      => (int)BlendShapeName.eyeSquintRight,
                nameof(BlendShapeName.eyeWideLeft)         => (int)BlendShapeName.eyeWideLeft,
                nameof(BlendShapeName.eyeWideRight)        => (int)BlendShapeName.eyeWideRight,
                nameof(BlendShapeName.jawForward)          => (int)BlendShapeName.jawForward,
                nameof(BlendShapeName.jawLeft)             => (int)BlendShapeName.jawLeft,
                nameof(BlendShapeName.jawOpen)             => (int)BlendShapeName.jawOpen,
                nameof(BlendShapeName.jawRight)            => (int)BlendShapeName.jawRight,
                nameof(BlendShapeName.mouthClose)          => (int)BlendShapeName.mouthClose,
                nameof(BlendShapeName.mouthDimpleLeft)     => (int)BlendShapeName.mouthDimpleLeft,
                nameof(BlendShapeName.mouthDimpleRight)    => (int)BlendShapeName.mouthDimpleRight,
                nameof(BlendShapeName.mouthFrownLeft)      => (int)BlendShapeName.mouthFrownLeft,
                nameof(BlendShapeName.mouthFrownRight)     => (int)BlendShapeName.mouthFrownRight,
                nameof(BlendShapeName.mouthFunnel)         => (int)BlendShapeName.mouthFunnel,
                nameof(BlendShapeName.mouthLeft)           => (int)BlendShapeName.mouthLeft,
                nameof(BlendShapeName.mouthLowerDownLeft)  => (int)BlendShapeName.mouthLowerDownLeft,
                nameof(BlendShapeName.mouthLowerDownRight) => (int)BlendShapeName.mouthLowerDownRight,
                nameof(BlendShapeName.mouthPressLeft)      => (int)BlendShapeName.mouthPressLeft,
                nameof(BlendShapeName.mouthPressRight)     => (int)BlendShapeName.mouthPressRight,
                nameof(BlendShapeName.mouthPucker)         => (int)BlendShapeName.mouthPucker,
                nameof(BlendShapeName.mouthRight)          => (int)BlendShapeName.mouthRight,
                nameof(BlendShapeName.mouthRollLower)      => (int)BlendShapeName.mouthRollLower,
                nameof(BlendShapeName.mouthRollUpper)      => (int)BlendShapeName.mouthRollUpper,
                nameof(BlendShapeName.mouthShrugLower)     => (int)BlendShapeName.mouthShrugLower,
                nameof(BlendShapeName.mouthShrugUpper)     => (int)BlendShapeName.mouthShrugUpper,
                nameof(BlendShapeName.mouthSmileLeft)      => (int)BlendShapeName.mouthSmileLeft,
                nameof(BlendShapeName.mouthSmileRight)     => (int)BlendShapeName.mouthSmileRight,
                nameof(BlendShapeName.mouthStretchLeft)    => (int)BlendShapeName.mouthStretchLeft,
                nameof(BlendShapeName.mouthStretchRight)   => (int)BlendShapeName.mouthStretchRight,
                nameof(BlendShapeName.mouthUpperUpLeft)    => (int)BlendShapeName.mouthUpperUpLeft,
                nameof(BlendShapeName.mouthUpperUpRight)   => (int)BlendShapeName.mouthUpperUpRight,
                nameof(BlendShapeName.noseSneerLeft)       => (int)BlendShapeName.noseSneerLeft,
                nameof(BlendShapeName.noseSneerRight)      => (int)BlendShapeName.noseSneerRight,
                nameof(BlendShapeName.tongueOut)           => (int)BlendShapeName.tongueOut,
                _ => -1,
            };
            return index;
        }
    }
}