using System;
using System.Diagnostics;

namespace Tabloid
{
    public class EditorManager
    {
        public void Open(Entry entry)
        {
            Console.WriteLine();
            Console.WriteLine("Starting your editor...");
            Console.WriteLine();
            ProcessStartInfo info = new ProcessStartInfo("code", $"-n {entry.Path}");
            info.EnvironmentVariables["PATH"] = Environment.GetEnvironmentVariable("PATH");
            Process editorProcess = Process.Start(info);
        }
    }
}