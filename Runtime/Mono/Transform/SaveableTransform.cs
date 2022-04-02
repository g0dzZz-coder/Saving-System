using Depra.Saving.Runtime.Data;
using Depra.Saving.Runtime.Data.Transform;
using Depra.Saving.Runtime.Interfaces;
using UnityEngine;

namespace Depra.Saving.Runtime.Mono.Transform
{
    public class SaveableTransform : MonoBehaviour, ISaveable
    {
        public TransformData LastData { get; private set; }
        
        public object CaptureState()
        {
            LastData = new TransformData(transform);
            return LastData;
        }

        public void RestoreState(object state)
        {
            LastData = (TransformData)state;
            SetState(LastData);
        }

        public void SetState(TransformData data)
        {
            transform.SetPositionAndRotation(data.LocalPosition, data.LocalRotation);
            transform.localScale = data.LocalScale;
        }
    }
}