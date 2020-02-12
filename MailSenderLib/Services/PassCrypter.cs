using System;
using System.Collections.Generic;
using System.Text;

namespace MailSenderLib.Services
{
    public static class PassCrypter
    {
        public static string Encrypt(string pass, int key=1)
        {
            char[] charpass = pass.ToCharArray();
            for (int i = 0; i < charpass.Length; i++) charpass[i] = (char)((int)charpass[i]+ key);
            return new string(charpass);
        }

        public static string Decrypt(string pass, int key=1)
        {
            char[] charpass = pass.ToCharArray();
            for (int i = 0; i < charpass.Length; i++) charpass[i] = (char)((int)charpass[i] - key);
            return new string(charpass);
        }
    }
}
