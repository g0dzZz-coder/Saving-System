using System.Collections.Generic;
using JetBrains.Annotations;

namespace Depra.Saving.Runtime.Interfaces
{
    public interface ISavingRoot
    {
        [PublicAPI]
        IEnumerable<ISaveable> GetAllSaveables();
    }
}