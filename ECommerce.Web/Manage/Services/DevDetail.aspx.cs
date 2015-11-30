using System.Collections;
using DotNet.Framework.Common;
using ECommerce.Admin.DAL;
using ECommerce.Lib.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using ECommerce.DBUtilities;

namespace ECommerce.Web.Manage.Services {
    public partial class DevDetail : UI.WebPage {
        readonly LoanInfo _loanInfoDal = new LoanInfo();
        readonly DeviceList _deviceListDal = new DeviceList();
        readonly AUserInfo _aUserInfo = new AUserInfo();
        protected void Page_Load(object sender, EventArgs e) {
            VerifyPage("", false);
            try {
                var dId = Request.QueryString["did"];
                if (!string.IsNullOrEmpty(dId)) {
                    var model = _deviceListDal.GetModel(Convert.ToInt32(dId));
                    if (!IsPostBack) {
                        if (!string.IsNullOrEmpty(dId)) {
                            if (null != model) {
                                litDescri.Text = model.Descri;
                                litDevName.Text = model.DeviceName;
                                litLoanDate.Text = model.LoanDate != null
                                    ? Convert.ToDateTime(model.LoanDate).ToString("yyyy-MM-dd")
                                    : "";
                                var auserInfo = _aUserInfo.GetModel(" UserName='" + model.Loaner + "' ", new List<SqlParameter>());
                                if (null != auserInfo) {
                                    litLoaner.Text = auserInfo.Name;
                                }
                                else {
                                    litLoaner.Text = model.Loaner;
                                }
                                litPkey.Text = model.PKey;
                                litStatus.Text = model.LoanStatus == "1" ? "已借出" : "未借出";
                                BindLoanInfo();
                                litMsg.Text = GetMsg(model.Loaner).ToString();
                            }
                        }
                    }
                    else {
                        if (!string.IsNullOrEmpty(Request.Form["textarea"])) {
                            var sql = "insert into dr_user_notice (UserName,FromUser,MsgTitle,Message,IsValid) values ('" +
                                model.Loaner + "','" + CurrentEmp.EmplName + "','通知消息','" + Request.Form["textarea"] + "',1);SELECT LAST_INSERT_ID();";
                            MySQlHelper mySQlHelper = new MySQlHelper();
                            var res = mySQlHelper.ExecuteScalar(sql, CommandType.Text);
                            if (res > 0) {
                                litMsg.Text = GetMsg(model.Loaner).ToString();
                                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('消息已发送！');</script>");
                            }
                            else {
                                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('发送消息失败！');</script>");
                            }
                        }
                    }
                }
            }
            catch {
            }
        }
        private StringBuilder GetMsg(string loaner) {
            var sb = new StringBuilder();
            if (!string.IsNullOrEmpty(loaner)) {
                dMsg.Visible = true;

                #region

                MySQlHelper mySQlHelper = new MySQlHelper();
                var sql = "SELECT * FROM dr_user_notice WHERE (UserName='" + CurrentEmp.EmplName + "' AND FromUser='" +
                          loaner + "') OR (UserName='" + loaner + "' AND FromUser='" + CurrentEmp.EmplName +
                          "') ORDER BY InfoId DESC ";
                var dt = mySQlHelper.ExecuteDataset(sql).Tables[0];
                if (dt.Rows.Count > 0) {
                    sb.Append("<ul class=\"clearfix\">");
                    for (int i = dt.Rows.Count - 1; i >= 0; i--) {
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
                            sb.Append("<a class=\"name\" href=\"javascript:void(0);\">" + GetName(dt.Rows[i]["FromUser"]) +
                                      "</a>");
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
                else {
                    sb.Append("<div style=\"text-align: center\">暂无消息</div>");
                }

                #endregion
            }
            else {
                dMsg.Visible = false;
            }
            return sb;
        }

        private void BindLoanInfo() {
            List<SqlParameter> parameters = new List<SqlParameter>();
            var str = " LoanInfo.DID='" + Request.QueryString["did"] + "' order by LoanInfo.CreateDate desc ";
            var dt = _loanInfoDal.GetLoanerList(str, parameters).Tables[0];
            rptListWork.DataSource = dt;
            rptListWork.DataBind();
        }

        protected string GetName(object userName) {
            var auser = _aUserInfo.GetModel(" UserName='" + userName + "' ", new List<SqlParameter>());
            if (null != auser) {
                return auser.Name;
            }
            return userName.ToString();
        }

        /// <summary>
        /// 保存方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e) {

        }
    }
}