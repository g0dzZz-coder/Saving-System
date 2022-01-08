using System;
using System.Collections.Generic;

namespace Depra.SavingSystem.Runtime.Data
{
    [Serializable]
    public struct TransformNode
    {
        public TransformData NodeTransformData;
        public List<TransformNode> ChildrenTransformsData;
    }
}