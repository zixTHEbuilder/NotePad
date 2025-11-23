using System;
using System.Collections.Generic;
using System.Text;

namespace NotesApp
{
    class Input
    {
        public int ReadInt(string message, bool writeLine = false)
        {
            while (true)
            {
                if (writeLine == true)
                    Console.WriteLine(message);
                else
                    Console.Write($"{message} : ");
                string UserInput = Console.ReadLine();

                if (UserInput != null)
                {
                    int.TryParse(UserInput, out int value);
                    return value;
                }
                else
                {
                    Console.WriteLine("Invalid Input, Please enter a number");
                }
            }
        }
        public string ReadString(string message, bool LowerTrim = false, bool writeLine = false)
        {
            while (true)
            {
                if (writeLine == true)
                {
                    Console.WriteLine(message);
                }
                else
                {
                    Console.Write(message);
                }
                string UserInput;
                if (LowerTrim == false)
                {
                    UserInput = Console.ReadLine();
                }
                else
                {
                    UserInput = Console.ReadLine().ToLower().Trim();
                }
                if (UserInput != null)
                {
                    return UserInput;
                }
                else
                {
                    Console.WriteLine("Cannot Save an Empty Note");
                }
            }
        }
        public static string TxtExtension(string FileName)
        {
            string extension = ".txt";

            if (!FileName.EndsWith(extension, StringComparison.Ordinal))
            {
                return FileName + extension;
            }
            return FileName;
        }
    }
}

