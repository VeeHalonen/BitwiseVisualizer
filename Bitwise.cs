using System;
using System.Threading;

namespace BitwiseVisualizer
{
    public class Bitwise
    {
        public uint NumberDecimal { get; set; }
        public string NumberBinary { get; private set; }

        public Bitwise()
        {
            NumberDecimal = 0;
            NumberBinary = ConvertToBinary(NumberDecimal);
        }


        public Bitwise(uint i)
        {
            NumberDecimal = i;
            NumberBinary = ConvertToBinary(NumberDecimal);
        }


        /* Converts given positive integer to binary.
         * Adds leading zeros to always have at least 8-bit strings. */
        public static string ConvertToBinary(uint decim)
        {
            string bString = "";

            if (decim == 0)
            {
                bString = "0";
            }
            else
            {
                uint tmp = decim;
                while (tmp != 0)
                {
                    bString = bString.Insert(0, (tmp % 2).ToString());

                    tmp = (tmp - (tmp % 2)) / 2;
                }
            }

            // Insert leading zeros to get at least 8 bits
            for (int i = bString.Length; i < 8; i++)
            {
                bString = bString.Insert(0, "0");
            }

            return bString;
        }

        /* Converts given binary string to decimal, returns -1 if conversion is not possible */
        public static long ConvertToDecimal(string binaryString)
        {

            // Do not perform on empty strings
            if (binaryString == "")
            {
                return -1;
            }

            double result = 0;

            for (int i = binaryString.Length-1, round = 0; i >= 0; i--, round++)
            {
                
                // If a character other than 1 or 0 is found, method fails
                if (binaryString[i] != '1' && binaryString[i] != '0')
                    return -1;

                if (binaryString[i] == '1')
                {
                    result += Math.Pow(2, round);
                }
            }

            // Convert from double to long
            try
            {
                checked
                {
                    return Convert.ToInt64(result);
                }
            }
            catch (OverflowException)
            {
                return -1;
            }
        }

        /* Adds leading zeroes to binary string to help equalize string lengths */
        private static string InsertLeadingZeros(string binaryString, int zeros)
        {
            string newBinaryString = binaryString;

            for (int i = 0; i < zeros; i++)
            {
                newBinaryString = newBinaryString.Insert(0, "0");
            }

            return newBinaryString;

        }

        /* Performs the specified bitwise set operation (AND, OR, or XOR) to the current object.
         * Takes the name of the operation and the second binary string as parameters.
         * Returns a new object with the result. Original remains unchanged. */
        private Bitwise PerformOperation(string operation, string binaryStringB)
        {

            string binaryStringA = NumberBinary;

            int len1 = binaryStringA.Length;
            int len2 = binaryStringB.Length;

            string newBinaryString = "";

            // Equalize string lengths by adding zeros
            if (len1 > len2)
            {
                binaryStringB = InsertLeadingZeros(binaryStringB, len1 - len2);
            }
            else if (len2 > len1)
            {
                binaryStringA = InsertLeadingZeros(binaryStringA, len2 - len1);
                len1 = len2;
            }

            /* Perform the appropriate operation and construct the new string */

            if (operation == "AND")
            {
                for (int i = 0; i < len1; i++)
                {
                    if ((binaryStringA[i] == '1') && (binaryStringB[i] == '1'))
                        newBinaryString += "1";
                    else
                        newBinaryString += "0";
                }
            }
            else if (operation == "OR")
            {
                for (int i = 0; i < len1; i++)
                {
                    if ((binaryStringA[i] == '1') || (binaryStringB[i] == '1'))
                        newBinaryString += "1";
                    else
                        newBinaryString += "0";
                }
            }
            else if (operation == "XOR")
            {
                for (int i = 0; i < len1; i++)
                {
                    if ((binaryStringA[i] == '1') && (binaryStringB[i] == '0'))
                        newBinaryString += "1";
                    else if ((binaryStringA[i] == '0') && (binaryStringB[i] == '1'))
                        newBinaryString += "1";
                    else
                        newBinaryString += "0";
                }
            }
            // If operation was recognized, return empty string
            else
            {
                Console.WriteLine("Invalid call.");
                return null;
            }

            // Convert to decimal
            long newDecimal = ConvertToDecimal(newBinaryString);

            // If something went wrong, return empty string and do nothing
            if (newDecimal < 0 || newDecimal > uint.MaxValue)
            {
                Console.WriteLine("Operation failed.");
                return null;
            }

            // Otherwise return a new Bitwise object
            return new Bitwise((uint)newDecimal);

        }

        /* Performs the bitwise AND operation and returns the new object */
        public Bitwise BitwiseAnd(string binaryStringB)
        {
            return PerformOperation("AND", binaryStringB);
        }


        /* Performs the bitwise OR operation and returns the new object */
        public Bitwise BitwiseOr(string binaryStringB)
        {
            return PerformOperation("OR", binaryStringB);
        }

        /* Performs the bitwise XOR operation and returns the new object */
        public Bitwise BitwiseXor(string binaryStringB)
        {
            return PerformOperation("XOR", binaryStringB);
        }

