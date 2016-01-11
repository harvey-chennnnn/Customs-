using System;
using System.Data;
using System.Text;
using System.Web.UI.WebControls;
using ECommerce.Admin.DAL;
using ECommerce.DBUtilities;
using ECommerce.Web.UI;
using Microsoft.Practices.EnterpriseLibrary.Data;
using FactroyInfo = ECommerce.Admin.Model.FactroyInfo;
using SYS_AdminUser = ECommerce.Admin.Model.SYS_AdminUser;

namespace ECommerce.Web.Manage.Services {
    /// <summary>
    /// 角色管理
    /// </summary>
    public partial class EnterpriseInfo : WebPage {
        EnterpriseList _enterpriseList = new EnterpriseList();
        protected void Page_Load(object sender, EventArgs e) {
            VerifyPage("", false);
            if (!IsPostBack) {
                DBindMyRole(false);
            }
        }
        #region  角色管理页面方法
        /// <summary>
        /// 绑定角色信息
        /// </summary>
        private void DBindMyRole(bool isFirstPage) {
            #region 分页
            string sql = "select row_number() over(order by  oo.CreateDate desc,oo.ELID DESC) as rownum,oo.* FROM EnterpriseList oo where Status=1 ";
            var name = string.Empty;
            if (!string.IsNullOrEmpty(txtRealName.Value)) {
                name = txtRealName.Value;
                sql += " and  oo.EnterpriseName like '%" + name + "%' ";
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["name"])) {
                name = Request.QueryString["name"];
                txtRealName.Value = name;
                sql += " and  oo.EnterpriseName like '%" + name + "%' ";
            }
            int pageNum = 1;
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
            Pager1.GetDataBind("Repeater", "RepeaterMyRole", sql, pageNum, 10, "", "rownum", "EnterpriseInfo.aspx?name=" + name + "&");

            #endregion
        }

        /// <summary>
        /// 搜索方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearchRole_Click(object sender, EventArgs e) {
            DBindMyRole(true);
        }
        protected void btnDelAll_Click(object sender, EventArgs e) {
            string delStr = "";
            foreach (RepeaterItem item in RepeaterMyRole.Items) {
                CheckBox cb = (CheckBox)item.FindControl("cbList");
                if (cb == null || !cb.Checked) continue;
                var litId = cb.ToolTip;
                if (litId != null) {
                    delStr += litId + ",";
                }
            }
            if (!string.IsNullOrEmpty(delStr)) {
                delStr = delStr.Substring(0, delStr.Length - 1);
                var res = _enterpriseList.DeleteList(delStr);
                if (res) {
                    //Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('删除成功！');</script>");
                    DBindMyRole(true);
                }
                else {
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('删除失败！');</script>");
                }
            }
            else {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请选择您要操作的数据！');</script>");
            }
        }

        protected void lbtnDel_Click(object sender, CommandEventArgs e) {
            if (!string.IsNullOrEmpty(e.CommandName)) {
                var res = _enterpriseList.DeleteList(e.CommandName);
                if (res) {
                    //Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('删除成功！');</script>");
                    DBindMyRole(true);
                }
                else {
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('删除失败！');</script>");
                }
            }
            else {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('操作失败！');</script>");
            }
        }


        #endregion

        /// <summary>
        /// 获取访问节点
        /// </summary>
        /// <returns></returns>
        public DataTable GetUrl() {
            VerifyPage("", false);
            var user = Session["CurrentUser"] as SYS_AdminUser;
            var facUser = Session["CurrentFacUser"] as FactroyInfo;
            DataTable mtable = new DataTable();
            if (user != null) {
                string sql = "select * from sys_pageconfig where pc_id in (select pc_id from sys_roleforpage where  role_id  in (select role_id from sys_userforrole where adn_id=@Adn_Id)) and  PC_ParentId=" + Request.QueryString["id"] + " order by PC_Id desc";
                Database db = DatabaseFactory.CreateDatabase();
                var paramsStr = new StringBuilder();
                paramsStr.Append("@Adn_Id int");
                var command = SQLServerUtiles.Get_SP_ExecuteSQL(db, sql, paramsStr.ToString());
                db.AddInParameter(command, "Adn_Id", DbType.Int32, user.Adn_Id);
                mtable = db.ExecuteDataSet(command).Tables[0];
            }
            else if (facUser != null) {
                string sql =
                 "select pc.* from [SYS_PageConfig] pc join [SYS_RoleForPage] rfp on rfp.[PC_Id]=pc.[PC_Id] join [SYS_RoleInfo] ri on ri.[Role_Id]=rfp.[Role_Id] where ri.[Role_Name]='会员单位' and pc.PC_ParentId=" +
                    Request.QueryString["id"] + " order by PC_Id desc";
                Database db = DatabaseFactory.CreateDatabase();
                mtable = db.ExecuteDataSet(CommandType.Text, sql).Tables[0];

            }
            return mtable;
        }

        ///// <summary>
        ///// 状态搜索方法
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string rName = txtRoleName.Value;
        //    string status = ddlStatus.SelectedValue;
        //    DBindMyRole(rName, Convert.ToInt32(status));
        //}
    }
}