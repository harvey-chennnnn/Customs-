using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ECommerce.Admin.DAL;
using ECommerce.Web.UI;

namespace ECommerce.Web.Manage.Systems {
    public partial class AddEnterprise : UI.WebPage {
        private readonly EnterpriseList _enterpriseList = new EnterpriseList();
        protected void Page_Load(object sender, EventArgs e) {
            VerifyPage("", false);
            if (!IsPostBack) {
                //BindOrgName();
                if (!string.IsNullOrEmpty(Request.QueryString["empId"])) {
                    BindData(Request.QueryString["empId"]);
                }
            }
        }

        private void BindData(string empId) {
            try {
                var model = _enterpriseList.GetModel(Convert.ToInt32(empId));
                if (null != model) {
                    txtEnterpriseID.Value = model.EnterpriseID.ToString();
                    txtEnterpriseName.Value = model.EnterpriseName;
                }
            }
            catch (Exception) {
            }
        }
        //private void BindOrgName() {
        //    List<SqlParameter> parameters = new List<SqlParameter>();         //创建sql参数存储对象
        //    string sqlWhere = " Status =1 ";
        //    DataSet dtor = _enterpriseList.GetList(sqlWhere, parameters);
        //    ddlOrgName.DataSource = dtor;
        //    ddlOrgName.DataTextField = "EnterpriseName";
        //    ddlOrgName.DataValueField = "EnterpriseID";
        //    ddlOrgName.DataBind();
        //    ddlOrgName.Items.Insert(0, new ListItem("请选择所属企业", "-1"));
        //}

        protected void btnSub_Click(object sender, EventArgs e) {
            var EnterpriseID = txtEnterpriseID.Value.Trim();
            var EnterpriseName = txtEnterpriseName.Value.Trim();
            if (string.IsNullOrEmpty(EnterpriseID)) {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写企业ID！');</script>");
                return;
            }
            if (string.IsNullOrEmpty(EnterpriseName)) {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写企业名称！');</script>");
                return;
            }
            if (!string.IsNullOrEmpty(Request.QueryString["empId"])) {
                try {
                    var model = _enterpriseList.GetModel(Convert.ToInt32(Request.QueryString["empId"]));
                    if (model == null) {
                        Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('企业不存在！');</script>");
                        return;
                    }
                    var exists = _enterpriseList.GetModel(" EnterpriseID='" + EnterpriseID + "' and ELID!='" + model.ELID + "'", new List<SqlParameter>());
                    if (null != exists) {
                        Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('企业ID已存在！');</script>");
                        return;
                    }
                    model.EnterpriseID = Convert.ToInt32(EnterpriseID);
                    model.EnterpriseName = EnterpriseName;
                    model.Status = 1;
                    var res = _enterpriseList.Update(model);
                    Page.ClientScript.RegisterStartupScript(GetType(), "",
                        res
                            ? "<script>window.top.$op.location=window.top.$op.location;window.top.$modal.destroy();</script>"
                            : "<script>alert('操作失败！');</script>");
                }
                catch (Exception) {
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('操作失败！');</script>");
                }
            }
            else {
                var model = new Admin.Model.EnterpriseList {
                    EnterpriseName = EnterpriseName,
                    EnterpriseID = Convert.ToInt32(EnterpriseID),
                    UId = CurrentUser.UId,
                    Status = 1
                };
                var exists = _enterpriseList.GetModel(" EnterpriseID='" + EnterpriseID + "'", new List<SqlParameter>());
                if (null != exists) {
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('企业ID已存在！');</script>");
                    return;
                }
                var resAdd = _enterpriseList.Add(model);
                Page.ClientScript.RegisterStartupScript(GetType(), "",
                    resAdd > 0
                        ? "<script>window.top.$op.location=window.top.$op.location;window.top.$modal.destroy();</script>"
                        : "<script>alert('操作失败！');</script>");
            }
        }
    }

}