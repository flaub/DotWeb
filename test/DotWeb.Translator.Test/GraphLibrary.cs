// Copyright 2010, Frank Laub
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotWeb.Decompiler.Core;

namespace DotWeb.Translator.Test
{
	static class GraphLibrary
	{
		public static ControlFlowGraph Simple() {
			var builder = new SimpleGraphBuilder(2);
			builder.Connect(1, 2);
			return builder.Graph;
		}

		public static ControlFlowGraph SimpleBranch() {
			var builder = new SimpleGraphBuilder(4);
			builder.Connect(1, 2);
			builder.Connect(1, 3);
			builder.Connect(2, 4);
			builder.Connect(3, 4);
			return builder.Graph;
		}

		public static ControlFlowGraph SimpleLoop() {
			// /->1
			// |  |
			// |  v
			// |  2
			// |  |
			// |  v
			// \--3
			var builder = new SimpleGraphBuilder(3);
			builder.Connect(1, 2);
			builder.Connect(2, 3);
			builder.Connect(3, 1);
			return builder.Graph;
		}

		public static ControlFlowGraph SimpleDoWhile() {
			//  1
			//  |
			//  v
			//  2-O
			//  |
			//  v
			//  3
			var builder = new SimpleGraphBuilder(3);
			builder.Connect(1, 2);
			builder.Connect(2, 2);
			builder.Connect(2, 3);
			return builder.Graph;
		}

		public static ControlFlowGraph SimpleWhile() {
			// 1
			// |   
			// |   
			// |  2<-\
			// |  |  |
			// |  v  |
			// \->3--/
			//    |
			//    v
			//    4
			var builder = new SimpleGraphBuilder(4);
			builder.Connect(1, 3);
			builder.Connect(2, 3);
			builder.Connect(3, 4);
			builder.Connect(3, 2);
			return builder.Graph;
		}

		public static ControlFlowGraph WhileBreak() {
			//    1
			//    |
			//    v
			// /->2->4
			// |  |
			// |  v
			// \--3
			var builder = new SimpleGraphBuilder(4);
			builder.Connect(1, 2);
			builder.Connect(2, 3);
			builder.Connect(3, 2);
			builder.Connect(2, 4);
			return builder.Graph;
		}

		public static ControlFlowGraph WhileContinue() {
			//    1
			//    |
			//    v
			// /->2<-\
			// |  |  |
			// |  |  |
			// 3<-*->4
			var builder = new SimpleGraphBuilder(4);
			builder.Connect(1, 2);
			builder.Connect(2, 3);
			builder.Connect(2, 4);
			builder.Connect(3, 2);
			builder.Connect(4, 2);
			return builder.Graph;
		}

		public static ControlFlowGraph WhileCondBreak() {
			// 1
			// |   
			// |   
			// |  /->2--\
			// |  |  |  |
			// |  |  v  v
			// |  |  4  3
			// |  |  |  |
			// |  |  |  |
			// \->5<-/  |
			//    |     |
			//    v     |
			//    6<----/
			var builder = new SimpleGraphBuilder(6);
			builder.Connect(1, 5);
			builder.Connect(2, 3);
			builder.Connect(2, 4);
			builder.Connect(3, 6);
			builder.Connect(4, 5);
			builder.Connect(5, 2);
			builder.Connect(5, 6);
			return builder.Graph;
		}

		public static ControlFlowGraph WhileCondContinue() {
			// 1
			// |   
			// |   
			// |  /->2--\
			// |  |  |  |
			// |  |  v  v
			// |  |  4  3
			// |  |  |  |
			// |  |  |  |
			// \->5<-/<-/
			//    |    
			//    v    
			//    6
			var builder = new SimpleGraphBuilder(6);
			builder.Connect(1, 5);
			builder.Connect(2, 3);
			builder.Connect(2, 4);
			builder.Connect(3, 5);
			builder.Connect(4, 5);
			builder.Connect(5, 2);
			builder.Connect(5, 6);
			return builder.Graph;
		}

		public static ControlFlowGraph WhileBreakContinue() {
			//       1
			//       |
			//       v
			// /---->2<-\
			// |     |  |  
			// |     v  |  
			// 6<-4<-*->3   
			//    |     
			//    v  
			//    5->7
			var builder = new SimpleGraphBuilder(7);
			builder.Connect(1, 2);
			builder.Connect(2, 3);
			builder.Connect(2, 4);
			builder.Connect(3, 2);
			builder.Connect(4, 5);
			builder.Connect(4, 6);
			builder.Connect(5, 7);
			builder.Connect(6, 2);
			return builder.Graph;
		}

