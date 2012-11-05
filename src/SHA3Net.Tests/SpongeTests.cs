using NUnit.Framework;
using System;

namespace SHA3Net.Tests
{
    [TestFixture]
    public class SpongeTests : TestFixtureBase
    {
        private IPermutation mockPermutation;
        private int defaultBitRate;

        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            TestFixtureBaseSetup();
            mockPermutation = Create<IPermutation>();
            defaultBitRate = 1024;
        }

        [TestFixtureTearDown]
        public void FixtureTearDown()
        {
            TestFixtureBaseTearDown();
        }

        [Test]
        public void TestCanCreateSpongeWithDefaultPermutationAndBitRate()
        {
            var sponge = new Sponge();
            Assert.Pass();
        }

        [TestCase(1)]
        [TestCase(10)]
        [TestCase(100)]
        [TestCase(512)]
        [TestCase(1024)]
        [TestCase(1600)]
        public void TestCanCreateSpongeWithSpecificBitRateAndDefaultPermutation(int bitRate)
        {
            var sponge = new Sponge(bitRate);
            Assert.Pass();
        }

        [TestCase(-1)]
        [TestCase(-512)]
        [TestCase(1601)]
        [TestCase(65536)]
        public void TestCreatingSpongeWithInvalidBitRateAndDefaultPermutationThrowsException(int bitRate)
        {
            Assert.That(() => new Sponge(bitRate), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.Contains("bitRate"));
        }

        [TestCase(-1)]
        [TestCase(-512)]
        [TestCase(1601)]
        [TestCase(65536)]
        public void TestCreatingSpongeWithInvalidBitRateAndSpecifiedPermutationThrowsException(int bitRate)
        {
            Assert.That(() => new Sponge(bitRate, mockPermutation), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.Contains("bitRate"));
        }

        [Test]
        public void TestCanCreateSpongeWithDefaultBitRateAndSpecificPermutation()
        {
            var sponge = new Sponge(mockPermutation);
            Assert.Pass();
        }

        [TestCase(1)]
        [TestCase(10)]
        [TestCase(100)]
        [TestCase(512)]
        [TestCase(1024)]
        [TestCase(1600)]
        public void TestCanCreateSpongeWithSpecifiedBitRateAndPermutation(int bitRate)
        {
            var sponge = new Sponge(bitRate, mockPermutation);
            Assert.Pass();
        }

        [TestCase(1)]
        [TestCase(10)]
        [TestCase(100)]
        [TestCase(512)]
        [TestCase(1024)]
        [TestCase(1600)]
        public void TestSpongeBitRateIsCorrectlySetWithDefaultPermutation(int bitRate)
        {
            var sponge = new Sponge(bitRate);
            Assert.That(sponge.BitRate, Is.EqualTo(bitRate));

            sponge = new Sponge(bitRate, mockPermutation);
            Assert.That(sponge.BitRate, Is.EqualTo(bitRate));
        }

        [Test]
        public void TestSpongeCreationWithNullPermutationThrowsArgumentNullException()
        {
            Assert.That(() => new Sponge(null), Throws.TypeOf<ArgumentNullException>().With.Message.Contains("permutation"));
        }
    }
}
