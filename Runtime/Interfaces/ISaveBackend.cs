namespace Depra.SavingSystem.Runtime.Interfaces
{
    public interface ISaveBackend : ISaveSystem
    {
        object LoadRaw(string key);
        void SaveRaw(string key, object value);
    }
}