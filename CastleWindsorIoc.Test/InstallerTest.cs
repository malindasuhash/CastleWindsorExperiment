using CastleWindsorIoC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastleWindsorIoc.Test
{
    [TestClass]
    public class InstallerTest
    {
        [TestMethod]
        public void When_BatFeatureIsTurnedOn_There_ShouldOnlyBeThatInstanceRegistered()
        {
            // Arrange
            var installer = new Installer();
            var container = installer.Install();

            // Act
            var result = container.ResolveAll<IAnimal>();

            // Assert
            Assert.AreEqual(1, result.Count());
            var msg = container.Resolve<IAnimal>().Name;
            Assert.AreEqual("Bat", msg);

            // Release
            container.Dispose();
            container = null;
        }
    }
}
