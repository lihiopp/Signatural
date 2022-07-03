using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    static class StaticClass
    {
        public static string currentPage;

        public static string EmailVerification(string email)
        {
            string script = @"C:\Users\student\Desktop\try\Signatural\email_verification.py";
            var psi = new ProcessStartInfo();
            psi.FileName = @"C:\Users\student\AppData\Local\Programs\Python\Python38\python.exe"; //my/full/path/to/python.exe
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

        public static void CreateActivityGraph(string username, string attempts, string forgeries)
        {
            string script = @"C:\Users\student\Desktop\try\Signatural\calculateActivity.py";
            var psi = new ProcessStartInfo();
            psi.FileName = @"C:\Users\student\AppData\Local\Programs\Python\Python38\python.exe"; //my/full/path/to/python.exe
            psi.Arguments = string.Format(script+" "+attempts+" "+forgeries); //cmd, args
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
                process.WaitForExit();
                Console.WriteLine(result);
            }
        }

        public static string GoogleDrive(string func,string filename,string path)
        {
            string script = @"Run.py";
            var psi = new ProcessStartInfo();
            psi.FileName = @"C:\Users\student\AppData\Local\Programs\Python\Python38\python.exe"; //my/full/path/to/python.exe
            psi.WorkingDirectory = @"C:\Users\student\Desktop\try\Signatural\GoogleDriveAPI";
            psi.Arguments = string.Format(script + " " + func+" "+filename+" " +path); //cmd, args
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
