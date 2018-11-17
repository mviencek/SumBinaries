using System;

namespace SumBinaries
{
    class Program
    {
        static void Main(string[] args)
        {
            //line input from a file read
            //values seperated by a comma
            string lineOne = "11010,00101001";
            string lineTwo = "00000,0000000";
            string lineThree = "110011,1010";
            String[] binaries = { lineOne, lineTwo, lineThree };
            foreach (string s in binaries)
            {
                String[] split = s.Split(',');

                //parse strings into ints
                int numOne = Int32.Parse(split[0]);
                int numTwo = Int32.Parse(split[1]);

                //ints for calculations
                int i = 0;
                int remainder = 0;
                //limited to a 10 digit binary number
                int[] result = new int[10];
                bool printed = false;
                while (numOne != 0 || numTwo != 0)
                {
                    //mod 10 mod 2
                    result[i++] = (numOne % 10 + numTwo % 10 + remainder) % 2;
                    //mod 10 divide 2
                    remainder = (numOne % 10 + numTwo % 10 + remainder) / 2;
                    //peel off one digit
                    numOne = numOne / 10;
                    numTwo = numTwo / 10;
                }
                //add the remainder to the array
                if (remainder != 0)
                {
                    result[i++] = remainder;
                }
                //remove leading zeros
                --i;
                while (i >= 0)
                {
                    Console.Write(result[i--]);
                    printed = true;
                }
                //print zero binary was all zeros
                if (i == -1 && !printed)
                {
                    Console.Write(0);
                }
                Console.WriteLine("");
                //should be 1000011, 0, 111101
            }
        }
    }
}

