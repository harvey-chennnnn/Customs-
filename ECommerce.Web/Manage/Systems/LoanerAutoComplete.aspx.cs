using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using ECommerce.Admin.DAL;
using ECommerce.DBUtilities;

namespace ECommerce.Web.Manage.Systems {
    public partial class LoanerAutoComplete : System.Web.UI.Page {
        private readonly AUserInfo _dataDal = new AUserInfo();
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {

                #region

                string callback = Request.QueryString["jsoncallback"];
                var term = HttpUtility.UrlDecode(Request.QueryString["term"]);
                if (!string.IsNullOrEmpty(term)) {
                    var aUserList = _dataDal.GetList(" Name like '%" + term + "%' ", new List<SqlParameter>()).Tables[0];
                    var st = "";
                    string data = "";
                    MySQlHelper h = new MySQlHelper();
                    if (aUserList.Rows.Count > 0) {
                        for (int i = 0; i < aUserList.Rows.Count; i++) {
                            st += "'" + aUserList.Rows[i]["UserName"] + "',";
                        }
                        string sql = "SELECT UserName,UID FROM dr_user WHERE UserName IS NOT NULL AND UserName!='' and username in(" + st.Substring(0, st.Length - 1) + ") ";
                        DataTable dt = h.ExecuteQuery(sql, CommandType.Text);

                        if (dt.Rows.Count > 0) {
                            string names = "";
                            for (int i = 0; i < dt.Rows.Count; i++) {

                                string s = "{\"label\":\"" + dt.Rows[i]["UserName"] + "\",\"value\":\"" + dt.Rows[i]["UID"] + "\"},";
                                names += s;

                            }
                            names = names.Substring(0, names.Length - 1);
                            data = "[" + names + "]";
                        }
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