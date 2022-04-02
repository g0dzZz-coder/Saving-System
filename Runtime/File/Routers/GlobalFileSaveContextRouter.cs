using Depra.Saving.Runtime.File.Context;

namespace Depra.Saving.Runtime.File.Routers
{
    public class GlobalFileSaveContextRouter : FileSaveContextRouter
    {
        public override IFileSavingContext Context { get; }
    }
}