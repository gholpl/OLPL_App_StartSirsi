using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OLPL_App_StartSirsi
{
    class Program
    {
        static void Main(string[] args)
        {
            functions fn1 = new functions();
            Settings st1 = new Settings();
            st1 = Settings_Functions.getSettings();
            Environment.SetEnvironmentVariable("CLASSPATH", st1.var_ENV_User, EnvironmentVariableTarget.User);
            if(File.Exists(st1.location_Workflows + "\\new_custom.jar"))
            {
                try
                {
                    if (File.Exists(st1.location_Workflows + "\\custom.jar"))
                    {
                        File.Delete(st1.location_Workflows + "\\custom.jar");
                    }
                    Console.WriteLine("Overriding custom.jar with new file");
                    File.Move(st1.location_Workflows + "\\new_custom.jar", st1.location_Workflows + "\\custom.jar");
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else { Console.WriteLine("No new Custom.jar detected"); }
            if (!File.Exists(st1.location_Workflows + "\\Updates\\upd_jwf.exe"))
            {
                Console.WriteLine("No new Updates detected");
                if (args.Length == 0)
                {
                    Console.WriteLine("Starting Sirsi client with no Arguments");
                    try
                    {
                        Process pr = new Process();
                        ProcessStartInfo prs = new ProcessStartInfo();
                        prs.UseShellExecute = true;
                        prs.FileName = st1.location_Workflows + "\\Jre\\bin\\javaw.exe";
                        prs.WorkingDirectory = st1.location_Workflows;
                        prs.Arguments = "-Dworkflows.directory="+ "\"" + st1.location_Workflows + "\"" + " -Xms512m -Xmx512m -jar workflows.jar";
                        pr.StartInfo = prs;
                        pr.Start();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Starting Sirsi client with " + args[0] + " Argument");
                    try
                    {
                        Process pr = new Process();
                        ProcessStartInfo prs = new ProcessStartInfo();
                        prs.UseShellExecute = true;
                        prs.FileName = st1.location_Workflows + "\\Jre\\bin\\javaw.exe";
                        prs.WorkingDirectory = st1.location_Workflows;
                        prs.Arguments = "-Dworkflows.directory=" + "\"" + st1.location_Workflows + "\"" + " -Xms512m -Xmx512m -jar workflows.jar -w" + args[0];
                        pr.StartInfo = prs;
                        pr.Start();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            else
            {
                Console.WriteLine("Updating Sirsi Client");
                try
                {
                    if (File.Exists(st1.location_Workflows + "\\Updates\\new_jwf.exe"))
                    {
                        File.Delete(st1.location_Workflows + "\\Updates\\new_jwf.exe");
                    }
                    Console.WriteLine("Overriding upd_jwf.jar with new file");
                    File.Move(st1.location_Workflows + "\\Updates\\upd_jwf.exe", st1.location_Workflows + "\\Updates\\new_jwf.exe");
                    Process pr = new Process();
                    ProcessStartInfo prs = new ProcessStartInfo();
                    prs.UseShellExecute = true;
                    prs.FileName = st1.location_Workflows + "\\Updates\\new_jwf.exe";
                    prs.WorkingDirectory = st1.location_Workflows;
                    prs.Arguments = "";
                    pr.StartInfo = prs;
                    pr.Start();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
          


           Thread.Sleep(6000);

        }
    }
}
