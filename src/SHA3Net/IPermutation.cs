using System;
using System.Collections.Generic;
using System.Text;

namespace SHA3Net
{
    internal interface IPermutation
    {
        void Execute(ulong[][] state);
    }
}
