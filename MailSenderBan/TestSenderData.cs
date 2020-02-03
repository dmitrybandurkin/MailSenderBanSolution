using System;
using System.Collections.Generic;
using System.Text;

namespace MailSenderBan
{
    static public class TestSenderData
    {
        static public string from;
        static public string to;
        static public string host;
        static public int port;

        static TestSenderData()
        {
            from = "dmitrybandurkin@gmail.com";
            to = "dmitrybandurkin@gmail.com";
            host = "smtp.gmail.com";
            port = 587;
        }
    }
}
