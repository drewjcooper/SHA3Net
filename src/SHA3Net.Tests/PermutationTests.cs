using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SHA3Net.Tests
{
    [TestFixture]
    public class PermutationTests
    {
        private Permutation permutation;

        [SetUp]
        public void SetUp()
        {
            permutation = new Permutation();
        }

        [TearDown]
        public void TearDown()
        {
            permutation = null;
        }

        [TestCase(0x0123456789abcdefUL, 12, 0x3456789abcdef012UL)]
        [TestCase(0x0123456789abcdefUL, 32, 0x89abcdef01234567UL)]
        [TestCase(0x0123456789abcdefUL, 40, 0xabcdef0123456789UL)]
        [TestCase(0x0123456789abcdefUL, 60, 0xf0123456789abcdeUL)]
        [TestCase(0x0123456789abcdefUL, 64, 0x0123456789abcdefUL)]
        [TestCase(0x0123456789abcdefUL, 1, 0x02468acf13579bdeUL)]
        [TestCase(0x0123456789abcdefUL, 2, 0x048d159e26af37bcUL)]
        [TestCase(0x0123456789abcdefUL, 3, 0x091a2b3c4d5e6F78UL)]
        [TestCase(0x0123456789abcdefUL, 4, 0x123456789abcdef0UL)]
        [TestCase(0x0123456789abcdefUL, 62, 0xc048d159e26af37bUL)]
        [TestCase(0x0123456789abcdefUL, 63, 0x8091A2B3C4D5E6F7UL)]
        [TestCase(0x8091A2B3C4D5E6F7UL, 4, 0x091A2B3C4D5E6F78UL)]
        public void TestRot(ulong initial, int offset, ulong expected)
        {
            var actual = permutation.Rot(initial, offset);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestConversionOfHexStringToStateCube()
        {
            var hexString = "00 0a 0b 0c 0d 0e 0f 00 01 0a 0b 0c 0d 0e 0f 00 02 0a 0b 0c 0d 0e 0f 00 03 0a 0b 0c 0d 0e 0f 00 04 0a 0b 0c 0d 0e 0f 00 05 0a 0b 0c 0d 0e 0f 00 06 0a 0b 0c 0d 0e 0f 00 07 0a 0b 0c 0d 0e 0f 00 08 0a 0b 0c 0d 0e 0f 00 09 0a 0b 0c 0d 0e 0f 00 10 0a 0b 0c 0d 0e 0f 00 11 0a 0b 0c 0d 0e 0f 00 12 0a 0b 0c 0d 0e 0f 00 13 0a 0b 0c 0d 0e 0f 00 14 0a 0b 0c 0d 0e 0f 00 15 0a 0b 0c 0d 0e 0f 00 16 0a 0b 0c 0d 0e 0f 00 17 0a 0b 0c 0d 0e 0f 00 18 0a 0b 0c 0d 0e 0f 00 19 0a 0b 0c 0d 0e 0f 00 20 0a 0b 0c 0d 0e 0f 00 21 0a 0b 0c 0d 0e 0f 00 22 0a 0b 0c 0d 0e 0f 00 23 0a 0b 0c 0d 0e 0f 00 24 0a 0b 0c 0d 0e 0f 00";

            var expected = new[]
            {
                new ulong[] {0x000f0e0d0c0b0a00UL, 0x000f0e0d0c0b0a05UL, 0x000f0e0d0c0b0a10UL, 0x000f0e0d0c0b0a15UL, 0x000f0e0d0c0b0a20UL},
                new ulong[] {0x000f0e0d0c0b0a01UL, 0x000f0e0d0c0b0a06UL, 0x000f0e0d0c0b0a11UL, 0x000f0e0d0c0b0a16UL, 0x000f0e0d0c0b0a21UL},
                new ulong[] {0x000f0e0d0c0b0a02UL, 0x000f0e0d0c0b0a07UL, 0x000f0e0d0c0b0a12UL, 0x000f0e0d0c0b0a17UL, 0x000f0e0d0c0b0a22UL},
                new ulong[] {0x000f0e0d0c0b0a03UL, 0x000f0e0d0c0b0a08UL, 0x000f0e0d0c0b0a13UL, 0x000f0e0d0c0b0a18UL, 0x000f0e0d0c0b0a23UL},
                new ulong[] {0x000f0e0d0c0b0a04UL, 0x000f0e0d0c0b0a09UL, 0x000f0e0d0c0b0a14UL, 0x000f0e0d0c0b0a19UL, 0x000f0e0d0c0b0a24UL}
            };

            var actual = ConvertStringToStateCube(hexString);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase("53 58 7B 39 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00",
                  "1C 12 77 08 0E 9B 8E 33 74 3F E9 0B 6C 7F 48 52 03 83 CF 27 13 85 38 F9 9E E3 10 2C 4F 03 32 CE BD 44 6B E4 64 66 03 41 23 40 26 FE 3A AE 6E 22 13 5C B8 F9 A3 D4 BA 80 45 F0 DF 62 C9 C8 F1 5B AC B5 4C 29 35 45 4D C3 29 B8 E4 DC A0 59 8F 29 66 EC 71 7E A2 F6 24 E5 A9 C7 24 0B 60 FD B0 61 B9 2C FC BA 58 2E 74 41 D1 F6 18 1F 2E 2D BC 55 AF 65 8F 68 D4 82 5B 0B 7C AC 1C 9A 8D 15 85 42 E7 B1 FA 03 FE 21 46 9E C2 7A 9A C2 63 94 FA C8 87 06 66 57 DF 78 85 1E A8 86 B2 B9 08 94 15 B0 20 92 39 55 BC 48 36 F6 B9 C8 20 98 88 EC FF 72 BD D0 EC 86 1A E6 33 1B CB 78 60 63 24 B3 C2 56 E8 24 49 27 A4 88 E6 A8")]
        [TestCase("1C 12 77 08 0E 9B 8E 33 74 3F E9 0B 6C 7F 48 52 03 83 CF 27 13 85 38 F9 9E E3 10 2C 4F 03 32 CE BD 44 6B E4 64 66 03 41 23 40 26 FE 3A AE 6E 22 13 5C B8 F9 A3 D4 BA 80 45 F0 DF 62 C9 C8 F1 5B AC B5 4C 29 35 45 4D C3 29 B8 E4 DC A0 59 8F 29 66 EC 71 7E A2 F6 24 E5 A9 C7 24 0B 60 FD B0 61 B9 2C FC BA 58 2E 74 41 D1 F6 18 1F 2E 2D BC 55 AF 65 8F 68 D4 82 5B 0B 7C AC 1C 9A 8D 15 85 42 E7 B1 FA 03 FE 21 46 9E C2 7A 9A C2 63 94 FA C8 87 06 66 57 DF 78 85 1E A8 86 B2 B9 08 94 15 B0 20 92 39 55 BC 48 36 F6 B9 C8 20 98 88 EC FF 72 BD D0 EC 86 1A E6 33 1B CB 78 60 63 24 B3 C2 56 E8 24 49 27 A4 88 E6 A8",
                  "CB 2E 82 A0 3D E7 14 5E A7 F6 A0 68 D3 66 39 A2 FB 74 61 12 FA 59 64 05 9C F6 90 95 F3 9B ED 3C B4 25 24 C2 A5 F7 42 9D 3A AE 42 CD EA 80 05 25 17 7D FB 85 CD 53 81 08 F5 9D 78 8C AF C6 93 6C EF 7E 67 7C E2 CB C3 6C 16 31 AE A9 E9 76 9B 98 17 4C 0A B5 47 15 C6 B4 27 27 33 9F CE A9 46 10 CE 08 16 89 AF 21 49 1A 57 A0 1C 16 1E 59 4E CF A4 59 97 29 04 FB 1C B8 EF 30 33 90 AD 47 21 14 3E F2 A4 8A 7F 41 12 67 9C 2E 99 41 06 E5 6B 82 EC 5D 30 37 58 59 81 7E 04 BA 13 1B EF DE 01 E8 F1 D9 D3 E4 DB 24 4E AE 94 8F 55 2E 02 66 28 A2 F3 65 21 01 92 D2 F3 BD 55 E8 9D 8A 62 D9 D3 E8 C8 9F 62 A0 BE 6B 02 1D")]
        [TestCase("CB 2E 82 A0 3D E7 14 5E A7 F6 A0 68 D3 66 39 A2 FB 74 61 12 FA 59 64 05 9C F6 90 95 F3 9B ED 3C B4 25 24 C2 A5 F7 42 9D 3A AE 42 CD EA 80 05 25 17 7D FB 85 CD 53 81 08 F5 9D 78 8C AF C6 93 6C EF 7E 67 7C E2 CB C3 6C 16 31 AE A9 E9 76 9B 98 17 4C 0A B5 47 15 C6 B4 27 27 33 9F CE A9 46 10 CE 08 16 89 AF 21 49 1A 57 A0 1C 16 1E 59 4E CF A4 59 97 29 04 FB 1C B8 EF 30 33 90 AD 47 21 14 3E F2 A4 8A 7F 41 12 67 9C 2E 99 41 06 E5 6B 82 EC 5D 30 37 58 59 81 7E 04 BA 13 1B EF DE 01 E8 F1 D9 D3 E4 DB 24 4E AE 94 8F 55 2E 02 66 28 A2 F3 65 21 01 92 D2 F3 BD 55 E8 9D 8A 62 D9 D3 E8 C8 9F 62 A0 BE 6B 02 1D",
                  "7A BF 16 EC A1 FB 58 CB DF F9 E2 E0 57 7E E9 68 19 9A D7 E4 F2 23 9F 10 0C E4 18 3E 59 13 93 7B C8 CF 19 21 16 05 54 BE 74 69 86 FF 85 EE 0D 1E 15 A7 2F FD 52 9E 3F F9 33 F4 D7 2D 04 38 B0 C0 90 B6 85 61 F3 1B AF C4 4F 02 A2 54 0C FF 71 93 87 63 79 6D FE B6 28 14 B4 23 60 4C 51 3F 6E A9 D9 B4 56 58 31 64 2E 93 4D 60 5A 12 FD 33 2F 30 3A B1 86 3F E6 9F D1 24 CD 1D 7E BD AC 75 AF B2 A0 8A 7E 5C B1 EE 51 62 3D 63 D7 9C 7C 39 B1 82 6A EE 38 89 5D 19 39 D4 9A D4 BC 16 A3 6D 8F 6A D0 14 A5 A3 A3 85 BA 22 DF F8 82 B7 A4 20 CD E3 8B C9 3C FE ED 52 97 B8 86 7D 5D 41 04 59 F5 62 CB A7 70 F5 52 69 F4 7B")]
        [TestCase("7A BF 16 EC A1 FB 58 CB DF F9 E2 E0 57 7E E9 68 19 9A D7 E4 F2 23 9F 10 0C E4 18 3E 59 13 93 7B C8 CF 19 21 16 05 54 BE 74 69 86 FF 85 EE 0D 1E 15 A7 2F FD 52 9E 3F F9 33 F4 D7 2D 04 38 B0 C0 90 B6 85 61 F3 1B AF C4 4F 02 A2 54 0C FF 71 93 87 63 79 6D FE B6 28 14 B4 23 60 4C 51 3F 6E A9 D9 B4 56 58 31 64 2E 93 4D 60 5A 12 FD 33 2F 30 3A B1 86 3F E6 9F D1 24 CD 1D 7E BD AC 75 AF B2 A0 8A 7E 5C B1 EE 51 62 3D 63 D7 9C 7C 39 B1 82 6A EE 38 89 5D 19 39 D4 9A D4 BC 16 A3 6D 8F 6A D0 14 A5 A3 A3 85 BA 22 DF F8 82 B7 A4 20 CD E3 8B C9 3C FE ED 52 97 B8 86 7D 5D 41 04 59 F5 62 CB A7 70 F5 52 69 F4 7B",
                  "75 E1 9C 6D B1 C0 83 8C A9 D6 45 35 1B 51 23 87 DE D1 12 28 3D C9 B3 5F AE B8 FA B2 4B 96 FD 80 D8 3E DA 5F BC 47 1E 91 10 0A C6 37 CC 49 40 AF 24 3E D4 F8 6F A7 AC A7 5F 2C 8A 74 EC 20 8A 39 C2 12 04 67 B9 F9 2B 94 E7 CC D9 2D F3 76 E8 36 FA B1 A5 B3 2E D6 50 07 E1 C2 5E D8 0B 03 CE 94 9F 6E 08 3F 5F D1 D0 9D 8A 7C 93 A4 79 D4 19 22 8B 97 7C B9 73 9F 31 59 A2 99 99 38 D6 AA 99 68 D2 99 27 A5 54 4D 53 E2 4C B3 73 C5 1E 09 63 6E C3 57 39 7E FB 00 FF B1 A7 1D CB 8F 59 C1 8A 98 DB BC 5F 6D 9D 65 49 90 66 AF 05 C0 9C D2 5C 03 C9 46 83 9E 6A 71 3A 06 A3 D4 7C 38 97 BB 47 CB 55 7B 47 2D E7 4D EF 16")]
        public void TestPermutationGivesExpectedResult(string initialState, string expectedState)
        {
            var state = ConvertStringToStateCube(initialState);
            var expected = ConvertStringToStateCube(expectedState);

            permutation.Execute(state);

            CollectionAssert.AreEqual(expected, state);
        }

        public ulong[][] ConvertStringToStateCube(string hexString)
        {
            var cube = new[] {new ulong[5],
                              new ulong[5],
                              new ulong[5],
                              new ulong[5],
                              new ulong[5]};

            var bytes = new Queue<byte>(hexString.Split(' ').Select(s => byte.Parse(s, NumberStyles.AllowHexSpecifier)));

            for (int y = 0; y <= 4; y++)
            {
                for (int x = 0; x <= 4; x++)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        cube[x][y] = cube[x][y] | (((ulong)bytes.Dequeue()) << (i * 8));
                    }
                }
            }

            return cube;
        }
    }
}
