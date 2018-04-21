using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview
{
    class Assert
    {
        public static void That(bool value)
        {
            if (!value)
            {
                throw new AssertionException();
            }
        }
    }
    class AssertionException : Exception
    {

    }
}
