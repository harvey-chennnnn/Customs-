using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.WebControls;
using DotNet.Framework.Common;
using ECommerce.Admin.DAL;

namespace ECommerce.Web.Manage.Systems {
    public partial class AddProfInfo : UI.WebPage {
        private readonly DeviceList _dataDal = new DeviceList();
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
                    txtName.Value = model.DeviceName;
                    Text1.Value = model.PKey;
                    txtage.Value = model.PurchaseDep;
                    txtdescr.Value = model.Descri;
                    txtaddr.Value = model.Purchaser;
                    txtBirthDay.Value = Convert.ToDateTime(model.EnteringDate).ToString("yyyy-MM-dd");
                    ddltype.SelectedValue = model.Loanable.ToString();
                }
            }
            catch (Exception) {
            }
        }

        protected void btnSub_Click(object sender, EventArgs e) {
            var name = txtName.Value.Trim();
            var Loanable = ddltype.SelectedValue;
            var Purchaser = txtaddr.Value;
            var descr = txtdescr.Value;
            var PurchaseDep = txtage.Value;
            var EnteringDate = txtBirthDay.Value;
            var PKey = Text1.Value;
            if (string.IsNullOrEmpty(name)) {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写设备名称！');</script>");
                return;
            }
            if (string.IsNullOrEmpty(PKey)) {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写设备唯一编号！');</script>");
                return;
            }
            if (string.IsNullOrEmpty(EnteringDate))
            {
                //EnteringDate = DateTime.Now.ToString();
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写入库时间！');</script>");
                return;
            }
            if (!string.IsNullOrEmpty(Request.QueryString["OrgId"])) {
                try {
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    var parameter = new SqlParameter("@OrgId", DbType.AnsiString) { Value = Request.QueryString["OrgId"] };
                    parameters.Add(parameter);
                    var dt = _dataDal.GetModel(Convert.ToInt32(Request.QueryString["OrgId"]));
                    if (null == dt) {
                        Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('设备信息不存在！');</script>");
                        return;
                    }
                    var exists = _dataDal.GetModel(" PKey='" + PKey + "' and DID!=" + Convert.ToInt32(Request.QueryString["OrgId"]),
                            new List<SqlParameter>());
                    if (null != exists) {
                        Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('设备编号已经存在！');</script>");
                        return;
                    }
                    dt.PKey = PKey;
                    dt.DeviceName = name;
                    dt.Descri = descr;
                    dt.EnteringDate = Convert.ToDateTime(EnteringDate);
                    dt.Loanable = Convert.ToInt32(Loanable);
                    dt.PurchaseDep = PurchaseDep;
                    dt.Purchaser = Purchaser;
                    dt.UID = CurrentUser.UId;
                    //dt.EntID = Convert.ToInt32(CurrentEmp.OrgId);

                    var res = _dataDal.Update(dt);
                    if (res) {
                        Page.ClientScript.RegisterStartupScript(GetType(), "",
                            "<script>window.top.$op.location=window.top.$op.location;window.top.$modal.destroy();</script>");
                    }
                    else {
                        Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('更新失败！');window.top.$modal.destroy();</script>");
                    }
                }
                catch (Exception) {
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('操作失败！');window.top.$modal.destroy();</script>");
                }
            }
            else {
                var model = new ECommerce.Admin.Model.DeviceList {
                    PKey = PKey,
                    CreateDate = DateTime.Now,
                    DeviceName = name,
                    Descri = descr,
                    EnteringDate = Convert.ToDateTime(EnteringDate),
                    Loanable = Convert.ToInt32(Loanable),
                    PurchaseDep = PurchaseDep,
                    Purchaser = Purchaser,
                    UID = CurrentUser.UId,
                    Status = 1,
                    EntID = Convert.ToInt32(CurrentEmp.OrgId)
                };
                var exists = _dataDal.GetModel(" PKey='" + PKey + "' ", new List<SqlParameter>());
                if (null != exists) {
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('设备编号已经存在！');</script>");
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

        public static void UpImg(ref FileUpload upfile_href, out string imgurl, out string msg, string imgPath, out int size) {
            string datatime = System.DateTime.Now.ToString("yyyyMMddHHmmssffff");
            if (upfile_href.HasFile) {
                string fileName = upfile_href.FileName;
                string fileExition = System.IO.Path.GetExtension(fileName).ToLower();
                string de = "|.gif|.png|.jpeg|.jpg|.bmp";
                string strDay = System.DateTime.Now.ToString("yyyyMM");
                string path = HttpContext.Current.Server.MapPath(imgPath + "/" + strDay + "/");
                if (!System.IO.Directory.Exists(path)) {
                    System.IO.Directory.CreateDirectory(path);
                }
                if (fileName == "") {
                    msg = "请选择上传的图片";
                    imgurl = "";
                    size = 0;
                    return;
                }
                if (de.IndexOf(fileExition) > 0) {
                    string NewFileName = datatime + fileExition;
                    upfile_href.PostedFile.SaveAs(path + NewFileName);
                    size = upfile_href.PostedFile.ContentLength;
                    imgurl = imgPath + "/" + strDay + "/" + NewFileName;
                    msg = "上传成功!";
                }
                else {
                    msg = "上传图片格式错误";
                    imgurl = "";
                    size = 0;
                }
            }
            else {
                imgurl = "";
                msg = "请选择上传的图片";
                size = 0;
            }
        }

    }
}