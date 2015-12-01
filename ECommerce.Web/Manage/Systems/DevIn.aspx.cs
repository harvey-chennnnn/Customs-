using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.WebControls;
using DotNet.Framework.Common;
using ECommerce.Admin.DAL;
using ECommerce.DBUtilities;

namespace ECommerce.Web.Manage.Systems {
    public partial class DevIn : UI.WebPage {
        private readonly DeviceList _dataDal = new DeviceList();
        private readonly LoanInfo _loanInfo = new LoanInfo();
        private readonly AUserInfo _aUserInfo = new AUserInfo();
        protected void Page_Load(object sender, EventArgs e) {
            VerifyPage("", false);
            if (!IsPostBack) {
                //BindOrgTrain();
                if (!string.IsNullOrEmpty(Request.QueryString["OrgId"])) {
                    BindData(Request.QueryString["OrgId"]);
                }
            }
        }

        //private void BindOrgTrain() {
        //    MySQlHelper h = new MySQlHelper();
        //    string sql = "select * from dr_user";
        //    DataTable dtTable = h.ExecuteQuery(sql, CommandType.Text);
        //    ddltype.DataSource = dtTable;
        //    ddltype.DataTextField = "UserName";
        //    ddltype.DataValueField = "UID";
        //    ddltype.DataBind();
        //    ddltype.Items.Insert(0, new ListItem("请选择", ""));
        //}

        private void BindData(string orgId) {
            try {
                var model = _dataDal.GetModel(Convert.ToInt32(orgId));
                if (null != model) {
                    litDevName.Text = model.DeviceName;
                    litPkey.Text = model.PKey;
                    litDescri.Text = model.Descri;
                    var lmodel = _loanInfo.GetModel(Convert.ToInt32(model.LoanerID));
                    litLoanDescri.Text = lmodel.LoanDescri;
                    HiddenField1.Value = litLoanDate.Text = Convert.ToDateTime(lmodel.LoanDate).ToString("yyyy-MM-dd");
                    var auser = _aUserInfo.GetModel(" UserName='" + lmodel.Loaner + "' ", new List<SqlParameter>());
                    litLoaner.Text = null != auser ? auser.Name : lmodel.Loaner;
                    //ddltype.SelectedValue = model.Loanable.ToString();
                }
            }
            catch (Exception) {
            }
        }

        protected void btnSub_Click(object sender, EventArgs e) {
            var ReturnDescri = txtdescr.Value;
            var ReturnDate = txtReturnDate.Value;
            if (string.IsNullOrEmpty(ReturnDate)) {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写归还时间！');</script>");
                return;
            }

            if (string.IsNullOrEmpty(Request.QueryString["OrgId"])) {
                //try {
                //    List<SqlParameter> parameters = new List<SqlParameter>();
                //    var parameter = new SqlParameter("@OrgId", DbType.AnsiString) { Value = Request.QueryString["OrgId"] };
                //    parameters.Add(parameter);
                //    var dt = _dataDal.GetModel(Convert.ToInt32(Request.QueryString["OrgId"]));
                //    if (null == dt) {
                //        Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('设备信息不存在！');</script>");
                //        return;
                //    }
                //    var exists = _dataDal.GetModel(" PKey='" + PKey + "' and DID!=" + Convert.ToInt32(Request.QueryString["OrgId"]),
                //            new List<SqlParameter>());
                //    if (null != exists) {
                //        Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('设备编号已经存在！');</script>");
                //        return;
                //    }
                //    dt.PKey = PKey;
                //    dt.DeviceName = name;
                //    dt.Descri = descr;
                //    dt.EnteringDate = Convert.ToDateTime(EnteringDate);
                //    dt.Loanable = Convert.ToInt32(Loanable);
                //    dt.PurchaseDep = PurchaseDep;
                //    dt.Purchaser = Purchaser;
                //    dt.UID = CurrentUser.UId;

                //    var res = _dataDal.Update(dt);
                //    if (res) {
                //        Page.ClientScript.RegisterStartupScript(GetType(), "",
                //            "<script>window.top.$op.location=window.top.$op.location;window.top.$modal.destroy();</script>");
                //    }
                //    else {
                //        Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('更新失败！');window.top.$modal.destroy();</script>");
                //    }
                //}
                //catch (Exception) {
                //    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('操作失败！');window.top.$modal.destroy();</script>");
                //}
            }
            else {
                var model = _dataDal.GetModel(Convert.ToInt32(Request.QueryString["OrgId"]));
                var lmodel = _loanInfo.GetModel(Convert.ToInt32(model.LoanerID));
                lmodel.ReturnDescri = ReturnDescri;
                lmodel.ReturnDate = Convert.ToDateTime(ReturnDate);
                lmodel.UId = CurrentUser.UId;
                lmodel.OpName = CurrentUser.UserName;
                if (_loanInfo.ReturnDev(lmodel)) {
                    Page.ClientScript.RegisterStartupScript(GetType(), "",
                        "<script>window.top.$op.location=window.top.$op.location;window.top.$modal.destroy();</script>");
                }
                else {
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('操作失败！');window.top.$modal.destroy();</script>");
                }
            }
        }
    }
}