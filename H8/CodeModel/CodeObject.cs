using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H8.CodeModel
{
	public interface ICodeVisitor<Code, Return>
	{
		Return VisitReturn(Code obj);
	}

	public interface ICodeVisitor<Code>
	{
		void Visit(Code obj);
	}

	public abstract class CodeObject
	{
		public ILInstruction Instruction { get; set; }

		public abstract void Accept<Visitor>(Visitor visitor);
		public abstract Return Accept<Visitor, Return>(Visitor visitor);
	}

	//public class CodeObject<Code> : CodeObject where Code : CodeObject<Code>
	//{
	//    public override void Accept<Visitor>(Visitor visitor) {
	//        ICodeVisitor<Code> specialized = (ICodeVisitor<Code>)visitor;
	//        specialized.Visit((Code)this);
	//    }

	//    public override Return Accept<Visitor, Return>(Visitor visitor) {
	//        ICodeVisitor<Code, Return> specialized = (ICodeVisitor<Code, Return>)visitor;
	//        return specialized.VisitReturn((Code)this);
	//    }
	//}
}
