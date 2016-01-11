using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using ECommerce.DBUtilities;
using ECommerce.Web.UI;

namespace ECommerce.Web.Manage.Systems {
    public partial class AUserAutoComplete : WebPage {
        protected void Page_Load(object sender, EventArgs e) {
            VerifyPage("", false);
            if (!IsPostBack) {

                #region

                string callback = Request.QueryString["jsoncallback"];
                var term = HttpUtility.UrlDecode(Request.QueryString["term"]);
                if (!string.IsNullOrEmpty(term)) {
                    MySQlHelper h = new MySQlHelper();
                    string sql = "SELECT UserName,UID,CONVERT(IsEnterprise,SIGNED) as IsEnterprise FROM dr_user WHERE UserName IS NOT NULL AND UserName!='' and username like '%" + term + "%' and IsEnterprise='" + CurrentEmp.OrgId + "'";
                    DataTable dt = h.ExecuteQuery(sql, CommandType.Text);
                    string data = "";
                    if (dt.Rows.Count > 0) {
                        string names = "";
                        for (int i = 0; i < dt.Rows.Count; i++) {

                            string s = "{\"label\":\"" + dt.Rows[i]["UserName"] + "\",\"value\":\"" + dt.Rows[i]["UID"] + "\",\"entId\":\"" + dt.Rows[i]["IsEnterprise"].ToString() + "\"},";
                            names += s;

                        }
                        names = names.Substring(0, names.Length - 1);
                        data = "[" + names + "]";
                    }
                    //data = "[\"title\", \"Recent Uploads tagged cat\",\"link\", \"http://www.sina.com.cn\",\"ch\",\"chtest\"]";
                    string result = string.Format("{0}({1})", callback, data);
                    Response.Expires = -1;
                    Response.Clear();
                    Response.ContentEncoding = Encoding.UTF8;
                    Response.ContentType = "application/json";
                    Response.Write(data);

                    Response.Flush();
                    Response.End();
                }

                #endregion
            }
        }
    }

}