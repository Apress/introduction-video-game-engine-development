using System;
using System.Diagnostics;

namespace net.middlemind.MmgGameApiCs.MmgBase
{
    //Note: Class created to mimic the Java Runtime class used to run shell commands to determine the state of gpio pins.
    /// <summary>
    /// A shell execution class used to run shell commands to determine the state of gpio pins.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class Runtime
    {
        /// <summary>
        /// Static creation method returns a new instance of this class.
        /// </summary>
        /// <returns></returns>
        public static Runtime getRuntime()
        {
            return new Runtime();
        }

        /// <summary>
        /// Executes the specified command in a new process and returns the exit code of the process.
        /// </summary>
        /// <param name="cmd"></param>
        public int exec(string cmd)
        {
            var escapedArgs = cmd.Replace("\"", "\\\"");

            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "/bin/bash",
                    Arguments = $"-c \"{escapedArgs}\"",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };
            process.Start();
            process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return process.ExitCode;
        }
    }
}