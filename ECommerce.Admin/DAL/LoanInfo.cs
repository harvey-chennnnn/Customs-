
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
namespace ECommerce.Admin.DAL {
    /// <summary>
    /// 数据访问类:LoanInfo
    /// </summary>
    public partial class LoanInfo {
        public LoanInfo() { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId() {
            string strsql = "select max(LID)+1 from LoanInfo";
            Database db = DatabaseFactory.CreateDatabase();
            object obj = db.ExecuteScalar(CommandType.Text, strsql);
            if (obj != null && obj != DBNull.Value) {
                return int.Parse(obj.ToString());
            }
            return 1;
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int LID) {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from LoanInfo where LID=@LID ");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "LID", DbType.Int32, LID);
            int cmdresult;
            object obj = db.ExecuteScalar(dbCommand);
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value))) {
                cmdresult = 0;
            }
            else {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0) {
                return false;
            }
            else {
                return true;
            }
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ECommerce.Admin.Model.LoanInfo model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into LoanInfo(");
            strSql.Append("DID,LoID,Loaner,LoanDate,UId,OpName,LoanDescri,ReturnDescri,ReturnDate,Status,CreateDate)");

            strSql.Append(" values (");
            strSql.Append("@DID,@LoID,@Loaner,@LoanDate,@UId,@OpName,@LoanDescri,@ReturnDescri,@ReturnDate,@Status,@CreateDate)");
            strSql.Append(";select @@IDENTITY");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "DID", DbType.Int32, model.DID);
            db.AddInParameter(dbCommand, "LoID", DbType.Int32, model.LoID);
            db.AddInParameter(dbCommand, "Loaner", DbType.String, model.Loaner);
            db.AddInParameter(dbCommand, "LoanDate", DbType.DateTime, model.LoanDate);
            db.AddInParameter(dbCommand, "UId", DbType.Int32, model.UId);
            db.AddInParameter(dbCommand, "OpName", DbType.String, model.OpName);
            db.AddInParameter(dbCommand, "LoanDescri", DbType.String, model.LoanDescri);
            db.AddInParameter(dbCommand, "ReturnDescri", DbType.String, model.ReturnDescri);
            db.AddInParameter(dbCommand, "ReturnDate", DbType.DateTime, model.ReturnDate);
            db.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
            db.AddInParameter(dbCommand, "CreateDate", DbType.DateTime, model.CreateDate);
            int result;
            object obj = db.ExecuteScalar(dbCommand);
            if (!int.TryParse(obj.ToString(), out result)) {
                return 0;
            }
            return result;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ECommerce.Admin.Model.LoanInfo model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update LoanInfo set ");
            strSql.Append("DID=@DID,");
            strSql.Append("LoID=@LoID,");
            strSql.Append("Loaner=@Loaner,");
            strSql.Append("LoanDate=@LoanDate,");
            strSql.Append("UId=@UId,");
            strSql.Append("OpName=@OpName,");
            strSql.Append("LoanDescri=@LoanDescri,");
            strSql.Append("ReturnDescri=@ReturnDescri,");
            strSql.Append("ReturnDate=@ReturnDate,");
            strSql.Append("Status=@Status,");
            strSql.Append("CreateDate=@CreateDate");
            strSql.Append(" where LID=@LID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "LID", DbType.Int32, model.LID);
            db.AddInParameter(dbCommand, "DID", DbType.Int32, model.DID);
            db.AddInParameter(dbCommand, "LoID", DbType.Int32, model.LoID);
            db.AddInParameter(dbCommand, "Loaner", DbType.String, model.Loaner);
            db.AddInParameter(dbCommand, "LoanDate", DbType.DateTime, model.LoanDate);
            db.AddInParameter(dbCommand, "UId", DbType.Int32, model.UId);
            db.AddInParameter(dbCommand, "OpName", DbType.String, model.OpName);
            db.AddInParameter(dbCommand, "LoanDescri", DbType.String, model.LoanDescri);
            db.AddInParameter(dbCommand, "ReturnDescri", DbType.String, model.ReturnDescri);
            db.AddInParameter(dbCommand, "ReturnDate", DbType.DateTime, model.ReturnDate);
            db.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
            db.AddInParameter(dbCommand, "CreateDate", DbType.DateTime, model.CreateDate);
            int rows = db.ExecuteNonQuery(dbCommand);

            if (rows > 0) {
                return true;
            }
            else {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int LID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from LoanInfo ");
            strSql.Append(" where LID=@LID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "LID", DbType.Int32, LID);
            int rows = db.ExecuteNonQuery(dbCommand);

            if (rows > 0) {
                return true;
            }
            else {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string LIDlist) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from LoanInfo ");
            strSql.Append(" where LID in (" + LIDlist + ")  ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            int rows = db.ExecuteNonQuery(dbCommand);

            if (rows > 0) {
                return true;
            }
            else {
                return false;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ECommerce.Admin.Model.LoanInfo GetModel(int LID) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select LID,DID,LoID,Loaner,LoanDate,UId,OpName,LoanDescri,ReturnDescri,ReturnDate,Status,CreateDate from LoanInfo ");
            strSql.Append(" where LID=@LID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "LID", DbType.Int32, LID);
            ECommerce.Admin.Model.LoanInfo model = null;
            using (IDataReader dataReader = db.ExecuteReader(dbCommand)) {
                if (dataReader.Read()) {
                    model = ReaderBind(dataReader);
                }
            }
            return model;
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ECommerce.Admin.Model.LoanInfo DataRowToModel(DataRow row) {
            ECommerce.Admin.Model.LoanInfo model = new ECommerce.Admin.Model.LoanInfo();
            if (row != null) {
                if (row["LID"] != null && row["LID"].ToString() != "") {
                    model.LID = Convert.ToInt32(row["LID"].ToString());
                }
                if (row["DID"] != null && row["DID"].ToString() != "") {
                    model.DID = Convert.ToInt32(row["DID"].ToString());
                }
                if (row["LoID"] != null && row["LoID"].ToString() != "") {
                    model.LoID = Convert.ToInt32(row["LoID"].ToString());
                }
                if (row["Loaner"] != null) {
                    model.Loaner = row["Loaner"].ToString();
                }
                if (row["LoanDate"] != null && row["LoanDate"].ToString() != "") {
                    model.LoanDate = Convert.ToDateTime(row["LoanDate"].ToString());
                }
                if (row["UId"] != null && row["UId"].ToString() != "") {
                    model.UId = Convert.ToInt32(row["UId"].ToString());
                }
                if (row["OpName"] != null) {
                    model.OpName = row["OpName"].ToString();
                }
                if (row["LoanDescri"] != null) {
                    model.LoanDescri = row["LoanDescri"].ToString();
                }
                if (row["ReturnDescri"] != null) {
                    model.ReturnDescri = row["ReturnDescri"].ToString();
                }
                if (row["ReturnDate"] != null && row["ReturnDate"].ToString() != "") {
                    model.ReturnDate = Convert.ToDateTime(row["ReturnDate"].ToString());
                }
                if (row["Status"] != null && row["Status"].ToString() != "") {
                    model.Status = Convert.ToInt32(row["Status"].ToString());
                }
                if (row["CreateDate"] != null && row["CreateDate"].ToString() != "") {
                    model.CreateDate = Convert.ToDateTime(row["CreateDate"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// <param name="strWhere">查询条件 Status=@Status and Cell=@Cell order by CreateDate Desc  like写法:'%'+@Cell+'%' </param>
        /// <param name="parameters">List<SqlParameter> parameters</param>
        /// </summary>
        public DataSet GetList(string strWhere, List<SqlParameter> parameters) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select LID,DID,LoID,Loaner,LoanDate,UId,OpName,LoanDescri,ReturnDescri,ReturnDate,Status,CreateDate ");
            strSql.Append(" FROM LoanInfo ");
            Database db = DatabaseFactory.CreateDatabase();
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            if (parameters.Count > 0) {
                foreach (SqlParameter sqlParameter in parameters) {
                    dbCommand.Parameters.Add(sqlParameter);
                }
            }
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// 获得前几行数据
        /// <param name="Top">int Top</param>
        /// <param name="strWhere">查询条件 Status=@Status and Cell=@Cell order by CreateDate Desc  like写法:'%'+@Cell+'%' </param>
        /// <param name="parameters">List<SqlParameter> parameters</param>
        /// </summary>
        public DataSet GetList(int Top, string strWhere, List<SqlParameter> parameters) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0) {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" LID,DID,LoID,Loaner,LoanDate,UId,OpName,LoanDescri,ReturnDescri,ReturnDate,Status,CreateDate ");
            strSql.Append(" FROM LoanInfo ");
            Database db = DatabaseFactory.CreateDatabase();
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            if (parameters.Count > 0) {
                foreach (SqlParameter sqlParameter in parameters) {
                    dbCommand.Parameters.Add(sqlParameter);
                }
            }
            return db.ExecuteDataSet(dbCommand);
        }

        /*
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql=new StringBuilder();
            strSql.Append("select count(1) FROM LoanInfo ");
            if(strWhere.Trim()!="")
            {
                strSql.Append(" where "+strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }*/
        /// <summary>
        /// 分页获取数据列表
        /// <param name="strWhere">查询条件 Status=@Status and Cell=@Cell  like写法:'%'+@Cell+'%' </param>
        /// <param name="orderby">string orderby</param>
        /// <param name="startIndex">开始页码</param>
        /// <param name="endIndex">结束页码</param>
        /// <param name="parameters">List<SqlParameter> parameters</param>
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex, List<SqlParameter> parameters) {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim())) {
                strSql.Append("order by T." + orderby);
            }
            else {
                strSql.Append("order by T.LID desc");
            }
            strSql.Append(")AS Row, T.*  from LoanInfo T ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            if (parameters.Count > 0) {
                foreach (SqlParameter sqlParameter in parameters) {
                    dbCommand.Parameters.Add(sqlParameter);
                }
            }
            return db.ExecuteDataSet(dbCommand);
        }


        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize, int PageIndex, string strWhere) {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("UP_GetRecordByPage");
            db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "LoanInfo");
            db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "LID");
            db.AddInParameter(dbCommand, "PageSize", DbType.Int32, PageSize);
            db.AddInParameter(dbCommand, "PageIndex", DbType.Int32, PageIndex);
            db.AddInParameter(dbCommand, "IsReCount", DbType.Boolean, 0);
            db.AddInParameter(dbCommand, "OrderType", DbType.Boolean, 0);
            db.AddInParameter(dbCommand, "strWhere", DbType.AnsiString, strWhere);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// 获得数据列表（比DataSet效率高，推荐使用）
        /// <param name="strWhere">查询条件 Status=@Status and Cell=@Cell order by CreateDate Desc  like写法:'%'+@Cell+'%' </param>
        /// <param name="parameters">List<SqlParameter> parameters</param>
        /// </summary>
        public List<ECommerce.Admin.Model.LoanInfo> GetListArray(string strWhere, List<SqlParameter> parameters) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select LID,DID,LoID,Loaner,LoanDate,UId,OpName,LoanDescri,ReturnDescri,ReturnDate,Status,CreateDate ");
            strSql.Append(" FROM LoanInfo ");
            if (strWhere.Trim() != "") {
                strSql.Append(" where " + strWhere);
            }
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            if (parameters.Count > 0) {
                foreach (SqlParameter sqlParameter in parameters) {
                    dbCommand.Parameters.Add(sqlParameter);
                }
            }
            List<ECommerce.Admin.Model.LoanInfo> list = new List<ECommerce.Admin.Model.LoanInfo>();
            using (IDataReader dataReader = db.ExecuteReader(dbCommand)) {
                while (dataReader.Read()) {
                    list.Add(ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public ECommerce.Admin.Model.LoanInfo ReaderBind(IDataReader dataReader) {
            ECommerce.Admin.Model.LoanInfo model = new ECommerce.Admin.Model.LoanInfo();
            object ojb;
            ojb = dataReader["LID"];
            if (ojb != null && ojb != DBNull.Value) {
                model.LID = Convert.ToInt32(ojb);
            }
            ojb = dataReader["DID"];
            if (ojb != null && ojb != DBNull.Value) {
                model.DID = Convert.ToInt32(ojb);
            }
            ojb = dataReader["LoID"];
            if (ojb != null && ojb != DBNull.Value) {
                model.LoID = Convert.ToInt32(ojb);
            }
            model.Loaner = dataReader["Loaner"].ToString();
            ojb = dataReader["LoanDate"];
            if (ojb != null && ojb != DBNull.Value) {
                model.LoanDate = Convert.ToDateTime(ojb);
            }
            ojb = dataReader["UId"];
            if (ojb != null && ojb != DBNull.Value) {
                model.UId = Convert.ToInt32(ojb);
            }
            model.OpName = dataReader["OpName"].ToString();
            model.LoanDescri = dataReader["LoanDescri"].ToString();
            model.ReturnDescri = dataReader["ReturnDescri"].ToString();
            ojb = dataReader["ReturnDate"];
            if (ojb != null && ojb != DBNull.Value) {
                model.ReturnDate = Convert.ToDateTime(ojb);
            }
            ojb = dataReader["Status"];
            if (ojb != null && ojb != DBNull.Value) {
                model.Status = Convert.ToInt32(ojb);
            }
            ojb = dataReader["CreateDate"];
            if (ojb != null && ojb != DBNull.Value) {
                model.CreateDate = Convert.ToDateTime(ojb);
            }
            return model;
        }

        #endregion  Method

        #region
        public bool LoanDev(Model.LoanInfo model) {
            bool result = false;
            Database db = DatabaseFactory.CreateDatabase();
            using (DbConnection conn = db.CreateConnection()) {
                conn.Open();
                DbTransaction trans = conn.BeginTransaction();
                try {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("insert into LoanInfo(");
                    strSql.Append("DID,LoID,Loaner,LoanDate,UId,OpName,LoanDescri,ReturnDescri,ReturnDate,Status,CreateDate)");

                    strSql.Append(" values (");
                    strSql.Append("@DID,@LoID,@Loaner,@LoanDate,@UId,@OpName,@LoanDescri,@ReturnDescri,@ReturnDate,@Status,@CreateDate)");
                    strSql.Append(";select @@IDENTITY");
                    DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
                    db.AddInParameter(dbCommand, "DID", DbType.Int32, model.DID);
                    db.AddInParameter(dbCommand, "LoID", DbType.Int32, model.LoID);
                    db.AddInParameter(dbCommand, "Loaner", DbType.String, model.Loaner);
                    db.AddInParameter(dbCommand, "LoanDate", DbType.DateTime, model.LoanDate);
                    db.AddInParameter(dbCommand, "UId", DbType.Int32, model.UId);
                    db.AddInParameter(dbCommand, "OpName", DbType.String, model.OpName);
                    db.AddInParameter(dbCommand, "LoanDescri", DbType.String, model.LoanDescri);
                    db.AddInParameter(dbCommand, "ReturnDescri", DbType.String, model.ReturnDescri);
                    db.AddInParameter(dbCommand, "ReturnDate", DbType.DateTime, model.ReturnDate);
                    db.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
                    db.AddInParameter(dbCommand, "CreateDate", DbType.DateTime, model.CreateDate);
                    object obj = db.ExecuteScalar(dbCommand, trans);

                    StringBuilder strSqlUp = new StringBuilder();
                    strSqlUp.Append("update DeviceList set ");
                    strSqlUp.Append("LoanStatus=1,");
                    strSqlUp.Append("LoanerID=" + obj + ",");
                    strSqlUp.Append("Loaner='" + model.Loaner + "',");
                    strSqlUp.Append("LoanDate='" + model.LoanDate + "'");
                    strSqlUp.Append(" where DID=" + model.DID + "  ");
                    DbCommand dbCommandUp = db.GetSqlStringCommand(strSqlUp.ToString());
                    db.ExecuteNonQuery(dbCommandUp, trans);
                    trans.Commit();
                    result = true;
                }
                catch {
                    trans.Rollback();
                }
                conn.Close();

                return result;
            }
        }

        public bool ReturnDev(Model.LoanInfo model) {
            bool result = false;
            Database db = DatabaseFactory.CreateDatabase();
            using (DbConnection conn = db.CreateConnection()) {
                conn.Open();
                DbTransaction trans = conn.BeginTransaction();
                try {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("update LoanInfo set ");
                    strSql.Append("OpName='" + model.OpName + "',ReturnDescri='" + model.ReturnDescri + "',ReturnDate='" + model.ReturnDate + "'");
                    strSql.Append(" where LID=" + model.LID + "  ");
                    DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
                    db.ExecuteNonQuery(dbCommand, trans);

                    StringBuilder strSqlUp = new StringBuilder();
                    strSqlUp.Append("update DeviceList set ");
                    strSqlUp.Append("LoanStatus=0,");
                    strSqlUp.Append("LoanerID=NULL,");
                    strSqlUp.Append("Loaner=NULL,");
                    strSqlUp.Append("LoanDate=NULL");
                    strSqlUp.Append(" where DID=" + model.DID + "  ");
                    DbCommand dbCommandUp = db.GetSqlStringCommand(strSqlUp.ToString());
                    db.ExecuteNonQuery(dbCommandUp, trans);
                    trans.Commit();
                    result = true;
                }
                catch {
                    trans.Rollback();
                }
                conn.Close();

                return result;
            }
        }

        #endregion
    }
}

