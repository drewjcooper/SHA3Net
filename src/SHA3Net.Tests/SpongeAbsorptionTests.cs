using NUnit.Framework;

namespace SHA3Net.Tests
{
    [TestFixture]
    public class SpongeAbsorptionTests
    {
        private Sponge sponge;

        [SetUp]
        public void SetUp()
        {
            sponge = new Sponge();
        }
    }
}
