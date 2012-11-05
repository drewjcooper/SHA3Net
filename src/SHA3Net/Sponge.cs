using System;
using System.Collections.Generic;
using System.Text;

namespace SHA3Net
{
    internal class Sponge
    {
        static private int defaultBitRate = 1024;

        private readonly ulong[][] state;

        private readonly IPermutation permutation;
        private readonly int bitRate;
        private readonly byte[] input;
        private int currentInputLength = 0;

        public Sponge()
            : this(defaultBitRate, new Permutation())
        {
        }

        public Sponge(int bitRate)
            : this(bitRate, new Permutation())
        {
        }

        public Sponge(IPermutation permutation)
            : this(defaultBitRate, permutation)
        {
        }

        public Sponge(int bitRate, IPermutation permutation)
        {
            if (permutation == null)
            {
                throw new ArgumentNullException("permutation");
            }

            if (bitRate <= 0 || bitRate > 1600)
            {
                throw new ArgumentOutOfRangeException("bitRate", "The bit rate must be betwen 1 and 1600, inclusive");
            }

            this.permutation = permutation;
            this.bitRate = bitRate;

            state = new[] 
            { 
                new ulong[] { 0, 0, 0, 0, 0 },
                new ulong[] { 0, 0, 0, 0, 0 },
                new ulong[] { 0, 0, 0, 0, 0 },
                new ulong[] { 0, 0, 0, 0, 0 },
                new ulong[] { 0, 0, 0, 0, 0 }
            };
        }

        public int BitRate
        {
            get { return bitRate; }
        }

        public void Absorb(byte[] inputBlock)
        {
            if (inputBlock == null)
            {
                throw new ArgumentNullException("inputBlock");
            }

            var inputSize = inputBlock.Length;
            for (int index = 0; index < inputSize; index += bitRate)
            {

            }
        }

        public void FinaliseAbsorbtion()
        {
            throw new NotImplementedException();
        }

        public byte[] Squeeze()
        {
            throw new NotImplementedException();
        }

        internal IEnumerable<IEnumerable<ulong>> State 
        { 
            get 
            {
                foreach (var row in state)
                {
                    yield return row.GetEnumerator() as IEnumerable<ulong>;
                }
            } 
        }


    }
}
