﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.WebControls;
using DotNet.Framework.Common;
using ECommerce.Admin.DAL;
using ECommerce.DBUtilities;

namespace ECommerce.Web.Manage.Systems {
    public partial class DevOut : UI.WebPage {
        private readonly DeviceList _dataDal = new DeviceList();
        private readonly LoanInfo _loanInfo = new LoanInfo();
        protected void Page_Load(object sender, EventArgs e) {
            VerifyPage("", false);
            if (!IsPostBack) {
                BindOrgTrain();
                if (!string.IsNullOrEmpty(Request.QueryString["OrgId"])) {
                    BindData(Request.QueryString["OrgId"]);
                }
            }
        }

        private void BindOrgTrain() {
            MySQlHelper h = new MySQlHelper();
            string sql = "select * from dr_user";
            DataTable dtTable = h.ExecuteQuery(sql, CommandType.Text);
            ddltype.DataSource = dtTable;
            ddltype.DataTextField = "UserName";
            ddltype.DataValueField = "UID";
            ddltype.DataBind();
            ddltype.Items.Insert(0, new ListItem("请选择", ""));
        }

        private void BindData(string orgId) {
            try {
                var model = _dataDal.GetModel(Convert.ToInt32(orgId));
                if (null != model) {
                    litDevName.Text = model.DeviceName;
                    litPkey.Text = model.PKey;
                    litDescri.Text = model.Descri;
                    //ddltype.SelectedValue = model.Loanable.ToString();
                }
            }
            catch (Exception) {
            }
        }

        protected void btnSub_Click(object sender, EventArgs e) {
            var LoID = ddltype.SelectedValue;
            var Loaner = ddltype.SelectedItem.Text;
            var LoanDescri = txtdescr.Value;
            var LoanDate = txtBirthDay.Value;
            if (string.IsNullOrEmpty(LoID)) {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请选择借出人！');</script>");
                return;
            }
            if (string.IsNullOrEmpty(LoanDate)) {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写借出时间！');</script>");
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
                var model = new ECommerce.Admin.Model.LoanInfo {
                    CreateDate = DateTime.Now,
                    LoanDescri = LoanDescri,
                    LoanDate = Convert.ToDateTime(LoanDate),
                    DID = Convert.ToInt32(Request.QueryString["OrgId"]),
                    LoID = Convert.ToInt32(LoID),
                    Loaner = Loaner,
                    UId = CurrentUser.UId,
                    OpName = CurrentUser.UserName,
                    Status = 1
                };
                if (_loanInfo.LoanDev(model)) {
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