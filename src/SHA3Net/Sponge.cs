using System;
using System.Collections.Generic;
using System.Text;

namespace SHA3Net
{
    internal class Sponge
    {
        private ulong[][] state;
        private byte[] inputBlock;
        private int nextInputIndex;

        static Sponge()
        {
        }

        public Sponge(byte[] input, int bitRate, long outputLength)
        {
            throw new NotImplementedException();
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