		public static ControlFlowGraph WhileBreakBreak() {
			//    1
			//    |
			//    v
			// /->2->3--\
			// |  |     |
			// |  v     v
			// |  4->5--\
			// |  |     |
			// |  v     v
			// \--6     7
			//
			// 1: {1000000}
			// 2: {1100000}
			// 3: {1110000}
			// 4: {1101000}
			// 5: {1101100}
			// 6: {1101010}
			// 7: {1100001}
			var builder = new SimpleGraphBuilder(7);
			builder.Connect(1, 2);
			builder.Connect(2, 3);
			builder.Connect(2, 4);
			builder.Connect(3, 7);
			builder.Connect(4, 5);
			builder.Connect(4, 6);
			builder.Connect(5, 7);
			builder.Connect(6, 2);
			return builder.Graph;
		}

		public static ControlFlowGraph ComplexLoop() {
			//      1
			//      |
			//      v
			//   /->2<-------\
			//   |  |        |
			//   |  v        |
			//   7<-*->3->5->6
			//         |  |
			//         v  v
			//         4->8
			var builder = new SimpleGraphBuilder(8);
			builder.Connect(1, 2);
			builder.Connect(2, 3);
			builder.Connect(2, 7);
			builder.Connect(3, 4);
			builder.Connect(3, 5);
			builder.Connect(4, 8);
			builder.Connect(5, 6);
			builder.Connect(5, 8);
			builder.Connect(6, 2);
			builder.Connect(7, 2);
			return builder.Graph;
		}

		public static ControlFlowGraph ComplexNestedLoop() {
			//digraph G {
			//    graph [label="System.Void H8.Loops::ComplexNestedLoop()"];
			//    subgraph cluster_I1 {
			//        graph [label="I1"];
			//        B1 [label="B1 (#1) (^)\ncall"];
			//    }
			//    subgraph cluster_I2 {
			//        graph [label="I2"];
			//        B2 [label="B2 (#2) (^B1)\nbge.s"];
			//        B3 [label="B3 (#3) (^B2)\nbne.un.s"];
			//        B5 [label="B5 (#4) (^B3)\nbne.un.s"];
			//        B8 [label="B8 (#5) (^B2)\nbr.s"];
			//        B4 [label="B4 (#8) (^B3)\nbr.s"];
			//    }
			//    subgraph cluster_I3 {
			//        graph [label="I3"];
			//        B6 [label="B6 (#6) (^B5)\nblt.s"];
			//        B7 [label="B7 (#7) (^B6)\nbr.s"];
			//    }
			//    subgraph cluster_I4 {
			//        graph [label="I4"];
			//        B9 [label="B9 (#9) (^B3)\nret"];
			//    }
			//    B1 -> B2;
			//    B2 -> B3;
			//    B2 -> B8;
			//    B3 -> B4;
			//    B3 -> B5;
			//    B5 -> B6;
			//    B5 -> B8;
			//    B8 -> B2;
			//    B6 -> B7;
			//    B6 -> B6;
			//    B7 -> B9;
			//    B4 -> B9;
			//}
			var builder = new SimpleGraphBuilder(9);
			builder.Connect(1, 2);
			builder.Connect(2, 3);
			builder.Connect(2, 8);
			builder.Connect(3, 4);
			builder.Connect(3, 5);
			builder.Connect(5, 6);
			builder.Connect(5, 8);
			builder.Connect(8, 2);
			builder.Connect(6, 7);
			builder.Connect(6, 6);
			builder.Connect(7, 9);
			builder.Connect(4, 9);
			return builder.Graph;
		}

		public static ControlFlowGraph MultiReturns() {
			//digraph G {
			//    graph [label="System.Void H8.Loops::MultiReturns()"];
			//    subgraph cluster_I1 {
			//        graph [label="I1"];
			//        B1 [label="B1 (#1) (^)\nbr.s"];
			//    }
			//    subgraph cluster_I2 {
			//        graph [label="I2"];
			//        B7 [label="B7 (#2) (^B1)\nblt.s"];
			//        B2 [label="B2 (#3) (^B7)\nbne.un.s"];
			//        B4 [label="B4 (#4) (^B2)\nbne.un.s"];
			//        B6 [label="B6 (#5) (^B4)\ncall"];
			//        B5 [label="B5 (#6) (^B4)\nbr.s"];
			//        B3 [label="B3 (#7) (^B2)\nret"];
			//        B8 [label="B8 (#8) (^B7)\nret"];
			//    }
			//    B1 -> B7;
			//    B7 -> B8;
			//    B7 -> B2;
			//    B2 -> B3;
			//    B2 -> B4;
			//    B4 -> B5;
			//    B4 -> B6;
			//    B6 -> B7;
			//    B5 -> B8;
			//}
			var builder = new SimpleGraphBuilder(8);
			builder.Connect(1, 7);
			builder.Connect(7, 8);
			builder.Connect(7, 2);
			builder.Connect(2, 3);
			builder.Connect(2, 4);
			builder.Connect(4, 5);
			builder.Connect(4, 6);
			builder.Connect(6, 7);
			builder.Connect(5, 8);
			return builder.Graph;
		}

