using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCR
{
    public class ChecksumGenerator
    {

        public int GenerateChecksum(string number)
        {
            int weightedSum = 0;
            for (int i = number.Length - 1; i >= 0; i--)
            {
                int digit = number[i]-'0';
                var coefficient = ((number.Length - i - 1) % 6) + 2;
                weightedSum += coefficient*digit;
            }

            int checksum = 11 - (weightedSum%11);

            if (checksum == 11)
            {
                checksum = 0;
            }else if(checksum == 10)
            {
                checksum = -1;
            }

            return checksum;
        }

        public string ValidateChecksum(string no, int checksum)
        {
            if (no.Contains("?"))
                return "ILL";
            if (no.EndsWith(checksum.ToString()))
                return "";
            else
                return "ERR";
        }
    }
}
