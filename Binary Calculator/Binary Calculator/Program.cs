using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kaiosharp;

namespace Binary_Calculator
{
    class Program : KaioConsole
    {
        static BitArray x = new BitArray(2,false);
        static BitArray y = new BitArray(2, false);
        static BitArray z = new BitArray(4, false);
        static void Main(string[] args)
        {
            x = BinarytoBitArray("0111");
            y = BinarytoBitArray("1000");
            BitArraytoBinary(x);
            BitArraytoBinary(y);
            Tell("+");
            z = Add(x, y);
            BitArraytoBinary(z);
            Wait();
        }

        static BitArray expandBitArray(BitArray a)
        {
            BitArray ba = new BitArray(a.Length + 1, false);

            for (int i = 1; i < ba.Length; i++)
            {
                ba[i] = a[i - 1];
            }
            return ba;
        }

        static BitArray Add2(BitArray a, BitArray b)
        {
            if (a[0] && b[0])
            {
                a = expandBitArray(a);
                b = expandBitArray(b);
            }
            BitArray ba = new BitArray(a.Length, false);
            bool C = false;
            for (int i = ba.Length - 1; i >= 0; i--)
            {
                bool xor = a[i] ^ b[i];
                bool and = a[i] && b[i];
                bool xorb = xor ^ C;
                bool andb = xor && C;
                        C = xorb || andb;
                ba[i] = xorb;
            }
            return ba;
        }


        static BitArray Add(BitArray a, BitArray b)
        {
            if (a[0] && b[0])
            {
                a = expandBitArray(a);
                b = expandBitArray(b);
             
            }
            BitArray ba = new BitArray(a.Length, false);
            
                for (int i = ba.Length - 1; i >= 1; i--)
                {
                    if (a[i] && b[i])
                    {
                        ba[i-1] = true;
                        ba[i] = false;
                    }
                    else if (a[i] || b[i])
                    {
                        ba[i] = true;
                    }
                }
            
            return ba;
        }

        static BitArray BinarytoBitArray (string binary)
        {
            BitArray ba = new BitArray(binary.Length, false);
            for (int i = 0; i < binary.Length; i++)
            {
                if (binary[i] == '1')
                {
                    ba[i] = true;
                }
                else if (binary[i] == '0')
                {
                    ba[i] = false;
                }
            }
            return ba;
        }

        static void BitArraytoBinary (BitArray ba)
        {
            string binary = "";
            foreach (bool bit in ba)
            {
                if (bit)
                {
                    binary += "1";
                }
                else
                {
                    binary += "0";
                }
            }
            Tell(binary);
        }

    }
}
