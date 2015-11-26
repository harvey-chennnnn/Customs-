using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.WebControls;
using DotNet.Framework.Common;
using ECommerce.Admin.DAL;

namespace ECommerce.Web.Manage.Systems {
    public partial class AddAUInfo : UI.WebPage {
        private readonly AUserInfo _dataDal = new AUserInfo();
        protected void Page_Load(object sender, EventArgs e) {
            VerifyPage("", false);
            if (!IsPostBack) {
                if (!string.IsNullOrEmpty(Request.QueryString["OrgId"])) {
                    BindData(Request.QueryString["OrgId"]);
                }
            }
        }

        //private void BindOrgTrain() {
        //    List<SqlParameter> parameters = new List<SqlParameter>();
        //    var str = " 1=1 order by CreateDate desc ";
        //    var dt = _dataSWCDal.GetList(str, parameters).Tables[0];
        //    ddltype.DataSource = dt;
        //    ddltype.DataTextField = "Name";
        //    ddltype.DataValueField = "PTID";
        //    ddltype.DataBind();
        //    ddltype.Items.Insert(0, new ListItem("请选择", ""));
        //}

        private void BindData(string orgId) {
            try {
                var model = _dataDal.GetModel(Convert.ToInt32(orgId));
                if (null != model) {
                    txtName.Value = model.Name;
                    txtDId.Value = model.UserName;
                }
            }
            catch (Exception) {
            }
        }

        protected void btnSub_Click(object sender, EventArgs e) {
            var name = txtName.Value.Trim();
            var LoID = HiddenField1.Value;
            var Loaner = txtDId.Value;

            if (string.IsNullOrEmpty(name)) {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写姓名！');</script>");
                return;
            }
            if (string.IsNullOrEmpty(Loaner) || string.IsNullOrEmpty(LoID)) {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请选择小天使帐户名！');</script>");
                return;
            }

            if (!string.IsNullOrEmpty(Request.QueryString["OrgId"])) {
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
                var model = new ECommerce.Admin.Model.AUserInfo {
                    Name = name,
                    CreateDate = DateTime.Now,
                    UserName = Loaner,
                    AUID = Convert.ToInt32(LoID),
                    UID = CurrentUser.UId
                };
                var exists = _dataDal.GetModel(" UserName='"+Loaner+"' ", new List<SqlParameter>());
                if (null != exists) {
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('员工信息已经存在！');</script>");
                    return;
                }
                var resAdd = _dataDal.Add(model);
                if (resAdd > 0) {
                    Page.ClientScript.RegisterStartupScript(GetType(), "",
                        "<script>window.top.$op.location=window.top.$op.location;window.top.$modal.destroy();</script>");
                }
                else {
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('新增失败！');window.top.$modal.destroy();</script>");
                }
            }
        }
    }
}