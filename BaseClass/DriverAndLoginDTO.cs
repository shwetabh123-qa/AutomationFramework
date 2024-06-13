using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationFramework.BaseClass
{
    public class DriverAndLoginDto
    {
        public string Browser { get; set; }
        public string Url { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Account { get; set; }
        public string downloadFilepath { get; set; }
        public string logFilePath { get; set; }
    }
}
