using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizObj
{
  public   class GL_006 : BizObj.IGetData
    {
      PLABS.DbProvider _objDb = PLABS.DbProvider.MySql;

        public GL_006()
		{
			// this._objDb = ConfigurationManager.AppSettings[""].ToString();
		}
		#region IGetData Members
		public string GetData(string Xml,  string AddParams,string mode)
		{
			String retXml = string.Empty;
			try
			{
            
					PLABS.DAL objDbHelper = new PLABS.DAL();
				    return PLABS.Utils.CnvDataSetToXml(objDbHelper.SelectSP("login", Xml, 1, this._objDb),true);
				
			}
			catch (Exception ex)
			{
				return ex.Message;
			} 
			return "";
		}
		#endregion
    }
}
