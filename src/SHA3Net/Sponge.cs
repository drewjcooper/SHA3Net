using System;
using System.Collections.Generic;
using System.Text;

namespace SHA3Net
{
    internal class Sponge
    {
        private readonly IPermutation permutation;
        private readonly ulong[][] state;
        private readonly byte[] input;
        private int currentInputLength = 0;

        static Sponge()
        {
        }

        public Sponge(int bitRate, IPermutation permutation)
        {
            this.permutation = permutation;
            throw new NotImplementedException();
        }

        public Sponge(int bitRate)
            : this(bitRate, new Permutation())
        {
        }

        public void Absorb(byte[] inputBlock)
        {
            throw new NotImplementedException();
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
