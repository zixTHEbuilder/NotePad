using Microsoft.VisualBasic.FileIO;
using NotesApp;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NotesApp
{
    class Program
    {
        static void Main()
        {
            Input input = new Input();
            Functions function = new Functions();
            while (true)
            {
                int UserRequest = input.ReadInt("Enter number for what you want to do : \n1. Create Note \n2. View Notes \n3. Edit Notes \n4. Delete All Notes \n5. Exit Program", writeLine: true);
                switch (UserRequest)
                {
                    case 1:
                        {
                            function.CreateNote();
                            break;
                        }
                    case 2:
                        {
                            function.ViewNotes();
                            break;
                        }
                    case 3:
                        {
                            function.EditNotes();
                            break;
                        }
                    case 4:
                        {
                            function.DeleteNotes();
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Exiting Program");
                            return;
                        }
                    default: Console.WriteLine("Error, Please Enter a valid number to choose a program"); break;
                }
            }
        }
    }
}

