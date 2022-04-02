using System;
using System.Collections.Generic;

namespace Depra.Saving.Runtime.Data.Transform
{
    [Serializable]
    public struct TransformNode
    {
        public TransformData NodeTransformData;
        public List<TransformNode> ChildrenTransformsData;
    }
}