using System;
using DotWeb.Client;

namespace Ext.util {
	/// <summary>
	///     /**
	///     Provides a convenient method of performing setTimeout where a new
	///     timeout cancels the old timeout. An example would be performing validation on a keypress.
	///     You can use this class to buffer
	///     the keypress events for a certain number of milliseconds, and perform only if they stop
	///     for that amount of time.
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\util\DelayedTask.js</jssource>
	public class DelayedTask : DotWeb.Client.JsNativeBase {

		/// <summary></summary>
		/// <returns></returns>
		public DelayedTask() { C_(); }
		/// <summary></summary>
		/// <param name="fn">(optional) The default function to timeout</param>
		/// <returns></returns>
		public DelayedTask(Delegate fn) { C_(fn); }
		/// <summary></summary>
		/// <param name="fn">(optional) The default function to timeout</param>
		/// <param name="scope">(optional) The default scope of that timeout</param>
		/// <returns></returns>
		public DelayedTask(Delegate fn, object scope) { C_(fn, scope); }
		/// <summary></summary>
		/// <param name="fn">(optional) The default function to timeout</param>
		/// <param name="scope">(optional) The default scope of that timeout</param>
		/// <param name="args">(optional) The default Array of arguments</param>
		/// <returns></returns>
		public DelayedTask(Delegate fn, object scope, System.Array args) { C_(fn, scope, args); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static DelayedTask prototype { get { return S_<DelayedTask>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }


		/// <summary>Cancels any pending timeout and queues a new one</summary>
		/// <returns></returns>
		public virtual void delay() { _(); }

		/// <summary>Cancels any pending timeout and queues a new one</summary>
		/// <param name="delay">The milliseconds to delay</param>
		/// <returns></returns>
		public virtual void delay(double delay) { _(delay); }

		/// <summary>Cancels any pending timeout and queues a new one</summary>
		/// <param name="delay">The milliseconds to delay</param>
		/// <param name="newFn">(optional) Overrides function passed to constructor</param>
		/// <returns></returns>
		public virtual void delay(double delay, Delegate newFn) { _(delay, newFn); }

		/// <summary>Cancels any pending timeout and queues a new one</summary>
		/// <param name="delay">The milliseconds to delay</param>
		/// <param name="newFn">(optional) Overrides function passed to constructor</param>
		/// <param name="newScope">(optional) Overrides scope passed to constructor</param>
		/// <returns></returns>
		public virtual void delay(double delay, Delegate newFn, object newScope) { _(delay, newFn, newScope); }

		/// <summary>Cancels any pending timeout and queues a new one</summary>
		/// <param name="delay">The milliseconds to delay</param>
		/// <param name="newFn">(optional) Overrides function passed to constructor</param>
		/// <param name="newScope">(optional) Overrides scope passed to constructor</param>
		/// <param name="newArgs">(optional) Overrides args passed to constructor</param>
		/// <returns></returns>
		public virtual void delay(double delay, Delegate newFn, object newScope, System.Array newArgs) { _(delay, newFn, newScope, newArgs); }

		/// <summary>Cancel the last queued timeout</summary>
		/// <returns></returns>
		public virtual void cancel() { _(); }



	}
}
