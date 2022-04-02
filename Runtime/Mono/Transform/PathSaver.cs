using System.Collections.Generic;
using System.Linq;
using Depra.Saving.Runtime.Data;
using Depra.Saving.Runtime.Data.Transform;
using Depra.Saving.Runtime.Interfaces;
using NaughtyAttributes;
using UnityEngine;

namespace Depra.Saving.Runtime.Mono.Transform
{
    public class PathSaver : MonoBehaviour, ISaveable
    {
        [Min(0f)] [SerializeField] private float _minDistance = 1f;
        [SerializeField] private List<TransformData> _savedStates;

        private TransformData _lastData;

        private void Start()
        {
            _savedStates = new List<TransformData>();
            CaptureIntermediateState();
        }

        private void LateUpdate()
        {
            var distance = Vector3.Distance(transform.localPosition, _lastData.LocalPosition);
            if (distance > _minDistance)
            {
                CaptureIntermediateState();
            }
        }

        [Button]
        public void CaptureIntermediateState()
        {
            _lastData = new TransformData(transform);
            _savedStates.Add(_lastData);
        }

        public void RestoreState(object state)
        {
            _savedStates = (List<TransformData>)state;
            if (_savedStates == null)
            {
                _lastData = default;
                return;
            }

            _lastData = _savedStates.LastOrDefault();
            _lastData.ApplyTo(transform);
        }

        public object CaptureState()
        {
            return _savedStates;
        }
    }
}