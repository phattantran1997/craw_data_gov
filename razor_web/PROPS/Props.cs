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
        public static string CODEVERSION = "RELEASE-1.0";

        public string ROOTDIR = "";
        public string PROCESSED_FOLDER_PATH { get { return ROOTDIR + "//UPLOAD//PROCESSED"; } }

        public static string LOGINPAGE = "https://iampe.agenziaentrate.gov.it/sam/UI/Login?realm=/agenziaentrate";
        public static string USERNAME = "PSTNTN85C26F839N";
        public static string PASSWORD = "Rosaria1985!";

        public static TimeSpan WaitSeconds = new TimeSpan(0,0,10);
        public static string LOGOUT_XPATH = "//*[@id=\"user-collapse\"]/div/a";
        
    }
}

   