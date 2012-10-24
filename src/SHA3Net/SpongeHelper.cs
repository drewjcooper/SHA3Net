using System;
using System.Collections.Generic;
using System.Text;

namespace SHA3Net
{
    internal static class SpongeHelper
    {
        private static readonly ulong[] roundConstants;
        private static readonly int[][] shiftOffsets;

        private static readonly ulong[][] b;
        private static readonly ulong[] c;
        private static readonly ulong[] d;

        static SpongeHelper()
        {
            b = new[] {new ulong[5],
                        new ulong[5],
                        new ulong[5],
                        new ulong[5],
                        new ulong[5]};
            c = new ulong[5];
            d = new ulong[5];

            roundConstants = new[] {0x0000000000000001UL, 0x0000000000008082UL, 0x800000000000808AUL,
                                    0x8000000080008000UL, 0x000000000000808BUL, 0x0000000080000001UL,
                                    0x8000000080008081UL, 0x8000000000008009UL, 0x000000000000008AUL,
                                    0x0000000000000088UL, 0x0000000080008009UL, 0x000000008000000AUL, 
                                    0x000000008000808BUL, 0x800000000000008BUL, 0x8000000000008089UL,                                    0x8000000000008003UL, 0x8000000000008002UL, 0x8000000000000080UL,                                    0x000000000000800AUL, 0x800000008000000AUL, 0x8000000080008081UL,                                     0x8000000000008080UL, 0x0000000080000001UL, 0x8000000080008008UL};

            shiftOffsets = new[] {new [] {0, 36, 3, 41, 18},
                                  new [] {1, 44, 10, 45, 2},
                                  new [] {62, 6, 43, 15, 61},
                                  new [] {28, 55, 25, 21, 56},
                                  new [] {27, 20, 39, 8, 14}};
        }

        static internal void PermuteState(ulong[][] a)
        {
            for (int round = 0; round < 24; round++)
            {
                DoThetaStep(a);
                DoRhoPiSteps(a);
                DoChiStep(a);
                DoIotaStep(a, roundConstants[round]);
            }
        }

        static private void DoThetaStep(ulong[][] a)
        {
            for (int x = 0; x <= 4; x++)
            {
                var ax = a[x];
                c[x] = ax[0] ^ ax[1] ^ ax[2] ^ ax[3] ^ ax[4];
            }
            for (int x = 0; x <= 4; x++)
            {
                d[x] = c[(x + 4) % 5] ^ Rot(c[(x + 1) % 5], 1);
                for (int y = 0; y <= 4; y++)
                {
                    a[x][y] = a[x][y] ^ d[x];
                }
            }
        }

        static private void DoRhoPiSteps(ulong[][] a)
        {
            for (int x = 0; x <= 4; x++)
            {
                for (int y = 0; y <= 4; y++)
                {
                    b[y][(2 * x + 3 * y) % 5] = Rot(a[x][y], shiftOffsets[x][y]);
                }
            }
        }

        static private void DoChiStep(ulong[][] a)
        {
            for (int x = 0; x <= 4; x++)
            {
                for (int y = 0; y <= 4; y++)
                {
                    a[x][y] = b[x][y] ^ (~b[(x + 1) % 5][y] & b[(x + 2) % 5][y]);
                }
            }
        }

        static private void DoIotaStep(ulong[][] a, ulong RC)
        {
            a[0][0] ^= RC;
        }

        static internal ulong Rot(ulong value, int offset)
        {
            return (value << offset) | (value >> (64 - offset));
        }
    }
}
