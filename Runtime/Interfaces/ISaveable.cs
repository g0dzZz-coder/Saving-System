using JetBrains.Annotations;

namespace Depra.Saving.Runtime.Interfaces
{
    public interface ISaveable
    {
        [PublicAPI]
        object CaptureState();

        [PublicAPI]
        void RestoreState(object state);
    }
}