		public static ControlFlowGraph MultiReturns2() {
			//digraph G {
			//    graph [label="System.Void H8.Loops::MultiReturns2()"];
			//    subgraph cluster_I1 {
			//        graph [label="I1"];
			//        B1 [label="B1 (#1) (^)\nbr.s"];
			//    }
			//    subgraph cluster_I2 {
			//        graph [label="I2"];
			//        B7 [label="B7 (#2) (^B1)\nblt.s"];
			//        B2 [label="B2 (#3) (^B7)\nble.s"];
			//        B4 [label="B4 (#4) (^B2)\nbge.s"];
			//        B6 [label="B6 (#5) (^B4)\ncall"];
			//        B5 [label="B5 (#6) (^B4)\nret"];
			//        B3 [label="B3 (#7) (^B2)\nret"];
			//        B8 [label="B8 (#8) (^B7)\nret"];
			//    }
			//    B1 -> B7;
			//    B7 -> B8;
			//    B7 -> B2;
			//    B2 -> B3;
			//    B2 -> B4;
			//    B4 -> B5;
			//    B4 -> B6;
			//    B6 -> B7;
			//}
			var builder = new SimpleGraphBuilder(8);
			builder.Connect(1, 7);
			builder.Connect(7, 8);
			builder.Connect(7, 2);
			builder.Connect(2, 3);
			builder.Connect(2, 4);
			builder.Connect(4, 5);
			builder.Connect(4, 6);
			builder.Connect(6, 7);
			return builder.Graph;
		}

		public static ControlFlowGraph NestedDoWhile() {
			//    1
			//    |
			//    v
			// /->4->5
			// |  |
			// |  v
			// |  2-O
			// |  |
			// |  v
			// \--3
			var builder = new SimpleGraphBuilder(5);
			builder.Connect(1, 4);
			builder.Connect(4, 5);
			builder.Connect(4, 2);
			builder.Connect(2, 3);
			builder.Connect(2, 2);
			builder.Connect(3, 4);
			return builder.Graph;
		}

		public static ControlFlowGraph Switch() {
			//digraph G {
			//    graph [label="Switch"];
			//    B1 [label="B1 (#1) (^)\nswitch"];
			//    B4 [label="B4 (#2) (^B1)\nbr.s"];
			//    B3 [label="B3 (#3) (^B1)\nbr.s"];
			//    B2 [label="B2 (#4) (^B1)\nbr.s"];
			//    B5 [label="B5 (#5) (^B2)\ncall"];
			//    B6 [label="B6 (#6) (^B1)\nret"];
			//    B1 -> B2;
			//    B1 -> B3;
			//    B1 -> B4;
			//    B4 -> B6;
			//    B3 -> B6;
			//    B2 -> B5;
			//    B5 -> B6;
			//}
			var builder = new SimpleGraphBuilder(6);
			builder.Connect(1, 2);
			builder.Connect(1, 3);
			builder.Connect(1, 4);
			builder.Connect(4, 6);
			builder.Connect(3, 6);
			builder.Connect(2, 5);
			builder.Connect(5, 6);
			return builder.Graph;
		}

		public static ControlFlowGraph SwitchInsideWhile() {
			//digraph G {
			//    graph [label="SwitchInsideWhile"];
			//    B1 [label="B1 (#1) (^)\nbr.s"];
			//    B9 [label="B9 (#2) (^B1)\nbgt.s"];
			//    B2 [label="B2 (#3) (^B9)\nswitch"];
			//    B6 [label="B6 (#4) (^B2)\nbr.s"];
			//    B5 [label="B5 (#5) (^B2)\nbr.s"];
			//    B4 [label="B4 (#6) (^B2)\nret"];
			//    B3 [label="B3 (#7) (^B2)\nbr.s"];
			//    B7 [label="B7 (#8) (^B3)\ncall"];
			//    B8 [label="B8 (#9) (^B2)\ncall"];
			//    B10 [label="B10 (#10) (^B9)\nret"];
			//    B1 -> B9;
			//    B9 -> B10;
			//    B9 -> B2;
			//    B2 -> B3;
			//    B2 -> B4;
			//    B2 -> B5;
			//    B2 -> B6;
			//    B6 -> B9;
			//    B5 -> B8;
			//    B3 -> B7;
			//    B7 -> B8;
			//    B8 -> B9;
			//}
			var builder = new SimpleGraphBuilder(10);
			builder.Connect(1, 9);
			builder.Connect(9, 10);
			builder.Connect(9, 2);
			builder.Connect(2, 3);
			builder.Connect(2, 4);
			builder.Connect(2, 5);
			builder.Connect(2, 6);
			builder.Connect(6, 9);
			builder.Connect(5, 8);
			builder.Connect(3, 7);
			builder.Connect(7, 8);
			builder.Connect(8, 9);
			return builder.Graph;
		}

