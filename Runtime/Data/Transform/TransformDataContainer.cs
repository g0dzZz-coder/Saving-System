using UnityEngine;

namespace Depra.Saving.Runtime.Data.Transform
{
    [CreateAssetMenu(fileName = "Transform Data Container", menuName = "Misc/SO/TransformData", order = 51)]
    public class TransformDataContainer : ScriptableObject
    {
        public TransformNode ParentNode;
    }
}