using EShopApi.SDK.Model;
using EShopApi.SDK.Model.Req;
using EShopApi.SDK.Model.Res;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EShopApi.SDK
{
	/// <summary>
	/// 定义Http请求，Hwak header头
	/// </summary>
	public class ApiHttpClient
	{
		/// <summary>
		/// 使用api的Key identifier
		/// </summary>
		private string appId;
		/// <summary>
		/// 使用api的应用key
		/// </summary>
		private string appKey;
		/// <summary>
		/// api的应用主机
		/// </summary>
		private string[] apiHost;
		public ApiHttpClient(string appId, string appKey, params string[] apiHost)
		{
			this.appId = appId;
			this.appKey = appKey;
			this.apiHost = apiHost;
		}

		/// <summary>
		///  header签名
		/// </summary>
		/// <param name="request"></param>
		/// <param name="ext"></param>
		/// <param name="payloadHash"></param>
		private void SignRequest(HttpRequestMessage request, string ext = null, string payloadHash = null)
		{
			Uri uri = request.RequestUri;
			string host = request.Headers.Host != null ? request.Headers.Host : uri.Host;
			string sanitizedHost = (host.IndexOf(':') > 0) ? host.Substring(0, host.IndexOf(':')) : host;
			var nonce = Guid.NewGuid().ToString("N").Substring(0, 6);
			long ticks = (long)(DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds;
			//hawk.1.header  时间 随机字符 请求方法 路径 主机  端口
			string normalized = "hawk.1.header\n" +
				ticks + "\n" +
				nonce + "\n" +
				request.Method.Method.ToUpper() + "\n" +
				uri.PathAndQuery + "\n" +
				uri.Port + "\n" +
				((!string.IsNullOrEmpty(payloadHash)) ? payloadHash : "") + "\n" +
				((!string.IsNullOrEmpty(ext)) ? ext : "") + "\n";
			string hmacString = Util.Encryptions.HmacSha256(normalized, appKey);
			string authorization = string.Format("id=\"{0}\",ts=\"{1}\",nonce=\"{2}\",mac=\"{3}\",", appId, ticks, nonce, hmacString);
			request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Hawk", authorization);
		}

		/// <summary>
		/// 发送api请求
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="url"></param>
		/// <param name="method"></param>
		/// <param name="data"></param>
		/// <returns></returns>
		private async Task<T> SendRequest<T>(string url, HttpMethod method, object data = null)
		{
			//HttpClient使用消息处理器来处理请求，默认的消息处理器是HttpClientHandler，可以定制客户端消息处理器
			var handler = new HttpClientHandler() { AutomaticDecompression = System.Net.DecompressionMethods.GZip };
			//一般情况一个应用程序只使用一个HttpClient,避免反复httpclient创建销毁，tcp连接及tls耗时。创建过多会引起socket消耗
			using (HttpClient client = new HttpClient(handler))
			{
				HttpRequestMessage requestMessage = new HttpRequestMessage(method, url);
				requestMessage.Headers.Add("Accept", "text/json");
				SignRequest(requestMessage);
				if (data != null)
				{
					requestMessage.Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
				}

				HttpResponseMessage response = await client.SendAsync(requestMessage);
				if (response.StatusCode == System.Net.HttpStatusCode.OK)
				{
					string result = await response.Content.ReadAsStringAsync();
					if (!string.IsNullOrEmpty(result))
					{
						return JsonConvert.DeserializeObject<T>(result);
					}
				}
				else
				{
					throw new Exception(response.ReasonPhrase);
				}
				return default(T);
			}
		}

		private string GenerateUrl(string path)
		{
			long ticks = DateTime.Now.Ticks;
			Random random = new Random((int)(ticks & 0xffffffffL) | (int)(ticks >> 32));
			string baseUrl = apiHost[random.Next(0, apiHost.Length)].TrimEnd('/');
			return baseUrl + "/" + path;
		}

		/// <summary>
		/// 测试请求api用
		/// </summary>
		/// <returns></returns>
		public async Task<ApiResult<List<BillResModel>>> GetBillService(BillReqModel model)
		{
			string url = GenerateUrl(ApiUrl.APIURL);
			return await SendRequest<ApiResult<List<BillResModel>>>(url, HttpMethod.Post,model);
		}
	}
}
