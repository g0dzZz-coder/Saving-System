using Depra.SavingSystem.Runtime.Interfaces;
using Depra.Toolkit.Serialization.Serializers;

namespace Depra.SavingSystem.Runtime.Configuration
{
    public interface ISaveConfiguration
    {
        ISaveBackend Backend { get; }
        
        ISerializer Serializer { get; }
    }
}