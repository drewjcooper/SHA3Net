using NUnit.Framework;

namespace SHA3Net.Tests
{
    [TestFixture]
    public class PublicInterfaceTests
    {
        [Test]
        public void CanCreateHashAlgorithmObject()
        {
            SHA3.Create();
            Assert.Pass();
        }

        [Test]
        public void ComputeHashRunsWithoutError()
        {
            SHA3.Create().ComputeHash(new byte[] { 0 });
            Assert.Pass();
        }
    }
}
