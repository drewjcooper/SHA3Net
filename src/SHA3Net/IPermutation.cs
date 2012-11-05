using System;
using System.Collections.Generic;
using System.Text;

namespace SHA3Net
{
    public interface IPermutation
    {
        void Execute(ulong[][] state);
    }
}
