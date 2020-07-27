using System;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.IO.Compression;
using System.IO;
using System.Text;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class Service : System.Web.Services.WebService
{
    public Service () 
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string CallWS(String Xml, String ClassName, String Mode)
    {

        if (!string.IsNullOrEmpty(ClassName))
        {
            try
            {
                Type tp = Type.GetType(ClassName);

                if (tp == null)
                    return "Class File Not Found IN BizObjects";


                //  return Compress((((BizObj.IGetData)Activator.CreateInstance(tp)).GetData(Xml, "", Mode)));
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        else
        {
            return string.Empty;
        }

        return string.Empty;
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

