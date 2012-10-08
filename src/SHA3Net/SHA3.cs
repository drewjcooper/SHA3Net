using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace SHA3Net
{
    public abstract class SHA3 : HashAlgorithm
    {
        protected SHA3()
        {
            throw new NotImplementedException();
        }

        public static SHA3 Create()
        {
            throw new NotImplementedException();
        }
    }
}
