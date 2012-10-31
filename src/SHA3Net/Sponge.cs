using System;
using System.Collections.Generic;
using System.Text;

namespace SHA3Net
{
    internal class Sponge
    {
        private readonly ulong[][] state;
        private byte[] inputBlock;
        private int nextInputIndex;
        private readonly IPermutation permutation;

        static Sponge()
        {
        }

        public Sponge(byte[] input, int bitRate, long outputLength, IPermutation permutation)
        {
            this.permutation = permutation;
            throw new NotImplementedException();
        }

        public Sponge(byte[] input, int bitRate, long outputLength)
            : this(input, bitRate, outputLength, new Permutation())
        {
        }

        public void Absorb(byte[] inputBlock)
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
