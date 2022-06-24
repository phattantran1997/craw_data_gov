﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace razor_web
{
    public static class LOGGER
    {
        public static void WriteLogFile(string msg)
        {
            string path = MyProps.getInstance().ROOTDIR + "\\Logs\\";
            try
            {
                System.IO.DirectoryInfo dr = new System.IO.DirectoryInfo(path);
                if (!dr.Exists)
                    dr.Create();
                System.IO.FileStream fs = new System.IO.FileStream(path + DateTime.Now.ToString("dd-MM-yy") + ".txt", System.IO.FileMode.OpenOrCreate);
                fs.Seek(0, System.IO.SeekOrigin.End);
                System.IO.StreamWriter sw = new System.IO.StreamWriter(fs);
                sw.WriteLine(DateTime.Now.ToString("HH:mm dd/MM/yyyy")+" " +msg);
                sw.Close();
                fs.Close();
            }
            catch (Exception)
            {

            }
        }
        public static void WriteLogFile_Cookie(string msg, OpenQA.Selenium.IWebDriver driver,string username)
        {

            string log = Environment.NewLine + DateTime.Now.ToString("HH:mm dd/MM/yyyy") +" Cookie::" + Environment.NewLine + 
                        String.Format("--- Login page : {0} ---", username) + Environment.NewLine;
            
            var cookies = driver.Manage().Cookies.AllCookies;
            if(cookies != null)
            {
                foreach (var cook in cookies)
                {
                    log += String.Format("\t {0} = {1} ", cook.Name, cook.Value) + Environment.NewLine;
                }
            }
            string path = MyProps.getInstance().ROOTDIR + "\\Logs\\";
            try
            {
                System.IO.DirectoryInfo dr = new System.IO.DirectoryInfo(path);
                if (!dr.Exists)
                    dr.Create();
                System.IO.FileStream fs = new System.IO.FileStream(path + DateTime.Now.ToString("dd-MM-yy") + ".txt", System.IO.FileMode.OpenOrCreate);
                fs.Seek(0, System.IO.SeekOrigin.End);
                System.IO.StreamWriter sw = new System.IO.StreamWriter(fs);
                sw.WriteLine(log);
                sw.Close();
                fs.Close();
            }
            catch (Exception)
            {

            }
        }
    }
}
