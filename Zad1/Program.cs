using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad1
{
    class Program
    {
        static string FileSizeToString(long number,int n=2)
        {
            string type;//kb, mb, gb...
            int counter = 0;//counter to follow for km, mb etc...
            double NumberFloat = number;//number goes to double, for floating point operations
            if (number < 1024)
            {
                return (number + " bytes");
            }

            NumberFloat /= 1024;
            NumberFloat = Math.Round(NumberFloat, n);

            while (NumberFloat >= 1024)
            {
                NumberFloat /= 1024;
                counter++;
            }

            switch (counter)//determine kb, mb
            {
                case 0:
                    {
                        type = "KB";
                        break;
                    }
                case 1:
                    {
                        type = "MB";
                        break;
                    }
                case 2:
                    {
                        type = "GB";
                        break;
                    }
                case 3:
                    {
                        type = "TB";
                        break;
                    }
                case 4:
                    {
                        type = "PB";
                        break;
                    }
                case 5:
                    {
                        type = "EB";
                        break;
                    }

                default://shouldnt be here
                    {
                        type = " ";
                        Console.WriteLine("error");
                        break;
                    }
            }


            NumberFloat = Math.Round(NumberFloat, n);//round to N-th digit

            string result = (NumberFloat.ToString());
            result = string.Format("{0:F"+n+"}", NumberFloat);//describing the number to Nth digit, to clear the 1 and 1.00 difference

            result+=(" " + type);
                return result;
            
            
        }
        static void Main(string[] args)
        {
            //all test from the E-Mail are here
            
            Console.WriteLine(FileSizeToString(0));
            Console.WriteLine(FileSizeToString(1));
            Console.WriteLine(FileSizeToString(2));
            Console.WriteLine(FileSizeToString(511));
            Console.WriteLine(FileSizeToString(512));
            Console.WriteLine(FileSizeToString(1023));
            Console.WriteLine(FileSizeToString(1024));
            Console.WriteLine(FileSizeToString(1025));
            Console.WriteLine(FileSizeToString(1048575));
            Console.WriteLine(FileSizeToString(1048576));
            Console.WriteLine(FileSizeToString(1048577));
            Console.WriteLine(FileSizeToString(14288043651787));
            Console.WriteLine(FileSizeToString(1126, 1));
            Console.WriteLine(FileSizeToString(1127, 1));
            Console.WriteLine(FileSizeToString(1178, 1));
            Console.WriteLine(FileSizeToString(20, 0));
            Console.WriteLine(FileSizeToString(1024, 0));
            Console.WriteLine(FileSizeToString(1127, 0));
            Console.WriteLine(FileSizeToString(1536, 0));

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("MANUAL TESTING");


            while (true)
            {
                Console.WriteLine("input number");
                long number = long.Parse(Console.ReadLine());
                while(number<0)
                {
                    Console.WriteLine("input number bigger than 0!!!");
                    number = long.Parse(Console.ReadLine());
                }
                Console.WriteLine("input numbers after decimal(OPTIONAL, PRESS ENTER TO SKIP)");
                string StringNumbersAfterDecimalPoint = Console.ReadLine();
                if (string.IsNullOrEmpty(StringNumbersAfterDecimalPoint))
                {
                    Console.WriteLine(FileSizeToString(number));
                }
                else
                {
                    int NumbersAfterDecimalPoint = int.Parse(StringNumbersAfterDecimalPoint);
                    if(NumbersAfterDecimalPoint<0)
                    {
                        NumbersAfterDecimalPoint *= -1;
                    }
                    Console.WriteLine(FileSizeToString(number,NumbersAfterDecimalPoint));
                }

            }

        }
    }
}
