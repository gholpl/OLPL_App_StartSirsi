using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLPL_App_StartSirsi
{
    public class Settings
    {
        public string location_Install { get; set; }
        public string location_Workflows { get; set; }
        public string var_ENV_User { get; set; }



    }
    public class Settings_Functions
    {
        public static Settings getSettings()
        {
            Settings st1 = new Settings();
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string[] SettingMain = File.ReadAllLines(Path.GetDirectoryName(path) + "\\start.properties");
            st1.location_Workflows = getSettingINI(SettingMain, "workflows.directory");
            st1.location_Install = getSettingINI(SettingMain, "install.directory");
            st1.var_ENV_User = getSettingINI(SettingMain, "classpath.variable");
            st1.var_ENV_User=st1.var_ENV_User.Replace("workflowslocaton", st1.location_Workflows);
            st1.var_ENV_User=st1.var_ENV_User.Replace("installlocation", st1.location_Install);


            return st1;
        }
        public static string getSettingINI(string[] str, string strName)
        {
            foreach (string str1 in str)
            {
                if (str1.Contains(strName))
                {
                    return str1.Split('=')[1];
                }
            }
            return "none";
        }
    }
}
