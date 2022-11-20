using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using Microsoft.VisualStudio.PlatformUI;

namespace ShareX_Log_Automation_Console.Models
{
    internal class LaunchOptions
    {
        [Option("log-path", Required = true, HelpText = "The ShareX log file. It should be TXT format.")]
        public string LogPath { get; set; }

        [Option("move-dest", Required = false)]
        public string MovingDestination { get; set; }
        [Option("only-src", Required = false)]
        public string OnlySource { get; set; }

        [Option("dry-run", Required = false, HelpText = "Do not make changes to any files, but'd like to see how it will run.")]
        public bool DryRun { get; set; }

        private string NormalizePath(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return path;
            }
            string newPath = path;
            if (path.StartsWith('"') && path.EndsWith('"'))
            {
                newPath = path[1..^1];
            }
            
            newPath = newPath.NormalizePath();
            return newPath;
        }
        public void Normalize()
        {
            var arg = this;
            arg.LogPath = NormalizePath(arg.LogPath);
            arg.MovingDestination = NormalizePath(arg.MovingDestination);
            arg.OnlySource = NormalizePath(arg.OnlySource);
        }
    }
}
