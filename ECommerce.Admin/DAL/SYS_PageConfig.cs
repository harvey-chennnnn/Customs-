
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
	/// 数据访问类:SYS_PageConfig
	/// </summary>
	public partial class SYS_PageConfig
	{
		public SYS_PageConfig()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(PC_Id)+1 from SYS_PageConfig";
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
		public bool Exists(int PC_Id)
		{
			Database db = DatabaseFactory.CreateDatabase();
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from SYS_PageConfig where PC_Id=@PC_Id ");
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "PC_Id", DbType.Int32,PC_Id);
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
		public int Add(ECommerce.Admin.Model.SYS_PageConfig model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SYS_PageConfig(");
			strSql.Append("PC_Name,PC_Memo,PC_HrefUrl,PC_HaveChild,PC_ParentId,PC_State,PC_Icon)");

			strSql.Append(" values (");
			strSql.Append("@PC_Name,@PC_Memo,@PC_HrefUrl,@PC_HaveChild,@PC_ParentId,@PC_State,@PC_Icon)");
			strSql.Append(";select @@IDENTITY");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "PC_Name", DbType.AnsiString, model.PC_Name);
			db.AddInParameter(dbCommand, "PC_Memo", DbType.AnsiString, model.PC_Memo);
			db.AddInParameter(dbCommand, "PC_HrefUrl", DbType.AnsiString, model.PC_HrefUrl);
			db.AddInParameter(dbCommand, "PC_HaveChild", DbType.Int32, model.PC_HaveChild);
			db.AddInParameter(dbCommand, "PC_ParentId", DbType.Int32, model.PC_ParentId);
			db.AddInParameter(dbCommand, "PC_State", DbType.Int32, model.PC_State);
			db.AddInParameter(dbCommand, "PC_Icon", DbType.String, model.PC_Icon);
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
		public bool Update(ECommerce.Admin.Model.SYS_PageConfig model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SYS_PageConfig set ");
			strSql.Append("PC_Name=@PC_Name,");
			strSql.Append("PC_Memo=@PC_Memo,");
			strSql.Append("PC_HrefUrl=@PC_HrefUrl,");
			strSql.Append("PC_HaveChild=@PC_HaveChild,");
			strSql.Append("PC_ParentId=@PC_ParentId,");
			strSql.Append("PC_State=@PC_State,");
			strSql.Append("PC_Icon=@PC_Icon");
			strSql.Append(" where PC_Id=@PC_Id ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "PC_Id", DbType.Int32, model.PC_Id);
			db.AddInParameter(dbCommand, "PC_Name", DbType.AnsiString, model.PC_Name);
			db.AddInParameter(dbCommand, "PC_Memo", DbType.AnsiString, model.PC_Memo);
			db.AddInParameter(dbCommand, "PC_HrefUrl", DbType.AnsiString, model.PC_HrefUrl);
			db.AddInParameter(dbCommand, "PC_HaveChild", DbType.Int32, model.PC_HaveChild);
			db.AddInParameter(dbCommand, "PC_ParentId", DbType.Int32, model.PC_ParentId);
			db.AddInParameter(dbCommand, "PC_State", DbType.Int32, model.PC_State);
			db.AddInParameter(dbCommand, "PC_Icon", DbType.String, model.PC_Icon);
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
		public bool Delete(int PC_Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SYS_PageConfig ");
			strSql.Append(" where PC_Id=@PC_Id ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "PC_Id", DbType.Int32,PC_Id);
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
		public bool DeleteList(string PC_Idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SYS_PageConfig ");
			strSql.Append(" where PC_Id in ("+PC_Idlist + ")  ");
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
		public ECommerce.Admin.Model.SYS_PageConfig GetModel(int PC_Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select PC_Id,PC_Name,PC_Memo,PC_HrefUrl,PC_HaveChild,PC_ParentId,PC_State,PC_Icon from SYS_PageConfig ");
			strSql.Append(" where PC_Id=@PC_Id ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "PC_Id", DbType.Int32,PC_Id);
			ECommerce.Admin.Model.SYS_PageConfig model=null;
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
		public ECommerce.Admin.Model.SYS_PageConfig DataRowToModel(DataRow row)
		{
			ECommerce.Admin.Model.SYS_PageConfig model=new ECommerce.Admin.Model.SYS_PageConfig();
			if (row != null)
			{
				if(row["PC_Id"]!=null && row["PC_Id"].ToString()!="")
				{
					model.PC_Id=Convert.ToInt32(row["PC_Id"].ToString());
				}
				if(row["PC_Name"]!=null)
				{
					model.PC_Name=row["PC_Name"].ToString();
				}
				if(row["PC_Memo"]!=null)
				{
					model.PC_Memo=row["PC_Memo"].ToString();
				}
				if(row["PC_HrefUrl"]!=null)
				{
					model.PC_HrefUrl=row["PC_HrefUrl"].ToString();
				}
				if(row["PC_HaveChild"]!=null && row["PC_HaveChild"].ToString()!="")
				{
					model.PC_HaveChild=Convert.ToInt32(row["PC_HaveChild"].ToString());
				}
				if(row["PC_ParentId"]!=null && row["PC_ParentId"].ToString()!="")
				{
					model.PC_ParentId=Convert.ToInt32(row["PC_ParentId"].ToString());
				}
				if(row["PC_State"]!=null && row["PC_State"].ToString()!="")
				{
					model.PC_State=Convert.ToInt32(row["PC_State"].ToString());
				}
				if(row["PC_Icon"]!=null)
				{
					model.PC_Icon=row["PC_Icon"].ToString();
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
			strSql.Append("select PC_Id,PC_Name,PC_Memo,PC_HrefUrl,PC_HaveChild,PC_ParentId,PC_State,PC_Icon ");
			strSql.Append(" FROM SYS_PageConfig ");
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
			strSql.Append(" PC_Id,PC_Name,PC_Memo,PC_HrefUrl,PC_HaveChild,PC_ParentId,PC_State,PC_Icon ");
			strSql.Append(" FROM SYS_PageConfig ");
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
			strSql.Append("select count(1) FROM SYS_PageConfig ");
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
				strSql.Append("order by T.PC_Id desc");
			}
			strSql.Append(")AS Row, T.*  from SYS_PageConfig T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "SYS_PageConfig");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "PC_Id");
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
		public List<ECommerce.Admin.Model.SYS_PageConfig> GetListArray(string strWhere, List<SqlParameter> parameters)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select PC_Id,PC_Name,PC_Memo,PC_HrefUrl,PC_HaveChild,PC_ParentId,PC_State,PC_Icon ");
			strSql.Append(" FROM SYS_PageConfig ");
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
			List<ECommerce.Admin.Model.SYS_PageConfig> list = new List<ECommerce.Admin.Model.SYS_PageConfig>();
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
		public ECommerce.Admin.Model.SYS_PageConfig ReaderBind(IDataReader dataReader)
		{
			ECommerce.Admin.Model.SYS_PageConfig model=new ECommerce.Admin.Model.SYS_PageConfig();
			object ojb; 
			ojb = dataReader["PC_Id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.PC_Id=Convert.ToInt32(ojb);
			}
			model.PC_Name=dataReader["PC_Name"].ToString();
			model.PC_Memo=dataReader["PC_Memo"].ToString();
			model.PC_HrefUrl=dataReader["PC_HrefUrl"].ToString();
			ojb = dataReader["PC_HaveChild"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.PC_HaveChild=Convert.ToInt32(ojb);
			}
			ojb = dataReader["PC_ParentId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.PC_ParentId=Convert.ToInt32(ojb);
			}
			ojb = dataReader["PC_State"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.PC_State=Convert.ToInt32(ojb);
			}
			model.PC_Icon=dataReader["PC_Icon"].ToString();
			return model;
		}

		#endregion  Method
	}
}

