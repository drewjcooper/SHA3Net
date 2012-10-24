using System;
using System.Collections.Generic;
using System.Text;

namespace SHA3Net
{
    internal class Sponge
    {
        private long[][] a;
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

        internal IEnumerable<IEnumerable<byte>> State 
        { 
            get 
            {
                foreach (var row in a)
                {
                    yield return row.GetEnumerator() as IEnumerable<byte>;
                }
            } 
        }


    }
}
