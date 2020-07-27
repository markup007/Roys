using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols; 
using System.IO.Compression;
using System.IO;
using System.Text;


[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(Name = "tforService", ConformsTo = WsiProfiles.BasicProfile1_1)]
public class tforService : System.Web.Services.WebService
{

    public tforCredentials Auth;

    public tforService()
    {

    }

    [WebMethod]
    [SoapDocumentMethod(Binding = "tforService")]
    [SoapHeader("Auth", Required = true)]
    public string CallWS(String Xml, String ClassName, String Mode)
    {

        if (!string.IsNullOrEmpty(ClassName))
        {
            try
            {
                string sRtnVal = tforAuthDetails();
                if (sRtnVal == "")
                {
                    Type tp = Type.GetType(ClassName);

                    if (tp == null)
                        return "Class File Not Found IN BizObjects";


                    return Compress((((BizObj.IGetData)Activator.CreateInstance(tp)).GetData(Xml, "", Mode)));
                }
                else
                    return sRtnVal;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        else
            return "Class File Not Found IN BizObjects";
         
    }



    private string tforAuthDetails()
    {
        if (Auth != null)
        {
            if ((Auth.UserName == "Admin") && (Auth.Pwd == "Admin123"))
                return "";
            else
                return "Incorrect Auth. details";
        }
        else
            return "Auth. details not found.";
    }

    public string Compress(string text)
    {
        byte[] buffer = Encoding.UTF8.GetBytes(text);
        MemoryStream ms = new MemoryStream();
        using (GZipStream zip = new GZipStream(ms, CompressionMode.Compress, true))
        {
            zip.Write(buffer, 0, buffer.Length);
        }
        ms.Position = 0;
        byte[] compressed = new byte[ms.Length];
        ms.Read(compressed, 0, compressed.Length);
        byte[] gzBuffer = new byte[compressed.Length + 4];
        System.Buffer.BlockCopy(compressed, 0, gzBuffer, 4, compressed.Length);
        System.Buffer.BlockCopy(BitConverter.GetBytes(buffer.Length), 0, gzBuffer, 0, 4);
        return Convert.ToBase64String(gzBuffer);
    }

}
# region "SOAP Headers"

public class tforCredentials : System.Web.Services.Protocols.SoapHeader
{
    public string UserName;
    public string Pwd;
}

# endregion

 

    
 