		public static ControlFlowGraph DragonBook() {
			//digraph G {
			//    graph [label="DragonBook"];
			//    B1 -> B3;
			//    B1 -> B2;
			//    B2 -> B3;
			//    B3 -> B4;
			//    B4 -> B6;
			//    B4 -> B5;
			//    B4 -> B3;
			//    B5 -> B7;
			//    B6 -> B7;
			//    B7 -> B4;
			//    B7 -> B8;
			//    B8 -> B10;
			//    B8 -> B9;
			//    B8 -> B3;
			//    B9 -> B1;
			//    B10 -> B7;
			//}
			// Taken from the Dragon book, Page 661, Example 10.30, Fig. 10.45
			var builder = new SimpleGraphBuilder(10);
			builder.Connect(1, 3);
			builder.Connect(1, 2);
			builder.Connect(2, 3);
			builder.Connect(3, 4);
			builder.Connect(4, 6);
			builder.Connect(4, 5);
			builder.Connect(4, 3);
			builder.Connect(5, 7);
			builder.Connect(6, 7);
			builder.Connect(7, 4);
			builder.Connect(7, 8);
			builder.Connect(8, 10);
			builder.Connect(8, 9);
			builder.Connect(8, 3);
			builder.Connect(9, 1);
			builder.Connect(10, 7);
			return builder.Graph;
		}

		public static ControlFlowGraph Cifuentes1() {
			// Taken from "Reverse Compilation Techniques", by C. Cifuentes, Section 6.3, Fig. 6-11
			// /---->1
			// |     |
			// |     v
			// |  /->2--\
			// |  |  |  |
			// |  |  v  |
			// |  |  3  |
			// |  |  |  |
			// |  |  v  |
			// |  \--4  |
			// |        |
			// |        |
			// \-----5<-/
			//       |
			//       v
			//       6
			var builder = new SimpleGraphBuilder(6);
			builder.Connect(1, 2);
			builder.Connect(2, 3);
			builder.Connect(3, 4);
			builder.Connect(4, 2);
			builder.Connect(2, 5);
			builder.Connect(5, 1);
			builder.Connect(5, 6);
			return builder.Graph;
		}

		public static ControlFlowGraph Cifuentes2() {
			//digraph G {
			//    graph [label="Cifuentes2"];
			//    B1 -> B2;
			//    B1 -> B5;
			//    B2 -> B3;
			//    B2 -> B4;
			//    B3 -> B5;
			//    B4 -> B5;
			//    B5 -> B6;
			//    B6 -> B7;
			//    B6 -> B11;
			//    B7 -> B8;
			//    B8 -> B9;
			//    B9 -> B8;
			//    B9 -> B10;
			//    B10 -> B6;
			//    B11 -> B12;
			//    B11 -> B13;
			//    B12 -> B13;
			//    B12 -> B14;
			//    B13 -> B14;
			//    B14 -> B15;
			//}
			// Taken from "Reverse Compilation Techniques", by C. Cifuentes, Section 6.3, Fig. 6-23
			var builder = new SimpleGraphBuilder(15);
			builder.Connect(1, 2);
			builder.Connect(1, 5);
			builder.Connect(2, 3);
			builder.Connect(2, 4);
			builder.Connect(3, 5);
			builder.Connect(4, 5);
			builder.Connect(5, 6);
			builder.Connect(6, 7);
			builder.Connect(6, 11);
			builder.Connect(7, 8);
			builder.Connect(8, 9);
			builder.Connect(9, 8);
			builder.Connect(9, 10);
			builder.Connect(10, 6);
			builder.Connect(11, 12);
			builder.Connect(11, 13);
			builder.Connect(12, 13);
			builder.Connect(12, 14);
			builder.Connect(13, 14);
			builder.Connect(14, 15);
			return builder.Graph;
		}
	}
}
