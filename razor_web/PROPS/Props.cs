using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace razor_web
{
    public class MyProps
    {
        private static MyProps instance;
        public static MyProps getInstance()
        {
            if (instance == null)
            {
                instance = new MyProps();
            }
            return instance;
        }
        private MyProps() { }
        
        public string ROOTDIR = "";

        public static string LOGINPAGE = "https://iampe.agenziaentrate.gov.it/sam/UI/Login?realm=/agenziaentrate";
        public static string USERNAME = "username";
        public static string PASSWORD = "password";

        public static TimeSpan WaitSeconds = new TimeSpan(0,0,10);
        public static string LOGOUT_XPATH = "//*[@id=\"user-collapse\"]/div/a";
        
    }
}

   