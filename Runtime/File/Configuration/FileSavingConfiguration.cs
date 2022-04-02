using System;
using System.Text;
using Depra.Saving.Runtime.File.Configuration.Interfaces;
using Depra.Tools.Serialization.Serializers;
using UnityEngine;

namespace Depra.Saving.Runtime.File.Configuration
{
    [Serializable]
    [AddTypeMenu("File Saving")]
    public class FileSavingConfiguration : IFileSavingConfiguration
    {
        [field: SerializeReference, SubclassSelector]
        public ISerializer Serializer { get; private set; }

        [field: SerializeReference, SubclassSelector]
        public Encoding Encoding { get; private set; }

        internal static readonly FileSavingConfiguration Default;

        static FileSavingConfiguration()
        {
            Default = new FileSavingConfiguration()
            {
                Serializer = new JsonSerializer(),
                Encoding = Encoding.Default
            };
        }
    }
}