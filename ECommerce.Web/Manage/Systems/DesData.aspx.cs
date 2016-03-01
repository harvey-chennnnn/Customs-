using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using DotNet.Framework.Common;
using ECommerce.Admin.DAL;
using ECommerce.DBUtilities;

namespace ECommerce.Web.Manage.Systems {
    public partial class DesData : UI.WebPage {
        private readonly DeviceList _deviceListDal = new DeviceList();
        private readonly DesList _desListDal = new DesList();
        readonly AUserInfo _aUserInfo = new AUserInfo();
        protected void Page_Load(object sender, EventArgs e) {
            VerifyPage("", false);
            if (!IsPostBack) {
                var dId = Request.QueryString["did"];
                if (!string.IsNullOrEmpty(dId)) {
                    var model = _deviceListDal.GetModel(Convert.ToInt32(dId));
                    if (null != model) {
                        if (!string.IsNullOrEmpty(model.Loaner) && model.EntID == CurrentEmp.OrgId) {
                            var auserInfo = _aUserInfo.GetModel(" UserName='" + model.Loaner + "' ", new List<SqlParameter>());
                            if (null != auserInfo) {
                                Literal1.Text = auserInfo.Name;
                            }
                            else {
                                Literal1.Text = model.Loaner;
                            }
                            Literal1.Text += " 的 " + model.DeviceName;
                        }
                    }
                }
            }
        }
    }
}