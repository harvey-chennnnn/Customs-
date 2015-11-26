
using System;
namespace ECommerce.Admin.Model
{
	/// <summary>
	/// AUserInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class AUserInfo
	{
		public AUserInfo()
		{}
		#region Model
		private int _id;
		private string _name;
		private string _username;
		private int? _auid;
		private int? _entid;
		private int? _uid;
		private DateTime? _createdate= DateTime.Now;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? AUID
		{
			set{ _auid=value;}
			get{return _auid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? EntID
		{
			set{ _entid=value;}
			get{return _entid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? UID
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		#endregion Model

	}
}

