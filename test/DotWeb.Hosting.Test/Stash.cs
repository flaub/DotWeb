using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using DotWeb.System.DotWeb;

namespace DotWeb.Hosting.Test
{
	class Stash
	{
		public Stash() {
			HostedMode.Host.Invoke(this, MethodBase.GetCurrentMethod(), new object[0]);
		}

		[JsCode("console.log(obj);")]
		public static void Write(object obj) {
			MethodBase currentMethod = MethodBase.GetCurrentMethod();
			object[] args = new object[] { obj };
			HostedMode.Host.Invoke(null, currentMethod, args);
		}

	}
	//class HostingBootstrapper
	//{
	//    private AppDomain hostedDomain;
	//    private HostingShell shell;

	//    public HostingBootstrapper() {
	//        var thisDomain = AppDomain.CurrentDomain;
	//        var thisSetup = thisDomain.SetupInformation;
	//        var appBase = thisSetup.ApplicationBase;
	//        var hostedPath = Path.Combine(appBase, "Hosted");
	//        var setup = new AppDomainSetup {
	//            ApplicationName = thisSetup.ApplicationName,
	//            ApplicationBase = hostedPath,
	//            LoaderOptimization = LoaderOptimization.MultiDomainHost,
	//        };

	//        this.hostedDomain = AppDomain.CreateDomain("DotWeb Hosted-Mode", null, setup);
	//        this.shell = CreateRemoteType<HostingShell>();
	//        this.shell.Init(appBase);
	//    }

	//    public void Run(object target, MethodInfo method) {
	//        this.shell.Run(target, method.Name);
	//    }

	//    public T CreateRemoteType<T>() {
	//        var type = typeof(T);
	//        return (T)hostedDomain.CreateInstanceAndUnwrap(type.Assembly.FullName, type.FullName);
	//    }
	//}

	//public class HostingShell : MarshalByRefObject
	//{
	//    private string appBase;

	//    public HostingShell() {
	//        var thisDomain = AppDomain.CurrentDomain;
	//        thisDomain.AssemblyResolve += new ResolveEventHandler(thisDomain_AssemblyResolve);
	//    }

	//    public void Init(string appBase) {
	//        this.appBase = appBase;
	//    }

	//    Assembly thisDomain_AssemblyResolve(object sender, ResolveEventArgs args) {
	//        var asmName = new AssemblyName(args.Name);
	//        var asmFile = Path.Combine(this.appBase, asmName.Name + ".dll");
	//        return Assembly.LoadFrom(asmFile);
	//    }

	//    public void Run(object target, string methodName) {
	//        var type = target.GetType();
	//        var method = type.GetMethod(methodName);
	//        method.Invoke(target, null);
	//    }
	//}

	//[TestFixture]
	//public class JsFuntionTest
	//{
	//    private HostingBootstrapper bootstrapper = new HostingBootstrapper();
	//    private JsFunctionTestShell shell;

	//    public JsFuntionTest() {
	//        this.shell = this.bootstrapper.CreateRemoteType<JsFunctionTestShell>();
	//    }

	//    [Test]
	//    public void TestConstructor() {
	//        this.shell.TestConstructor();
	//    }

	//    [Test]
	//    public void TestJsCode() {
	//        this.shell.TestJsCode();
	//    }

	//    [Test]
	//    public void TestJsNamespace() {
	//        this.shell.TestJsNamespace();
	//    }

	//    [Test]
	//    public void TestMethod() {
	//        this.shell.TestMethod();
	//    }

	//    [Test]
	//    public void TestParameters() {
	//        this.shell.TestParameters();
	//    }

	//    [Test]
	//    public void TestPropertyGetter() {
	//        this.shell.TestPropertyGetter();
	//    }

	//    [Test]
	//    public void TestPropertySetter() {
	//        this.shell.TestPropertySetter();
	//    }

	//    [Test]
	//    public void TestStaticMethod() {
	//        this.shell.TestStaticMethod();
	//    }
	//}
}
