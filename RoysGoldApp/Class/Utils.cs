using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using System.IO;

namespace RoysGold
{
    class Utils
    {
        public double PurityConversion(double purity, double value ,double Base)
        {
             double cvtVal = 0.00;
             cvtVal = (purity * value) / Base;
            return cvtVal;
        }
        public double McCalculation(double weight, int ratio,double mc,double purty)
        {
            double ttlmc = 0.00;
            switch (ratio)
            {
                case 1:
                    ttlmc = mc;
                   
                    break;
                case 2:
                    ttlmc = (weight*  mc)/100;
                    
                    break;
                case 3:
                    ttlmc = weight * mc;
                    
                    break;
            }
            return ttlmc;

        }

        public static Hashtable sumofdt(DataTable dt)
        {
            double value = 0;
            Hashtable ht = new Hashtable();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; dt.Columns.Count > i; i++)
                {
                    string type = dt.Columns[i].DataType.Name;
                   if (type == "Double")
                   {
                       string colname = dt.Columns[i].ColumnName;
                       value = (double)(dt.Compute("Sum(" + colname + ")", ""));

                       ht.Add(colname, value);
                   }

                }

              // 

            }
            return ht;
        }
        public static void CreateDatatable(DataTable dt, double dtOping,double wtOping, string Form)
        {
            double DrTotal = 0, Crtotal = 0, DrWtTotal=0,   CrWtTotal=0, ClosBal = 0,ClosWt=0;
            //int i = 0;
            DataRow drOp = dt.NewRow();
            DataRow drCah = dt.NewRow();
            DataRow drTot = dt.NewRow();
            DataRow drDayTot = dt.NewRow();

            for (int count = 0;     dt.Rows.Count > count; count++)
            {
                DrTotal += PLABS .Utils.CnvToDouble(dt.Rows[count]["dramt"]);
                Crtotal += PLABS.Utils.CnvToDouble(dt.Rows[count]["cramt"]);
                DrWtTotal += PLABS.Utils.CnvToDouble(dt.Rows[count]["drwt"]);
                CrWtTotal += PLABS.Utils.CnvToDouble(dt.Rows[count]["crwt"]);
            }
            //Create Data Row Day Total
            drDayTot["Name"] = "TOTAL";
            drDayTot["dramt"] = DrTotal;
            drDayTot["cramt"] = Crtotal;
            drDayTot["drwt"] = DrWtTotal;
            drDayTot["crwt"] = CrWtTotal;

            //Create Data Row Day Opening Balance
            drOp["NAME"] = "OPENING BALANCE";
            if (dtOping >= 0)
            {
               
                drOp["cramt"] = Convert.ToDouble(dtOping.ToString("N2"));
               
                Crtotal += dtOping;
                
            }
            else
            {
                dtOping = (0 - PLABS.Utils.CnvToDouble(dtOping.ToString("N2")));
                drOp["dramt"] = dtOping;
                DrTotal += dtOping;
               
            }
            if (wtOping >= 0)
            {
                drOp["crwt"] = Convert.ToDouble(wtOping.ToString("N3"));
                CrWtTotal += wtOping;
            }
            else 
            {
                wtOping = (0 - PLABS.Utils.CnvToDouble(wtOping.ToString("N3")));
                drOp["drwt"] = wtOping;
                DrWtTotal += wtOping;
            }
            //ADD Opening Balance And Day Total

            dt.Rows.InsertAt(drOp, 0);// Add Opening Balance
            if (Form != "T")
                dt.Rows.Add(drDayTot);//Add Day Total
            //Create Cash-IN-Hand
            ClosBal = (Crtotal - DrTotal);
            ClosWt = (CrWtTotal - DrWtTotal);
            if (Form == "L")
            {
                drCah["NAME"] = "CLOSING";
            }
            else
            {
                drCah["NAME"] = "CASH-IN-HAND";
            }
            if (ClosBal >= 0)
            {
                drCah["dramt"] = PLABS.Utils.CnvToDouble(ClosBal.ToString("N2"));
                DrTotal += ClosBal;
               
            }
            else
            {

                drCah["cramt"] = 0 - PLABS.Utils.CnvToDouble(ClosBal.ToString("N2"));
                Crtotal += (0 - ClosBal);
               
            }
            if (ClosWt >= 0)
            {
                drCah["drwt"] = PLABS.Utils.CnvToDouble(ClosWt.ToString("N3"));
                DrWtTotal += ClosWt;
            }
            else 
            {
                drCah["crwt"] = -PLABS.Utils.CnvToDouble(ClosWt.ToString("N3"));
                CrWtTotal += (0 - ClosWt);
            }
            dt.Rows.Add(drCah);//Add Cash-IN-Hand

            //Create Data Row Grand Total
            drTot["NAME"] = "GRAND TOTAL";
            drTot["cramt"] = PLABS.Utils.CnvToDouble(Crtotal.ToString("N2"));
            drTot["dramt"] = PLABS.Utils.CnvToDouble(DrTotal.ToString("N2"));
            drTot["crwt"] = PLABS.Utils.CnvToDouble(CrWtTotal.ToString("N2"));
            drTot["drwt"] = PLABS.Utils.CnvToDouble(DrWtTotal.ToString("N2"));
            dt.Rows.Add(drTot);//Add GrandTotal

        }
        public static void GetAutoCompleteSource(DataTable dt,TextBox txt)
        {
            try
            {
             //string [] sourceArray=new string[dt.Rows .Count];
                AutoCompleteStringCollection source = new AutoCompleteStringCollection();
             for (int i = 0; i < dt.Rows.Count; i++)
             {
                 source.Add(PLABS.Utils.CnvToStr  (dt.Rows[i][0]));
                 
             }
             
             //source.AddRange(sourceArray);
             txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
             txt.AutoCompleteCustomSource = source;
             txt.AutoCompleteMode = AutoCompleteMode.Suggest;
                
            }
            catch (Exception ex)
            {
 
            }
        }
        public DataSet GetRefreshTables(String as_mode, String ai_typ_id,String ai_addr_id)
        {
            DataSet ds=new DataSet ();
            try
            {
                PLABS.MasterForm obj=new PLABS.MasterForm ();
                string argXml = obj.getBlankXml();
                argXml = PLABS.Utils.addNode(argXml, "as_mode", as_mode);
                argXml = PLABS.Utils.addNode(argXml, "ai_typ_id", ai_typ_id);
                argXml = PLABS.Utils.addNode(argXml, "ai_addr_id", ai_addr_id);
                argXml = PLABS.Utils.addNode(argXml, "ai_usr_id",Properties .Settings .Default .id.ToString());

                UtilsApp.CallBO objServ = new UtilsApp.CallBO();
                argXml = objServ.CallWS(argXml, "BizObj.Utils,BizObj", "");
                ds = PLABS.Utils.CnvXMLToDataSet(argXml);
                return ds;
            }
            catch (Exception ex)
            {
 
            }
            return ds;
        }



        #region DllDownLoad

        public static void getUpdates(String FtpLocation, String uName, String passWD, String AppName)
        {
            String NewFileName = "plNew.txt";
            String ServFileName = "Serv.txt";
            String LclFileName = "pllcl.txt";

            PLFileManager.PLClient.Download(FtpLocation + ServFileName, NewFileName, uName, passWD);



            // Read Server Settings File
            string xmlText = "";
            xmlText = ReadFile(NewFileName);
            xmlText = PLABS.Utils.Decompress(xmlText);
            DataSet dsNew = PLABS.Utils.CnvXMLToDataSet(xmlText);
            dsNew.Tables[1].DefaultView.Sort = "UrlPath";
            DataTable newDt = dsNew.Tables[1].DefaultView.ToTable();
            newDt.TableName = "newDt";


            //Read Local File
            xmlText = ReadFile(LclFileName);
            if (xmlText != string.Empty)
            {
                xmlText = PLABS.Utils.Decompress(xmlText);
                DataSet dsLcl = PLABS.Utils.CnvXMLToDataSet(xmlText);
                dsLcl.Tables[1].DefaultView.Sort = "UrlPath";
                DataTable LclDt = dsLcl.Tables[1].DefaultView.ToTable();
                LclDt.TableName = "LclDt";

                DataTable lstDt = GetDifferentRecords(newDt, LclDt);
                lstDt.DefaultView.ToTable(true, new string[] { "UrlPath" });
                DownLoadFiles(FtpLocation, uName, passWD, NewFileName, LclFileName, lstDt, AppName);
            }
            else
            {
                DownLoadFiles(FtpLocation, uName, passWD, NewFileName, LclFileName, newDt, AppName);

            }

        }

        public static void DownLoadFiles(String baseUrl, String uName, String passWD, String NewFileName, String LclFileName, DataTable newDt, String AppName)
        {
            System.Diagnostics.Process myProcess = new System.Diagnostics.Process();

            try
            {
                String Dat = PLABS.Utils.Compress(PLABS.Utils.CnvDataTableToXml(newDt, true));

                String SplitFn = "~@~!~$~";
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.FileName = "FtpDownloader.exe";

                myProcess.StartInfo.Arguments = baseUrl + SplitFn + uName + SplitFn + passWD + SplitFn + NewFileName + SplitFn + LclFileName + SplitFn + Dat + SplitFn + AppName;
                myProcess.Start();

              
               

            }
            catch (Exception e)
            {
            }

        }

        public static DataTable GetDifferentRecords(DataTable FirstDataTable, DataTable SecondDataTable)
        {
            DataTable ResultDataTable = new DataTable("ResultDataTable");
            try
            {



                using (DataSet ds = new DataSet())
                {

                    ds.Tables.Add(FirstDataTable.Copy());
                    ds.Tables.Add(SecondDataTable.Copy());


                    DataColumn[] firstColumns = new DataColumn[ds.Tables[0].Columns.Count];
                    for (int i = 0; i < firstColumns.Length; i++)
                    {
                        firstColumns[i] = ds.Tables[0].Columns[i];
                    }

                    DataColumn[] secondColumns = new DataColumn[ds.Tables[1].Columns.Count];
                    for (int i = 0; i < secondColumns.Length; i++)
                    {
                        secondColumns[i] = ds.Tables[1].Columns[i];
                    }


                    DataRelation r1 = new DataRelation(string.Empty, firstColumns, secondColumns, false);
                    ds.Relations.Add(r1);

                    DataRelation r2 = new DataRelation(string.Empty, secondColumns, firstColumns, false);
                    ds.Relations.Add(r2);


                    for (int i = 0; i < FirstDataTable.Columns.Count; i++)
                    {
                        ResultDataTable.Columns.Add(FirstDataTable.Columns[i].ColumnName, FirstDataTable.Columns[i].DataType);
                    }

                    ResultDataTable.BeginLoadData();
                    foreach (DataRow parentrow in ds.Tables[0].Rows)
                    {
                        DataRow[] childrows = parentrow.GetChildRows(r1);
                        if (childrows == null || childrows.Length == 0)
                            ResultDataTable.LoadDataRow(parentrow.ItemArray, true);
                    }

                    foreach (DataRow parentrow in ds.Tables[1].Rows)
                    {
                        DataRow[] childrows = parentrow.GetChildRows(r2);
                        if (childrows == null || childrows.Length == 0)
                            ResultDataTable.LoadDataRow(parentrow.ItemArray, true);
                    }
                    ResultDataTable.EndLoadData();
                }


            }
            catch (Exception ex)
            {
            }
            return ResultDataTable;
        }
        public static string ReadFile(String temFileName)
        {
            try
            {
                FileInfo f = new FileInfo(temFileName);
                if (f.Exists)
                {
                    String text = "";
                    using (StreamReader sr = new StreamReader(temFileName))
                    {
                        String line;
                        while ((line = sr.ReadLine()) != null)
                            text += line;

                    }
                    return text;
                }
                else
                    return "";
            }
            catch
            {
                return "";
            }
        }

        #endregion
    }
}
