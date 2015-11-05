
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
namespace ECommerce.Admin.DAL
{
	/// <summary>
	/// 数据访问类:DeviceList
	/// </summary>
	public partial class DeviceList
	{
		public DeviceList()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(DID)+1 from DeviceList";
			Database db = DatabaseFactory.CreateDatabase();
			object obj = db.ExecuteScalar(CommandType.Text, strsql);
			if (obj != null && obj != DBNull.Value)
			{
				return int.Parse(obj.ToString());
			}
			return 1;
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int DID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from DeviceList where DID=@DID ");
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "DID", DbType.Int32,DID);
			int cmdresult;
			object obj = db.ExecuteScalar(dbCommand);
			if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
			{
				cmdresult = 0;
			}
			else
			{
				cmdresult = int.Parse(obj.ToString());
			}
			if (cmdresult == 0)
			{
				return false;
			}
			else
			{
				return true;
			}
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ECommerce.Admin.Model.DeviceList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into DeviceList(");
			strSql.Append("PKey,DeviceName,Loanable,PurchaseDep,Purchaser,LoanStatus,LoanerID,Loaner,LoanDate,Status,DeviceDispose,Descri,UID,EnteringDate,CreateDate)");

			strSql.Append(" values (");
			strSql.Append("@PKey,@DeviceName,@Loanable,@PurchaseDep,@Purchaser,@LoanStatus,@LoanerID,@Loaner,@LoanDate,@Status,@DeviceDispose,@Descri,@UID,@EnteringDate,@CreateDate)");
			strSql.Append(";select @@IDENTITY");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "PKey", DbType.String, model.PKey);
			db.AddInParameter(dbCommand, "DeviceName", DbType.String, model.DeviceName);
			db.AddInParameter(dbCommand, "Loanable", DbType.Byte, model.Loanable);
			db.AddInParameter(dbCommand, "PurchaseDep", DbType.String, model.PurchaseDep);
			db.AddInParameter(dbCommand, "Purchaser", DbType.String, model.Purchaser);
			db.AddInParameter(dbCommand, "LoanStatus", DbType.String, model.LoanStatus);
			db.AddInParameter(dbCommand, "LoanerID", DbType.Int32, model.LoanerID);
			db.AddInParameter(dbCommand, "Loaner", DbType.String, model.Loaner);
			db.AddInParameter(dbCommand, "LoanDate", DbType.DateTime, model.LoanDate);
			db.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
			db.AddInParameter(dbCommand, "DeviceDispose", DbType.String, model.DeviceDispose);
			db.AddInParameter(dbCommand, "Descri", DbType.String, model.Descri);
			db.AddInParameter(dbCommand, "UID", DbType.Int32, model.UID);
			db.AddInParameter(dbCommand, "EnteringDate", DbType.DateTime, model.EnteringDate);
			db.AddInParameter(dbCommand, "CreateDate", DbType.DateTime, model.CreateDate);
			int result;
			object obj = db.ExecuteScalar(dbCommand);
			if(!int.TryParse(obj.ToString(),out result))
			{
				return 0;
			}
			return result;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ECommerce.Admin.Model.DeviceList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update DeviceList set ");
			strSql.Append("PKey=@PKey,");
			strSql.Append("DeviceName=@DeviceName,");
			strSql.Append("Loanable=@Loanable,");
			strSql.Append("PurchaseDep=@PurchaseDep,");
			strSql.Append("Purchaser=@Purchaser,");
			strSql.Append("LoanStatus=@LoanStatus,");
			strSql.Append("LoanerID=@LoanerID,");
			strSql.Append("Loaner=@Loaner,");
			strSql.Append("LoanDate=@LoanDate,");
			strSql.Append("Status=@Status,");
			strSql.Append("DeviceDispose=@DeviceDispose,");
			strSql.Append("Descri=@Descri,");
			strSql.Append("UID=@UID,");
			strSql.Append("EnteringDate=@EnteringDate,");
			strSql.Append("CreateDate=@CreateDate");
			strSql.Append(" where DID=@DID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "DID", DbType.Int32, model.DID);
			db.AddInParameter(dbCommand, "PKey", DbType.String, model.PKey);
			db.AddInParameter(dbCommand, "DeviceName", DbType.String, model.DeviceName);
			db.AddInParameter(dbCommand, "Loanable", DbType.Byte, model.Loanable);
			db.AddInParameter(dbCommand, "PurchaseDep", DbType.String, model.PurchaseDep);
			db.AddInParameter(dbCommand, "Purchaser", DbType.String, model.Purchaser);
			db.AddInParameter(dbCommand, "LoanStatus", DbType.String, model.LoanStatus);
			db.AddInParameter(dbCommand, "LoanerID", DbType.Int32, model.LoanerID);
			db.AddInParameter(dbCommand, "Loaner", DbType.String, model.Loaner);
			db.AddInParameter(dbCommand, "LoanDate", DbType.DateTime, model.LoanDate);
			db.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
			db.AddInParameter(dbCommand, "DeviceDispose", DbType.String, model.DeviceDispose);
			db.AddInParameter(dbCommand, "Descri", DbType.String, model.Descri);
			db.AddInParameter(dbCommand, "UID", DbType.Int32, model.UID);
			db.AddInParameter(dbCommand, "EnteringDate", DbType.DateTime, model.EnteringDate);
			db.AddInParameter(dbCommand, "CreateDate", DbType.DateTime, model.CreateDate);
			int rows=db.ExecuteNonQuery(dbCommand);

			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int DID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DeviceList ");
			strSql.Append(" where DID=@DID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "DID", DbType.Int32,DID);
			int rows=db.ExecuteNonQuery(dbCommand);

			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string DIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DeviceList ");
			strSql.Append(" where DID in ("+DIDlist + ")  ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			int rows=db.ExecuteNonQuery(dbCommand);

			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ECommerce.Admin.Model.DeviceList GetModel(int DID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select DID,PKey,DeviceName,Loanable,PurchaseDep,Purchaser,LoanStatus,LoanerID,Loaner,LoanDate,Status,DeviceDispose,Descri,UID,EnteringDate,CreateDate from DeviceList ");
			strSql.Append(" where DID=@DID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "DID", DbType.Int32,DID);
			ECommerce.Admin.Model.DeviceList model=null;
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
			{
				if(dataReader.Read())
				{
					model=ReaderBind(dataReader);
				}
			}
			return model;
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ECommerce.Admin.Model.DeviceList DataRowToModel(DataRow row)
		{
			ECommerce.Admin.Model.DeviceList model=new ECommerce.Admin.Model.DeviceList();
			if (row != null)
			{
				if(row["DID"]!=null && row["DID"].ToString()!="")
				{
					model.DID=Convert.ToInt32(row["DID"].ToString());
				}
				if(row["PKey"]!=null)
				{
					model.PKey=row["PKey"].ToString();
				}
				if(row["DeviceName"]!=null)
				{
					model.DeviceName=row["DeviceName"].ToString();
				}
				if(row["Loanable"]!=null && row["Loanable"].ToString()!="")
				{
					model.Loanable=Convert.ToInt32(row["Loanable"].ToString());
				}
				if(row["PurchaseDep"]!=null)
				{
					model.PurchaseDep=row["PurchaseDep"].ToString();
				}
				if(row["Purchaser"]!=null)
				{
					model.Purchaser=row["Purchaser"].ToString();
				}
				if(row["LoanStatus"]!=null)
				{
					model.LoanStatus=row["LoanStatus"].ToString();
				}
				if(row["LoanerID"]!=null && row["LoanerID"].ToString()!="")
				{
					model.LoanerID=Convert.ToInt32(row["LoanerID"].ToString());
				}
				if(row["Loaner"]!=null)
				{
					model.Loaner=row["Loaner"].ToString();
				}
				if(row["LoanDate"]!=null && row["LoanDate"].ToString()!="")
				{
					model.LoanDate=Convert.ToDateTime(row["LoanDate"].ToString());
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=Convert.ToInt32(row["Status"].ToString());
				}
				if(row["DeviceDispose"]!=null)
				{
					model.DeviceDispose=row["DeviceDispose"].ToString();
				}
				if(row["Descri"]!=null)
				{
					model.Descri=row["Descri"].ToString();
				}
				if(row["UID"]!=null && row["UID"].ToString()!="")
				{
					model.UID=Convert.ToInt32(row["UID"].ToString());
				}
				if(row["EnteringDate"]!=null && row["EnteringDate"].ToString()!="")
				{
					model.EnteringDate=Convert.ToDateTime(row["EnteringDate"].ToString());
				}
				if(row["CreateDate"]!=null && row["CreateDate"].ToString()!="")
				{
					model.CreateDate=Convert.ToDateTime(row["CreateDate"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// <param name="strWhere">查询条件 Status=@Status and Cell=@Cell order by CreateDate Desc  like写法:'%'+@Cell+'%' </param>
		/// <param name="parameters">List<SqlParameter> parameters</param>
		/// </summary>
		public DataSet GetList(string strWhere, List<SqlParameter> parameters)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select DID,PKey,DeviceName,Loanable,PurchaseDep,Purchaser,LoanStatus,LoanerID,Loaner,LoanDate,Status,DeviceDispose,Descri,UID,EnteringDate,CreateDate ");
			strSql.Append(" FROM DeviceList ");
			Database db = DatabaseFactory.CreateDatabase();
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			if(parameters.Count > 0)
			{
				foreach (SqlParameter sqlParameter in parameters)
				{
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
		public DataSet GetList(int Top,string strWhere, List<SqlParameter> parameters)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" DID,PKey,DeviceName,Loanable,PurchaseDep,Purchaser,LoanStatus,LoanerID,Loaner,LoanDate,Status,DeviceDispose,Descri,UID,EnteringDate,CreateDate ");
			strSql.Append(" FROM DeviceList ");
			Database db = DatabaseFactory.CreateDatabase();
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			if(parameters.Count > 0)
			{
				foreach (SqlParameter sqlParameter in parameters)
				{
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
			strSql.Append("select count(1) FROM DeviceList ");
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
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex, List<SqlParameter> parameters)
		{
			Database db = DatabaseFactory.CreateDatabase();
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.DID desc");
			}
			strSql.Append(")AS Row, T.*  from DeviceList T ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			if(parameters.Count > 0)
			{
				foreach (SqlParameter sqlParameter in parameters)
				{
					dbCommand.Parameters.Add(sqlParameter);
				}
			}
			return db.ExecuteDataSet(dbCommand);
		}

		
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_GetRecordByPage");
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "DeviceList");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "DID");
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
		public List<ECommerce.Admin.Model.DeviceList> GetListArray(string strWhere, List<SqlParameter> parameters)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select DID,PKey,DeviceName,Loanable,PurchaseDep,Purchaser,LoanStatus,LoanerID,Loaner,LoanDate,Status,DeviceDispose,Descri,UID,EnteringDate,CreateDate ");
			strSql.Append(" FROM DeviceList ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			if(parameters.Count > 0)
			{
				foreach (SqlParameter sqlParameter in parameters)
				{
					dbCommand.Parameters.Add(sqlParameter);
				}
			}
			List<ECommerce.Admin.Model.DeviceList> list = new List<ECommerce.Admin.Model.DeviceList>();
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public ECommerce.Admin.Model.DeviceList ReaderBind(IDataReader dataReader)
		{
			ECommerce.Admin.Model.DeviceList model=new ECommerce.Admin.Model.DeviceList();
			object ojb; 
			ojb = dataReader["DID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.DID=Convert.ToInt32(ojb);
			}
			model.PKey=dataReader["PKey"].ToString();
			model.DeviceName=dataReader["DeviceName"].ToString();
			ojb = dataReader["Loanable"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Loanable=Convert.ToInt32(ojb);
			}
			model.PurchaseDep=dataReader["PurchaseDep"].ToString();
			model.Purchaser=dataReader["Purchaser"].ToString();
			model.LoanStatus=dataReader["LoanStatus"].ToString();
			ojb = dataReader["LoanerID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.LoanerID=Convert.ToInt32(ojb);
			}
			model.Loaner=dataReader["Loaner"].ToString();
			ojb = dataReader["LoanDate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.LoanDate=Convert.ToDateTime(ojb);
			}
			ojb = dataReader["Status"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Status=Convert.ToInt32(ojb);
			}
			model.DeviceDispose=dataReader["DeviceDispose"].ToString();
			model.Descri=dataReader["Descri"].ToString();
			ojb = dataReader["UID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UID=Convert.ToInt32(ojb);
			}
			ojb = dataReader["EnteringDate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.EnteringDate=Convert.ToDateTime(ojb);
			}
			ojb = dataReader["CreateDate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CreateDate=Convert.ToDateTime(ojb);
			}
			return model;
		}

		#endregion  Method

        #region

        public Model.DeviceList GetModel(string strWhere, List<SqlParameter> parameters) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from DeviceList ");
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
            Model.DeviceList model = null;
            using (IDataReader dataReader = db.ExecuteReader(dbCommand)) {
                if (dataReader.Read()) {
                    model = ReaderBind(dataReader);
                }
            }
            return model;
        }

        #endregion
	}
}

