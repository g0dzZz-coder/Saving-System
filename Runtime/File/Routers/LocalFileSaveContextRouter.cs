using Depra.Saving.Runtime.File.Context;
using Depra.Saving.Runtime.File.Systems;
using Depra.Tools.Serialization.Interfaces.Runtime;
using UnityEngine;

namespace Depra.Saving.Runtime.File.Routers
{
    public class LocalFileSaveContextRouter : FileSaveContextRouter
    {
        [SerializeField] private InterfaceReference<FileSaveSystem> _system;

        public override IFileSavingContext Context => _system.Value.Context;
    }
}