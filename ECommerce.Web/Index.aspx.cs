﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ECommerce.Admin.Model;

namespace ECommerce.Web {
    public partial class Index : System.Web.UI.Page {
        private readonly Admin.DAL.ComInfo _comInfoDal = new Admin.DAL.ComInfo();
        private readonly Admin.DAL.ProfInfo _profInfoDal = new Admin.DAL.ProfInfo();
        private readonly Admin.DAL.ProfOrg _profOrgDal = new Admin.DAL.ProfOrg();
        private readonly CM.DAL.CMArticle _cmArticleDal = new CM.DAL.CMArticle();
        private readonly CM.DAL.CMColumn _cmArticleType = new CM.DAL.CMColumn();
        protected void Page_Load(object sender, EventArgs e) {
            ((MasterPage)Page.Master).index = "class=\"active\"";
            rptOrg.DataSource = _profOrgDal.GetList(3, " Status=1 order by CreateDate desc ", new List<SqlParameter>()).Tables[0];
            rptOrg.DataBind();
            rptexp.DataSource = _profInfoDal.GetList(3, " Status=1 order by CreateDate desc ", new List<SqlParameter>()).Tables[0];
            rptexp.DataBind();
            rptCom.DataSource = _comInfoDal.GetList(10, " 1=1 order by CreateDate desc ", new List<SqlParameter>()).Tables[0];
            rptCom.DataBind();
            var cum = _cmArticleDal.GetModel(" Title='客户评价' ", new List<SqlParameter>());
            var cmtype = _cmArticleType.GetModel(" ColName='客户评价' ", new List<SqlParameter>());
            if (null != cmtype) {
                rptPJ.DataSource = _cmArticleDal.GetList(" Status=1 and ColId='" + cmtype.ColId + "' order by AddTime desc ", new List<SqlParameter>()).Tables[0];
                rptPJ.DataBind();
            }
        }
    }
}