using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareX_Log_Automation_Console.Models
{
    internal class ShareXJobInfo
    {
        public enum JobType
        {
            None = 0,
            Upload = 1,
        }
        public enum StatusType
        {
            None = 0,
            Succeed = 1,
            Failed = 2,
            Working = 3
        }
        public StatusType Status { get; set; }
        public JobType Type { get; set; }
        public string Filename { get; set; }
        public string FullPath { get; set; }

    }
}
