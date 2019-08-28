using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EShopApi.SDK.Model.Req
{
	/// <summary>
	/// 用户账单请求数据
	/// </summary>
	[DataContract]
	public class BillReqModel
	{
		/// <summary>
		/// 用户账号 
		/// </summary>
		[DataMember(Name ="member")]
		public string Member { get; set; }
		/// <summary>
		/// 用户类型 （普通 金 钻石 
		/// </summary>
		[DataMember(Name = "type")]
		public string Type { get; set; }

		/// <summary>
		/// 开始时间 
		/// </summary>
		[DataMember(Name = "startdate")]
		public DateTime StartDate { get; set; }

		/// <summary>
		/// 截至时间 
		/// </summary>
		[DataMember(Name = "enddate")]
		public DateTime EndDate { get; set; }


	}
}
