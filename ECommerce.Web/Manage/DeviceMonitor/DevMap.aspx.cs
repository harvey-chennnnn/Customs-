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

namespace ECommerce.Web.Manage.DeviceMonitor {
    public partial class DevMap : UI.WebPage {
        readonly LoanInfo _loanInfoDal = new LoanInfo();
        readonly DeviceList _deviceListDal = new DeviceList();
        readonly AUserInfo _aUserInfo = new AUserInfo();
        readonly MySQlHelper mySQlHelper = new MySQlHelper();
        protected void Page_Load(object sender, EventArgs e) {
            VerifyPage("", false);
            try {
                var dId = Request.QueryString["did"];
                var tid = Request.QueryString["tid"];
                if (!string.IsNullOrEmpty(dId)) {
                    var model = _deviceListDal.GetModel(Convert.ToInt32(dId));
                    if (!IsPostBack) {
                        if (null != model) {
                            litDevName.Text = model.DeviceName;
                            if (!string.IsNullOrEmpty(model.Loaner) && model.EntID == CurrentEmp.OrgId) {
                                string sql = "SELECT TraceId,TraceTime,WifiLat,ServiceIp,LogonName,ComputerName,LocalIp,ProxyIpFirst FROM dr_user_trace WHERE UserName='" + model.Loaner + "' order by TraceTime desc";
                                if (!string.IsNullOrEmpty(tid)) {
                                    sql = "SELECT TraceId,TraceTime,WifiLat,ServiceIp,LogonName,ComputerName,LocalIp,ProxyIpFirst FROM dr_user_trace WHERE TraceId='" + tid + "'";
                                }

                                DataTable dt = mySQlHelper.ExecuteQuery(sql, CommandType.Text);
                                if (dt.Rows.Count > 0) {
                                    var str = "";
                                    for (int i = 0; i < dt.Rows.Count; i++) {
                                        str += dt.Rows[i]["WifiLat"] + "," + (i + 1) + ". " + Convert.ToDateTime(dt.Rows[i]["TraceTime"]).ToString("yyyy-MM-dd hh:mm:ss") + " " + dt.Rows[i]["ServiceIp"] + "|";
                                    }
                                    hfPos.Value = str.Substring(0, str.Length - 1);
                                }
                            }

                            var auserInfo = _aUserInfo.GetModel(" UserName='" + model.Loaner + "' ", new List<SqlParameter>());
                            if (null != auserInfo) {
                                //litLoaner.Text = auserInfo.Name;
                            }
                            else {
                                //litLoaner.Text = model.Loaner;
                            }
                        }
                    }
                }
            }
            catch {
            }
        }

        protected string GetName(object userName) {
            var auser = _aUserInfo.GetModel(" UserName='" + userName + "' ", new List<SqlParameter>());
            if (null != auser) {
                return auser.Name;
            }
            return userName.ToString();
        }
    }
}