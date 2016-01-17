using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem22.BitFlipper
{
    class BitFlipper
    {
        static char[] ToBinary(ulong number)
        {
            char[] binary = new char[64];
            for (int i = 0; i < 64; i++)
            {
                binary[i] = '0';
            }
            int count = 0;
            while (number != 0)
            {
                if (number % 2 == 1)
                {
                    binary[count] = '1';
                }
                number /= 2;
                count++;
            }
            Array.Reverse(binary);
            return binary;
        }

        static ulong ToDecimal(char[] binary)
        {
            ulong number = 0;
            ulong power = 1;
            for (int i = binary.Length - 1; i >= 0; i--)
            {
                number += ((ulong)(binary[i] - 48) * power);
                power *= 2;
            }
            return number;
        }

        static void Main()
        {
            ulong number = ulong.Parse(Console.ReadLine());
            char[] binary = ToBinary(number);

            for (int i = 0; i < 62; i++)
            {
                if (binary[i] == binary[i + 1] && binary[i] == binary[i + 2])
                {
                    if (binary[i] == '0')
                    {
                        binary[i] = '1';
                        binary[i + 1] = '1';
                        binary[i + 2] = '1';
                    }
                    else
                    {
                        binary[i] = '0';
                        binary[i + 1] = '0';
                        binary[i + 2] = '0';
                    }
                    i += 2;
                }
            }

            number = ToDecimal(binary);
            Console.WriteLine(number);
        }
    }
}