        /* Performs the bitwise NOT operation and returns the new object */
        public Bitwise BitwiseNot()
        {
            string newBinaryString = "";

            // Reverse bits
            for (int i = 0; i < NumberBinary.Length; i++)
            {
                if (NumberBinary[i] == '1')
                    newBinaryString += '0';
                else if (NumberBinary[i] == '0')
                    newBinaryString += '1';
                else
                    return null;
            }

            // Convert, assign, and return

            long newDecimal = ConvertToDecimal(newBinaryString);
            if (newDecimal < 0 || newDecimal > uint.MaxValue)
            {
                Console.WriteLine("Operation failed.");
                return null;
            }

            return new Bitwise((uint)newDecimal);
        }

        /* Performs the bitwise LEFT-SHIFT operation and returns the new object */
        public Bitwise BitwiseShiftLeft(int steps)
        {
            string newBinaryString = "";

            // Make sure steps don't exceed binary string length
            if (steps > NumberBinary.Length)
                steps = NumberBinary.Length;

            // Shift to new string
            for (int i = steps; i < NumberBinary.Length; i++)
            {
                newBinaryString += NumberBinary[i];
            }
            
            // Add zeros to fill the rest
            for (int i = 0; i < steps; i++)
            {
                newBinaryString += "0";
            }
            


            // Convert, assign, and return

            long newDecimal = ConvertToDecimal(newBinaryString);
            if (newDecimal < 0 || newDecimal > uint.MaxValue)
            {
                Console.WriteLine("Operation failed.");
                return null;
            }

            return new Bitwise((uint)newDecimal);
        }

        /* Performs the bitwise RIGHT-SHIFT operation and returns the new object */
        public Bitwise BitwiseShiftRight(int steps)
        {
            string newBinaryString = "";

            // Make sure steps don't exceed binary string length
            if (steps > NumberBinary.Length)
                steps = NumberBinary.Length;


            // Add zeros - for visualization purposes
            for (int i = 0; i < steps; i++)
            {
                newBinaryString += "0";
            }

            // Shift the rest
            for (int i = 0; i < NumberBinary.Length-steps; i++)
            {
                newBinaryString += NumberBinary[i];
            }


            // Convert, assign, and return

            long newDecimal = ConvertToDecimal(newBinaryString);
            if (newDecimal < 0 || newDecimal > uint.MaxValue)
            {
                Console.WriteLine("Operation failed.");
                return null;
            }

            return new Bitwise((uint)newDecimal);
        }

        /* Prints the set operators' (AND, OR, XOR) results for the current and given object. 
         * Uses Thread to print row by row in a timed manner. */
        public void PrintSetOperations(Bitwise b2)
        {

            if (b2 == null)
            {
                return;
            }

            // Equalize lengths for presentation
            int len1 = this.NumberBinary.Length;
            int len2 = b2.NumberBinary.Length;

            if (len1 > len2)
            {
                b2.NumberBinary = InsertLeadingZeros(b2.NumberBinary, len1 - len2);
            }
            else if (len2 > len1)
            {
                this.NumberBinary = InsertLeadingZeros(this.NumberBinary, len2 - len1);
            }


            // AND
            Thread.Sleep(500);
            Console.WriteLine();
            Console.WriteLine(this);
            Console.WriteLine("AND");
            Thread.Sleep(500);
            Console.WriteLine(b2);
            Thread.Sleep(500);
            Console.WriteLine("=");
            Thread.Sleep(1000);
            Console.WriteLine(BitwiseAnd(b2.NumberBinary));
            Console.WriteLine();

            // OR
            Thread.Sleep(500);
            Console.WriteLine();
            Console.WriteLine(this);
            Console.WriteLine("OR");
            Thread.Sleep(500);
            Console.WriteLine(b2);
            Thread.Sleep(500);
            Console.WriteLine("=");
            Thread.Sleep(1000);
            Console.WriteLine(BitwiseOr(b2.NumberBinary));
            Console.WriteLine();

            // XOR
            Thread.Sleep(500);
            Console.WriteLine();
            Console.WriteLine(this);
            Console.WriteLine("XOR");
            Thread.Sleep(500);
            Console.WriteLine(b2);
            Thread.Sleep(500);
            Console.WriteLine("=");
            Thread.Sleep(1000);
            Console.WriteLine(BitwiseXor(b2.NumberBinary));
            Console.WriteLine();




            Thread.Sleep(500);
        }

        /* Prints the non-set operators' (NOT, << 1, >> 1) results for the current object.
         * Uses Thread to print row by row in a timed manner. */
        public void PrintNonSetOperations()
        {
            // NOT
            Thread.Sleep(500);
            Console.WriteLine();
            Console.WriteLine("NOT");
            Console.WriteLine(this);
            Thread.Sleep(500);
            Console.WriteLine("=");
            Thread.Sleep(1000);
            Console.WriteLine(BitwiseNot());
            Console.WriteLine();

            // Left shift
            Thread.Sleep(1000);
            Console.WriteLine(this);
            Console.WriteLine(" << 1");
            Thread.Sleep(500);
            Console.WriteLine("=");
            Thread.Sleep(1000);
            Console.WriteLine(BitwiseShiftLeft(1));
            Console.WriteLine();

            // Right shift
            Thread.Sleep(1000);
            Console.WriteLine(this);
            Console.WriteLine(" >> 1");
            Thread.Sleep(500);
            Console.WriteLine("=");
            Thread.Sleep(1000);
            Console.WriteLine(BitwiseShiftRight(1));
            Console.WriteLine();


            Thread.Sleep(1000);
        }


        // Overrides the string conversion
        public override string ToString() {
            return $"{NumberBinary} ({NumberDecimal})";
        }

    }
}
