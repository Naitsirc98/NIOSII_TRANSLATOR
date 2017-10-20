using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AssemblyToBinaryTranslator
{
    public static class BinaryUtilities
    {

        public static string ToBinary(int data, int bytes, bool frontPadding = true)
        {

            StringBuilder builder = new StringBuilder(Convert.ToString(data, 2));

            int i = frontPadding ? 0 : builder.Length;

            while(builder.Length < bytes)
            {
                builder.Insert(i, '0');
            }

            return builder.ToString();

        }

        public static string ApplyPadding(string binaryNumber, int bytesForPadding)
        {

            StringBuilder builder = new StringBuilder(binaryNumber);

            for(int i = bytesForPadding; i < builder.Length;i+= bytesForPadding+1)
            {
                builder.Insert(i, " ");
            }

            return builder.ToString();
        }


    }
}
