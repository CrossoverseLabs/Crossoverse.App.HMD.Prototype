using Crossoverse.Core.Domain.MotionCapture.FaceTracking;

namespace Crossoverse.HMDApp.Quest.Infrastructure.FaceTracking
{
    public partial class FaceTrackingUtility
    {
        public static BlendShapeName GetBlendShapeName(OVRFaceExpressions.FaceExpression ovrFaceExpression)
        {
            var blendShapeName = ovrFaceExpression switch
            {
                OVRFaceExpressions.FaceExpression.EyesClosedL         => BlendShapeName.eyeBlinkLeft,
                OVRFaceExpressions.FaceExpression.EyesLookDownL       => BlendShapeName.eyeLookDownLeft,
                OVRFaceExpressions.FaceExpression.EyesLookRightL      => BlendShapeName.eyeLookInLeft,
                OVRFaceExpressions.FaceExpression.EyesLookLeftL       => BlendShapeName.eyeLookOutLeft,
                OVRFaceExpressions.FaceExpression.EyesLookUpL         => BlendShapeName.eyeLookUpLeft,
                OVRFaceExpressions.FaceExpression.LidTightenerL       => BlendShapeName.eyeSquintLeft,
                OVRFaceExpressions.FaceExpression.UpperLidRaiserL     => BlendShapeName.eyeWideLeft,
                OVRFaceExpressions.FaceExpression.EyesClosedR         => BlendShapeName.eyeBlinkRight,
                OVRFaceExpressions.FaceExpression.EyesLookDownR       => BlendShapeName.eyeLookDownRight,
                OVRFaceExpressions.FaceExpression.EyesLookLeftR       => BlendShapeName.eyeLookInRight,
                OVRFaceExpressions.FaceExpression.EyesLookRightR      => BlendShapeName.eyeLookOutRight,
                OVRFaceExpressions.FaceExpression.EyesLookUpR         => BlendShapeName.eyeLookUpRight,
                OVRFaceExpressions.FaceExpression.LidTightenerR       => BlendShapeName.eyeSquintRight,
                OVRFaceExpressions.FaceExpression.UpperLidRaiserR     => BlendShapeName.eyeWideRight,
                OVRFaceExpressions.FaceExpression.JawThrust           => BlendShapeName.jawForward,
                OVRFaceExpressions.FaceExpression.JawSidewaysLeft     => BlendShapeName.jawLeft,
                OVRFaceExpressions.FaceExpression.JawSidewaysRight    => BlendShapeName.jawRight,
                OVRFaceExpressions.FaceExpression.JawDrop             => BlendShapeName.jawOpen,
                OVRFaceExpressions.FaceExpression.LipsToward          => BlendShapeName.mouthClose,
                OVRFaceExpressions.FaceExpression.LipFunnelerLB       => BlendShapeName.mouthFunnel,
                OVRFaceExpressions.FaceExpression.LipPuckerL          => BlendShapeName.mouthPucker,
                OVRFaceExpressions.FaceExpression.MouthLeft           => BlendShapeName.mouthLeft,
                OVRFaceExpressions.FaceExpression.MouthRight          => BlendShapeName.mouthRight,
                OVRFaceExpressions.FaceExpression.LipCornerPullerL    => BlendShapeName.mouthSmileLeft,
                OVRFaceExpressions.FaceExpression.LipCornerPullerR    => BlendShapeName.mouthSmileRight,
                OVRFaceExpressions.FaceExpression.LipCornerDepressorL => BlendShapeName.mouthFrownLeft,
                OVRFaceExpressions.FaceExpression.LipCornerDepressorR => BlendShapeName.mouthFrownRight,
                OVRFaceExpressions.FaceExpression.DimplerL            => BlendShapeName.mouthDimpleLeft,
                OVRFaceExpressions.FaceExpression.DimplerR            => BlendShapeName.mouthDimpleRight,
                OVRFaceExpressions.FaceExpression.LipStretcherL       => BlendShapeName.mouthStretchLeft,
                OVRFaceExpressions.FaceExpression.LipStretcherR       => BlendShapeName.mouthStretchRight,
                OVRFaceExpressions.FaceExpression.LipSuckLB           => BlendShapeName.mouthRollLower,
                OVRFaceExpressions.FaceExpression.LipSuckLT           => BlendShapeName.mouthRollUpper,
                OVRFaceExpressions.FaceExpression.ChinRaiserB         => BlendShapeName.mouthShrugLower,
                OVRFaceExpressions.FaceExpression.ChinRaiserT         => BlendShapeName.mouthShrugUpper,
                OVRFaceExpressions.FaceExpression.LipPressorL         => BlendShapeName.mouthPressLeft,
                OVRFaceExpressions.FaceExpression.LipPressorR         => BlendShapeName.mouthPressRight,
                OVRFaceExpressions.FaceExpression.LowerLipDepressorL  => BlendShapeName.mouthLowerDownLeft,
                OVRFaceExpressions.FaceExpression.LowerLipDepressorR  => BlendShapeName.mouthLowerDownRight,
                OVRFaceExpressions.FaceExpression.UpperLipRaiserL     => BlendShapeName.mouthUpperUpLeft,
                OVRFaceExpressions.FaceExpression.UpperLipRaiserR     => BlendShapeName.mouthUpperUpRight,
                OVRFaceExpressions.FaceExpression.BrowLowererL        => BlendShapeName.browDownLeft,
                OVRFaceExpressions.FaceExpression.BrowLowererR        => BlendShapeName.browDownRight,
                OVRFaceExpressions.FaceExpression.InnerBrowRaiserL    => BlendShapeName.browInnerUp,
                OVRFaceExpressions.FaceExpression.OuterBrowRaiserL    => BlendShapeName.browOuterUpLeft,
                OVRFaceExpressions.FaceExpression.OuterBrowRaiserR    => BlendShapeName.browOuterUpRight,
                OVRFaceExpressions.FaceExpression.CheekPuffL          => BlendShapeName.cheekPuff,
                OVRFaceExpressions.FaceExpression.CheekRaiserL        => BlendShapeName.cheekSquintLeft,
                OVRFaceExpressions.FaceExpression.CheekRaiserR        => BlendShapeName.cheekSquintRight,
                OVRFaceExpressions.FaceExpression.NoseWrinklerL       => BlendShapeName.noseSneerLeft,
                OVRFaceExpressions.FaceExpression.NoseWrinklerR       => BlendShapeName.noseSneerRight,
                _ => BlendShapeName.unknown,
            };
            return blendShapeName;
        }
    }
}