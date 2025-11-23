using System;

using System.Collections.Generic;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace NotesApp
{
    class Functions
    {
        Input input = new Input();
        public void CreateNote()
        {
            string Note = input.ReadString("Enter text to save in notes app : ");
            string FileName = input.ReadString("Enter file name to save : ");
            string TxtFileName = Input.TxtExtension(FileName);      // use class name to call the TxtExtension since its static

            string DirectoryPath = @"C:\Users\xylea\Documents\NotesApp";
            string FilePath = $"C:\\Users\\xylea\\Documents\\NotesApp\\{TxtFileName}";
            if (!Directory.Exists(DirectoryPath))
            {
                Directory.CreateDirectory(DirectoryPath);
            }
            if (!File.Exists(FileName))
            {
                File.WriteAllText(FilePath, Note);
                Console.WriteLine("Note Saved Successfully");
            }
        }
        public void ViewNotes()
        {
            string DirectoryPath = @"C:\Users\xylea\Documents\NotesApp";
            if (Directory.Exists(DirectoryPath))
            {
                string[] Files = Directory.GetFiles(DirectoryPath);

                foreach (string file in Files)
                {
                    string FileName = Path.GetFileName(file);
                    Console.WriteLine(FileName);
                }
                string ReadNote = input.ReadString("Do you want to view contents inside the notes? if yes enter file name as is, else press Enter");
                if (!string.IsNullOrEmpty(ReadNote))
                {
                    string txtReadNote = Input.TxtExtension(ReadNote);
                    string FullPath = Path.Combine(DirectoryPath, txtReadNote);     // make sure to use Path.Combine so the entire directory path is made, the error is previously made was just enter "txtReadNote" which cannot find the file.
                    if (File.Exists(FullPath))
                    {
                        Console.WriteLine(File.ReadAllText(txtReadNote));
                    }
                    else { Console.WriteLine("File Not Found, Please Make Sure You Enter The File Name As Is"); }
                }
            }
            else
            {
                Console.WriteLine("No Notes Here!");
            }
        }
        public void EditNotes()
        {
            string EditRequest = input.ReadString("Enter the note name to edit", LowerTrim: true);

            if (!string.IsNullOrEmpty(EditRequest))
            {
                if (File.Exists(EditRequest))
                {
                    File.OpenRead(EditRequest);
                    int AppendOrOverwrite = input.ReadInt("1. Append (Add text to existing note) \n2. Overwrite (Replace the old content entirely with the new note)");
                    if (AppendOrOverwrite == 1)
                    {
                        string AppendText = input.ReadString("Enter the text u want to add to the existing note");
                        File.AppendAllText(EditRequest, AppendText);
                        Console.WriteLine("Note Updated Successfully");
                    }
                    else if (AppendOrOverwrite == 2)
                    {
                        string OverwriteText = input.ReadString("Enter the FULL, EDITED text for the note. This will replace the old content entirely." + "\nPress Enter when finished:", writeLine: true);
                        File.WriteAllText(EditRequest, OverwriteText);
                        Console.WriteLine("Note Replaced Successfully");
                    }
                }
            }
            else
            {
                Console.WriteLine("File Doesn't Exist");
            }
        }
        public void DeleteNotes()
        {
            string DirectoryPath = @"C:\Users\xylea\Documents\NotesApp";
            if (Directory.Exists(DirectoryPath))
            {
                string[] Files = Directory.GetFiles(DirectoryPath);

                foreach (string file in Files)
                {
                    string FileName = Path.GetFileName(file);
                    Console.WriteLine(FileName);
                }
                string DeletionConfirmation = input.ReadString("Are you sure you want to delete the above notes? (y/n)");
                DeletionConfirmation = DeletionConfirmation.ToLower().Trim();
                if (DeletionConfirmation == "y")
                {
                    Directory.Delete(DirectoryPath, true );
                }
                else
                {
                    Console.WriteLine("Nothing to delete!");
                }
            }
        }
    }
}
