using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using SHDocVw;
using Microsoft.Win32;
using DotWeb.Agent.Ie;

namespace DotWeb.Hosting.Agent.Ie
{
	[ComVisible(true)]
	[Guid("378F722A-A64C-4e90-9F9B-F57832FF9713")]
	[ClassInterface(ClassInterfaceType.None)]
	public class BrowserHelperObject : IObjectWithSite
	{
		public static string BHO_KEYNAME = "Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Browser Helper Objects";

		//private JsAgent agent;
		private WebBrowser browser;

		#region IObjectWithSite Members

		public int SetSite(object site) {
			if (site != null) {
				this.browser = (WebBrowser)site;
				//this.agent = new JsAgent(this.browser);
			}
			else {
				//this.agent.Detach();
				this.browser = null;
			}
			return 0;
		}

		public int GetSite(ref Guid guid, out IntPtr ppvSite) {
			IntPtr punk = Marshal.GetIUnknownForObject(this.browser);
			int hr = Marshal.QueryInterface(punk, ref guid, out ppvSite);
			Marshal.Release(punk);
			return hr;
		}

		#endregion

		#region COM Registration

		[ComRegisterFunction]
		public static void RegisterBHO(Type type) {
			RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(BHO_KEYNAME, true);
			if (registryKey == null)
				registryKey = Registry.LocalMachine.CreateSubKey(BHO_KEYNAME);

			string guid = type.GUID.ToString("B");
			RegistryKey ourKey = registryKey.OpenSubKey(guid);

			if (ourKey == null)
				ourKey = registryKey.CreateSubKey(guid);

			ourKey.SetValue("NoExplorer", 1);
			ourKey.SetValue("", "DotWeb.Agent");

			registryKey.Close();
			ourKey.Close();
		}

		[ComUnregisterFunction]
		public static void UnregisterBHO(Type type) {
			RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(BHO_KEYNAME, true);
			string guid = type.GUID.ToString("B");

			if (registryKey != null)
				registryKey.DeleteSubKey(guid, false);
		}

		#endregion
	}
}
