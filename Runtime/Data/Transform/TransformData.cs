using System;
using UnityEngine;

namespace Depra.Saving.Runtime.Data.Transform
{
    [Serializable]
    public struct TransformData
    {
        public Vector3 LocalPosition;
        public Quaternion LocalRotation;
        public Vector3 LocalScale;

        public void ApplyTo(UnityEngine.Transform transform)
        {
            transform.localPosition = LocalPosition;
            transform.localRotation = LocalRotation;
            transform.localScale = LocalScale;
        }
        
        public TransformData(Vector3 position, Quaternion rotation, Vector3 scale)
        {
            LocalPosition = position;
            LocalRotation = rotation;
            LocalScale = scale;
        }

        public TransformData(UnityEngine.Transform transform) :
            this(transform.localPosition, transform.localRotation, transform.localScale)
        {
        }
    }
}