
using System.Windows.Forms;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Data;
using System.IO;

namespace PLFileManager
{
    public class PLClient
    {

        public static void Download(string FTPFullFileName, string DestFullFileName, string UserName, string Password)
        {
            try
            {

                DestFullFileName = DestFullFileName.Replace("/", "\\");
                int indexPart = DestFullFileName.LastIndexOf("\\");

                if (indexPart != -1)
                {
                    String DestFolder = DestFullFileName.Substring(0, indexPart + 1);

                    if (!Directory.Exists(DestFolder))
                        Directory.CreateDirectory(DestFolder);
                }

                FtpWebRequest FTP = (FtpWebRequest)FtpWebRequest.Create(FTPFullFileName);
                FTP.Method = WebRequestMethods.Ftp.DownloadFile;
                FTP.UseBinary = true;
                FTP.Credentials = new NetworkCredential(UserName, Password);

                FtpWebResponse Response = (FtpWebResponse)FTP.GetResponse();
                Stream FtpStream = Response.GetResponseStream();
                int BufferSize = 2048;
                byte[] Buffer = new byte[BufferSize];

                FileStream OutputStream = new FileStream(DestFullFileName, FileMode.Create);
                int ReadCount = FtpStream.Read(Buffer, 0, BufferSize);
                while (ReadCount > 0)
                {
                    OutputStream.Write(Buffer, 0, ReadCount);
                    ReadCount = FtpStream.Read(Buffer, 0, BufferSize);
                }

                FtpStream.Close();
                OutputStream.Close();
                Response.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
