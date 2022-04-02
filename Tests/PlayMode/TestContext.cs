using Depra.Saving.Runtime.File.Configuration.Interfaces;
using Depra.Saving.Runtime.File.Configuration.Structs;
using Depra.Saving.Runtime.File.Context;
using Depra.Saving.Runtime.File.Extensions;

namespace Depra.Saving.Tests.PlayMode
{
    public class TestContext : IFileSavingContext
    {
        public IFileSavingPreferences Preferences { get; }

        public string DirectoryPath => Preferences.GetDirectoryPath();

        public string GetFullPath(string fileName) => Preferences.GetFullPath(fileName);

        public TestContext()
        {
            Preferences = new FileSavingPreferences("Test", "test", SaveGamePath.DataPath);
        }
    }
}