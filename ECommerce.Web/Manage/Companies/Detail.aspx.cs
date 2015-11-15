using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ECommerce.Admin.DAL;
using ECommerce.DBUtilities;
using ECommerce.Web.UI;

namespace ECommerce.Web.Manage.Companies {
    public partial class Detail : WebPage {
        protected void Page_Load(object sender, EventArgs e) {
            VerifyPage("", false);
            try {
                if (!string.IsNullOrEmpty(Request.QueryString["fu"])&&!string.IsNullOrEmpty(Request.QueryString["tu"])) {
                    litMsg.Text = GetMsg().ToString();
                }
            }
            catch {
            }
        }
        private StringBuilder GetMsg() {
            var sb = new StringBuilder();
            #region
            MySQlHelper mySQlHelper = new MySQlHelper();
            var sql = "SELECT * FROM dr_user_notice WHERE (UserName='" + Request.QueryString["fu"] + "' AND FromUser='" + Request.QueryString["tu"] + "') OR (UserName='" + Request.QueryString["tu"] + "' AND FromUser='" + Request.QueryString["fu"] + "') ORDER BY InfoId ";
            var dt = mySQlHelper.ExecuteDataset(sql).Tables[0];
            if (dt.Rows.Count > 0) {
                sb.Append("<ul class=\"clearfix\">");
                for (int i = 0; i < dt.Rows.Count; i++) {
                    if (CurrentEmp.EmplName == dt.Rows[i]["FromUser"].ToString()) {
                        sb.Append("<li class=\"out\">");
                        sb.Append("<div class=\"message\">");
                        sb.Append("<span class=\"arrow\"></span>");
                        sb.Append("<a class=\"name\" href=\"javascript:void(0);\">" + CurrentEmp.EmplName + "</a>");
                        sb.Append("<span class=\"datetime\"> " +
                                  Convert.ToDateTime(dt.Rows[i]["CreateTime"])
                                      .ToString("yyyy-MM-dd HH:mm:ss") + "</span>");
                        sb.Append("<span class=\"body\">" + dt.Rows[i]["Message"]);
                        sb.Append("</span>");
                        sb.Append("</div>");
                        sb.Append("</li>");
                    }
                    else {
                        sb.Append("<li class=\"in\">");
                        sb.Append("<div class=\"message\">");
                        sb.Append("<span class=\"arrow\"></span>");
                        sb.Append("<a class=\"name\" href=\"javascript:void(0);\">" + dt.Rows[i]["FromUser"] + "</a>");
                        sb.Append("<span class=\"datetime\"> " +
                                  Convert.ToDateTime(dt.Rows[i]["CreateTime"])
                                      .ToString("yyyy-MM-dd HH:mm:ss") + "</span>");
                        sb.Append("<span class=\"body\">" + dt.Rows[i]["Message"]);
                        sb.Append("</span>");
                        sb.Append("</div>");
                        sb.Append("</li>");
                    }
                }
                sb.Append("</ul>");
            }
            #endregion
            return sb;
        }
    }
}