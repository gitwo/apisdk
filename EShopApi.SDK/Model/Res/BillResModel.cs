using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EShopApi.SDK.Model.Res
{
	/// <summary>
	/// 会员账单数据
	/// </summary>
	[DataContract]
	public class BillResModel
	{
		/// <summary>
		/// 序号
		/// </summary>
		[DataMember(Name ="id")]
		public decimal Id { get; set; }

		/// <summary>
		/// 账单时间
		/// </summary>
		[DataMember(Name = "billtime")]
		public DateTime BillTime { get; set; }

		/// <summary>
		/// 金额
		/// </summary>
		[DataMember(Name = "money")]
		public decimal Money { get; set; }

		/// <summary>
		/// 商品编号
		/// </summary>
		[DataMember(Name = "goodsno")]
		public decimal GoodsNo { get; set; }

		/// <summary>
		/// 归属类别
		/// </summary>
		[DataMember(Name = "goodstype")]
		public string GoodsType { get; set; }

		/// <summary>
		/// 商品数量
		/// </summary>
		[DataMember(Name = "goodsaccount")]
		public int GoodsAccount { get; set; }

		/// <summary>
		/// 商品名称
		/// </summary>
		[DataMember(Name = "goodsname")]
		public decimal GoodsName { get; set; }

	}
}
