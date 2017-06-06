using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD_AttendanceIn
{
    public delegate void StatusChangedEventHandler(object sender, StatusChangedEventArgs e);

    public class StatusChangedEventArgs
    {
        public StatusChangedEventArgs(bool status)
        {
            this.Status = status;
        }
        public bool Status { get; set; }
    }
}
