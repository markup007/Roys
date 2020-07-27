using System;
using System.Collections.Generic;
using System.Text; 
using System.Xml;
using System.Configuration;



namespace tforConnector
{
   public  class AuthWS
    {

        public string CallWS(String Xml, String ClassName, String Mode, String URL)
        {
            //RPS.showPlsWt objFrm = new RPS.showPlsWt();
            //objFrm.Show();
            //Application.DoEvents();
            XmlDocument dom = new XmlDocument();
            string sRtnVal = string.Empty;
            try
            {
                String URl = URL;

                String UserName = "Admin";
                String Password = "Admin123";


                //dom.LoadXml(Xml);
                tforConnector.tforservice url = new tforConnector.tforservice(URl);
                tforConnector.tforCredentials usr = new tforConnector.tforCredentials();
                usr.UserName = UserName;
                usr.Pwd = Password;
                url.Timeout = 50000;
                url.tforCredentialsValue = usr;

                sRtnVal = url.CallWS(Xml, ClassName, Mode);
                url.Dispose();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("PLErrorPlease Check Internet Connection");
            }
            finally
            { 
                dom = null; 
            }
            //objFrm.Close();

            return sRtnVal;
        }
    }
}
