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
using dsEncrypt;
using ECommerce.DBUtilities;

namespace ECommerce.Web.Manage.DeviceMonitor {
    public partial class DevPos : UI.WebPage {
        readonly LoanInfo _loanInfoDal = new LoanInfo();
        readonly DeviceList _deviceListDal = new DeviceList();
        readonly AUserInfo _aUserInfo = new AUserInfo();
        readonly MySQlHelper mySQlHelper = new MySQlHelper();
        protected void Page_Load(object sender, EventArgs e) {
            VerifyPage("", false);
            try {
                var dId = Request.QueryString["did"];
                if (!string.IsNullOrEmpty(dId)) {
                    var model = _deviceListDal.GetModel(Convert.ToInt32(dId));
                    if (!IsPostBack) {
                        if (null != model) {
                            litDevName.Text = model.DeviceName;
                            if (!string.IsNullOrEmpty(model.Loaner) && model.EntID == CurrentEmp.OrgId) {
                                string sql = "SELECT TraceId,TraceTime,WifiLat,ServiceIp,LogonName,ComputerName,LocalIp,ProxyIpFirst FROM dr_user_trace WHERE UserName='" + model.Loaner + "'";
                                DataTable dt = mySQlHelper.ExecuteQuery(sql, CommandType.Text);
                                Repeater1.DataSource = dt;
                                Repeater1.DataBind();
                            }

                            //var auserInfo = _aUserInfo.GetModel(" UserName='" + model.Loaner + "' ", new List<SqlParameter>());
                            //if (null != auserInfo) {
                            //    litLoaner.Text = auserInfo.Name;
                            //}
                            //else {
                            //    litLoaner.Text = model.Loaner;
                            //}
                        }
                    }
                }
            }
            catch {
            }
        }
        private void BindLoanInfo() {
            List<SqlParameter> parameters = new List<SqlParameter>();
            var str = " LoanInfo.DID='" + Request.QueryString["did"] + "' order by LoanInfo.CreateDate desc ";
            var dt = _loanInfoDal.GetLoanerList(str, parameters).Tables[0];
            //rptListWork.DataSource = dt;
            //rptListWork.DataBind();
        }

        protected string GetName(object userName) {
            var auser = _aUserInfo.GetModel(" UserName='" + userName + "' ", new List<SqlParameter>());
            if (null != auser) {
                return auser.Name;
            }
            return userName.ToString();
        }

        protected string GetIp(object eval)
        {
            var ds = new dsEncryptBean();
            return ds.Encrypt(eval.ToString());

        }
    }
}