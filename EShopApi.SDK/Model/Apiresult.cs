using EShopApi.SDK.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopApi.SDK.Model
{
	/// <summary>
	/// 返回结果
	/// </summary>
	public class ApiResult
	{
		/// <summary>
		/// Api返回状态码
		/// </summary>
		public int Code { get; set; }

		/// <summary>
		/// Api返回信息
		/// </summary>
		public string Message { get; set; }

		public bool IsSuccess
		{
			get
			{
				return Code == (int)ApiResultCode.Success;
			}
		}
	}

	public class ApiResult<T> : ApiResult
	{
		/// <summary>
		/// 封装传输的数据
		/// </summary>
		public T Data { get; set; }
	}
}
