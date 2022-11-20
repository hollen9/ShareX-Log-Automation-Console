// See https://aka.ms/new-console-template for more information

using System;
using CommandLine;
using Microsoft.VisualStudio.PlatformUI;
using ShareX_Log_Automation_Console.Models;

#if DEBUG
args = new string[] { "--log-path=\"" + @"E:\Libraries\Documents\ShareX\Logs\ShareX-Log-2022-11.txt" + "\"" };
#endif
var pr = Parser.Default.ParseArguments<LaunchOptions>(args);

if (pr.Value is default(LaunchOptions))
{
    return;
}
var arg = pr.Value;

#if DEBUG
arg.MovingDestination = @"J:\Libraries\Videos\NVCaptured\Counter-strike  Global Offensive\toBeRemoved";
arg.OnlySource = @"J:\Libraries\Videos\NVCaptured\Counter-strike  Global Offensive\";
arg.DryRun = true;
#endif
arg.Normalize();
if (arg.MovingDestination != String.Empty)
{
    if (!Directory.Exists(arg.MovingDestination))
    {
        Directory.CreateDirectory(arg.MovingDestination);
        Console.Write("Move-Dest folder not exists, so this program created it.");
    }
}

string[] lines = File.ReadAllLines(arg.LogPath);
var dictSharexJob = new Dictionary<string, ShareXJobInfo>();
foreach (var line in lines)
{
    if (line.Length >= 41)
    {
        string keyword = line[26..41];
        if (keyword == "Upload started.")
        {
            string raw_fn_and_fullpath = line[52..];
            var raws = raw_fn_and_fullpath.Split(", Filepath: ");
            if (dictSharexJob.ContainsKey(raws[0]))
            {
                continue;
            }
            dictSharexJob.Add(raws[0], new ShareXJobInfo
            {
                Type = ShareXJobInfo.JobType.Upload,
                Filename = raws[0],
                FullPath = raws[1],
                Status = ShareXJobInfo.StatusType.Working
            });
            //Console.WriteLine(raw_fn_and_fullpath);
        }
        else if (keyword == "Task completed.")
        {            
            string raw_fn_and_duration = line[52..];
            var raws = raw_fn_and_duration.Split(", Duration: ");
            if (dictSharexJob.ContainsKey(raws[0]))
            {
                dictSharexJob[raws[0]].Status = ShareXJobInfo.StatusType.Succeed;
            }
        }
    }
}
var uploaded_list = dictSharexJob.Where(x => x.Value.Status == ShareXJobInfo.StatusType.Succeed).ToList();

if (arg.MovingDestination != String.Empty)
{
    foreach (var item in uploaded_list)
    {
        string dest = Path.Combine(arg.MovingDestination, item.Value.Filename);
        if (arg.OnlySource != null && arg.OnlySource != Directory.GetParent(item.Value.FullPath).FullName.NormalizePath())
        {
            
            string t = Directory.GetParent(item.Value.FullPath).FullName;
            Console.WriteLine("Ignored " + item.Value.Filename + " because it's not in the source folder.");
            continue;
        }
        try
        {
            if (arg.DryRun)
            {
                Console.WriteLine($"DRY-RUN Moving: {item.Value.FullPath} -> {dest}");
            }
            else
            {
                File.Move(item.Value.FullPath, dest);
            }
        }
        catch (Exception mvex)
        {
            Console.WriteLine($"[{mvex}] Failed to move file: " + item.Value.Filename);
            continue;
        }
    }
}

#if DEBUG
Console.Read();
#endif