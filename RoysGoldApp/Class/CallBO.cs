using System;
using System.Collections.Generic;
using System.Text;

namespace UtilsApp
{
    public class CallBO
    {

        public String CallWS(String Xml, String ClassName, String Mode)
        {

            if (!string.IsNullOrEmpty(ClassName))
            {
                try
                {


                    Type tp = Type.GetType(ClassName);
                    //String retDat = (((BizObj.IGetData)Activator.CreateInstance(tp)).GetData(Xml, "", Mode));
                    //return retDat;


                    //RoysGold.RoysService.Service obj = new RoysGold.RoysService.Service();
                    tforConnector.AuthWS obj = new tforConnector.AuthWS();
                    string retDat = obj.CallWS(Xml, ClassName, Mode, "http://ekmadm.com/tforService.asmx");//ekmadm
                    //string retDat = obj.CallWS(Xml, ClassName, Mode, "http://dtdekm.com/tforService.asmx");//sys
                    //string retDat = obj.CallWS(Xml, ClassName, Mode, "http://yorgg.com/tforService.asmx");//raa
                    //string retDat = obj.CallWS(Xml, ClassName, Mode, "http://app.caloram.com/tforService.asmx");//caloram
                    //string retDat = obj.CallWS(Xml, ClassName, Mode, "http://app.gggaus.com/tforService.asmx"); //geo
                    return PLABS.Utils.Decompress(retDat);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                   // PLABS.MessageBoxPL.Show("Please Check Internet Connection.", "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.OK, PLABS.MessageBoxPL.PLMessageBoxIcon.Warning);
                }
            }
            else
                PLABS.MessageBoxPL.Show("Class Name Not Found", "Alert", PLABS.MessageBoxPL.PLMessageBoxButtons.OK, PLABS.MessageBoxPL.PLMessageBoxIcon.Warning);


            return string.Empty;
        }
    }



}


