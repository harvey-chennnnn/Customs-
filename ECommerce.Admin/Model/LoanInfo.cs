
using System;
namespace ECommerce.Admin.Model
{
	/// <summary>
	/// LoanInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class LoanInfo
	{
		public LoanInfo()
		{}
		#region Model
		private int _lid;
		private int? _did;
		private int? _loid;
		private string _loaner;
		private DateTime? _loandate;
		private int? _uid;
		private string _opname;
		private string _loandescri;
		private string _returndescri;
		private DateTime? _returndate;
		private int? _status=0;
		private DateTime? _createdate= DateTime.Now;
		/// <summary>
		/// 
		/// </summary>
		public int LID
		{
			set{ _lid=value;}
			get{return _lid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? DID
		{
			set{ _did=value;}
			get{return _did;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? LoID
		{
			set{ _loid=value;}
			get{return _loid;}
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
		public int? UId
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OpName
		{
			set{ _opname=value;}
			get{return _opname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LoanDescri
		{
			set{ _loandescri=value;}
			get{return _loandescri;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ReturnDescri
		{
			set{ _returndescri=value;}
			get{return _returndescri;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ReturnDate
		{
			set{ _returndate=value;}
			get{return _returndate;}
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
		public DateTime? CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		#endregion Model

	}
}

