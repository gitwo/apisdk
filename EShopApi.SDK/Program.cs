using EShopApi.SDK.Model;
using EShopApi.SDK.Model.Res;
using System;
using System.Collections.Generic;

namespace EShopApi.SDK
{
	class Program
	{
		static void Main(string[] args)
		{
			//测试SDK
			ApiHttpClient client = new ApiHttpClient("baidu", "asdfadsfidJlasdjfljoiIJOLjlasdf", "https://baidu.com/");
			ApiResult<List<BillResModel>> res = client.GetBillService(new EShopApi.SDK.Model.Req.BillReqModel() { Member = "abc", Type = "", StartDate = DateTime.Now.AddHours(-1), EndDate = DateTime.Now }).Result;
			if (res.IsSuccess)
			{
				foreach (BillResModel item in res.Data)
				{
					//对返回对数据进行处理
				};
			}
			Console.ReadLine();
		}


	}
}
