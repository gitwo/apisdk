using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopApi.SDK.Model.Enum
{
	/// <summary>
	/// Api返回code编码
	/// </summary>
	public enum ApiResultCode
	{
		/// <summary>
		/// 请求成功
		/// </summary>
		[Description("Success")]
		Success=0,
		/// <summary>
		/// 错误的请求
		/// </summary>
		[Description("BadRequest")]
		BadRequest =400,
		/// <summary>
		/// 授权验证失败
		/// </summary>
		[Description("Unauthorized")]
		Unauthorized =401,
		/// <summary>
		/// 无法找到请求的资源
		/// </summary>
		[Description("Not Found")]
		NotFound =404,
		/// <summary>
		/// 请求超时
		/// </summary>
		[Description("请求超时")]
		RequestTimeout = 408,
		/// <summary>
		/// 请求太频繁
		/// </summary>
		[Description("频繁请求")]
		TooManyRequests = 429,
		/// <summary>
		/// 服务器错误
		/// </summary>
		[Description("服务器错误")]
		InternalServerError = 500,
		/// <summary>
		/// 不支持请求类型
		/// </summary>
		[Description("不支持请求类型")]
		NotImplemented = 501,
		/// <summary>
		/// 用户不存在
		/// </summary>
		[Description("用户不存在")]
		UserNotExist = 999,
		

	}
}
