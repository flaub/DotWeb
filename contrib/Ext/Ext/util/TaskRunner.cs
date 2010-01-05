using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext.util {
	/// <summary>
	///     /**
	///     Provides the ability to execute one or more arbitrary tasks in a multithreaded manner.  Generally, you can use
	///     the singleton {@link Ext.TaskMgr} instead, but if needed, you can create separate instances of TaskRunner.  Any
	///     number of separate tasks can be started at any time and will run independently of each other.  Example usage:
	///     <pre><code>
	///     // Start a simple clock task that updates a div once per second
	///     var task = {
	///     run: function(){
	///     Ext.fly('clock').update(new Date().format('g:i:s A'));
	///     },
	///     interval: 1000 //1 second
	///     }
	///     var runner = new Ext.util.TaskRunner();
	///     runner.start(task);
	///     </code></pre>
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\util\TaskMgr.js</jssource>
	public class TaskRunner : System.DotWeb.JsObject {

		/// <summary>(defaults to 10)</summary>
		/// <returns></returns>
		public extern TaskRunner();
		/// <summary>(defaults to 10)</summary>
		/// <param name="interval">(optional) The minimum precision in milliseconds supported by this TaskRunner instance</param>
		/// <returns></returns>
		public extern TaskRunner(double interval);

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static TaskRunner prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }


		/// <summary>
		///     Starts a new task.
		///     <li><code>run</code> : Function<div class="sub-desc">The function to execute each time the task is run. The
		///     function will be called at each interval and passed the <code>args</code> argument if specified.  If a
		///     particular scope is required, be sure to specify it using the <code>scope</scope> argument.</div></li>
		///     <li><code>interval</code> : Number<div class="sub-desc">The frequency in milliseconds with which the task
		///     should be executed.</div></li>
		///     <li><code>args</code> : Array<div class="sub-desc">(optional) An array of arguments to be passed to the function
		///     specified by <code>run</code>.</div></li>
		///     <li><code>scope</code> : Object<div class="sub-desc">(optional) The scope in which to execute the
		///     <code>run</code> function.</div></li>
		///     <li><code>duration</code> : Number<div class="sub-desc">(optional) The length of time in milliseconds to execute
		///     the task before stopping automatically (defaults to indefinite).</div></li>
		///     <li><code>repeat</code> : Number<div class="sub-desc">(optional) The number of times to execute the task before
		///     stopping automatically (defaults to indefinite).</div></li>
		///     </ul>
		/// </summary>
		/// <returns>Object</returns>
		public extern virtual void start();

		/// <summary>
		///     Starts a new task.
		///     <li><code>run</code> : Function<div class="sub-desc">The function to execute each time the task is run. The
		///     function will be called at each interval and passed the <code>args</code> argument if specified.  If a
		///     particular scope is required, be sure to specify it using the <code>scope</scope> argument.</div></li>
		///     <li><code>interval</code> : Number<div class="sub-desc">The frequency in milliseconds with which the task
		///     should be executed.</div></li>
		///     <li><code>args</code> : Array<div class="sub-desc">(optional) An array of arguments to be passed to the function
		///     specified by <code>run</code>.</div></li>
		///     <li><code>scope</code> : Object<div class="sub-desc">(optional) The scope in which to execute the
		///     <code>run</code> function.</div></li>
		///     <li><code>duration</code> : Number<div class="sub-desc">(optional) The length of time in milliseconds to execute
		///     the task before stopping automatically (defaults to indefinite).</div></li>
		///     <li><code>repeat</code> : Number<div class="sub-desc">(optional) The number of times to execute the task before
		///     stopping automatically (defaults to indefinite).</div></li>
		///     </ul>
		/// </summary>
		/// <param name="task">A config object that supports the following properties:<ul></param>
		/// <returns>Object</returns>
		public extern virtual void start(object task);

		/// <summary>Stops an existing running task.</summary>
		/// <returns>Object</returns>
		public extern virtual void stop();

		/// <summary>Stops an existing running task.</summary>
		/// <param name="task">The task to stop</param>
		/// <returns>Object</returns>
		public extern virtual void stop(object task);

		/// <summary>Stops all tasks that are currently running.</summary>
		/// <returns></returns>
		public extern virtual void stopAll();



	}
}
