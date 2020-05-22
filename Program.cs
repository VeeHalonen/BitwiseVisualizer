using System;

namespace BitwiseVisualizer
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // All the commands that trigger quit
            string[] Quit = { "Q", "q", "quit", "QUIT", "Quit" };
            const string WelcomeMessage = "\n\n*** Welcome to Bitwise Visualizer! ***\n";

            Console.WriteLine(WelcomeMessage);

            bool cont = true;
            while (cont)
            {

                Console.Write("Give number or (Q)uit: ");
                string selection = Console.ReadLine();

                if (Array.IndexOf(Quit, selection) > -1)
                {
                    cont = false;
                }
                else
                {
                    if (uint.TryParse(selection, out uint newNum))
                    {

                        Bitwise b = new Bitwise(newNum);


                        // Print NOT, << 1, and >> 1
                        b.PrintNonSetOperations();
                        
                        // Get a second binary string for the other operations
                        Bitwise b2 = null;
                        bool validBinaryString = false;

                        while (!validBinaryString)
                        {
                            Console.WriteLine();
                            Console.Write("Give a binary string: ");
                            string bString = Console.ReadLine();


                            if (Array.IndexOf(Quit, bString) > -1)
                            {
                                //Environment.Exit(0);
                                cont = false;
                                validBinaryString = true;
                            }
                            else
                            {
                                long b2Int = Bitwise.ConvertToDecimal(bString);
                                if (b2Int > -1 && b2Int <= uint.MaxValue)
                                {
                                    b2 = new Bitwise((uint)b2Int);
                                    validBinaryString = true;
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Not a valid binary string.");
                                    Console.WriteLine("Binary strings can only have 1s and 0s.");
                                }
                            }
                        }

                        // Unless the user wants to quit, print AND, OR, and XOR
                        if (cont)
                        {

                            b.PrintSetOperations(b2);
                            
                            Console.WriteLine();
                            Console.Write("Press Enter to Continue");
                            Console.ReadLine();
                            Console.Clear();
                            Console.WriteLine(WelcomeMessage);
                        }
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Invalid number");
                        Console.WriteLine();
                    }

                }
            }
            
        }

    }
}
