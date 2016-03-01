
using System;
namespace ECommerce.Admin.Model
{
	/// <summary>
	/// DeviceList:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DeviceList
	{
		public DeviceList()
		{}
		#region Model
		private int _did;
		private string _pkey;
		private string _devicename;
		private int? _loanable=1;
		private string _purchasedep;
		private string _purchaser;
		private int? _loanstatus=0;
		private int? _loanerid;
		private string _loaner;
		private DateTime? _loandate;
		private int? _status;
		private string _devicedispose;
		private string _descri;
		private int? _uid;
		private DateTime? _enteringdate;
		private DateTime? _createdate= DateTime.Now;
		private int? _entid;
		private int? _reid;
		/// <summary>
		/// 
		/// </summary>
		public int DID
		{
			set{ _did=value;}
			get{return _did;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PKey
		{
			set{ _pkey=value;}
			get{return _pkey;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DeviceName
		{
			set{ _devicename=value;}
			get{return _devicename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Loanable
		{
			set{ _loanable=value;}
			get{return _loanable;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PurchaseDep
		{
			set{ _purchasedep=value;}
			get{return _purchasedep;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Purchaser
		{
			set{ _purchaser=value;}
			get{return _purchaser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? LoanStatus
		{
			set{ _loanstatus=value;}
			get{return _loanstatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? LoanerID
		{
			set{ _loanerid=value;}
			get{return _loanerid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Loaner
		{
			set{ _loaner=value;}
			get{return _loaner;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? LoanDate
		{
			set{ _loandate=value;}
			get{return _loandate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DeviceDispose
		{
			set{ _devicedispose=value;}
			get{return _devicedispose;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Descri
		{
			set{ _descri=value;}
			get{return _descri;}
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
		public DateTime? EnteringDate
		{
			set{ _enteringdate=value;}
			get{return _enteringdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
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
		public int? ReID
		{
			set{ _reid=value;}
			get{return _reid;}
		}
		#endregion Model

	}
}

