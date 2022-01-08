namespace Depra.SavingSystem.Runtime.Interfaces
{
    public interface ISaveable
    {
        object CaptureState();
        void RestoreState(object state);
    }
}