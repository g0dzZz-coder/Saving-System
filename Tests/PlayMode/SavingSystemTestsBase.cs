using System.Collections;
using System.Linq;
using Depra.Saving.Runtime.Interfaces.Systems;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Assert = UnityEngine.Assertions.Assert;

namespace Depra.Saving.Tests.PlayMode
{
    public abstract class SavingSystemTestsBase<TSystem> where TSystem : ISaveSystem
    {
        #region Protected Properties
        
        protected abstract string TestKey { get; }
        protected abstract ISavingKeyStorage KeyStorage { get; }
        
        protected TSystem System { get; set; }
        
        #endregion
        
        #region Test Methods
        
        [SetUp]
        public void Setup()
        {
            KeyStorage?.DeleteAll();
            InitSystem();
            OnSetup();
        }
        
        [TearDown]
        public void Teardown()
        {
            KeyStorage.DeleteAll();
            
            OnTearDown();
        }

        [UnityTest]
        public IEnumerator Can_Save()
        {
            var state = CaptureState();
            System.Save(TestKey, state);

            yield return null;
            Assert.IsTrue(KeyStorage.HasKey(TestKey));
        }

        [UnityTest]
        public IEnumerator Can_Save_And_Load()
        {
            var state = CaptureState();
            System.Save(TestKey, state);

            yield return null;
            
            var restoredState = System.Load<object>(TestKey);
            
            Assert.IsNotNull(restoredState);
        }

        [UnityTest]
        public IEnumerator Can_Delete()
        {
            var state = CaptureState();
            System.Save("can_Delete_key", state);
            yield return null;

            Assert.IsTrue(KeyStorage.HasKey("can_Delete_key"));

            KeyStorage.DeleteKey("can_Delete_key");
            yield return null;

            Assert.IsFalse(KeyStorage.HasKey("can_Delete_key"));
        }

        [UnityTest]
        public IEnumerator Can_Delete_All()
        {
            var state = CaptureState();
            System.Save("can_Delete_All_key", state);
            yield return null;

            Assert.IsTrue(KeyStorage.HasKey("can_Delete_All_key"));

            KeyStorage.DeleteAll();
            yield return new WaitForEndOfFrame();

            Assert.IsFalse(KeyStorage.GetAllKeys().Any());
        }
        
        #endregion

        #region Abstract Methods
        
        protected abstract void InitSystem();
        
        protected abstract void OnSetup();
        protected abstract void OnTearDown();

        protected abstract object CaptureState();
        
        #endregion
    }
}