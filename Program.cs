using System;
using System.IO;
using static System.Console;
using static System.IO.NotifyFilters;
namespace MyDirectoryWatcher
{
    class Program
    {
        static void Main()
        {
            WriteLine("***** The Amazing File Watcher App *****\n");

            // Establish the path to the directory to watch.
            FileSystemWatcher watcher = new FileSystemWatcher();
            try
            {
                watcher.Path = @"C:\MyFolder";
            }
            catch (ArgumentException ex)
            {
                WriteLine(ex.Message);
                return;
            }
            // Set up the things to be on the lookout for.
            watcher.NotifyFilter = LastAccess
              | LastWrite
              | FileName
              | DirectoryName;

            // Only watch text files.
            watcher.Filter = "*.txt";

            // Specify what is done when a file is changed, created, or deleted.
            watcher.Changed += (s, e) =>
            {
                WriteLine($"File: {e.FullPath} {e.ChangeType}!");
            };

            watcher.Created += (s, e) =>
            {
                WriteLine($"File: {e.FullPath} {e.ChangeType}!");
            };

            watcher.Deleted += (s, e) =>
            {
                WriteLine($"File: {e.FullPath} {e.ChangeType}!");
            };

            watcher.Renamed += (s, e) =>
            {
                // Specify what is done when a file is renamed.
                WriteLine($"File: {e.OldFullPath} renamed to {e.FullPath}");
            };

            // Begin watching the directory.
            watcher.EnableRaisingEvents = true;

            // Wait for the user to quit the program.
            WriteLine(@"Press 'q' to quit app.");
            while (Read() != 'q') ;
        }
    }
}