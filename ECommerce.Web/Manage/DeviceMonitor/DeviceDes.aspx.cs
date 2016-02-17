using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.Web.UI.WebControls;
using ECommerce.Admin.DAL;
using ECommerce.DBUtilities;

namespace ECommerce.Web.Manage.DeviceMonitor {
    public partial class DeviceDes : UI.WebPage {
        private readonly ECommerce.Admin.DAL.ProfInfo _dataDal = new ECommerce.Admin.DAL.ProfInfo();
        readonly LoanInfo _loanInfoDal = new LoanInfo();
        readonly MySQlHelper mySQlHelper = new MySQlHelper();
        protected void Page_Load(object sender, EventArgs e) {
            VerifyPage("", true);
            if (!IsPostBack) {
                BindData(false);
            }
        }

        /// <summary>
        /// 绑定数据 
        /// </summary>
        /// <param name="isFirstPage">搜索和删除用true IsPostBack用false</param>
        private void BindData(bool isFirstPage) {
            #region 分页
            //当前页码
            int pageNum = 1;
            int pageSize = 10;
            //分页查询语句
            string sql = "select row_number() over(order by  oo.CreateDate desc,oo.DID DESC) as rownum,oo.*,AUserInfo.Name FROM DeviceList oo left join AUserInfo on oo.Loaner=AUserInfo.UserName where oo.status=1 and oo.EntID='" + CurrentEmp.OrgId + "'";
            var name = string.Empty;
            if (!string.IsNullOrEmpty(txtRealName.Value)) {
                name = txtRealName.Value;
                sql += " and  oo.DeviceName like '%" + name + "%' ";
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["name"])) {
                name = Request.QueryString["name"];
                txtRealName.Value = name;
                sql += " and  oo.DeviceName like '%" + name + "%' ";
            }
            var puser = string.Empty;
            if (!string.IsNullOrEmpty(Text1.Value)) {
                puser = Text1.Value;
                sql += " and  AUserInfo.Name like '%" + puser + "%' ";
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["loaner"])) {
                puser = Request.QueryString["loaner"];
                Text1.Value = puser;
                sql += " and  AUserInfo.Name like '%" + puser + "%' ";
            }
            if (!isFirstPage) {
                try {

                    if (!string.IsNullOrEmpty(Request.QueryString["Page"])) //页数判断
                    {
                        pageNum = Convert.ToInt32(Request.QueryString["Page"]);
                    }
                }
                catch (Exception ex) {
                    pageNum = 1;
                }
            }
            //分页方法
            Pager1.GetDataBind("Repeater", "rptListWork", sql, pageNum, pageSize, "", "rownum", "DeviceDes.aspx?name=" + name + "&loaner=" + puser + "&");
            #endregion
        }

        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelAll_Click(object sender, EventArgs e) {
            string delStr = "";
            foreach (RepeaterItem item in rptListWork.Items) {
                CheckBox cb = (CheckBox)item.FindControl("cbList");
                if (cb == null || !cb.Checked) continue;
                var litId = cb.ToolTip;
                if (litId != null) {
                    delStr += litId + ",";
                }
            }
            if (!string.IsNullOrEmpty(delStr)) {
                delStr = delStr.Substring(0, delStr.Length - 1);
                var res = _dataDal.DeleteList(delStr);
                if (res) {
                    //Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('删除成功！');</script>");
                    BindData(true);
                }
                else {
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('删除失败！');</script>");
                }
            }
            else {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请选择您要操作的数据！');</script>");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e) {
            BindData(true);
        }

        /// <summary>
        /// 删除单条数据方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnDel_Click(object sender, CommandEventArgs e) {
            if (!string.IsNullOrEmpty(e.CommandName)) {
                var res = _dataDal.DeleteList(e.CommandName);
                if (res) {
                    //Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('删除成功！');</script>");
                    BindData(true);
                }
                else {
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('删除失败！');</script>");
                }
            }
            else {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('操作失败！');</script>");
            }
        }
        protected string GetLastRecord(object eval) {
            string str = string.Empty;
            var model = _loanInfoDal.GetModel(1, " DID='" + eval + "' order by LID desc", new List<SqlParameter>());
            if (null == model) return str;
            var sql = "select TraceTime from dr_user_trace where UserName='" + model.Loaner + "' and WifiLat!='未能获取' and WifiLng!='未能获取' order by TraceId desc LIMIT 1";
            var date = mySQlHelper.ExecuteObject(sql, CommandType.Text);
            if (!Equals(date, null) && !Equals(date, DBNull.Value)) {
                str = Convert.ToDateTime(date).ToString("yyyy-MM-dd");
            }
            return str;
        }
    }
}