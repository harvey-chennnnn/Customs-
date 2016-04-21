using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ECommerce.Admin.DAL;
using ECommerce.DBUtilities;

namespace ECommerce.Web.Manage.Systems.AJAX
{
    public partial class DesData : UI.WebPage
    {
        private readonly DesList _desListDal = new DesList();
        private readonly DeviceList _deviceListDal = new DeviceList();
        readonly MySQlHelper mySQlHelper = new MySQlHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            var dId = Request.QueryString["did"];
            if (!string.IsNullOrEmpty(dId))
            {
                try
                {
                    var model = _deviceListDal.GetModel(Convert.ToInt32(dId));
                    if (null != model)
                    {
                        if (!string.IsNullOrEmpty(model.Loaner) && model.EntID == CurrentEmp.OrgId)
                        {
                            var dmodel = new Admin.Model.DesList
                            {
                                DID = model.DID,
                                CreateDate = DateTime.Now,
                                Sender = CurrentUser.UserName,
                                Receiver = model.Loaner,
                                UID = CurrentUser.UId
                            };
                            //var result = DoRequest(dmodel);
                            var sql =
                                "INSERT INTO dr_execute_order (Sender,Receiver,CmdOrder,OrderCotent,IsValid,CREATETIME,STATUS) VALUES ('" + CurrentUser.UserName + "','" + model.Loaner + "','DEL','D',1,'" + DateTime.Now + "',0)";
                            var result = mySQlHelper.ExecuteScalar(sql);
                            //var result =
                            //    "{\"Logic\":true,\"Body\":{\"Sender\":\"ch\",\"Receiver\":\"ch\",\"CmdOrder\":\"DEL\",\"OrderCotent\":\"D\",\"STATUS\":\"0\",\"IsValid\":\"1\"},\"Error\":null}";
                            //var messageArr = Newtonsoft.Json.Linq.JObject.Parse(result);
                            //if (string.IsNullOrEmpty(messageArr["Error"].ToString())) {
                            if (result > 0)
                            {
                                //dmodel.ReID = Convert.ToInt32(messageArr["Body"]["IsValid"]);
                                dmodel.ReID = Convert.ToInt32(result);
                                var re = _desListDal.Add(dmodel);
                                if (re != 0)
                                {
                                    model.ReID = Convert.ToInt32(result);
                                    _deviceListDal.Update(model);
                                    Response.Write("<p>清空指令已发送，您可以在销毁列表中查看状态。</p>");
                                    Response.End();
                                }
                                else
                                {
                                    Response.Write("<p>发送指令失败</p>");
                                    Response.End();
                                }
                            }
                            else
                            {
                                Response.Write("<p>发送指令失败</p>");
                                Response.End();
                            }
                        }
                    }
                }
                catch (System.Threading.ThreadAbortException ex)
                {
                }
                catch (Exception)
                {
                    Response.Write("<p>发送指令失败</p>");
                    Response.End();
                }
            }
        }

        private static readonly string DefaultUserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
        public string DoRequest(Admin.Model.DesList dmodel)
        {
            try
            {
                HttpWebRequest request = null;
                //ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                string url = "http://interface.angeletsoft.cn/interface_ent.php";
                request = WebRequest.Create(url) as HttpWebRequest;
                //request.ProtocolVersion = HttpVersion.Version10;
                request.ContentType = "application/json";
                request.Method = "POST";
                request.UserAgent = DefaultUserAgent;
                //string form = "{\"FunctionCode\":\"GET_STATUS_BYID\",\"ID\":\"1\"}";
                string form = "{\"FunctionCode\":\"EXEUTE_ORDER\",\"Body\":{\"Sender\":\"" + dmodel.Sender + "\",\"Receiver\":\"" + dmodel.Receiver + "\",\"CmdOrder\":\"DEL\",\"OrderCotent\":\"D\",\"STATUS\":\"0\",\"IsValid\":\"1\"}}";
                byte[] data = Encoding.UTF8.GetBytes(form);
                request.ContentLength = data.Length;
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                    stream.Close();
                }
                HttpWebResponse wr = request.GetResponse() as HttpWebResponse;
                string cs = wr.CharacterSet;
                StreamReader reader = new StreamReader(wr.GetResponseStream(), Encoding.GetEncoding(cs));
                return reader.ReadToEnd();
            }
            catch (Exception)
            {
                return "";
            }
        }

    }
}