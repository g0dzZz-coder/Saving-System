using Depra.Saving.Runtime.File.Systems;
using Depra.Saving.Runtime.Interfaces.Systems;

namespace Depra.Saving.Tests.PlayMode
{
    public class FileSavingSystemTests : SavingSystemTestsBase<FileSaveSystem>
    {
        protected override string TestKey { get; }
        protected override ISavingKeyStorage KeyStorage => System;

        protected override void InitSystem()
        {
            System = new FileSaveSystem(new TestContext());
        }

        protected override void OnSetup()
        {
        }

        protected override void OnTearDown()
        {
        }

        protected override object CaptureState()
        {
            return null;
        }
    }
}