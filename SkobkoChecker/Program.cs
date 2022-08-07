using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkobkoChecker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true) 
            { 
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Input string with hooks  {  [  (  ) ] } )");
            string inputString = Console.ReadLine();
            List<char> openHooks = new List<char>();
            for (int i = 0; i < inputString.Length; i++)
            {
                if ((inputString[i] == '{') | (inputString[i] == '(') | (inputString[i] == '['))
                {
                    openHooks.Add(inputString[i]);
                }
                else
                {
                    if ((inputString[i] == '}') | (inputString[i] == ')') | (inputString[i] == ']'))
                    {
                        if (openHooks.Count > 0)
                        {
                            if (inputString[i] == '}')
                            {
                            Recheck:
                                if (openHooks[openHooks.Count - 1] == '{')
                                {

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    openHooks.Remove(openHooks[openHooks.Count - 1]);
                                    Console.WriteLine("{...} find\n");
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                }
                                else
                                {
                                    if (openHooks.Contains('{'))
                                    {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Incorrect {0} on place {1}", openHooks[openHooks.Count - 1], i + 1);
                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            openHooks.Remove(openHooks[openHooks.Count - 1]);
                                        goto Recheck;
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Incorrect hook {0} hook on place {1}\n", inputString[i], i + 1);
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                    }
                                }
                            }
                            if (inputString[i] == ')')
                            {
                            Recheck2:
                                if (openHooks[openHooks.Count - 1] == '(')
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    openHooks.Remove(openHooks[openHooks.Count - 1]);
                                    Console.WriteLine("(...) find \n");
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                }
                                else
                                {
                                    if (openHooks.Contains('('))
                                    {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Incorrect {0} on place {1}", openHooks[openHooks.Count - 1], i + 1);
                                            openHooks.Remove(openHooks[openHooks.Count - 1]);
                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            goto Recheck2;
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Incorrect hook ) hook on place {0}\n", i + 1);
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                    }
                                }
                            }
                            if (inputString[i] == ']')
                            {
                            Recheck3:
                                if (openHooks[openHooks.Count - 1] == '[')
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    openHooks.Remove(openHooks[openHooks.Count - 1]);
                                    Console.WriteLine("[...] find \n");
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                }
                                else
                                {
                                    if (openHooks.Contains('['))
                                    {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Incorrect {0} on place {1}", openHooks[openHooks.Count - 1], i + 1);
                                            openHooks.Remove(openHooks[openHooks.Count - 1]);
                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            goto Recheck3;
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Incorrect hook ] hook on place {0}\n", i + 1);
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                    }
                                }
                            }

                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Incorrect hook {0}, on place {1}", inputString[i], i + 1);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }
                    }
                }
            }
            if (openHooks.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect open & not closed hooks:\n");
                for (int i = 0; i < openHooks.Count; i++)
                {
                    Console.WriteLine("Hook {0} ", openHooks[i]);
                }
                Console.ForegroundColor = ConsoleColor.Cyan;
            }

            Console.ReadKey();

        }
        }
    }
}
