using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    static class StaticClass
    {
        public static string currentPage;

        public static string EmailVerification(string email)
        {
            string script = @"C:\Users\idd\Desktop\Michals\cyber\Signatural\email_verification.py";
            var psi = new ProcessStartInfo();
            psi.FileName = @"C:\Users\idd\AppData\Local\Programs\Python\Python38-32\python.exe"; //my/full/path/to/python.exe
            psi.Arguments = string.Format(script + " " + email); //cmd, args
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            var errors = "";
            var result = "";
            using (var process = Process.Start(psi))
            {
                errors = process.StandardError.ReadToEnd();
                result = process.StandardOutput.ReadToEnd();
                Console.WriteLine(result);
            }
            return result;
        }
    }
}
