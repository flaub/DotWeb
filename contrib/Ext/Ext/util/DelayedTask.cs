using System;
using System.DotWeb;
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
	public class DelayedTask : System.DotWeb.JsObject {

		/// <summary></summary>
		/// <returns></returns>
		public extern DelayedTask();
		/// <summary></summary>
		/// <param name="fn">(optional) The default function to timeout</param>
		/// <returns></returns>
		public extern DelayedTask(Delegate fn);
		/// <summary></summary>
		/// <param name="fn">(optional) The default function to timeout</param>
		/// <param name="scope">(optional) The default scope of that timeout</param>
		/// <returns></returns>
		public extern DelayedTask(Delegate fn, object scope);
		/// <summary></summary>
		/// <param name="fn">(optional) The default function to timeout</param>
		/// <param name="scope">(optional) The default scope of that timeout</param>
		/// <param name="args">(optional) The default Array of arguments</param>
		/// <returns></returns>
		public extern DelayedTask(Delegate fn, object scope, System.Array args);

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static DelayedTask prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }


		/// <summary>Cancels any pending timeout and queues a new one</summary>
		/// <returns></returns>
		public extern virtual void delay();

		/// <summary>Cancels any pending timeout and queues a new one</summary>
		/// <param name="delay">The milliseconds to delay</param>
		/// <returns></returns>
		public extern virtual void delay(double delay);

		/// <summary>Cancels any pending timeout and queues a new one</summary>
		/// <param name="delay">The milliseconds to delay</param>
		/// <param name="newFn">(optional) Overrides function passed to constructor</param>
		/// <returns></returns>
		public extern virtual void delay(double delay, Delegate newFn);

		/// <summary>Cancels any pending timeout and queues a new one</summary>
		/// <param name="delay">The milliseconds to delay</param>
		/// <param name="newFn">(optional) Overrides function passed to constructor</param>
		/// <param name="newScope">(optional) Overrides scope passed to constructor</param>
		/// <returns></returns>
		public extern virtual void delay(double delay, Delegate newFn, object newScope);

		/// <summary>Cancels any pending timeout and queues a new one</summary>
		/// <param name="delay">The milliseconds to delay</param>
		/// <param name="newFn">(optional) Overrides function passed to constructor</param>
		/// <param name="newScope">(optional) Overrides scope passed to constructor</param>
		/// <param name="newArgs">(optional) Overrides args passed to constructor</param>
		/// <returns></returns>
		public extern virtual void delay(double delay, Delegate newFn, object newScope, System.Array newArgs);

		/// <summary>Cancel the last queued timeout</summary>
		/// <returns></returns>
		public extern virtual void cancel();



	}
}
