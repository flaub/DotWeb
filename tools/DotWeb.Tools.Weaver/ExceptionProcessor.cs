// Copyright 2009, Frank Laub
// 
// This file is part of DotWeb.
// 
// DotWeb is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// DotWeb is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with DotWeb.  If not, see <http://www.gnu.org/licenses/>.
// 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Cecil.Cil;
using System.Reflection.Emit;
using System.Collections;

namespace DotWeb.Tools.Weaver
{
	class ExceptionProcessor
	{
		private MethodProcessor parent;
		private ILGenerator generator;

		private ExceptionHandler curHandler = null;

		private IEnumerator itTry;
		private ExceptionHandler nextTry = null;

		private IEnumerator itCatch;
		private ExceptionHandler nextCatch = null;

		private IEnumerator itFilter;
		private ExceptionHandler nextFilter = null;

		private IEnumerator itFinally;
		private ExceptionHandler nextFinally = null;

		public ExceptionProcessor(MethodProcessor parent, ILGenerator generator) {
			this.parent = parent;
			this.generator = generator;
		}

		public void Start(ExceptionHandlerCollection handlers) {
			this.itTry = handlers.GetEnumerator();
			this.nextTry = Next(itTry);

			this.itCatch = handlers.GetEnumerator();
			this.nextCatch = Next(itCatch);

			this.itFilter = handlers.GetEnumerator();
			this.nextFilter = Next(itFilter);

			this.itFinally = handlers.GetEnumerator();
			this.nextFinally = Next(itFinally);
		}

		private ExceptionHandler Next(IEnumerator it) {
			return it.MoveNext() ? (ExceptionHandler)it.Current : null;
		}

		public void ProcessInstruction(Instruction cil) {
			if (curHandler != null && cil.Offset >= curHandler.HandlerEnd.Offset) {
				generator.EndExceptionBlock();
			}

			if (nextTry != null && cil.Offset >= nextTry.TryStart.Offset) {
				curHandler = nextTry;
				nextTry = Next(this.itTry);

				generator.BeginExceptionBlock(); // try

				//var type = this.parent.hoister.ResolveTypeReference(nextTry.CatchType);
				//generator.BeginCatchBlock(type);

				//generator.BeginFaultBlock(); 
				//generator.BeginFinallyBlock();
			}
		}
	}

}
