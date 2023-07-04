using System;
using System.Linq;
using UnityEngine;
using Crossoverse.HMDApp.Quest.Domain.FaceTracking;

namespace Crossoverse.HMDApp.Quest.Behaviour.FaceTracking
{
    public class FaceTrackingTarget : MonoBehaviour
    {
        [SerializeField] string _blendShapePrefix = "";
        [SerializeField] char _blendShapePrefixDelimiter = '.';

        public bool Initialized => _initialized;
        private bool _initialized = false;

        private SkinnedMeshRenderer[] _faceMeshRenderers;
        private (int MeshIndex, int BlendShapeIndex)[] _blendShapeIndexMap = new (int MeshIndex, int BlendShapeIndex)[FaceTrackingData.BlendShapeCount];

        public void Initialize()
        {
            if (_initialized) { return; }

            _faceMeshRenderers = GetComponentsInChildren<SkinnedMeshRenderer>();

            for (int i = 0; i < _blendShapeIndexMap.Length; i++)
            {
                _blendShapeIndexMap[i] = (-1, -1);
            }

            var blendShapeNames = ((BlendShapeName[])Enum.GetValues(typeof(BlendShapeName))).Select(value => value.ToString());

            for (int meshIndex = 0; meshIndex < _faceMeshRenderers.Length; meshIndex++)
            {
                var mesh = _faceMeshRenderers[meshIndex].sharedMesh;
                if (mesh != null && mesh.blendShapeCount > 0)
                {
                    foreach (var blendShapeName in blendShapeNames)
                    {
                        var blendShapeNameInMesh = blendShapeName;
                        if (!string.IsNullOrEmpty(_blendShapePrefix))
                        {
                            blendShapeNameInMesh = $"{_blendShapePrefix}{_blendShapePrefixDelimiter}{blendShapeName}";
                        }

                        var index = BlendShapeUtility.GetBlendShapeIndex(blendShapeName);
                        var blendShapeIndexInMesh = mesh.GetBlendShapeIndex(blendShapeNameInMesh);

                        if (index >= 0 && blendShapeIndexInMesh >= 0)
                        {
                            _blendShapeIndexMap[index] = (meshIndex, blendShapeIndexInMesh);
                        }
                    }
                }
            }

            _initialized = true;
        }

        public void SetBlendShapes(FaceTrackingData data)
        {
            for (int i = 0; i < FaceTrackingData.BlendShapeCount; i++)
            {
                var meshIndex = _blendShapeIndexMap[i].MeshIndex;
                var blendShapeIndex = _blendShapeIndexMap[i].BlendShapeIndex;

                if (meshIndex >= 0 && blendShapeIndex >= 0)
                {
                    _faceMeshRenderers[meshIndex].SetBlendShapeWeight(blendShapeIndex, data.BlendShapeValues[i]);
                }
            }
        }
    }
}