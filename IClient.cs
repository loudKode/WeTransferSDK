using System;
using System.Threading;
using System.Threading.Tasks;
using WeTransferSDK.JSON;

namespace WeTransferSDK
{
	public interface IClient
	{
		Task<JSON_GetToken> GetToken(string UserRandomID = null);

		Task<JSON_Finalize> Upload(object FileToUpload, OClient.UploadTypes UploadType, string FileName, string UToken, IProgress<ReportStatus> ReportCls = null, ProxyConfig _proxi = null, CancellationToken token = default(CancellationToken));
	}
}
