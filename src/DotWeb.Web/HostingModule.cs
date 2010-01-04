using System;
using System.Web;
using DotWeb.Runtime;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;

// Add the following as a COM reference - C:\WINDOWS\Microsoft.NET\Framework\vXXXXXX\mscoree.tlb
//using mscoree;
//using System.Runtime.InteropServices;

namespace DotWeb.Web
{
	public class HostingModule : IHttpModule
	{
		private static object syncRoot = new object();
		private static HostedMode host = null;

		public HostedMode HostedMode {
			get {
				// don't think we need to grab a lock because this getter
				// will be called much later in the lifetime of the webapp
				return host;
			}
		}

		#region IHttpModule Members

		public void Dispose() {
		}

		public void Init(HttpApplication context) {
			//var domain = AppDomain.CreateDomain("DotWeb Development Domain");
			//domain.DoCallBack(InitDomain);
		}

		#endregion

		private void InitDomain() {
			lock (syncRoot) {
				if (host == null) {
					var thread = new Thread(Run);
					thread.Start();
				}
			}
		}

		private void Run() {
			host = new HostedMode();
			host.Start();
		}

		//private static IList<AppDomain> GetAppDomains() {
		//    IList<AppDomain> _IList = new List<AppDomain>();
		//    IntPtr enumHandle = IntPtr.Zero;
		//    CorRuntimeHostClass host = new mscoree.CorRuntimeHostClass();
		//    try {
		//        host.EnumDomains(out enumHandle);
		//        object domain = null;
		//        while (true) {
		//            host.NextDomain(enumHandle, out domain);
		//            if (domain == null) break;
		//            AppDomain appDomain = (AppDomain)domain;
		//            _IList.Add(appDomain);
		//        }
		//        return _IList;
		//    }
		//    catch (Exception e) {
		//        Console.WriteLine(e.ToString());
		//        return null;
		//    }
		//    finally {
		//        host.CloseEnum(enumHandle);
		//        Marshal.ReleaseComObject(host);
		//    }
		//}
	}
}