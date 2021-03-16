using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySportsClubLesson6.Models {

    // todo lesson 6-05: model the SMTP server data 
    public class MailSettings {
        public string Mail { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
    }
}
