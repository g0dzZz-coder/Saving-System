using Depra.Saving.Runtime.Interfaces.Systems;
using Depra.Saving.Runtime.Mono.Transform;
using Depra.Saving.Runtime.Prefs;
using UnityEngine;

namespace Depra.Saving.Tests.PlayMode
{
    public class PrefsSavingSystemTests : SavingSystemTestsBase<PlayerPrefsSaveSystem>
    {
        protected override string TestKey => "Test";
        protected override ISavingKeyStorage KeyStorage => System;

        private SaveableTransform _testTransform;

        protected override void InitSystem()
        {
            System = new PlayerPrefsSaveSystem();
        }

        protected override void OnSetup()
        {
            _testTransform = new GameObject().AddComponent<SaveableTransform>();
        }

        protected override void OnTearDown()
        {
            Object.Destroy(_testTransform.gameObject);
        }

        protected override object CaptureState()
        {
            return _testTransform.CaptureState();
        }
    }
}