using System;
using H8.Support;

namespace Ext.util {
    /// <summary>
    ///     /**
    ///     Provides a convenient method of performing setTimeout where a new
    ///     timeout cancels the old timeout. An example would be performing validation on a keypress.
    ///     You can use this class to buffer
    ///     the keypress events for a certain number of milliseconds, and perform only if they stop
    ///     for that amount of time.
    /// </summary>
    /// <jssource>C:\home\src\external\ext-2.2\source\util\DelayedTask.js</jssource>
    [Native]
    public class DelayedTask  {

        /// <summary></summary>
        /// <returns></returns>
        public DelayedTask() {}
        /// <summary></summary>
        /// <param name="fn">(optional) The default function to timeout</param>
        /// <returns></returns>
        public DelayedTask(Delegate fn) {}
        /// <summary></summary>
        /// <param name="fn">(optional) The default function to timeout</param>
        /// <param name="scope">(optional) The default scope of that timeout</param>
        /// <returns></returns>
        public DelayedTask(Delegate fn, object scope) {}
        /// <summary></summary>
        /// <param name="fn">(optional) The default function to timeout</param>
        /// <param name="scope">(optional) The default scope of that timeout</param>
        /// <param name="args">(optional) The default Array of arguments</param>
        /// <returns></returns>
        public DelayedTask(Delegate fn, object scope, System.Array args) {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static DelayedTask prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }


        /// <summary>Cancels any pending timeout and queues a new one</summary>
        /// <returns></returns>
        public virtual void delay() { return ; }

        /// <summary>Cancels any pending timeout and queues a new one</summary>
        /// <param name="delay">The milliseconds to delay</param>
        /// <returns></returns>
        public virtual void delay(double delay) { return ; }

        /// <summary>Cancels any pending timeout and queues a new one</summary>
        /// <param name="delay">The milliseconds to delay</param>
        /// <param name="newFn">(optional) Overrides function passed to constructor</param>
        /// <returns></returns>
        public virtual void delay(double delay, Delegate newFn) { return ; }

        /// <summary>Cancels any pending timeout and queues a new one</summary>
        /// <param name="delay">The milliseconds to delay</param>
        /// <param name="newFn">(optional) Overrides function passed to constructor</param>
        /// <param name="newScope">(optional) Overrides scope passed to constructor</param>
        /// <returns></returns>
        public virtual void delay(double delay, Delegate newFn, object newScope) { return ; }

        /// <summary>Cancels any pending timeout and queues a new one</summary>
        /// <param name="delay">The milliseconds to delay</param>
        /// <param name="newFn">(optional) Overrides function passed to constructor</param>
        /// <param name="newScope">(optional) Overrides scope passed to constructor</param>
        /// <param name="newArgs">(optional) Overrides args passed to constructor</param>
        /// <returns></returns>
        public virtual void delay(double delay, Delegate newFn, object newScope, System.Array newArgs) { return ; }

        /// <summary>Cancel the last queued timeout</summary>
        /// <returns></returns>
        public virtual void cancel() { return ; }



    }
    [Anonymous]
    public class DelayedTaskConfig {

    }


}
