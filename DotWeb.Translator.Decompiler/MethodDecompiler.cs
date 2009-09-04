using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotWeb.Translator.CodeModel;
using System.Reflection;

namespace DotWeb.Translator
{
	public static class MethodDecompiler
	{
		public static CodeMethodMember Parse(MethodBase method) {
			Console.WriteLine(method);

			ControlFlowGraph cfg = new ControlFlowGraph(method);
			Console.WriteLine(cfg);

			ControlFlowAnalyzer cfa = new ControlFlowAnalyzer(cfg);
			cfa.Structure();

			BackEnd be = new BackEnd(cfg);
			be.WriteCode();

			AssociatedProperty ap = method.GetAssociatedProperty();
			if (ap != null) {
				if (ap.IsGetter) {
					return new CodePropertyGetterMember(be.Method) {
						PropertyInfo = ap.Info
					};
				}
				else {
					return new CodePropertySetterMember(be.Method) {
						PropertyInfo = ap.Info
					};
				}
			}
			else {
				return be.Method;
			}
		}
	}
}
