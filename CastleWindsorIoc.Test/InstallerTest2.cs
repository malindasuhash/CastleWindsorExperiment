using System.Linq;
using CastleWindsorIoC;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CastleWindsorIoc.Test
{
    [TestClass]
    public class InstallerTest2
    {
        [TestMethod]
        public void When_BatFeatureIsEnabled_ThereIsOnlyAGiven_ServiceInContainer()
        {
            // Arrange
            var installer = new Installer2();
            var container = installer.Install();

            var resolved = container.ResolveAll<IAnimal>();

            Assert.AreEqual(1, resolved.Count());
        }
    }
}