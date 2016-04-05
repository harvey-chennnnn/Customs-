using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using ECommerce.Admin.Model;
using ECommerce.Lib.Security;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ECommerce.Web.Manage.Systems {
    public partial class Default : UI.WebPage {
        private string _num = "4";
        public string GetMenuCount() {
            return _num;
        }

        protected void lbtnLogout_Click(object sender, EventArgs e) {
            SecurityMgr.Logoff();
            Response.Redirect("/login.aspx");
        }
        private readonly ECommerce.Admin.DAL.OrgEmployees _orgEmployeesDal = new ECommerce.Admin.DAL.OrgEmployees();
        private readonly ECommerce.Admin.DAL.OrgOrganize _orgOrganizeDal = new ECommerce.Admin.DAL.OrgOrganize();
        protected void Page_Load(object sender, EventArgs e) {
            VerifyPage("", false);
            litRoleTree.Text = GetRoleTree();
            if (CurrentUser != null) {
                ECommerce.Admin.Model.OrgEmployees orgEmpl = _orgEmployeesDal.GetModel(int.Parse(CurrentUser.EmplId.ToString()));
                litUserName.Text = orgEmpl.EmplName;
                var title = "";
                if (CurrentUser.Type == 1) {
                    title = SecurityMgr.GetEntName();
                }
                else {
                    var emp = _orgEmployeesDal.GetModel(Convert.ToInt32(CurrentUser.EmplId));
                    var org = _orgOrganizeDal.GetModel(Convert.ToInt64(emp.OrgId));
                    title = SecurityMgr.GetEntName();
                }
                litTitle.Text =  title;
                if (null != HttpContext.Current.Session["CurrentEnt"])
                {
                    Literal1.Text =
                        ((Admin.Model.EnterpriseList) HttpContext.Current.Session["CurrentEnt"]).EnterpriseName;
                }
            }
        }

        private string GetRoleTree() {
            try {
                StringBuilder sbr = new StringBuilder();
                if (Session["CurrentUser"] != null) {
                    OrgUsers dtUser = Session["CurrentUser"] as OrgUsers;
                    string sqlFather = @"SELECT * FROM SYS_PageConfig WHERE PC_Id IN(
SELECT PC_Id FROM SYS_RoleForPage WHERE Role_Id IN (SELECT Role_Id FROM SYS_UserForRole WHERE UId= " + dtUser.UId + @")) and PC_State=1 and PC_ParentId=0 order by PC_Id ";
                    Database db = DatabaseFactory.CreateDatabase();
                    DataTable dt = db.ExecuteDataSet(CommandType.Text, sqlFather).Tables[0];
                    _num = dt.Rows.Count.ToString();
                    for (int i = 0; i < dt.Rows.Count; i++) {
                        int mi = i + 1;
                        if (GetSongCount(mi, dt.Rows[i]["PC_ParentId"].ToString(), sbr, dtUser.UId.ToString()) == 0)
                            continue;
                        sbr.Append("<dl");
                        if (i == 0) {
                            sbr.Append(" style=\"border-top: none\"");
                        }
                        sbr.Append("><dt><span class=\"btn-box clearfix\"><i class=\"dt-icon icon1\" style=\"background-position: " + dt.Rows[i]["PC_Icon"] + ";\"></i><strong>" + dt.Rows[i]["PC_Name"] + "</strong><i class=\"icon1-arrow\"></i></span></dt>");
                        //循环子菜单
                        GetSonMenu(mi, dt.Rows[i]["PC_Id"].ToString(), sbr, dtUser.UId.ToString());
                        sbr.Append("</dl>");
                    }
                }
                return sbr.ToString();
            }
            catch (Exception) {
                return "";
            }
        }

        private int GetSongCount(int ii, string PARENTPAGENO, StringBuilder sbr, string userID) {
            string sqlSon = @"SELECT * FROM SYS_PageConfig WHERE PC_Id IN(
SELECT PC_Id FROM SYS_RoleForPage WHERE Role_Id IN (SELECT Role_Id FROM SYS_UserForRole WHERE UId= " + userID + @")) and PC_State=1 AND PC_ParentId = " + PARENTPAGENO + " order by PC_Id ";

            Database db = DatabaseFactory.CreateDatabase();
            DataTable dt = db.ExecuteDataSet(CommandType.Text, sqlSon).Tables[0];
            if (dt == null) {
                return 0;
            }
            else
                return dt.Rows.Count;
        }

        private void GetSonMenu(int ii, string PARENTPAGENO, StringBuilder sbr, string userID) {
            string sqlSon = @"SELECT * FROM SYS_PageConfig WHERE PC_Id IN(
SELECT PC_Id FROM SYS_RoleForPage WHERE Role_Id IN (SELECT Role_Id FROM SYS_UserForRole WHERE UId= " + userID + @")) and PC_State=1 AND PC_ParentId = " + PARENTPAGENO + " order by PC_Id ";

            Database db = DatabaseFactory.CreateDatabase();
            DataTable dt = db.ExecuteDataSet(CommandType.Text, sqlSon).Tables[0];
            if (dt != null && dt.Rows.Count != 0) {
                for (int i = 0; i < dt.Rows.Count; i++) {
                    sbr.Append("<dd style=\"display:none\" name=\"" + dt.Rows[i]["PC_HrefUrl"] + "\">");
                    //sbr.Append("<a href=\"javascript:;\" title=\"" + dt.Rows[i]["PC_Name"] + "\"");
                    //sbr.Append(" name=\"" + dt.Rows[i]["PC_HrefUrl"] + "\">" + dt.Rows[i]["PC_Name"]);

                    sbr.Append(dt.Rows[i]["PC_Name"]);

                    //sbr.Append("</a>");
                    //GetSonMenu(ii, dt.Rows[i]["PC_Id"].ToString(), sbr, userID);
                    sbr.Append("</dd>");
                }
            }
        }
        /// <summary>
        /// 库管员
        /// </summary>
        /// <returns></returns>
        public bool GetKG() {
            ECommerce.Admin.DAL.SYS_RoleInfo sysRoleDal = new ECommerce.Admin.DAL.SYS_RoleInfo();          //用户角色关系表

            bool resVisit = false;
            VerifyPage("", false);
            var user = Session["CurrentUser"] as ECommerce.Admin.Model.OrgUsers;
            if (user != null) {
                List<SqlParameter> parameters = new List<SqlParameter>();
                string sqlWhe = " Role_Id in (select Role_Id from dbo.SYS_RoleInfo where Role_Name like '%库管%' or Role_Name like '%物流经理%') and UID=@UID";
                var parameter = new SqlParameter("@UID", DbType.AnsiString);
                parameter.Value = user.UId;
                parameters.Add(parameter);
                DataSet dts = sysRoleDal.GetListAdmin(sqlWhe, parameters);
                if (dts != null) {
                    if (dts.Tables[0].Rows.Count > 0) {
                        resVisit = true;
                    }
                }
            }
            return resVisit;
        }

    }
}