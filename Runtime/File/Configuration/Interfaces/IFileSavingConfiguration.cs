using System.Text;
using Depra.Tools.Serialization.Serializers;
using JetBrains.Annotations;

namespace Depra.Saving.Runtime.File.Configuration.Interfaces
{
    public interface IFileSavingConfiguration
    {
        [PublicAPI]
        ISerializer Serializer { get; }
        
        [PublicAPI]
        Encoding Encoding { get; }
    }
}