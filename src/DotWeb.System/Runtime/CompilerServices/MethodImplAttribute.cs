//using System;
//using System.Linq;
//using System.Text;

//namespace System.Runtime.CompilerServices
//{
//    // Summary:
//    //     Defines how a method is implemented.
//    //[Serializable]
//    //[ComVisible(true)]
//    public enum MethodCodeType
//    {
//        // Summary:
//        //     Specifies that the method implementation is in Microsoft intermediate language
//        //     (MSIL).
//        IL = 0,
//        //
//        // Summary:
//        //     Specifies that the method is implemented in native code.
//        Native = 1,
//        //
//        // Summary:
//        //     Specifies that the method implementation is in optimized intermediate language
//        //     (OPTIL).
//        OPTIL = 2,
//        //
//        // Summary:
//        //     Specifies that the method implementation is provided by the runtime.
//        Runtime = 3,
//    }

//    // Summary:
//    //     Defines the details of how a method is implemented.
//    //[Serializable]
//    //[ComVisible(true)]
//    [Flags]
//    public enum MethodImplOptions
//    {
//        // Summary:
//        //     Specifies that the method is implemented in unmanaged code.
//        Unmanaged = 4,
//        //
//        // Summary:
//        //     Specifies that the method cannot be inlined.
//        NoInlining = 8,
//        //
//        // Summary:
//        //     Specifies that the method is declared, but its implementation is provided
//        //     elsewhere.
//        ForwardRef = 16,
//        //
//        // Summary:
//        //     Specifies that the method can be executed by only one thread at a time. Static
//        //     methods lock on the type, whereas instance methods lock on the instance.
//        //     Only one thread can execute in any of the instance functions, and only one
//        //     thread can execute in any of a class's static functions.
//        Synchronized = 32,
//        //
//        // Summary:
//        //     Specifies that the method is not optimized by the just-in-time (JIT) compiler
//        //     or by native code generation (see Ngen.exe) when debugging possible code
//        //     generation problems.
//        NoOptimization = 64,
//        //
//        // Summary:
//        //     Specifies that the method signature is exported exactly as declared.
//        PreserveSig = 128,
//        //
//        // Summary:
//        //     Specifies an internal call. An internal call is a call to a method that is
//        //     implemented within the common language runtime itself.
//        InternalCall = 4096,
//    }

//    // Summary:
//    //     Specifies the details of how a method is implemented. This class cannot be
//    //     inherited.
////	[Serializable]
//    [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method, Inherited = false)]
////	[ComVisible(true)]
//    public sealed class MethodImplAttribute : Attribute
//    {
//        // Summary:
//        //     A System.Runtime.CompilerServices.MethodCodeType value indicating what kind
//        //     of implementation is provided for this method.
//        public MethodCodeType MethodCodeType;

//        // Summary:
//        //     Initializes a new instance of the MethodImplAttribute class.
//        public MethodImplAttribute() { }
//        //
//        // Summary:
//        //     Initializes a new instance of the MethodImplAttribute class with the specified
//        //     System.Runtime.CompilerServices.MethodImplOptions value.
//        //
//        // Parameters:
//        //   methodImplOptions:
//        //     A System.Runtime.CompilerServices.MethodImplOptions value specifying properties
//        //     of the attributed method.
//        public MethodImplAttribute(MethodImplOptions methodImplOptions) { }
//        //
//        // Summary:
//        //     Initializes a new instance of the MethodImplAttribute class with the specified
//        //     System.Runtime.CompilerServices.MethodImplOptions value.
//        //
//        // Parameters:
//        //   value:
//        //     A bitmask representing the desired System.Runtime.CompilerServices.MethodImplOptions
//        //     value which specifies properties of the attributed method.
//        public MethodImplAttribute(short value) { }

//        // Summary:
//        //     Gets the System.Runtime.CompilerServices.MethodImplOptions value describing
//        //     the attributed method.
//        //
//        // Returns:
//        //     The System.Runtime.CompilerServices.MethodImplOptions value describing the
//        //     attributed method.
//        public MethodImplOptions Value { get; private set; }
//    }
//}
