using System;
using System.Collections.Generic;
using System.Text;

namespace MailSenderLib.Services
{
    public static class PassCrypter
    {
        static readonly int K = 1;
        public static string Encrypt(string pass)
        {
            char[] charpass = pass.ToCharArray();
            for (int i = 0; i < charpass.Length; i++) charpass[i] = (char)((int)charpass[i]+K);
            return new string(charpass);
        }

        public static string Decrypt(string pass)
        {
            char[] charpass = pass.ToCharArray();
            for (int i = 0; i < charpass.Length; i++) charpass[i] = (char)((int)charpass[i] - K);
            return new string(charpass);
        }
    }
}
