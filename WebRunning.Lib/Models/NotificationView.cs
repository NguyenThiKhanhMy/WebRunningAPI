using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WebRunning.Lib.Enums.System;

namespace WebRunning.Lib.Models
{
    public class NotificationView
    {
        public NotificationType Type { get; set; }
        public string Title { get; set; }        
        public string Content { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
    }
}
