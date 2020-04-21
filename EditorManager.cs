using System;
using System.Diagnostics;

namespace Tabloid
{
    public class EditorManager
    {
        public void Start(Entry entry)
        {
            Console.WriteLine("Starting your editor...");
            ProcessStartInfo info = new ProcessStartInfo("code", $"-n {entry.Path}");
            info.EnvironmentVariables["PATH"] = Environment.GetEnvironmentVariable("PATH");
            Process editorProcess = Process.Start(info);
        }
    }
}